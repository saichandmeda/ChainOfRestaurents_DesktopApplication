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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "AdminId" && txtPwd.Text == "AdminPass")
                {
                    txtId.Text = "";
                    txtPwd.Text = "";
                    AdminMaster obj = new AdminMaster();
                    //obj.MdiParent = this;
                    
                    obj.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Invalid Credentials");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
