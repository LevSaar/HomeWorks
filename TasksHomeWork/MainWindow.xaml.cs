using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace TasksHomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static CancellationTokenSource token = new CancellationTokenSource();
        public Task _task;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _task = Task.Run(() => Prockill(token.Token));
        }   

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            token.Cancel();
        }

        public static async Task Prockill(CancellationToken cancellationToken)
        {
            try
            {
                Process[] procList = Process.GetProcesses();

                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(500, cancellationToken);

                    for (int i = 0; i < procList.Length; i++)
                    {
                        Process[] processesByName = Process.GetProcessesByName(procList[i].MachineName.ToString());
                        foreach (Process process in processesByName)
                        {
                            process.Kill();
                        }
                   }
                }
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show("Ошибка: "+ ex.ToString());
            }
        }
    }
}
