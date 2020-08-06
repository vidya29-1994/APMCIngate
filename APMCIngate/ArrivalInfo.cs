using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMCIngate
{
    public partial class ArrivalInfo : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        DateTime RSTDate;
        string date;
        string time;
        DateTime RSTTime;
        int No;

        public ArrivalInfo()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblType.Visible = false;
            cmbVehicletype.Visible = false;
            lblVehicleType.Visible = false;
            txtVehicleNo.Visible = false;
            lblFromPlace.Visible = false;
            txtFromPlace.Visible = false;
            lblMandi.Visible = false;
            txtMandi.Visible = false;
            lblMemoNo.Visible = false;
            txtMemNo.Visible = false;
            lblMaldhani.Visible = false;
            txtMaldhani.Visible = false;
            lblSeries.Visible = false;
            txtSeries.Visible = false;
            lblShop.Visible = false;
            txtShop.Visible = false;
            cmbAgent.Visible = false;
            lblAgentNo.Visible = false;
            txtAgentNo.Visible = false;
            lblAc_Name.Visible = false;
            lblLicn_No.Visible = false;
            lblComodity.Visible = false;
            txtComodity.Visible = false;
            cmbComodity.Visible = false;
            lblUnit.Visible = false;
            cmbUnit.Visible = false;
            lblBag.Visible = false;
            txtBag.Visible = false;
            lblPerBagWeight.Visible = false;
            txtPerBagWeight.Visible = false;
            lblWeight.Visible = false;
            txtWeight.Visible = false;
            lblAmount.Visible = false;
            txtAmount.Visible = false;
            btnSave.Visible = false;
            lblPrint.Visible = false;
            txtPrint.Visible = false;

            txtEntryPassNo.Enabled = true;
            txtVehicleNo.Enabled = true;
            txtMemNo.Enabled = true;
            txtMandi.Enabled = true;
            txtFromPlace.Enabled = true;
            txtMaldhani.Enabled = true;
            cmbVehicletype.Enabled = true;
            txtSeries.Enabled = true;
            txtShop.Enabled = true;
            cmbAgent.Enabled = true;
            txtComodity.Enabled = true;
            cmbComodity.Enabled = true;
            cmbUnit.Enabled = true;
            cmbAgent.Enabled = true;
            cmbComodity.Enabled = true;
            txtBag.Enabled = true;
            txtWeight.Enabled = true;
            txtPerBagWeight.Enabled = true;
            txtAmount.Enabled = true;

        }

        public void LoadVehicleType()
        {
            DataRow dr;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from entry_rt", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { "--Select--", 0 };
            dt.Rows.InsertAt(dr, 0);

            cmbVehicletype.ValueMember = "ID";
            cmbVehicletype.DisplayMember = "DES";
            cmbVehicletype.DataSource = dt;
            con.Close();
        }

        public void LoadAgent(string series, string shop)
        {
            DataRow dr;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select concat(AC_NAME, LIC_NO) As DES ,LIC_NO As ID from Cagent05 where Trim(SERIES)='" + series + "' and Trim(SHOP)='" + shop + "' and LIC_NO not in (0,'')", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { "--Select--", 0 };
            dt.Rows.InsertAt(dr, 0);

            cmbAgent.ValueMember = "ID";
            cmbAgent.DisplayMember = "DES";
            cmbAgent.DataSource = dt;
            con.Close();
        }

        public void LoadComodity(string comd)
        {
            DataRow dr;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select VR As ID, * from comodity where COMD=" + comd + " ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "---select---" };
            dt.Rows.InsertAt(dr, 0);

            cmbComodity.ValueMember = "ID";
            cmbComodity.DisplayMember = "COM_NAME";
            cmbComodity.DataSource = dt;
            con.Close();
        }

        public void LoadUnit(string comd)
        {
            string[] numb;
            numb = new string[4];
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  * from comodity where COMD=" + comd + " ", con);
            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {


                    for (int i = 1; i < 3; i++)
                    {
                        numb[i] = dr1["um_" + i].ToString();

                    }
                }

            }
            var distinctArray = numb.Distinct().ToArray();
            List<string> list = new List<string>(distinctArray);
            list.RemoveAt(0);
            distinctArray = list.ToArray();

            string[] Unit = new string[] { "", "1..Quintal ", "2..Judi 100", "3..LSE Truck", "4..Nag,Pati,Box", "5..   " };
            string[] FUnit;
            FUnit = new string[distinctArray.Length];
            List<KeyValuePair<int, string>> unit = new List<KeyValuePair<int, string>>();


            for (int i = 0; i < distinctArray.Length; i++)
            {
                if (distinctArray[i] != null && distinctArray[i].Trim() != "")
                {
                    int j = Convert.ToInt32(distinctArray[i]);
                    FUnit[i] = Unit[j];
                    unit.Add(new KeyValuePair<int, string>(j, Unit[j]));
                }

            }

            con.Close();
            dr1.Close();
            cmbUnit.DisplayMember = "Value";
            cmbUnit.ValueMember = "Key";
            cmbUnit.DataSource = unit;
        }

        private void ArrivalInfo_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtEntryPassNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEntryPassNo.Text != null || txtEntryPassNo.Text != "")
                {

                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from [dbo].[AR_EM] where trim(RST_NO)='" + txtEntryPassNo.Text + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //string Truck = dr["TRUCK"].ToString();
                            date = dr["DATE"].ToString();
                            time = dr["TIME"].ToString();
                        }

                        Reset();
                        lblVehicleType.Visible = true;
                        cmbVehicletype.Visible = true;
                        LoadVehicleType();
                        cmbVehicletype.Focus();
                        cmbVehicletype.DroppedDown = true;
                    }
                    else
                    {
                        MessageBox.Show("RST No Does Not Exists");
                    }

                    // txtEntryPassNo.Enabled = false;
                }
                e.Handled = true;
            }
        }


        private void cmbVehicletype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbVehicletype.SelectedIndex > 0)
                {
                    lblType.Visible = true;
                    lblType.Text = cmbVehicletype.SelectedText.ToString();
                    txtVehicleNo.Visible = true;
                    cmbVehicletype.Visible = false;
                    lblVehicleType.Visible = false;
                    lblFromPlace.Visible = true;
                    txtFromPlace.Visible = true;
                    lblMandi.Visible = true;
                    txtMandi.Visible = true;
                    lblMemoNo.Visible = true;
                    txtMemNo.Visible = true;
                    lblMaldhani.Visible = true;
                    txtMaldhani.Visible = true;
                    lblSeries.Visible = true;
                    lblShop.Visible = true;
                    txtShop.Visible = true;
                    txtSeries.Visible = true;
                    txtVehicleNo.Focus();
                }
                else
                {
                    MessageBox.Show("Please select vehicle type");
                }

                e.Handled = true;

            }
        }

        public void getLFByShop(string series, string shop)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Cagent05 where Trim(SERIES)='" + series + "' and Trim(SHOP)='" + shop + "' and LIC_NO not in (0,'')", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtAgentNo.Text = dr["LF"].ToString();
                    No = Convert.ToInt32(dr["NO"]);
                }
            }
            dr.Close();
            con.Close();

        }

        private void txtShop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtSeries.Text != null || txtSeries.Text != "")
                {

                    if (txtShop.Text != null && txtShop.Text != "" && txtShop.Text != "0")
                    {

                        LoadAgent(txtSeries.Text, txtShop.Text);
                        getLFByShop(txtSeries.Text, txtShop.Text);
                        if (cmbAgent.Items.Count > 1)
                        {
                            cmbAgent.Visible = true;
                            cmbAgent.Focus();
                            //  txtShop.Enabled = false;
                            cmbAgent.DroppedDown = true;
                        }
                        else
                        {
                            MessageBox.Show("Agent Does Not Exists...");
                        }

                    }
                    else
                    {
                        lblSeries.Visible = false;
                        lblShop.Visible = false;
                        txtSeries.Visible = false;
                        txtShop.Visible = false;
                        cmbAgent.Visible = false;
                        lblAgentNo.Visible = true;
                        txtAgentNo.Visible = true;
                        txtAgentNo.Focus();

                        SqlConnection con = new SqlConnection(conString);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select concat(AC_NAME, LIC_NO) As DES ,* from Cagent05 where trim(LF)='" + txtAgentNo.Text + "' and LIC_NO not in (0,'')", con);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lblAc_Name.Text = dr["DES"].ToString();
                                lblLicn_No.Text = "LICN_No : " + dr["LIC_NO"].ToString();
                            }

                        }
                        con.Close();
                        dr.Close();

                    }
                }
                e.Handled = true;
            }
        }

        public void LoadAgentByLf(int lfno)
        {
            DataRow dr;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select concat(AC_NAME, LIC_NO) As DES ,LIC_NO As ID from Cagent05 Where LF=" + lfno + " and LIC_NO not in (0,'')", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //dr = dt.NewRow();
            //dr.ItemArray = new object[] { "--Select--", 0 };
            //dt.Rows.InsertAt(dr, 0);
            cmbAgent.ValueMember = "ID";
            cmbAgent.DisplayMember = "DES";
            cmbAgent.DataSource = dt;
            con.Close();

        }

        public void getAgentByLF(int lfno)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Cagent05 Where LF=" + lfno + " and LIC_NO not in (0,'')", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtSeries.Text = dr["SERIES"].ToString();
                    txtShop.Text = dr["SHOP"].ToString();
                    No = Convert.ToInt32(dr["NO"]);
                }
            }
            dr.Close();
            con.Close();

        }

        private void txtAgentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAgentNo.Text != "" && txtAgentNo.Text != null)
                {
                    lblAc_Name.Visible = true;
                    lblLicn_No.Visible = true;
                    lblComodity.Visible = true;
                    LoadAgentByLf(Convert.ToInt32(txtAgentNo.Text));
                    getAgentByLF(Convert.ToInt32(txtAgentNo.Text));
                    if (cmbAgent.Items.Count > 0)
                    {
                        string selected = this.cmbAgent.GetItemText(this.cmbAgent.SelectedItem);
                        lblAc_Name.Text = selected.ToString();
                        lblLicn_No.Text = "LICN_No : " + cmbAgent.SelectedValue.ToString();

                        txtEntryPassNo.Enabled = false;
                        txtFromPlace.Enabled = false;
                        txtMandi.Enabled = false;
                        txtMaldhani.Enabled = false;
                        txtMemNo.Enabled = false;
                        txtSeries.Enabled = false;
                        txtShop.Enabled = false;
                        txtVehicleNo.Enabled = false;
                        cmbAgent.Visible = false;
                        lblComodity.Visible = true;
                        txtComodity.Visible = true;
                        txtComodity.Focus();
                        txtAgentNo.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Agent Does Not Exists...");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter agent no");
                    txtSeries.Visible = true;
                    txtShop.Visible = true;
                    lblSeries.Visible = true;
                    lblShop.Visible = true;
                    cmbAgent.Visible = false;
                    lblAgentNo.Visible = false;
                    txtAgentNo.Visible = false;
                }
                e.Handled = true;
            }
        }


        private void cmbAgent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbAgent.SelectedIndex > 0)
                {
                    lblAc_Name.Visible = true;
                    lblLicn_No.Visible = true;
                    lblAc_Name.Text = cmbAgent.SelectedText;
                    lblLicn_No.Text = "LICN_No : " + cmbAgent.SelectedValue.ToString();
                    txtEntryPassNo.Enabled = false;
                    txtFromPlace.Enabled = false;
                    txtMandi.Enabled = false;
                    txtMaldhani.Enabled = false;
                    txtMemNo.Enabled = false;
                    txtSeries.Enabled = false;
                    txtShop.Enabled = false;
                    txtVehicleNo.Enabled = false;
                    cmbAgent.Visible = false;
                    lblComodity.Visible = true;
                    txtComodity.Visible = true;
                    txtComodity.Focus();
                }
                else
                {
                    MessageBox.Show("Please select agent");
                }
            }

        }

        private void txtComodity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtComodity.Text != null && txtComodity.Text != "" && txtComodity.Text != "0")
                {
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand("Select Count(*) from comodity Where COMD=" + txtComodity.Text + "", con);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (count > 0)
                    {
                        LoadComodity(txtComodity.Text);
                        //txtComodity.Enabled = false;
                        cmbComodity.Visible = true;
                        // txtComodity.Visible = false;
                        cmbComodity.Focus();
                        cmbComodity.DroppedDown = true;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Comodity..Reenter");
                        txtComodity.Focus();
                    }



                }
                else if (txtComodity.Text == "0")
                {
                    Reset();
                    txtEntryPassNo.Text = "";
                    txtVehicleNo.Text = "";
                    txtMaldhani.Text = "";
                    txtMandi.Text = "";
                    txtFromPlace.Text = "";
                    txtMemNo.Text = "";
                    txtSeries.Text = "";
                    txtShop.Text = "";
                    txtAgentNo.Text = "";
                    txtEntryPassNo.Focus();

                }
                e.Handled = true;
            }


        }

        private void cmbComodity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbComodity.SelectedIndex > 0)
                {
                    txtComodity.Enabled = false;
                    cmbComodity.Enabled = false;
                    cmbUnit.Visible = true;
                    lblUnit.Visible = true;
                    //txtComodity.Visible = false;
                    cmbUnit.Focus();
                    LoadUnit(txtComodity.Text);
                    cmbUnit.DroppedDown = true;
                }
                else
                {
                    MessageBox.Show("Please select comodity");
                }
                e.Handled = true;
            }

        }

        private void txtPerBagWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblWeight.Visible = true;
                txtWeight.Visible = true;
                lblAmount.Visible = true;
                txtAmount.Visible = true;

                txtBag.Enabled = false;
                txtPerBagWeight.Enabled = false;
                if (txtBag.Text != null && txtPerBagWeight.Text != null && txtBag.Text != "" && txtPerBagWeight.Text != "")
                {
                    decimal weight = (Convert.ToDecimal(txtBag.Text) * Convert.ToDecimal(txtPerBagWeight.Text)) / 100;
                    txtWeight.Text = weight.ToString();
                }


                txtWeight.Enabled = true;
                txtAmount.Enabled = true;
                txtWeight.Focus();
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Clicked");
            try
            {
                string year = date.Substring(0, 4);
                string Month = date.Substring(4, 2);
                string dd = date.Substring(6, 2);
                decimal umconv = 0;

                if (Convert.ToDecimal(txtWeight.Text) > 0)
                {
                    umconv = Convert.ToDecimal(txtWeight.Text) / Convert.ToDecimal(txtBag.Text);

                }
                // double umconv=(Convert.ToDouble(txtBag.Text)*Convert.ToDouble(txtPerBagWeight.Text)/100);
                RSTDate = Convert.ToDateTime(year + "-" + Month + "-" + dd);

                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SaveArrival", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(RSTDate));
                cmd.Parameters.AddWithValue("@Truck_No", txtVehicleNo.Text);
                cmd.Parameters.AddWithValue("@RSTNo", txtEntryPassNo.Text);
                cmd.Parameters.AddWithValue("@Memo_No", txtMemNo.Text);
                cmd.Parameters.AddWithValue("@Mandi", txtMandi.Text);
                cmd.Parameters.AddWithValue("@Dest", txtFromPlace.Text);
                cmd.Parameters.AddWithValue("@Maldhani", txtMaldhani.Text);
                cmd.Parameters.AddWithValue("@LF", txtAgentNo.Text);
                cmd.Parameters.AddWithValue("@Series", txtSeries.Text);
                cmd.Parameters.AddWithValue("@Shop", txtShop.Text);
                cmd.Parameters.AddWithValue("@NO", No.ToString());
                cmd.Parameters.AddWithValue("@ID", cmbVehicletype.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@COMD", txtComodity.Text);
                cmd.Parameters.AddWithValue("@VR", cmbComodity.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@UM", cmbUnit.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@UMCONV", umconv.ToString());
                cmd.Parameters.AddWithValue("@NAG", txtBag.Text);
                cmd.Parameters.AddWithValue("@QTY", txtWeight.Text);
                cmd.Parameters.AddWithValue("@AMT", txtAmount.Text);
                cmd.Parameters.AddWithValue("@RSTDATE", date);
                cmd.Parameters.AddWithValue("@RSTTIME", time);

                int status = cmd.ExecuteNonQuery();
                if (status == 1)
                {
                    MessageBox.Show("Data inserted successfully");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void txtSeries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //    txtSeries.Enabled = false;
                txtShop.Focus();
                e.Handled = true;
            }
        }

        private void txtVehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  txtVehicleNo.Enabled = false;
                txtFromPlace.Focus();
                e.Handled = true;
            }
        }

        private void txtFromPlace_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //   txtFromPlace.Enabled = true;
                txtMandi.Focus();
                //  txtFromPlace.Enabled = false;
                e.Handled = true;
            }
        }

        private void txtMandi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // txtMandi.Enabled = false;
                txtMemNo.Focus();
                e.Handled = true;
            }
        }

        private void txtMemNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // txtMemNo.Enabled = false;
                txtMaldhani.Focus();
                e.Handled = true;
            }

        }

        private void txtMaldhani_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // txtMaldhani.Enabled = false;
                txtSeries.Focus();
                e.Handled = true;
            }
        }

        private void txtComodity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtMemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblPerBagWeight.Visible = true;
                txtPerBagWeight.Visible = true;
                cmbUnit.Enabled = false;
                txtBag.Enabled = true;
                txtPerBagWeight.Enabled = true;
                lblBag.Visible = true;
                txtBag.Visible = true;
                txtBag.Focus();
            }
        }

        private void txtBag_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtPerBagWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumeric(sender, e);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar)
            //        && Regex.IsMatch(txtWeight.Text, @"\.\d\d")
            //        && String.IsNullOrWhiteSpace(txtWeight.SelectedText))
            //{
            //    e.Handled = true;
            //}

            e.Handled = IsNumeric(sender, e);


        }

        private void txtEntryPassNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtBag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPerBagWeight.Focus();
                e.Handled = true;
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
                e.Handled = true;
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Enabled = false;
                txtWeight.Enabled = false;
                lblPrint.Visible = true;
                txtPrint.Visible = true;
                txtPrint.Enabled = true;
                txtPrint.Text = "N";
                txtPrint.Focus();
                e.Handled = true;
            }
        }

        private void btnTrcukChange_Click(object sender, EventArgs e)
        {
            Reset();
            txtEntryPassNo.Focus();
        }

        public void ResetComd()
        {
            lblComodity.Visible = true;
            txtComodity.Visible = true;
            txtComodity.Enabled = true;
            cmbComodity.Visible = false;
            lblUnit.Visible = false;
            cmbUnit.Visible = false;
            lblBag.Visible = false;
            txtBag.Visible = false;
            lblPerBagWeight.Visible = false;
            txtPerBagWeight.Visible = false;
            lblWeight.Visible = false;
            txtWeight.Visible = false;
            lblAmount.Visible = false;
            txtAmount.Visible = false;
            txtComodity.Focus();
            lblPrint.Visible = false;
            txtPrint.Visible = false;
            lblPrint.Visible = false;
            cmbUnit.Enabled = true;
            cmbComodity.Enabled = true;
        }

        private void txtPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPrint.Text != null && txtPrint.Text != "" && (txtPrint.Text == "Y" || txtPrint.Text == "y"))
                {
                    btnSave_Click(sender, e);
                    ResetComd();

                    txtComodity.Text = "";
                    txtBag.Text = "0";
                    txtPerBagWeight.Text = "0.00";
                    txtAmount.Text = "";
                    txtWeight.Text = "";
                    cmbUnit.Enabled = true;
                    cmbAgent.Enabled = true;
                    e.Handled = true;
                }
                else if (txtPrint.Text != null && txtPrint.Text != "" && (txtPrint.Text == "N" || txtPrint.Text == "n"))
                {
                    ResetComd();
                    e.Handled = true;
                }
            }
        }

        private void txtAgentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumeric(sender, e);
        }

        public bool IsNumeric(object sender, KeyPressEventArgs e)
        {

            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
              //  e.Handled = true;
                return true;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    //e.Handled = true;
                    return true;
            }

            return false;
        }
    }
}
