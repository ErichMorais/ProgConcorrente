namespace Concorrentes
{
    partial class Ambience
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
            this.timerAmbience = new System.Windows.Forms.Timer(this.components);
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelFrog = new System.Windows.Forms.Label();
            this.labelFly = new System.Windows.Forms.Label();
            this.labelSugar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerAmbience
            // 
            this.timerAmbience.Enabled = true;
            this.timerAmbience.Interval = 1000;
            this.timerAmbience.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(12, 9);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(35, 26);
            this.labelTimer.TabIndex = 0;
            this.labelTimer.Text = "\r\nlabel1";
            // 
            // labelFrog
            // 
            this.labelFrog.AutoSize = true;
            this.labelFrog.Location = new System.Drawing.Point(12, 35);
            this.labelFrog.Name = "labelFrog";
            this.labelFrog.Size = new System.Drawing.Size(35, 13);
            this.labelFrog.TabIndex = 1;
            this.labelFrog.Text = "label1";
            // 
            // labelFly
            // 
            this.labelFly.AutoSize = true;
            this.labelFly.Location = new System.Drawing.Point(12, 48);
            this.labelFly.Name = "labelFly";
            this.labelFly.Size = new System.Drawing.Size(35, 13);
            this.labelFly.TabIndex = 2;
            this.labelFly.Text = "label2";
            // 
            // labelSugar
            // 
            this.labelSugar.AutoSize = true;
            this.labelSugar.Location = new System.Drawing.Point(12, 61);
            this.labelSugar.Name = "labelSugar";
            this.labelSugar.Size = new System.Drawing.Size(35, 13);
            this.labelSugar.TabIndex = 3;
            this.labelSugar.Text = "label3";
            // 
            // Ambience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.labelSugar);
            this.Controls.Add(this.labelFly);
            this.Controls.Add(this.labelFrog);
            this.Controls.Add(this.labelTimer);
            this.Name = "Ambience";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambience";
            this.Load += new System.EventHandler(this.Ambience_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerAmbience;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelFrog;
        private System.Windows.Forms.Label labelFly;
        private System.Windows.Forms.Label labelSugar;
    }
}