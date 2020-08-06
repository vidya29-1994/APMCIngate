using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMCIngate
{
    public partial class Form2 : Form
    {
        public int GateId;
        int type;
        string conString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            GateId = Form1.GateId;
            if (GateId == 1)
            {
                lblHeader.Text = "Entry Pass Empty Vehicle";
            }
            else if (GateId == 2)
            {
                lblHeader.Text = "Entry Pass Loaded Vehicle";
            }
            refreshdata();
            hide();
        }

        public void Clear()
        {
            txtVehicleNo.Text = "";
            txtPlace.Text = "";
            refreshdata();
        }

        public void hide()
        {
            lblTrNoOkay.Visible = false;
            txtTrNoOkay.Visible = false;
            lblType.Visible = false;
            cmbType.Visible = false;
            lblPlaceMsg.Visible = false;
            lblPlace.Visible = false;
            txtPlace.Visible = false;
            lblPrint.Visible = false;
            txtPrint.Visible = false;
            lblAnotherTruck.Visible = false;
            txtAnotherTruck.Visible = false;
        }

        public void refreshdata()
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

            cmbType.ValueMember = "ID";
            cmbType.DisplayMember = "DES";
            cmbType.DataSource = dt;
            con.Close();
        }

        //private void txtVehicleNo_TextChanged(object sender, EventArgs e)
        //{
        //    lblTrNoOkay.Visible = true;
        //    txtTrNoOkay.Visible = true;
        //}


        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Exist = IsTruckNoExist();
            if (Exist == true)
            {
                lblType.Visible = true;
                cmbType.Visible = true;
                cmbType.SelectedIndex = type;
                cmbType.Enabled = false;
                lblPlace.Visible = false;
                lblPlaceMsg.Visible = false;
                txtPlace.Visible = false;
                lblPrint.Visible = true;
                txtPrint.Visible = true;
                txtPrint.Focus();

            }
            else
            {
                lblType.Visible = true;
                cmbType.Visible = true;
                txtPlace.Visible = true;
                txtPlace.Focus();
                lblPlace.Visible = true;
                lblPlaceMsg.Visible = true;
                txtPlace.Visible = true;
                lblPlaceMsg.Visible = true;
                lblPrint.Visible = false;
                txtPrint.Visible = false;
            }
            //lblPlaceMsg.Visible = true;
            //lblPlace.Visible = true;
            //txtPrint.Visible = true;
            //lblPrint.Visible = true;
        }


        private void txtVehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblTrNoOkay.Visible = true;
                txtTrNoOkay.Visible = true;
                txtTrNoOkay.Text = "N";
                txtTrNoOkay.Focus();
                e.Handled = true;
            }


        }

        private void txtTrNoOkay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if ((txtTrNoOkay.Text).ToString().Trim() != "" || (txtTrNoOkay.Text).ToString().Trim() != null)
                {
                    if ((txtTrNoOkay.Text).ToString().Trim() == "Y" || (txtTrNoOkay.Text).ToString().Trim() == "y")
                    {
                        //lblType.Visible = true;
                        //cmbType.Visible = true;
                        bool Exist = IsTruckNoExist();
                        if (Exist == true)
                        {
                            lblType.Visible = true;
                            cmbType.Visible = true;
                            cmbType.SelectedIndex = type;
                            cmbType.Enabled = false;
                            lblPlace.Visible = false;
                            lblPlaceMsg.Visible = false;
                            txtPlace.Visible = false;
                            lblPrint.Visible = true;
                            txtPrint.Visible = true;
                            txtPrint.Focus();

                        }
                        else
                        {
                            lblType.Visible = true;
                            cmbType.Visible = true;
                            cmbType.Enabled = true;
                            cmbType.Focus();
                            //lblPlace.Visible = true;
                            //txtPlace.Visible = true;
                            //lblPlaceMsg.Visible = true;
                            lblPrint.Visible = false;
                            txtPrint.Visible = false;
                            // refreshdata();
                        }
                    }
                    else if ((txtTrNoOkay.Text).ToString().Trim() == "N" || (txtTrNoOkay.Text).ToString().Trim() == "n")
                    {
                        hide();
                        txtVehicleNo.Text = "";
                        txtVehicleNo.Focus();
                    }
                    else if ((txtTrNoOkay.Text).ToString().Trim() == "Q" || (txtTrNoOkay.Text).ToString().Trim() == "q")
                    {
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        hide();
                        txtVehicleNo.Text = "";
                        txtVehicleNo.Focus();
                    }
                    e.Handled = true;
                }
                else
                {
                    Form1 form = new Form1();
                    this.Hide();
                    form.Show();
                }


            }
        }

        public bool IsTruckNoExist()
        {
            bool IsExist = false;
            string s = "SELECT TRUC_TEMPO FROM TRUCK WHERE Trim(TRUCK_NO) ='" + txtVehicleNo.Text.ToString().Trim() + "'";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        type = Convert.ToInt16(dr[0]);

                    }
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }
                con.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
            }
            return IsExist;
        }

        private void txtPlace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblPrint.Visible = true;
                txtPrint.Visible = true;
                txtPrint.Focus();
                e.Handled = true;
            }
        }

        private void txtPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((txtPrint.Text).ToString() != "" || (txtPrint.Text).ToString() == null)
                {

                    if ((txtPrint.Text).ToString().Trim() == "Y" || (txtPrint.Text).ToString().Trim() == "y")
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(conString);
                            SqlCommand cmd = new SqlCommand("[SaveAr_Em]", con);
                            con.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@GateId", Convert.ToInt32(GateId));
                            cmd.Parameters.AddWithValue("@Truck", txtVehicleNo.Text.ToString().Trim().ToUpper());
                            cmd.Parameters.AddWithValue("@place", txtPlace.Text.ToString());
                            cmd.Parameters.AddWithValue("@G_Ty", Convert.ToString(GateId));
                            cmd.Parameters.AddWithValue("@ID", Convert.ToString(cmbType.SelectedIndex));
                            int status = cmd.ExecuteNonQuery();
                            if (status > 1)
                            {
                                lblAnotherTruck.Visible = true;
                                txtAnotherTruck.Visible = true; txtAnotherTruck.Text = "Y";
                                txtAnotherTruck.Focus();
                                e.Handled = true;
                                MessageBox.Show("Data inserted successfully");

                            }
                            con.Close();

                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        hide();
                        lblPlace.Visible = false;
                        lblPlace.Visible = false;
                        txtPlace.Visible = false;
                        lblPrint.Visible = false;
                        txtPrint.Visible = false;
                        lblPrint.Visible = false;
                        lblTrNoOkay.Visible = true;
                        txtTrNoOkay.Text = "N";
                        txtTrNoOkay.Focus();
                        txtTrNoOkay.Visible = true;
                      //  refreshdata();
                    }

                }
                else
                {
                 //   refreshdata();
                    hide();

                }
                e.Handled = true;
            }
        }
        private void txtAnotherTruck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAnotherTruck.Text.ToString() != "" || txtAnotherTruck.Text.ToString() != null)
                {
                    if (txtAnotherTruck.Text.ToString().Trim() == "Y" || txtAnotherTruck.Text.ToString().Trim() == "y")
                    {
                        //refreshdata();
                        hide();
                        Clear();
                    }
                    else if (txtAnotherTruck.Text.ToString().Trim() == "N" || txtAnotherTruck.Text.ToString().Trim() == "n")
                    {
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                }
                e.Handled = true;
            }
        }

        //public int GetRstNo()
        //{
        //    string query = ""; ;
        //    int rst = 0;
        //    if (GateId == 1)
        //    {
        //        query = "SELECT * FROM rst_no_e";
        //    }
        //    else if (GateId == 2)
        //    {
        //        query = "SELECT * FROM rst_no";
        //    }

        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    try
        //    {
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                rst = Convert.ToInt32(dr[0]);
        //            }
        //            rst = rst + 1;
        //        }
        //        con.Close();
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return rst;


        //}

        //public string GetEntryFee()
        //{
        //    string query = ""; ;
        //    string rate = "";
        //    if (GateId == 1)
        //    {
        //        query = "SELECT E_RATE FROM entry_rt Where ID='" + cmbType.SelectedIndex + "'";
        //    }
        //    else if (GateId == 2)
        //    {
        //        query = "SELECT L_RATE FROM entry_rt Where ID='" + cmbType.SelectedIndex + "'";
        //    }

        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    try
        //    {
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                rate = dr[0].ToString();
        //            }

        //        }
        //        con.Close();
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return rate;


        //}

        //public int UpdateRstNo(string rst_no)
        //{
        //    string query = ""; ;
        //    int RowAffected = 0;
        //    if (GateId == 1)
        //    {
        //        query = "Update rst_no_e set RST_NO='" + rst_no + "'";
        //    }
        //    else if (GateId == 2)
        //    {
        //        query = "Update rst_no set RST_NO='" + rst_no + "'";
        //    }

        //    SqlConnection con = new SqlConnection(conString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    try
        //    {
        //        RowAffected = cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return RowAffected;
        //}

        //public int insertdata()
        //{
        //    int rstNo = GetRstNo();
        //    string rate = GetEntryFee();
        //    string date = DateTime.Now.ToString("yyyymmdd");
        //    string time = DateTime.Now.ToString("hh:mm:ss");
        //    int status = UpdateRstNo(rstNo.ToString());
        //    int RowAffected = 0;
        //    if (status == 1)
        //    {
        //        try
        //        {
        //            SqlConnection con = new SqlConnection(conString);
        //            con.Open();
        //            string query = (@"insert into ar_em (TRUCK,RST_NO,PLACE,G_TY,ID,ENTRY_FEE,[DATE],[TIME]) values 
        //                            ('" + txtVehicleNo.Text.ToString().Trim().ToUpper() + "', '" + rstNo.ToString().Trim() + "' ,'" + txtPlace.Text.ToString().Trim() + "'" +
        //                            ",'" + GateId + "', '" + cmbType.SelectedValue + "','" + rate + "','" + date + "','" + time + "')");
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            RowAffected = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    return RowAffected;
        //}
    }
}

