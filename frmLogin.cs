using System;
using System.Windows.Forms;
using System.Data.OleDb;
using TicTacToe;

namespace Alien_Invaders
{
    
    public partial class frmLogin : Form
    {
        private Account CurrentAccount;
        private DBContext db;
        public frmLogin(DBContext Base)
        {
            InitializeComponent();
            db = Base;
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();


        private void button1_Click(object sender, EventArgs e)
        {
            db.FindAccountByName(txtUsername.Text,txtpassword.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
            
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            Hide();
        }


        
    }
}