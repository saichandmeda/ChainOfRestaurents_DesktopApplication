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
    public partial class MyHistory : Form
    {
        public MyHistory()
        {
            InitializeComponent();
        }

        private void MyHistory_Load(object sender, EventArgs e)
        {
            try
            { 
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                var data = from a in ctx.Histories.ToList()
                           where (a.UserId == Program.UserId)
                           select new
                           {
                               a.Restaurant,
                               a.Branch,
                               a.FoodItem,
                               a.Price,
                               a.DaTi
                           };
                dataGridView1.DataSource = data.ToList();
            }
         catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
