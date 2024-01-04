using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Alien_Invaders
{
public partial class frmRegister : Form
{
    private DBContext db;
 
    public frmRegister()
    {
        InitializeComponent();
        db = new DBContext();
    }
    private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
    {
        if (checkbxShowPas.Checked)
        {
            txtpassword.PasswordChar = '\0';
            txtComPassword.PasswordChar = '\0';
        }
        else
        {
            txtpassword.PasswordChar = '*';
            txtComPassword.PasswordChar = '*';
        }
    }

  
    
    private void button1_Click_1(object sender, EventArgs e)
    {
        if (txtUsername.Text == "" && txtpassword.Text == "" && txtComPassword.Text == "")
        {
            MessageBox.Show("Username and Password fields are empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        { 
            db.CreateNewAccount(txtUsername.Text, txtpassword.Text, txtComPassword.Text);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        txtUsername.Text = "";
        txtpassword.Text = "";
        txtComPassword.Text = "";
        txtUsername.Focus();
    }


    private void label6_Click(object sender, EventArgs e)
    {
        new frmLogin(db).Show();
        this.Hide();
    }
}
}