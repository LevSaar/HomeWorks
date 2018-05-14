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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReminderApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Time { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MessageBox_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDate = dateRemindPicker.SelectedDate.Value.Date;

                if (selectedDate < DateTime.Now)
                    MessageBox.Show("Выберите дату корректно !");
                else
                    AddReminder(selectedDate, new TextRange(messageTextBox.Document.ContentStart, messageTextBox.Document.ContentEnd).Text);
            }
            catch { MessageBox.Show("Выберите дату корректно !"); }
        }

        private void AddReminder(DateTime _dateRemind, string _message)
        {
            TimeSpan time = _dateRemind - DateTime.Now;
            Timer timer = new Timer(new TimerCallback(state => MessageBox.Show(DateTime.Now.ToLongTimeString())), null, 0, (int)time.TotalMilliseconds); //  Доделать
        }
    }
}
