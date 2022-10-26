using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvermoonLogReader
{
    public partial class Form1 : Form
    {
        public int logIndex = 0;
        public string[] rawLog = new string[100];
        public string[][] framesLogs = new string[100][];
        Graphics gVisual;
        public Image movimg;
        public Image atkImg;
        public float[] x = new float[100];
        public float[] z = new float[100];
        public string[] logName = new string[100];
        public int maximumTick = 0;
        public bool isplaying = false;
        public int currentTick = 0;
        public Form1()
        {
            InitializeComponent();
            gVisual = mapvisualize.CreateGraphics();
            movimg = Image.FromFile("point.png");
            atkImg = Image.FromFile("attackPoint.png");

        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            if (openFileLog.ShowDialog() == DialogResult.OK)
            {
                var pathName = openFileLog.FileName;
                rawLog[logIndex] = File.ReadAllText(pathName);
                framesLogs[logIndex] = rawLog[logIndex].Split("====== ===== FRAME SUMMARY ==== ======");
                for (int i = 0; i < framesLogs[logIndex].Length; i++)
                {
                    framesLogs[logIndex][i] = framesLogs[logIndex][i].Replace("======= ==== END SUMMARY ==== =======", "");
                }
                if (maximumTick < framesLogs[logIndex].Length - 1)
                {
                    trackBar1.Maximum = framesLogs[logIndex].Length - 1;
                    maximumTick = framesLogs[logIndex].Length - 1;
                }
                logName[logIndex] = textlogName.Text;
                textlogName.Text = "";
                logIndex++;
                labelLogIndex.Text = logIndex.ToString();
            }

        }

        private void trackBar1_CursorChanged(object sender, EventArgs e)
        {
            ticklabel.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            currentTick = trackBar1.Value;
            ticklabel.Text = trackBar1.Value.ToString();
            gVisual.Clear(Color.White);
            for (int i = 0; i < 100; i++)
            {
                ExtractPosition(out x[i], out z[i], i);
                bool isAttacking = ExtractIsAttack(i);
                if (x[i] == 0 && z[i] == 0)
                    continue;
                Point p = new Point((int)MathF.Round(x[i]), (int)MathF.Round(z[i]));
                Point poffset = p;
                poffset.X += 10;
                poffset.Y += 15;
                if (!isAttacking)
                    gVisual.DrawImage(movimg, p);
                else
                    gVisual.DrawImage(atkImg, p);
                Font f = new Font("Arial", 8);
                Brush b = new SolidBrush(Color.Black);
                gVisual.DrawString(logName[i].ToString(), f, b, poffset);
            }
        }
        public void ExtractPosition(out float x, out float z, int index)
        {
            if (ExtractLatestFrameAtTick(index, currentTick) == null)
            {
                x = 0;
                z = 0;
                return;
            }
            string[] data = ExtractLatestFrameAtTick(index, trackBar1.Value).Split("|");
            int positionIndex = -1;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("POSITION"))
                {
                    positionIndex = ++i;
                    break;
                }
            }
            x = 0;
            z = 0;
            if (positionIndex == -1)
            {
                return;
            }
            string rawPositionData = data[positionIndex];
            rawPositionData = rawPositionData.Replace("(", "");
            rawPositionData = rawPositionData.Replace(")", "");
            rawPositionData = rawPositionData.Replace(" ", "");
            string[] positionData = rawPositionData.Split(",");
            x = float.Parse(positionData[0]) - 13.4f;
            z = (float.Parse(positionData[2]) * -1) + 170;
        }
        public bool ExtractIsAttack(int index)
        {
            if (framesLogs[index] == null)
            {
                return false;
            }
            if (framesLogs[index].Length <= trackBar1.Value)
            {
                return false;
            }
            if (ExtractLatestFrameAtTick(index, currentTick) == null)
            {
                return false;
            }
            string[] data = ExtractLatestFrameAtTick(index, currentTick).Split("|");
            int attackIndex = -1;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains(" WaitForRespond "))
                {
                    attackIndex = ++i;
                    break;
                }
            }
            if (attackIndex == -1) return false;
            if (data[attackIndex].ToLower().Contains("true"))
            {
                return true;
            }
            return false;
        }

        public string ExtractLatestFrameAtTick(int pages, int targetTick)
        {
            if (framesLogs[pages] == null)
            {
                return null;
            }
            if (framesLogs[pages].Length <= trackBar1.Value)
            {
                return null;
            }

            string targetData = "";
            bool isFound = false;
            for (int i = 0; i < framesLogs[pages].Length; i++)
            {
                if (isFound)
                {
                    break;
                }
                string[] data = framesLogs[pages][i].Split("|");
                foreach (var s in data)
                {
                    if (s.Contains("TICK:"))
                    {
                        string resultTick = s;
                        resultTick = resultTick.Replace(" ", "");
                        resultTick = resultTick.Replace("TICK:", "");
                        int parseResultTick = int.Parse(resultTick);
                        if(parseResultTick <= targetTick)
                        {
                            targetData = framesLogs[pages][i];
                            break;
                        }
                        else
                        {
                            isFound = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return targetData;
        }

        private void nextLog_Click(object sender, EventArgs e)
        {
            logIndex++;
            labelLogIndex.Text = logIndex.ToString();
            if (!string.IsNullOrEmpty(logName[logIndex]))
                labelLogIndex.Text = logName[logIndex];
        }

        private void previousLog_Click(object sender, EventArgs e)
        {
            logIndex--;
            if (logIndex <= 0)
            {
                logIndex = 0;
            }
            labelLogIndex.Text = logIndex.ToString();
            if (!string.IsNullOrEmpty(logName[logIndex]))
                labelLogIndex.Text = logName[logIndex];
        }

        private void playbutton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                isplaying = true;
            }
            else
            {
                backgroundWorker1.CancelAsync();
                isplaying = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (isplaying)
            {
                backgroundWorker1.ReportProgress(i++);
                Thread.Sleep(30);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (trackBar1.Value < trackBar1.Maximum - 1)
            {
                trackBar1.Value++;
                currentTick = trackBar1.Value;
            }
        }
    }
}
