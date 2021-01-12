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

namespace Task3_4b
{
    public partial class MainWindow : Window
    {
        public System.Windows.Threading.DispatcherTimer dispTimer;
        public MainWindow()
        {
            InitializeComponent();
            dispTimer = new System.Windows.Threading.DispatcherTimer();
            dispTimer.Interval = new TimeSpan(0, 0, 1);
            new Presenter(this);
        }

        public EventHandler start;
        public EventHandler stop;
        public EventHandler reset;

        public event EventHandler Start
        {
            add { start += value; }
            remove { start -= value; }
        }
        public event EventHandler Stop
        {
            add { stop += value; }
            remove { stop -= value; }
        }
        public event EventHandler Reset
        {
            add { reset += value; }
            remove { reset -= value; }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            start.Invoke(sender, e);
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            stop.Invoke(sender, e);
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            reset.Invoke(sender, e);
        }
    }
}
