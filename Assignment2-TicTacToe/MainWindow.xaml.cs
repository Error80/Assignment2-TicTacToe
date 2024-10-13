using System.Text;
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
        private string[,] boardGame = new string[3, 3];
        private string currentPlayer = "X";
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Will Execute regardless of which 9 buttons are pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Button clickedButton = sender as Button;
            string buttonName = clickedButton.Name; //slotRC

            
            int row = int.Parse(buttonName[4].ToString());
            int column = int.Parse(buttonName[5].ToString());

            if(!string.IsNullOrEmpty(boardGame[row,column]))
            {
                return;
            }

            clickedButton.Content = currentPlayer;
            boardGame[row, column] = currentPlayer;

            //if (checkWinner(boardGame))

            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            } else
            {
                currentPlayer = "X";
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardGame"></param>
        /// <returns></returns>
        private bool checkWinner(string[,] boardGame)
        {
            // Horizontal Compartion

            //*X*
            //*X*
            //*X*
            int size = 3;
            for (int index = 0; index < size; index++)
            {
                if (boardGame[index, 0] == boardGame[index, 1] && 
                    boardGame[index, 1] == boardGame[index, 2] &&
                    !string.IsNullOrEmpty(boardGame[index, 0]))
                {
                    return true;
                }
            }

            //***
            //XXX
            //***
            for (int index = 0; index < size; index++)
            {
                if (boardGame[0, index] == boardGame[1, index] &&
                    boardGame[1, index] == boardGame[2, index] &&
                    !string.IsNullOrEmpty(boardGame[0, index]))
                {
                    return true;
                }
            }

            //X**
            //*X*
            //**X
            if (boardGame[0, 0] == boardGame[1, 1] &&
                boardGame[1, 1] == boardGame[2, 2])
            {
                return true;
            }

            //**X
            //*X*
            //X**
            else if (boardGame[0, 2] == boardGame[1, 1] &&
                       boardGame[1, 1] == boardGame[2, 0])
            {
                return true;
            }

            return false;
        }
    }
}