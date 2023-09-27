using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Bookworm
{
    /// <summary>
    /// Interaction logic for ReplaceBookPage.xaml
    /// </summary>
    public partial class ReplaceBookPage : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string currentTime = string.Empty;

        public ReplaceBookPage()
        {
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }
        void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                StopWatch.Content = currentTime;
            }
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            //start multithreading timer
            sw.Start();
            dt.Start();

            //genenrate random calling number
            List<string> Numbers = Generate.CallNumber();
            ListBox.ItemsSource = Numbers;

            //enable listbox 
            ListBox.IsEnabled = true;
            Btn_Finish.IsEnabled = true;
            Btn_Start.IsEnabled = false;
            Btn_Up.IsEnabled = true;
            Btn_Down.IsEnabled = true;
        }

        private void Btn_Finish_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            StopWatch.Content = "00:00:00";

            if (sw.IsRunning)
            {
                sw.Stop();
            }
        }

        private void Btn_Up_Click(object sender, RoutedEventArgs e)
        {
            int i = ListBox.SelectedIndex;

            string item = ListBox.SelectedIndex.ToString();
            if(i > 0)
            {
                ListBox.Items.RemoveAt(i);
                ListBox.Items.Insert(i - 1, item);
                ListBox.SelectedIndex = i-1;
            }
            
        }

        private void Btn_Down_Click(object sender, RoutedEventArgs e)
        {
            int i = ListBox.SelectedIndex;

            string item = ListBox.SelectedIndex.ToString();
            if (i < ListBox.Items.Count -1 )
            {
                ListBox.Items.RemoveAt(i);
                ListBox.Items.Insert(i + 1, item);
                ListBox.SelectedIndex = i + 1;
            }
        }
    }
}
