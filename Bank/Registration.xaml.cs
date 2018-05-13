using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private delegate void RegDelegate(string  _name, string _password, int _creditNumber);

        public Registration()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int number = rand.Next(999, 9999);

            RegDelegate regDelegate = new RegDelegate(AddProfile);
            
            IAsyncResult res = regDelegate.BeginInvoke(RegNameBox.Text, RegPasswordBox.Text, number, null, null);
            regDelegate.EndInvoke(res);

            this.Close();

            MessageBox.Show("Your credit number: " + number);
        }

        private void AddProfile(string name, string password, int creditNum)
        {
            using (var connection = new BankDataModel())
            {
                var bankAcc1 = new BankAccount { Money = 0.0, CreditNumber = creditNum };
                var user1 = new User { Name = name, Password = password };

                connection.Users.Add(user1);
                connection.BankAccounts.Add(bankAcc1);

                connection.SaveChanges();
            }
        }
    }
}
