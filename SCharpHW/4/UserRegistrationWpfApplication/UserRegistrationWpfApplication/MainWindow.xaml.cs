using System;
using System.Linq;
using System.Windows;

namespace UserRegistrationWpfApplication
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

        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!VerifyFirstNameTextBox(FirstNameTextBox.Text))
            {
                MessageBox.Show("First name must contain at least 1 symbol, but less then 255 symbols and only alphabetical characters.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyLastNameTextBox(LastNameTextBox.Text))
            {
                MessageBox.Show("Last name must contain at least 1 symbol, but less then 255 symbols and only alphabetical characters.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyDayTextBox(DayTextBox.Text))
            {
                MessageBox.Show("Day must contain at least 1 symbol and only numbers. Minimum day value must be 1, maximum day value must be 31.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyDayTextBox(MonthTextBox.Text))
            {
                MessageBox.Show("Month must contain at least 1 symbol and only numbers. Minimum month value must be 1, maximum month value must be 12.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyYearTextBox(YearTextBox.Text))
            {
                MessageBox.Show("Year must contain 4 symbol and only numbers. Minimum year value must be 1901, maximum year value must be 2016.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyEmailTextBox(EmailTextBox.Text))
            {
                MessageBox.Show("Email must contain @ symbol and less then 255 symbols.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyPhoneNumberTextBox(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Phone number must contain only numbers and it lenth must be 12.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!VerifyAdditionalInfoTextBox(AdditionalInfoTextBox.Text))
            {
                MessageBox.Show("Additional info must contain less then 2000 symbols", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var birthDate = new DateTime(int.Parse(YearTextBox.Text), int.Parse(MonthTextBox.Text), int.Parse(DayTextBox.Text));
            var gender = (bool)MaleRadioButton.IsChecked ? Gender.Male : Gender.Female;
            var newUser = new User(FirstNameTextBox.Text, LastNameTextBox.Text, birthDate, gender, EmailTextBox.Text,
                PhoneNumberTextBox.Text, AdditionalInfoTextBox.Text);
        }

        private bool VerifyFirstNameTextBox(string firstName)
        {
            return firstName.Length >= 1 && firstName.Length < 255 && ContainsOnlyLetters(firstName);
        }

        private bool VerifyLastNameTextBox(string lastName)
        {
            return lastName.Length >= 1 && lastName.Length < 255 && ContainsOnlyLetters(lastName);
        }

        private bool VerifyDayTextBox(string day)
        {
            var dayValue = 0;
            return day.Length != 0 && int.TryParse(day, out dayValue) && dayValue > 0 && dayValue < 32;
        }

        private bool VerifyMonthTextBox(string month)
        {
            var monthValue = 0;
            return month.Length != 0 && int.TryParse(month, out monthValue) && monthValue > 0 && monthValue < 13;
        }
        private bool VerifyYearTextBox(string year)
        {
            var yearValue = 0;
            return year.Length != 0 && int.TryParse(year, out yearValue) && yearValue > 1900 && yearValue < 2017;
        }

        private bool VerifyEmailTextBox(string email)
        {
            return email.Length != 0 && email.Length < 255 && email.Contains("@");
        }

        private bool VerifyPhoneNumberTextBox(string phoneNumber)
        {
            return phoneNumber.Length != 0 && phoneNumber.Length < 13 && ContainsOnlyNumbers(phoneNumber);
        }

        private bool VerifyAdditionalInfoTextBox(string additionalInfo)
        {
            return additionalInfo.Length < 2000;
        }

        private bool ContainsOnlyLetters(string stringToVerify)
        {
            var containsNotOnlyLetters = stringToVerify.Any(c => !((c >= 65 && c <= 90) || (c >= 97 && c <= 122)));
            return !containsNotOnlyLetters;
        }

        private bool ContainsOnlyNumbers(string stringToVerify)
        {
            var containsNotOnlyNumbers = stringToVerify.Any(c => !(c >= 48 && c <= 57));
            return !containsNotOnlyNumbers;
        }
    }
}
