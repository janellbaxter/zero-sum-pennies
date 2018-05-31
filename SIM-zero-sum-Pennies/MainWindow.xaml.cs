using System;
using System.Collections.Generic;
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
/*
 * This game is based on an idea from
 * The Computational Beauty of Nature: Computer Explorations of Fractals, Chaos, Complex Systems, and Adaptation
 * By Gary William Flake
 * Code created for programmingisfun.com and licensed 
 * Creative Commons Attribution 4.0 International License
 */
namespace SIM_zero_sum_Pennies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int PlayerOnePennyAmount = 10;
        int PlayerTwoPennyAmount = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PennyGame_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateText("Use the spacebar to flip between heads and tails on your coin.");
            PennyTwoSide.Text = "";
            RandomSide("one");
        }
        private void PlayRound()
        {
            string message = "";

            //if either player has 0 or less pennies
            if ((PlayerOnePennyAmount <= 0) || (PlayerTwoPennyAmount <= 0))
            {
                //game is over
                message = "Game has ended!";
            }
            else
            {
                //choose side for Player Two
                RandomSide("two");

                string playerOne = PennyOneSide.Text;
                string playerTwo = PennyTwoSide.Text;

                //if both are heads OR both are tails
                //Player One gets both pennies
                //If they are not the same
                //Player Two gets both pennies
                if (PennyOneSide.Text == "T" && PennyTwoSide.Text == "T")
                {
                    PlayerOnePennyAmount++;
                    PlayerTwoPennyAmount--;
                    message = "Both coins had the same side showing. You gain a penny";
                }
                else if (PennyOneSide.Text == "H" && PennyTwoSide.Text == "H")
                {
                    PlayerOnePennyAmount++;
                    PlayerTwoPennyAmount--;
                    message = "Both coins had the same side showing. You gain a penny";
                }
                else
                {
                    PlayerTwoPennyAmount++;
                    PlayerOnePennyAmount--;
                    message = "Coins were not the same. You lose a penny";
                }
            }
            //update text on the screen
            UpdateText(message);
        }
        private void UpdateText(string message)
        {
            PlayerOneTotal.Text = "Pennies: " + PlayerOnePennyAmount;
            PlayerTwoTotal.Text = "Pennies: " + PlayerTwoPennyAmount;
            Instructions.Text = message;
            
        }
        private void RandomSide(string player)
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(2);
            string side;

            if (number == 1)
                side = "H";
            else
                side = "T";

            if (player == "one")
                PennyOneSide.Text = side;
            else
                PennyTwoSide.Text = side;
        }
        private void FlipCoin(string side, int player)
        {
            if (side == "H")
            {
                if (player == 1)
                {
                    PennyOneSide.Text = "T";
                }
                else { PennyTwoSide.Text = "T"; }
            }
            else {

                if (player == 1)
                {
                    PennyOneSide.Text = "H";
                }
                else { PennyTwoSide.Text = "H"; }

            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                FlipCoin(PennyOneSide.Text, 1);
            }
            
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            PlayRound();
        }
    }
}
