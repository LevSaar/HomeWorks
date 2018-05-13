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
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private delegate void MoneyManipulation(BankAccount _account, int _money);

        private MoneyManipulation replenish;
        private MoneyManipulation withdraw;

        BankAccount account;
        
        public Home(int _id, string _name, string _cash, string _creditNumber)
        {
            InitializeComponent();

            idTextBlock.Text = _id.ToString();
            nameTextBlock.Text = _name;
            cashTextBlock.Text = _cash;
            creditNumberTextBlock.Text = _creditNumber;

            using (var connection = new BankDataModel())
            {
                account = connection.BankAccounts.Find(_id);
            }

            replenish = new MoneyManipulation(ReplenishDB);
            withdraw = new MoneyManipulation(WithdrawDB);
        }

        private void ReplenishButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
                int result = Int32.Parse(cashTextBlock.Text) + Int32.Parse(moneyTextBox.Text);
                ReplenishMoney(account, result);
                cashTextBlock.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("The amount entered is invalid");
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                int result = Int32.Parse(cashTextBlock.Text) - Int32.Parse(moneyTextBox.Text);

                if (result >= 0)
                {
                    WithdrawMoney(account, result);
                    cashTextBlock.Text = result.ToString();
                }
                else MessageBox.Show("There is not enough money on your account.");
            }
            catch
            {
                MessageBox.Show("The amount entered is invalid");
            }
        }


        private void ReplenishMoney(BankAccount _account, int _money)
        {
            IAsyncResult res = replenish.BeginInvoke(_account, _money, new AsyncCallback(asyncResult => MessageBox.Show("Your account has been credited.")), null);
            replenish.EndInvoke(res);
        }

        private void WithdrawMoney(BankAccount _account, int _money)
        {
            IAsyncResult res = withdraw.BeginInvoke(_account, _money, new AsyncCallback(asyncResult => MessageBox.Show("The operation is completed.")), null);
            withdraw.EndInvoke(res);
        }


        public static void ReplenishDB(BankAccount _bankAccount, int _money)
        {
            _bankAccount.Money += _money;

            using (var connection = new BankDataModel())
            {
                connection.BankAccounts.Find(_bankAccount.Id).Money += _money;
                connection.SaveChanges();
            }
        }

        public static void WithdrawDB(BankAccount _bankAccount, int _money)
        {
            _bankAccount.Money -= _money;

            using (var connection = new BankDataModel())
            {
                connection.BankAccounts.Find(_bankAccount.Id).Money -= _money;
                connection.SaveChanges();
            }
        }
    }
}
