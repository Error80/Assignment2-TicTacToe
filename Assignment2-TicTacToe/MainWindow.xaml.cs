using System;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2_TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Players
        public const string player1 = "X";
        public const string player2 = "O";

        // Scores
        public int player1Score = 0;
        public int player2Score = 0;
        public int tieScore = 0;

        // 3x3 array for the tic tac toe board
        private string[,] boardGame = new string[3, 3];

        // Current player's turn
        private string currentPlayer = Random();

        /// <summary>
        /// Decides who starts first
        /// </summary>
        /// <returns></returns>
        private static string Random()
        {

            // Selects a random number between 0 and 1
            Random random = new Random();

            switch (random.Next(0,2))
            {

                // if 0 is choosen return X
                case 0: return player1;

                // if 0 is choosen return O
                case 1: return player2;
            }

            //
            return "";
        }

        /// <summary>
        /// Switches between X and O
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private static string Turn(string player)
        {
            if (player == player1)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }

        /// <summary>
        /// Declares the winner
        /// </summary>
        /// <param name="player"></param>
        private void DeclareWinner(string player)
        {

            // Gets the names the players have entered in the 2 text boxes
            string player1Name = xPlayerNameTextBox.Text;
            string player2Name = oPlayerNameTextBox.Text;


            // Decides which player gets a point
            if (player == player1) // X wins
            {

                // Checks if the player name textbox is empty or equals X
                if (string.IsNullOrEmpty(player1Name) || player1Name == player1)
                {

                    // Informs that the player has won
                    MessageBox.Show(player1 + " has won the game!", "Winner");

                } 
                else
                {

                    // Informs that the player has won
                    MessageBox.Show(player1Name + " (" +player1 + ") has won the game!", "Winner");

                }

                // Increments X Score by 1
                player1Score++;

                // Sends the score to Scores
                xScoreTextBox.Text = player1Score.ToString();

            } else if (player == player2)  // O wins
            {

                // Checks if the player name textbox is empty or equals O
                if (string.IsNullOrEmpty(player2Name) || player2Name == player2)
                {

                    // Informs that the player has won
                    MessageBox.Show(player2 + " has won the game!", "Winner");

                }
                else  // Tie
                {

                    // Informs that the player has won
                    MessageBox.Show(player2Name + " (" + player2 + ") has won the game!", "Winner");

                }

                // Increments O Score by 1
                player2Score++;

                // Sends the score to Scores
                oScoreTextBox.Text = player2Score.ToString();

            } else
            {

                // Informs the game ends with a tie
                MessageBox.Show("The game ended with a tie", "Tie");

                // Increments Tie Score by 1
                tieScore++;

                // Sends the score to Scores
                tieScoreTextBox.Text = tieScore.ToString();
            }

        }

        private void Clear()
        {

            // Clears all the buttons
            slot00.Content = "";
            slot01.Content = "";
            slot02.Content = "";
            slot10.Content = "";
            slot11.Content = "";
            slot12.Content = "";
            slot20.Content = "";
            slot21.Content = "";
            slot22.Content = "";

            // Clears the Board Game Array
            Array.Clear(boardGame, 0, boardGame.Length);
        }

        /// <summary>
        /// Checks if someone has won
        /// </summary>
        /// <param name="boardGame"></param>
        /// <returns>
        /// 0 = Continue
        /// 1 = Won
        /// 2 = Tie
        /// </returns>
        private static int CheckWinner(string[,] boardGame)
        {
            int size = 3;

            //Horizontal
            //*X*
            //*X*
            //*X*
            for (int index = 0; index < size; index++)
            {
                if (boardGame[index, 0] == boardGame[index, 1] &&
                    boardGame[index, 1] == boardGame[index, 2] &&
                    !string.IsNullOrEmpty(boardGame[index, 0]))
                {
                    return 1;
                }
            }

            //Vertical
            //***
            //XXX
            //***
            for (int index = 0; index < size; index++)
            {
                if (boardGame[0, index] == boardGame[1, index] &&
                    boardGame[1, index] == boardGame[2, index] &&
                    !string.IsNullOrEmpty(boardGame[0, index]))
                {
                    return 1;
                }
            }

            //Diagonal
            //X**
            //*X*
            //**X
            if (boardGame[0, 0] == boardGame[1, 1] &&
                boardGame[1, 1] == boardGame[2, 2] &&
                !string.IsNullOrEmpty(boardGame[0, 0]))
            {
                return 1;
            }

            //Diagonal
            //**X
            //*X*
            //X**
            if (boardGame[0, 2] == boardGame[1, 1] &&
                boardGame[1, 1] == boardGame[2, 0] &&
                !string.IsNullOrEmpty(boardGame[0, 2]))
            {
                return 1;
            }

            // Checks if all spaces are filled with no winner
            if (!string.IsNullOrEmpty(boardGame[0, 0]) &&
                !string.IsNullOrEmpty(boardGame[0, 1]) &&
                !string.IsNullOrEmpty(boardGame[0, 2]) &&
                !string.IsNullOrEmpty(boardGame[1, 0]) &&
                !string.IsNullOrEmpty(boardGame[1, 1]) &&
                !string.IsNullOrEmpty(boardGame[1, 2]) &&
                !string.IsNullOrEmpty(boardGame[2, 0]) &&
                !string.IsNullOrEmpty(boardGame[2, 1]) &&
                !string.IsNullOrEmpty(boardGame[2, 2]))
            {
                return 2;
            }



            return 0;
        }

        public MainWindow()
        {
            InitializeComponent();

            // Set the current player's turn
            currentPlayerTextBox.Text = currentPlayer;


            xPlayerNameLabel.Content = "Player " + player1 + " Name:";
            oPlayerNameLabel.Content = "Player " + player2 + " Name:";
        }

        /// <summary>
        /// Will Execute regardless of which 9 buttons are pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Determines which button got clicked
            Button clickedButton = sender as Button;

            // Gets the name of the button
            string buttonName = clickedButton.Name; //slotRC

            // Gets the last 2 characters from the button name
            int row = int.Parse(buttonName[4].ToString());
            int column = int.Parse(buttonName[5].ToString());

            // Checks if the button is not empty
            if(!string.IsNullOrEmpty(boardGame[row,column]))
            {
                return;
            }

            // Sets the text of the button that was clicked either X or O
            clickedButton.Content = currentPlayer;

            // Sends the data to the boardGame 2D array
            boardGame[row, column] = currentPlayer;

            // Checks if someone has won
            if (CheckWinner(boardGame) == 1) // Someone Wins
            {

                // Sends either X or O to DeclareWinner()
                DeclareWinner(currentPlayer);

                // Clear all 9 buttons
                Clear();

            } else if (CheckWinner(boardGame) == 2) // No one Wins
            {

                // Sends either X or O to DeclareWinner()
                DeclareWinner("Tie");

                // Clear all 9 buttons
                Clear();
            }

            // Changes the current player
            currentPlayer = Turn(currentPlayer);
            currentPlayerTextBox.Text = currentPlayer;

        }
    }
}