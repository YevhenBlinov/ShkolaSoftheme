using System;
using System.Collections.Generic;
using System.IO;
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

namespace GuessANumberWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void NumberTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key != Key.Enter)
                return;

            try
            {
                VerifyEnteredNumber();
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Number must be an integer.", "InvalidDataException", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Number must be in range from 1 to 10.", exception.Message, MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var enteredNumber = int.Parse(NumberTextBox.Text);
            var randomNumber = GetRandomNumberFrom1To10();

            if (enteredNumber == randomNumber)
            {
                MessageBox.Show("You guessed it!", "Congratulations", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("The number was " + randomNumber + ". Please, try again.", "I'm sorry, but you're wrong.", MessageBoxButton.OK);
            }
        }

        private void VerifyEnteredNumber()
        {
            var enteredNumber = 0;

            if (!int.TryParse(NumberTextBox.Text, out enteredNumber))
            {
                throw new InvalidDataException();
            }

            if (enteredNumber < 1 || enteredNumber > 10)
            {
                throw new Exception("NumberOutOfRangeException");
            }
        }

        private int GetRandomNumberFrom1To10()
        {
            var random = new Random();
            return random.Next(1, 10);
        }
    }
}
