
namespace EvermoonLogReader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputButton = new System.Windows.Forms.Button();
            this.openFileLog = new System.Windows.Forms.OpenFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.ticklabel = new System.Windows.Forms.Label();
            this.richTextLog = new System.Windows.Forms.RichTextBox();
            this.variableBooleanLog = new System.Windows.Forms.CheckedListBox();
            this.mapvisualize = new System.Windows.Forms.Panel();
            this.nextLog = new System.Windows.Forms.Button();
            this.previousLog = new System.Windows.Forms.Button();
            this.labelLogIndex = new System.Windows.Forms.Label();
            this.textlogName = new System.Windows.Forms.TextBox();
            this.playbutton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputButton
            // 
            this.InputButton.Location = new System.Drawing.Point(600, 12);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(160, 40);
            this.InputButton.TabIndex = 0;
            this.InputButton.Text = "Load Log";
            this.InputButton.UseVisualStyleBackColor = true;
            this.InputButton.Click += new System.EventHandler(this.InputButton_Click);
            // 
            // openFileLog
            // 
            this.openFileLog.DefaultExt = "evmlog";
            this.openFileLog.FileName = "logEvermoon";
            this.openFileLog.Filter = "Evermoon files (*.evmlog)|*.evmlog|All files (*.*)|*.*";
            this.openFileLog.FilterIndex = 0;
            this.openFileLog.Title = "Browse Log File";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(38, 406);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(680, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.CursorChanged += new System.EventHandler(this.trackBar1_CursorChanged);
            // 
            // ticklabel
            // 
            this.ticklabel.AutoSize = true;
            this.ticklabel.Location = new System.Drawing.Point(38, 388);
            this.ticklabel.Name = "ticklabel";
            this.ticklabel.Size = new System.Drawing.Size(13, 15);
            this.ticklabel.TabIndex = 2;
            this.ticklabel.Text = "0";
            // 
            // richTextLog
            // 
            this.richTextLog.Location = new System.Drawing.Point(24, 22);
            this.richTextLog.Name = "richTextLog";
            this.richTextLog.Size = new System.Drawing.Size(544, 260);
            this.richTextLog.TabIndex = 3;
            this.richTextLog.Text = "";
            // 
            // variableBooleanLog
            // 
            this.variableBooleanLog.FormattingEnabled = true;
            this.variableBooleanLog.Location = new System.Drawing.Point(38, 291);
            this.variableBooleanLog.Name = "variableBooleanLog";
            this.variableBooleanLog.Size = new System.Drawing.Size(120, 94);
            this.variableBooleanLog.TabIndex = 4;
            // 
            // mapvisualize
            // 
            this.mapvisualize.Location = new System.Drawing.Point(590, 112);
            this.mapvisualize.Name = "mapvisualize";
            this.mapvisualize.Size = new System.Drawing.Size(170, 170);
            this.mapvisualize.TabIndex = 5;
            // 
            // nextLog
            // 
            this.nextLog.Location = new System.Drawing.Point(730, 74);
            this.nextLog.Name = "nextLog";
            this.nextLog.Size = new System.Drawing.Size(30, 23);
            this.nextLog.TabIndex = 6;
            this.nextLog.Text = ">";
            this.nextLog.UseVisualStyleBackColor = true;
            this.nextLog.Click += new System.EventHandler(this.nextLog_Click);
            // 
            // previousLog
            // 
            this.previousLog.Location = new System.Drawing.Point(600, 73);
            this.previousLog.Name = "previousLog";
            this.previousLog.Size = new System.Drawing.Size(30, 24);
            this.previousLog.TabIndex = 7;
            this.previousLog.Text = "<";
            this.previousLog.UseVisualStyleBackColor = true;
            this.previousLog.Click += new System.EventHandler(this.previousLog_Click);
            // 
            // labelLogIndex
            // 
            this.labelLogIndex.AutoSize = true;
            this.labelLogIndex.Location = new System.Drawing.Point(670, 78);
            this.labelLogIndex.Name = "labelLogIndex";
            this.labelLogIndex.Size = new System.Drawing.Size(13, 15);
            this.labelLogIndex.TabIndex = 8;
            this.labelLogIndex.Text = "0";
            // 
            // textlogName
            // 
            this.textlogName.Location = new System.Drawing.Point(624, 52);
            this.textlogName.Name = "textlogName";
            this.textlogName.Size = new System.Drawing.Size(100, 23);
            this.textlogName.TabIndex = 9;
            // 
            // playbutton
            // 
            this.playbutton.Location = new System.Drawing.Point(181, 362);
            this.playbutton.Name = "playbutton";
            this.playbutton.Size = new System.Drawing.Size(75, 23);
            this.playbutton.TabIndex = 10;
            this.playbutton.Text = "Play";
            this.playbutton.UseVisualStyleBackColor = true;
            this.playbutton.Click += new System.EventHandler(this.playbutton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 463);
            this.Controls.Add(this.playbutton);
            this.Controls.Add(this.textlogName);
            this.Controls.Add(this.labelLogIndex);
            this.Controls.Add(this.previousLog);
            this.Controls.Add(this.nextLog);
            this.Controls.Add(this.mapvisualize);
            this.Controls.Add(this.variableBooleanLog);
            this.Controls.Add(this.richTextLog);
            this.Controls.Add(this.ticklabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.InputButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.OpenFileDialog openFileLog;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label ticklabel;
        private System.Windows.Forms.RichTextBox richTextLog;
        private System.Windows.Forms.CheckedListBox variableBooleanLog;
        private System.Windows.Forms.Panel mapvisualize;
        private System.Windows.Forms.Button nextLog;
        private System.Windows.Forms.Button previousLog;
        private System.Windows.Forms.Label labelLogIndex;
        private System.Windows.Forms.TextBox textlogName;
        private System.Windows.Forms.Button playbutton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

