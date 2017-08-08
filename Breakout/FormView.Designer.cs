namespace Breakout
{
    partial class FormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.Result = new System.Windows.Forms.Label();
            this.Pause = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.PlayArea = new System.Windows.Forms.PictureBox();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.Instructions = new System.Windows.Forms.Label();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayArea)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ControlPanel.Controls.Add(this.Instructions);
            this.ControlPanel.Controls.Add(this.Result);
            this.ControlPanel.Controls.Add(this.Pause);
            this.ControlPanel.Controls.Add(this.Start);
            this.ControlPanel.Location = new System.Drawing.Point(1, 3);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(1096, 63);
            this.ControlPanel.TabIndex = 0;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(211, 24);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(21, 20);
            this.Result.TabIndex = 2;
            this.Result.Text = "\"\"";
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(103, 9);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 38);
            this.Pause.TabIndex = 1;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(11, 9);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 38);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // PlayArea
            // 
            this.PlayArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PlayArea.Location = new System.Drawing.Point(1, 63);
            this.PlayArea.Name = "PlayArea";
            this.PlayArea.Size = new System.Drawing.Size(1094, 625);
            this.PlayArea.TabIndex = 1;
            this.PlayArea.TabStop = false;
            this.PlayArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayArea_Paint);
            // 
            // DrawTimer
            // 
            this.DrawTimer.Interval = 1;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // Instructions
            // 
            this.Instructions.AutoSize = true;
            this.Instructions.Location = new System.Drawing.Point(373, 24);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(21, 20);
            this.Instructions.TabIndex = 3;
            this.Instructions.Text = "\"\"";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 684);
            this.Controls.Add(this.PlayArea);
            this.Controls.Add(this.ControlPanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FormView";
            this.Text = "BreakOut";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormView_KeyUp);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.PictureBox PlayArea;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Instructions;
    }
}

