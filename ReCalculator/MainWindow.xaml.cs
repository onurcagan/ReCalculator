using System;
using System.Windows;
using System.Windows.Controls;

namespace ReCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creating a new instance of Calculate class, cal object

        Calculate cal = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Generic button click, adds the pressed button to the precalculationTextBox
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button aButton = (Button)sender;

            // Checks for whether the button clicked has a TextBlock inside, if it does, grabs the TextBlock content

            if (aButton.Content is TextBlock block)
            {
                preCalculationTextBox.Text += block.Text;
            }

            else
            {
                preCalculationTextBox.Text += aButton.Content.ToString();
            }
        }

        // Because of Cultures I made it so that when the "dot", "." button is clicked, the program instead types a comma for calculations
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            preCalculationTextBox.Text += ",";
        }

        // Button to erase both preCalculationTextBox and calculationTextBox
        private void Erase_Click(object sender, RoutedEventArgs e)
        {
            preCalculationTextBox.Text = null;
            calculationTextBox.Text = null;
        }

        // Results button, runs the Calculate function
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception)
            {
                calculationTextBox.Text = "Error!";
            }
        }

        // Calculation function, currently only handles a single operation at a time
        private void Calculate()
        {
            int opPos = 0;
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            string op = "";
            string content = preCalculationTextBox.Text;

            if (content.Length == 0)
            {
                return;
            }
            else if (content.Contains("÷"))
            {
                opPos = content.IndexOf("÷");
            }
            else if (content.Contains("×"))
            {
                opPos = content.IndexOf("×");
            }
            else if (content.Contains("-"))
            {
                opPos = content.IndexOf("-");
            }
            else if (content.Contains("+"))
            {
                opPos = content.IndexOf("+");
            }
            else if (content.Contains("%"))
            {
                opPos = content.IndexOf("%");
            }

            value1 = Double.Parse(content.Substring(0, opPos));
            op = content.Substring(opPos, 1);
            if (Double.TryParse(content.Substring(opPos + 1), out value2)) // This makes the % button work with a single value and not throw an error for when the value2 is missing

            if (op == "×")
            {
                result = cal.multiply(value1, value2);
                calculationTextBox.Text = result.ToString();
            }
            if (op == "÷")
            {
                result = cal.divide(value1, value2);
                calculationTextBox.Text = result.ToString();
            }
            if (op == "-")
            {
                result = cal.subtract(value1, value2);
                calculationTextBox.Text = result.ToString();
            }
            if (op == "+")
            {
                result = cal.add(value1, value2);
                calculationTextBox.Text = result.ToString();
            }
            if (op == "%")
            {
                result = cal.percentage(value1);
                calculationTextBox.Text = result.ToString();
            }

        }
    }
}