using System;
using System.Windows.Forms;
using TicTacToe;

namespace Alien_Invaders
{
    public partial class Statistic : Form
    {
        private Account CurrentAccount;
  

        public Statistic(Account account)
        {
            InitializeComponent();
            CurrentAccount = account;
            label4.Text = $"{CurrentAccount.ID}";
            
            
            label5.Text = $"{CurrentAccount.UserName}";

            
            label6.Text = $"{CurrentAccount.Rating}";
            
            UpdateListBox();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label2.Text = $" {CurrentAccount.ID}";
        }
        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = $"{CurrentAccount.UserName}";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = $"{CurrentAccount.Rating}";
        }
        private void UpdateListBox()
        {
            var gameHistoryList = CurrentAccount.History;

            History.Items.Clear();
            foreach (var gameHistory in gameHistoryList)
            {
                History.Items.Add($"Result: {gameHistory.Result}\t| Rating: {gameHistory.Rating}");
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gameHistoryList = CurrentAccount.History;

            History.Items.Clear();
            
           
            foreach (var gameHistory in gameHistoryList)
            {
               
                
                History.Items.Add($"Result: {gameHistory.Result}\t| Rating: {gameHistory.Rating}");
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1(CurrentAccount).Show();
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    } 
}

