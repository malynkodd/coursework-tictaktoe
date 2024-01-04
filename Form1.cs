using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alien_Invaders;
using System.Data.OleDb;

namespace TicTacToe
{
    
    public partial class Form1 : Form
    {
        // Variables
        private DBContext db;
        private Account CurrentAccount;
        private Game TicTac;
        private int i = 0;
        const int X_VALUE = 1;
        const int O_VALUE = 2;
        
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        public Form1(Account account)
        {
            db = new DBContext();
            CurrentAccount = account;
            InitializeComponent();
            TicTac = new Game();

        }

        // TIC TAC TOE BUTTONS -------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = GetRow(clickedButton);
            int col = GetColumn(clickedButton);

            if (TicTac.ValidMove(row,col) == 0) 
            {
                if (TicTac.player1_turn == true)
                {
                    TicTac.player1_turn = false;
                    clickedButton.Text = "X";
                    TicTac.boardValue[row, col] = X_VALUE;
                }
                else
                {
                    TicTac.player1_turn = true;
                    clickedButton.Text = "O";
                    TicTac.boardValue[row, col] = O_VALUE;
                }

                if (TicTac.check_win() == 1 && TicTac.player1_turn==false)
                {
                    MessageBox.Show("Player1 wins!");
                    CurrentAccount.WinGame(CurrentAccount);
                    var history = new GameResult(CurrentAccount.Rating, Result.Win);
                    CurrentAccount.History.Add(history);
                    label6.Text = CurrentAccount.Rating.ToString();
                    restart_matrix();
                }
                else if (TicTac.check_win() == 1 && TicTac.player1_turn == true)
                {
                    MessageBox.Show("Player2 wins!");
                    int player2_score = Convert.ToInt32(label7.Text);
                    ++player2_score;
                    label7.Text = player2_score.ToString();
                    CurrentAccount.LoseGame(CurrentAccount);
                    var history = new GameResult(CurrentAccount.Rating, Result.Lose);
                    CurrentAccount.History.Add(history);
                    restart_matrix();
                }
                else if(TicTac.check_win() == -1)
                {
                    MessageBox.Show("Draw!");
                   
                    var history = new GameResult(CurrentAccount.Rating, Result.Draw);
                    CurrentAccount.History.Add(history);
                    restart_matrix();
                }
            }
        }
        
        private int GetRow(Button button)
        {
            if (button == button1 || button == button2 || button == button3)
                return 0;
            else if (button == button6 || button == button5 || button == button4)
                return 1;
            else if (button == button9 || button == button8 || button == button7)
                return 2;
            else
                return -1; 
        }

        private int GetColumn(Button button)
        {
            if (button == button1 || button == button6 || button == button9)
                return 0;
            else if (button == button2 || button == button5 || button == button8)
                return 1;
            else if (button == button3 || button == button4 || button == button7)
                return 2;
            else
                return -1; 
        }
        
        // Restart tic tac toe board
        private void restart_matrix()
        {
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    TicTac.boardValue[i, j] = 0;

            clear_buttons();
            TicTac.player1_turn = true;
        }
     
        // Clear buttons
        private void clear_buttons()
        {
            i = 0;
            
            for (int i = 1; i <= 9; i++)
            {
                Button btn = Controls.Find($"button{i}", true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    btn.Text = "";
                    btn.BackColor = Color.Gray;
                    btn.ForeColor = Color.White;
                }
            }
        }
        
        // Reset game
        private void button10_Click(object sender, EventArgs e)
        {
            new Form1(CurrentAccount).Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
     
            new frmLogin(db).Show();
            this.Hide();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Statistic(CurrentAccount).Show();
            Hide();
        }
    }
}


