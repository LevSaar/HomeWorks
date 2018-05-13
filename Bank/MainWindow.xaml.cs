using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User getUser;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            List<User> users;
            List<BankAccount> bankAccounts;

            using (BankDataModel context = new BankDataModel())
            {
                users = context.Users.ToList();
                bankAccounts = context.BankAccounts.ToList();

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Name == authNameBox.Text)
                    {
                        if (users[i].Password == authPasswordBox.Text)
                        {
                            getUser = users[i];
                            for (int j = 0; j < bankAccounts.Count; j++)
                            {
                                if (bankAccounts[j].Id == getUser.BankAccountId)
                                {
                                    getUser.BankAccount = bankAccounts[j];
                                    Home home = new Home(getUser.BankAccountId, authNameBox.Text, bankAccounts[j].Money.ToString(), bankAccounts[j].CreditNumber.ToString());
                                    MainWindow main = this;
                                    home.Show();
                                    main.Close();
                                }
                            }
                        }
                    }
                    else MessageBox.Show("Incorrect username or password");
                }
            }
            
        }
    }
}
