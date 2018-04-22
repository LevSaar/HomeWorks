using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
           /*
            Заполнение
            using (var db = new SellsContainer())
            {
                var buyer1 = new Buyers {Id = 1, Name = "Name1", Surname = "Surname1" };
                var buyer2 = new Buyers {Id = 2, Name = "Name2", Surname = "Surname2" };
                var buyer3 = new Buyers {Id = 3, Name = "Name3", Surname = "Surname3" };
                db.BuyersSet.Add(buyer1);
                db.BuyersSet.Add(buyer2);
                db.BuyersSet.Add(buyer3);
                      
                var seller1 = new Sellers {Id = 1, Name = "Name1", Surname = "Surname1" };
                var seller2 = new Sellers {Id = 2,Name = "Name2", Surname = "Surname2" };
                var seller3 = new Sellers {Id = 3,Name = "Name3", Surname = "Surname3" };
                db.SellersSet.Add(seller1);
                db.SellersSet.Add(seller2);
                db.SellersSet.Add(seller3);

                var sell1 = new Sell { Sum = 1, Date = DateTime.Now, BuyersId = 1,  SellersId = 1};
                var sell2 = new Sell { Sum = 2, Date = DateTime.Now, BuyersId = 2 , SellersId = 2 };
                var sell3 = new Sell { Sum = 3, Date = DateTime.Now, BuyersId = 3 , SellersId = 3 };
                db.Sells.Add(sell1);
                db.Sells.Add(sell2);
                db.Sells.Add(sell3);

                db.SaveChanges();              
            }*/

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                using (var db = new SellsContainer())
                {
                    dataGridView1.DataSource = db.BuyersSet.ToList();
                    dataGridView1.Update();

                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                using (var db = new SellsContainer())
                {
                    dataGridView1.DataSource = db.SellersSet.ToList();
                    dataGridView1.Update();
                }
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                using (var db = new SellsContainer())
                {
                    dataGridView1.DataSource = db.Sells.ToList();
                    dataGridView1.Update();
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
