namespace HW_T06_01_10_2026
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
            btnLogDebug = new Button();
            btnLogWarning = new Button();
            btnThreadLog = new Button();
            buttonPrint = new Button();
            textBoxInputData = new TextBox();
            SuspendLayout();
            // 
            // btnLogDebug
            // 
            btnLogDebug.Location = new Point(59, 67);
            btnLogDebug.Name = "btnLogDebug";
            btnLogDebug.Size = new Size(97, 23);
            btnLogDebug.TabIndex = 0;
            btnLogDebug.Text = "Log Debug";
            btnLogDebug.UseVisualStyleBackColor = true;
            btnLogDebug.Click += btnLogDebug_Click;
            // 
            // btnLogWarning
            // 
            btnLogWarning.Location = new Point(162, 68);
            btnLogWarning.Name = "btnLogWarning";
            btnLogWarning.Size = new Size(92, 23);
            btnLogWarning.TabIndex = 1;
            btnLogWarning.Text = "Log Warning";
            btnLogWarning.UseVisualStyleBackColor = true;
            btnLogWarning.Click += btnLogWarning_Click;
            // 
            // btnThreadLog
            // 
            btnThreadLog.Location = new Point(260, 68);
            btnThreadLog.Name = "btnThreadLog";
            btnThreadLog.Size = new Size(101, 23);
            btnThreadLog.TabIndex = 2;
            btnThreadLog.Text = "Multithread Log";
            btnThreadLog.UseVisualStyleBackColor = true;
            btnThreadLog.Click += btnThreadLog_Click;
            // 
            // buttonPrint
            // 
            buttonPrint.Location = new Point(386, 12);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(207, 23);
            buttonPrint.TabIndex = 3;
            buttonPrint.Text = "Print Document";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // textBoxInputData
            // 
            textBoxInputData.Location = new Point(386, 68);
            textBoxInputData.Name = "textBoxInputData";
            textBoxInputData.Size = new Size(207, 23);
            textBoxInputData.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 288);
            Controls.Add(textBoxInputData);
            Controls.Add(buttonPrint);
            Controls.Add(btnThreadLog);
            Controls.Add(btnLogWarning);
            Controls.Add(btnLogDebug);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogDebug;
        private Button btnLogWarning;
        private Button btnThreadLog;
        private Button buttonPrint;
        private TextBox textBoxInputData;
    }
}
