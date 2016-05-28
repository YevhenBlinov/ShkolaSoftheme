using System.Windows;
using System.Windows.Input;

namespace ZodiacWpfApplication
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        private const int MinDay = 1;
        private const int MaxDay = 31;
        private const int MinMonth = 0;
        private const int MaxMonth = 12;
        private const int MinYear = 1;
        private const int DayAndMonthDigitsCount = 2;
        private const int YearDigitsCount = 4;

        public InputWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void DateTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            var date = VerifyBirthDate(DateTextBox.Text);
            if (date.Length == 0)
            {
                MessageBox.Show("Please, try again.", "Incorrect data format...", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            var birthdayCalculator = new BirthdayCalculator(date[0], date[1], date[2]);
            this.Visibility = Visibility.Collapsed;
            var userWindow = new UserInformationWindow(birthdayCalculator, this);
        }

        private int[] VerifyBirthDate(string date)
        {
            var birthDate = date.Split('/');

            int day = 0, month = 0, year = 0;
            if (birthDate.Length != 3 ||
                GetDigitsCount(birthDate[0]) != DayAndMonthDigitsCount ||
                !int.TryParse(birthDate[0], out day) ||
                GetDigitsCount(birthDate[1]) != DayAndMonthDigitsCount ||
                !int.TryParse(birthDate[1], out month) ||
                GetDigitsCount(birthDate[2]) != YearDigitsCount ||
                !int.TryParse(birthDate[2], out year) ||
                day < MinDay ||
                day > MaxDay ||
                month < MinMonth ||
                month > MaxMonth ||
                year < MinYear)
            {
                return new int[]{};
            }

            return new[]{day, month, year};
        }

        private static int GetDigitsCount(string number)
        {
            return number.Length;
        }
    }
}
