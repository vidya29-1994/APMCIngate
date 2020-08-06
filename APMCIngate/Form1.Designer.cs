namespace APMCIngate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnArrInfo = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btnLoaded = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.btnArrInfo);
            this.panel1.Controls.Add(this.btnEmpty);
            this.panel1.Controls.Add(this.btnLoaded);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.panel1.Location = new System.Drawing.Point(123, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 296);
            this.panel1.TabIndex = 0;
            // 
            // btnArrInfo
            // 
            this.btnArrInfo.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnArrInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrInfo.ForeColor = System.Drawing.Color.White;
            this.btnArrInfo.Location = new System.Drawing.Point(190, 181);
            this.btnArrInfo.Name = "btnArrInfo";
            this.btnArrInfo.Size = new System.Drawing.Size(142, 38);
            this.btnArrInfo.TabIndex = 4;
            this.btnArrInfo.Text = "Arrival Info Feeding";
            this.btnArrInfo.UseVisualStyleBackColor = false;
            this.btnArrInfo.Click += new System.EventHandler(this.btnArrInfo_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.BackColor = System.Drawing.Color.Crimson;
            this.btnEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpty.ForeColor = System.Drawing.Color.White;
            this.btnEmpty.Location = new System.Drawing.Point(86, 109);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(142, 38);
            this.btnEmpty.TabIndex = 3;
            this.btnEmpty.Text = "Entry -Pass Empty";
            this.btnEmpty.UseVisualStyleBackColor = false;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnLoaded
            // 
            this.btnLoaded.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnLoaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaded.ForeColor = System.Drawing.Color.White;
            this.btnLoaded.Location = new System.Drawing.Point(263, 109);
            this.btnLoaded.Name = "btnLoaded";
            this.btnLoaded.Size = new System.Drawing.Size(152, 38);
            this.btnLoaded.TabIndex = 2;
            this.btnLoaded.Text = "Entry - Pass Loaded";
            this.btnLoaded.UseVisualStyleBackColor = false;
            this.btnLoaded.Click += new System.EventHandler(this.btnLoaded_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingate System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.Button btnLoaded;
        private System.Windows.Forms.Button btnArrInfo;
    }
}

