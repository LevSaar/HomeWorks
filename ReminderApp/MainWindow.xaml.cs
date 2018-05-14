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

                if (selectedDate < DateTime.Now || hourBox.Text == null || minuteBox.Text == null || Int32.Parse(hourBox.Text) > 23 || Int32.Parse(minuteBox.Text) > 59)
                    MessageBox.Show("Введите данные корректно !");
                else
                    AddReminder(selectedDate, Int32.Parse(hourBox.Text), Int32.Parse(minuteBox.Text), new TextRange(messageTextBox.Document.ContentStart, messageTextBox.Document.ContentEnd).Text);
            }
            catch { MessageBox.Show("Введите данные корректно !"); }
        }

        private void AddReminder(DateTime _dateRemind, int _hour, int _minute, string _message)
        {
            TimeSpan time = _dateRemind - DateTime.Now;
            Timer timer = new Timer(
                new TimerCallback
                    (
                        state => MessageBox.Show("Напоминание \n" + DateTime.Now.ToLongTimeString() + ": " + _message)
                    ), 
                    null, 
                    0, 
                    (
                        (int)time.TotalMilliseconds + ((_hour * 3600000) + (_minute * 60000))
                    )
                );
        }
    }
}
