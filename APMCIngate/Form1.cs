using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APMCIngate
{
    public partial class Form1 : Form
    {
        public static int GateId;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEmpty_Click(object sender, EventArgs e)
        {
            GateId = 1;
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void btnLoaded_Click(object sender, EventArgs e)
        {
            GateId = 2;
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnArrInfo_Click(object sender, EventArgs e)
        {
            ArrivalInfo form = new ArrivalInfo();
            form.Show();
            this.Hide();
        }
    }
}
