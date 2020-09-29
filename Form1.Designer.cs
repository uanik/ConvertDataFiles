namespace ConvertDataFiles
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLData = new System.Windows.Forms.TextBox();
            this.btnLdata = new System.Windows.Forms.Button();
            this.buttonfilePath = new System.Windows.Forms.Button();
            this.textBoxfilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // textBoxLData
            // 
            this.textBoxLData.Location = new System.Drawing.Point(126, 33);
            this.textBoxLData.Name = "textBoxLData";
            this.textBoxLData.Size = new System.Drawing.Size(100, 20);
            this.textBoxLData.TabIndex = 0;
            // 
            // btnLdata
            // 
            this.btnLdata.Location = new System.Drawing.Point(25, 30);
            this.btnLdata.Name = "btnLdata";
            this.btnLdata.Size = new System.Drawing.Size(75, 23);
            this.btnLdata.TabIndex = 1;
            this.btnLdata.Text = "L Data";
            this.btnLdata.UseVisualStyleBackColor = true;
            // 
            // buttonfilePath
            // 
            this.buttonfilePath.Location = new System.Drawing.Point(25, 60);
            this.buttonfilePath.Name = "buttonfilePath";
            this.buttonfilePath.Size = new System.Drawing.Size(75, 23);
            this.buttonfilePath.TabIndex = 2;
            this.buttonfilePath.Text = "Папка Data";
            this.buttonfilePath.UseVisualStyleBackColor = true;
            this.buttonfilePath.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxfilePath
            // 
            this.textBoxfilePath.Location = new System.Drawing.Point(126, 62);
            this.textBoxfilePath.Name = "textBoxfilePath";
            this.textBoxfilePath.Size = new System.Drawing.Size(480, 20);
            this.textBoxfilePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\test";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(304, 262);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(327, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxfilePath);
            this.Controls.Add(this.buttonfilePath);
            this.Controls.Add(this.btnLdata);
            this.Controls.Add(this.textBoxLData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLData;
        private System.Windows.Forms.Button btnLdata;
        private System.Windows.Forms.Button buttonfilePath;
        private System.Windows.Forms.TextBox textBoxfilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

