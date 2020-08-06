namespace APMCIngate
{
    partial class Form2
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
            this.txtPrint = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.txtAnotherTruck = new System.Windows.Forms.TextBox();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.txtTrNoOkay = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblAnotherTruck = new System.Windows.Forms.Label();
            this.lblPrint = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblPlaceMsg = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTrNoOkay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.txtPrint);
            this.panel1.Controls.Add(this.txtPlace);
            this.panel1.Controls.Add(this.txtAnotherTruck);
            this.panel1.Controls.Add(this.txtVehicleNo);
            this.panel1.Controls.Add(this.txtTrNoOkay);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.lblAnotherTruck);
            this.panel1.Controls.Add(this.lblPrint);
            this.panel1.Controls.Add(this.lblPlace);
            this.panel1.Controls.Add(this.lblPlaceMsg);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblTrNoOkay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(63, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 406);
            this.panel1.TabIndex = 0;
            // 
            // txtPrint
            // 
            this.txtPrint.Location = new System.Drawing.Point(227, 271);
            this.txtPrint.Name = "txtPrint";
            this.txtPrint.Size = new System.Drawing.Size(35, 20);
            this.txtPrint.TabIndex = 21;
            this.txtPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrint_KeyDown);
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(127, 241);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(106, 20);
            this.txtPlace.TabIndex = 20;
            this.txtPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlace_KeyDown);
            // 
            // txtAnotherTruck
            // 
            this.txtAnotherTruck.Location = new System.Drawing.Point(340, 315);
            this.txtAnotherTruck.Name = "txtAnotherTruck";
            this.txtAnotherTruck.Size = new System.Drawing.Size(35, 20);
            this.txtAnotherTruck.TabIndex = 19;
            this.txtAnotherTruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnotherTruck_KeyDown);
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Location = new System.Drawing.Point(184, 124);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(100, 20);
            this.txtVehicleNo.TabIndex = 18;
            this.txtVehicleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleNo_KeyDown);
            // 
            // txtTrNoOkay
            // 
            this.txtTrNoOkay.Location = new System.Drawing.Point(501, 126);
            this.txtTrNoOkay.Name = "txtTrNoOkay";
            this.txtTrNoOkay.Size = new System.Drawing.Size(41, 20);
            this.txtTrNoOkay.TabIndex = 17;
            this.txtTrNoOkay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrNoOkay_KeyDown);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(129, 162);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 16;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblAnotherTruck
            // 
            this.lblAnotherTruck.AutoSize = true;
            this.lblAnotherTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnotherTruck.Location = new System.Drawing.Point(179, 319);
            this.lblAnotherTruck.Name = "lblAnotherTruck";
            this.lblAnotherTruck.Size = new System.Drawing.Size(142, 13);
            this.lblAnotherTruck.TabIndex = 14;
            this.lblAnotherTruck.Text = "Another Truck (Y/N) ) ?";
            // 
            // lblPrint
            // 
            this.lblPrint.AutoSize = true;
            this.lblPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrint.Location = new System.Drawing.Point(78, 275);
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Size = new System.Drawing.Size(123, 13);
            this.lblPrint.TabIndex = 12;
            this.lblPrint.Text = "Print Receipt? (Y/N)";
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlace.Location = new System.Drawing.Point(69, 242);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(51, 15);
            this.lblPlace.TabIndex = 10;
            this.lblPlace.Text = "Place :";
            // 
            // lblPlaceMsg
            // 
            this.lblPlaceMsg.AutoSize = true;
            this.lblPlaceMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceMsg.Location = new System.Drawing.Point(98, 206);
            this.lblPlaceMsg.Name = "lblPlaceMsg";
            this.lblPlaceMsg.Size = new System.Drawing.Size(242, 15);
            this.lblPlaceMsg.TabIndex = 9;
            this.lblPlaceMsg.Text = " Not Local.. Please Enter Place to go";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(66, 166);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 13);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type :";
            // 
            // lblTrNoOkay
            // 
            this.lblTrNoOkay.AutoSize = true;
            this.lblTrNoOkay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrNoOkay.Location = new System.Drawing.Point(321, 126);
            this.lblTrNoOkay.Name = "lblTrNoOkay";
            this.lblTrNoOkay.Size = new System.Drawing.Size(162, 15);
            this.lblTrNoOkay.TabIndex = 5;
            this.lblTrNoOkay.Text = "Truck-No Okay ? (Y/N/Q)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vehicle Number :";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Coral;
            this.lblHeader.Location = new System.Drawing.Point(254, 79);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(52, 17);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "mr2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Market";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrNoOkay;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPlaceMsg;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblPrint;
        private System.Windows.Forms.Label lblAnotherTruck;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtTrNoOkay;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.TextBox txtAnotherTruck;
        private System.Windows.Forms.TextBox txtPrint;
        private System.Windows.Forms.TextBox txtPlace;
    }
}