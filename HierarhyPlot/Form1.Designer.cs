namespace HierarhyPlot
{
    partial class Form1
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
            this.btnFilePicker = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tvVrski = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFilePicker
            // 
            this.btnFilePicker.Location = new System.Drawing.Point(460, 17);
            this.btnFilePicker.Name = "btnFilePicker";
            this.btnFilePicker.Size = new System.Drawing.Size(41, 23);
            this.btnFilePicker.TabIndex = 0;
            this.btnFilePicker.Text = "...";
            this.btnFilePicker.UseVisualStyleBackColor = true;
            this.btnFilePicker.Click += new System.EventHandler(this.btnFilePicker_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.btnFilePicker);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(8, 46);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(493, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Start ploting";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(7, 19);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(447, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // tvVrski
            // 
            this.tvVrski.Location = new System.Drawing.Point(12, 100);
            this.tvVrski.Name = "tvVrski";
            this.tvVrski.Size = new System.Drawing.Size(507, 632);
            this.tvVrski.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 744);
            this.Controls.Add(this.tvVrski);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFilePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TreeView tvVrski;
    }
}

