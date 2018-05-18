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

namespace TasksHomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Task[] TaskList;

        public MainWindow()
        {
            InitializeComponent();

            TaskList = new Task[3]
            {
                new Task(() => listBox.Items.Add("First Task")),
                new Task(() => listBox.Items.Add("Second Task")),
                new Task(() => listBox.Items.Add("Third Task"))
            };
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
