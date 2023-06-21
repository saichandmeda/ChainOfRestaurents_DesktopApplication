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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Program.UserId = txtId.Text;
                Program.City = cmbCity.Text;
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                int cnt = 0;
                foreach (var item in ctx.Users)
                {
                    if (txtId.Text == item.Id && txtPwd.Text == item.Pass)
                    {
                        cnt++;
                        break;
                    }
                }
            if(cnt==0)
            {
                MessageBox.Show("Invalid Credentials");
                txtId.Text = "";
                txtPwd.Text = "";
                cmbCity.Text = "";
            }
            else
            {
                UserMaster obj = new UserMaster();
                obj.Show();
                this.Close();
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                int cnt = 0;
                foreach (var item in ctx.Users)
                {
                    if (txtId.Text == item.Id)
                    {
                        MessageBox.Show("User Already Exist");
                        txtId.Text = "";
                        txtPwd.Text = "";
                        break;
                    }
                    cnt++;
                }
                    if(cnt==ctx.Users.Count())
                    {
                        User u1 = new User()
                        {
                            Id = txtId.Text,
                            Pass = txtPwd.Text
                        };
                        ctx.Users.Add(u1);
                        ctx.SaveChanges();
                        txtId.Text = "";
                        txtPwd.Text = "";
                        MessageBox.Show("Registered Successfully");
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                List<string> City = new List<string>();
                foreach (var item in ctx.Restaurants.ToList())
                {
                    City.Add(item.City);
                }
                List<string> Distinct = City.Distinct().ToList();
                cmbCity.Items.Clear();
                foreach (string item in Distinct.ToList())
                {
                    cmbCity.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
