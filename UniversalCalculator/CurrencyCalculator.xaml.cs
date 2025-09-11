using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator1 : Page
	{
		public CurrencyCalculator1()
		{
			this.InitializeComponent();
		}
		private void CalculateCurrencyButton_Click(object sender, RoutedEventArgs e)
		{
			decimal input = decimal.Parse(amountTextBox.Text); // user input
			string fromCurrency = ((ComboBoxItem)fromComboBox.SelectedItem).Tag.ToString();
			string toCurrency = ((ComboBoxItem)toComboBox.SelectedItem).Tag.ToString();

			var conversionRates = new Dictionary<string, Dictionary<string, decimal>>()
		{
	{ "USD", new Dictionary<string, decimal>
		{
			{ "EUR", 0.85189982m },
			{ "GBP", 0.72872436m },
			{ "RUP", 74.257327m }
		}
	},
	{ "EUR", new Dictionary<string, decimal>
		{
			{ "USD", 1.1739732m },
			{ "GBP", 0.8556672m },
			{ "RUP", 87.00755m }
		}
	},
	{ "GBP", new Dictionary<string, decimal>
		{
			{ "USD", 1.371907m },
			{ "EUR", 1.1686692m },
			{ "RUP", 101.68635m }
		}
	},
	{ "RUP", new Dictionary<string, decimal>
		{
			{ "USD", 0.011492628m },
			{ "EUR", 0.013492774m },
			{ "GBP", 0.0098339397m }
		}
	}
};
			// Get currency symbols
			string symbol = "";
			switch (toCurrency)
			{
				case "USD":
					symbol = "$";
					break;
				case "EUR":
					symbol = "€";
					break;
				case "GBP":
					symbol = "£";
					break;
				case "RUP":
					symbol = "₹";
					break;
				default:
					symbol = "";
					break;
			}

			if (fromCurrency == toCurrency)
			{
				resultTextBox.Text = input.ToString("N2") + " " + toCurrency;
				fromToConversionTextBox.Text = "1 " + fromCurrency + " = 1 " + toCurrency;
				toFromConversionTextBox.Text = "1 " + toCurrency + " = 1 " + fromCurrency;
				return;
			}

			// Lookup conversion rate
			decimal convertedAmount = 0m;
			if (conversionRates.ContainsKey(fromCurrency) && conversionRates[fromCurrency].ContainsKey(toCurrency))
			{
				convertedAmount = input * conversionRates[fromCurrency][toCurrency];
			}
			else
			{
				resultTextBox.Text = "Conversion rate not found.";
				return;
			}

			resultTextBox.Text = symbol + convertedAmount.ToString("N2") + " " + toCurrency;
			amountToConvertTextBox.Text = input.ToString();
			fromToConversionTextBox.Text = "1 " + fromCurrency + " = " + conversionRates[fromCurrency][toCurrency].ToString("N6") + " " + toCurrency;
			toFromConversionTextBox.Text = "1 " + toCurrency + " = " + conversionRates[toCurrency][fromCurrency].ToString("N6") + " " + fromCurrency;
		}
		private void ExitButton_Click_1(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
		private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void FromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void amountToConvertTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void resultTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
		private void fromToConversionTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void toFromConversionTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}


	}

}
