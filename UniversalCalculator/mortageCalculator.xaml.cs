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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class mortageCalculator : Page
	{
		public mortageCalculator()
		{
			this.InitializeComponent();
		}

		private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				double P = double.Parse(principalBorrowTextBox.Text);
				int years = int.Parse(yearsTextBox.Text);
				int months = int.Parse(monthsTextBox.Text);
				double annualRate = double.Parse(annualInterestRateTextBox.Text) / 100;

				int n = (years * 12) + months; //total months
				double i = annualRate / 12; //monthly interest
				monthlyInterestRateTextBox.Text = i.ToString();
											// Formula: M = P * [ i(1+i)^n ] / [ (1+i)^n - 1 ]
				double numerator = i * Math.Pow(1 + i, n);
				double denomitator = Math.Pow(1 + i, n) - 1;
				double M = P * (numerator / denomitator);

				//show results
				monthlyRepaymentTextBox.Text = M.ToString("C");

			}
			catch (Exception ex)
			{
				var dialog = new MessageDialog("Invalid input: " + ex.Message);
				await dialog.ShowAsync();
			}
		}
	}
}
