using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ZodiacWpfApplication
{
    /// <summary>
    /// Interaction logic for UserInformationWindow.xaml
    /// </summary>
    public partial class UserInformationWindow : Window
    {
        private InputWindow _inputWindow;
        public UserInformationWindow(BirthdayCalculator birthdayCalculator, InputWindow inputWindow)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _inputWindow = inputWindow;
            birthdayCalculator.CalculateAgeAndZodiacSign();
            AgeTextBlock.Text = birthdayCalculator.Age.ToString();
            ZodiacSignTextBlock.Text = birthdayCalculator.ZodiacSignName;
            ZodiacSignImage.Source =
                new BitmapImage(
                    new Uri("/ZodiacWpfApplication;component/Assets/" + birthdayCalculator.ZodiacSignName + ".jpg",
                        UriKind.Relative));
            Show();
        }

        private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            _inputWindow.Visibility = Visibility.Visible;
        }
    }
}
