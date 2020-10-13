using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BowlingCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initilization
        private static readonly Regex _regex = new Regex("[^0-9]+");

        int total;
        double average;


        public MainWindow()
        {
            InitializeComponent();
        }

        // Calculate button function
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Calculate total
            total = FindSeries(Convert.ToInt32(game1.Text), Convert.ToInt32(game2.Text), Convert.ToInt32(game3.Text));
            // Calculate average
            average = FindAverage(total);

            // Output total
            totalOutput.Text = Convert.ToString(total);
            // Output average
            averageOutput.Text = Convert.ToString(average);
            // Output handicap
            DisplayHandicap(average);
            highGameOutput.Text = FindHighGame(Convert.ToInt32(game1.Text), Convert.ToInt32(game2.Text), Convert.ToInt32(game3.Text));
        }

        // Return sum of 3 games
        private int FindSeries(int game1, int game2, int game3)
        {
            return game1 + game2 + game3;
        }

        // Return average of 3 games
        private double FindAverage(int total)
        {
            return total / 3;
        }

        // Calculate and display handicap
        private void DisplayHandicap(double average)
        {
            double handicap = (200 - average) * .8;
            handicapOutput.Text = Convert.ToString(handicap);
        } 

        // Calculate and return high game
        private string FindHighGame(int game1, int game2, int game3)
        {
            if (game1 > game2 && game1 > game3)
            {
                return "1";
            }
            else if (game2 > game1 && game2 > game3)
            {
                return "2";
            }
            else if (game3 > game1 && game3 > game2)
            {
                return "3";
            }
            else
            {
                return "Tie";
            }
        }

        // Clear/reset all text fields
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            game1.Text = "0";
            game2.Text = "0";
            game3.Text = "0";
            totalOutput.Text = "";
            averageOutput.Text = "";
            handicapOutput.Text = "";
            highGameOutput.Text = "";
        }

        // Exits the application and closes all threads
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Checks text to make sure only valid inputs are made
        private void NumberedOnlyInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        // Tests if text has anything other than the Regex values inside
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
