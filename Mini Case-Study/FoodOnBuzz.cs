using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Case_Study
{
    public partial class FoodOnBuzz : Form
    {
        public FoodOnBuzz()
        {
            InitializeComponent();
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AdminLogin obj = new AdminLogin();
                //obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogin obj = new UserLogin();
                //obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
