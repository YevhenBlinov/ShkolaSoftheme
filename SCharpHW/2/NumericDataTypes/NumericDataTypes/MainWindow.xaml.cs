using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NumericDataTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericDataTypesComboBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            var numericDataTypeNames = new List<string>()
            {
                "byte",
                "sbyte",
                "short",
                "ushort",
                "int",
                "uint",
                "long",
                "ulong",
                "decimal",
                "float",
                "double"
            };

            NumericDataTypesComboBox.ItemsSource = numericDataTypeNames;
            NumericDataTypesComboBox.SelectedIndex = 0;
        }

        private void NumericDataTypesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedNumericDataType = NumericDataTypesComboBox.SelectedItem as string;
            switch (selectedNumericDataType)
            {
                case "sbyte":
                    FillTextBoxesWithInformationAboutSByte();
                    break;
                case "short":
                    FillTextBoxesWithInformationAboutShort();
                    break;
                case "ushort":
                    FillTextBoxesWithInformationAboutUShort();
                    break;
                case "int":
                    FillTextBoxesWithInformationAboutInt();
                    break;
                case "uint":
                    FillTextBoxesWithInformationAboutUint();
                    break;
                case "long":
                    FillTextBoxesWithInformationAboutLong();
                    break;
                case "ulong":
                    FillTextBoxesWithInformationAboutULong();
                    break;
                case "decimal":
                    FillTextBoxesWithInformationAboutDecimal();
                    break;
                case "float":
                    FillTextBoxesWithInformationAboutFloat();
                    break;
                case "double":
                    FillTextBoxesWithInformationAboutDouble();
                    break;
                default:
                    FillTextBoxesWithInformationAboutByte();
                    break;
            }
        }

        private void FillTextBoxesWithInformationAboutByte()
        {
            MinValueTextBlock.Text = byte.MinValue.ToString();
            MaxValueTextBlock.Text = byte.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(byte).ToString();
        }

        private void FillTextBoxesWithInformationAboutSByte()
        {
            MinValueTextBlock.Text = sbyte.MinValue.ToString();
            MaxValueTextBlock.Text = sbyte.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(sbyte).ToString();
        }

        private void FillTextBoxesWithInformationAboutShort()
        {
            MinValueTextBlock.Text = short.MinValue.ToString();
            MaxValueTextBlock.Text = short.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(short).ToString();
        }

        private void FillTextBoxesWithInformationAboutUShort()
        {
            MinValueTextBlock.Text = ushort.MinValue.ToString();
            MaxValueTextBlock.Text = ushort.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(ushort).ToString();
        }

        private void FillTextBoxesWithInformationAboutInt()
        {
            MinValueTextBlock.Text = int.MinValue.ToString();
            MaxValueTextBlock.Text = int.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(int).ToString();
        }

        private void FillTextBoxesWithInformationAboutUint()
        {
            MinValueTextBlock.Text = uint.MinValue.ToString();
            MaxValueTextBlock.Text = uint.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(uint).ToString();
        }

        private void FillTextBoxesWithInformationAboutLong()
        {
            MinValueTextBlock.Text = long.MinValue.ToString();
            MaxValueTextBlock.Text = long.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(long).ToString();
        }

        private void FillTextBoxesWithInformationAboutULong()
        {
            MinValueTextBlock.Text = ulong.MinValue.ToString();
            MaxValueTextBlock.Text = ulong.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(ulong).ToString();
        }

        private void FillTextBoxesWithInformationAboutDecimal()
        {
            MinValueTextBlock.Text = decimal.MinValue.ToString();
            MaxValueTextBlock.Text = decimal.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(decimal).ToString();
        }

        private void FillTextBoxesWithInformationAboutFloat()
        {
            MinValueTextBlock.Text = float.MinValue.ToString();
            MaxValueTextBlock.Text = float.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(float).ToString();
        }

        private void FillTextBoxesWithInformationAboutDouble()
        {
            MinValueTextBlock.Text = double.MinValue.ToString();
            MaxValueTextBlock.Text = double.MaxValue.ToString();
            DefaultValueTextBlock.Text = default(double).ToString();
        }
    }
}
