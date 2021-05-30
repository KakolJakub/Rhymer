using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace Rhymer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private const int maxAmount = 5;
        private const int depleteAmount = 1;
        private int currentAmount;

        public MainWindow()
        {
            InitializeComponent();
            ResetVisuals();
        }

        private void RerollEngWord(object sender, RoutedEventArgs e)
        {
            var rolledWord = WordBlock.Text.GetDifferentRandomWord(Rhymer.Language.English);
            WordBlock.Text = rolledWord;
            ResetTimer();
        }

        private void RerollPlWord(object sender, RoutedEventArgs e)
        {
            var rolledWord = WordBlock.Text.GetDifferentRandomWord(Rhymer.Language.Polish);
            WordBlock.Text = rolledWord;
            ResetTimer();
        }

        private void ResetTimer()
        {
            ResetVisuals();
            StopTimer();
            currentAmount = maxAmount;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += DisplayTime;
            _timer.Start();
        }

        private void StopTimer()
        {
            if (_timer == null)
                return;

            _timer.Stop();
        }

        private void DisplayTime(object sender, EventArgs e)
        {
            var seconds = currentAmount--;

            if (seconds > 0)
            {
                TimerBlock.Text = seconds.ToString();
            }
            else
            {
                StopTimer();
                TimerBlock.Text = "0";
                DisplayWinMessage();
            }
        }

        private void DisplayWinMessage()
        {
            var isWon = InputTextBox.Text.IsRhyme(WordBlock.Text);
            TimerBlock.Text = isWon ? "ZWYCIĘSTWO!" : "PORAŻKA!";
            TimerBlock.Background = isWon ? Brushes.Green : Brushes.Red;
        }

        private void ResetVisuals()
        {
            TimerBlock.Background = Brushes.Gray;
            TimerBlock.Text = "-";
            InputTextBox.Clear();
        }
    }
}
