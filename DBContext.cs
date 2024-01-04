using System.Data.OleDb;
using System.Windows.Forms;
using TicTacToe;

namespace Alien_Invaders
{ 
    public class DBContext
    {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            
        public void CreateNewAccount(string username, string password, string comPassword){
        
            
            
            con.Open();
            string checkUsernameQuery = "SELECT COUNT(*) FROM tbl_users WHERE username = '" + username + "'";
            cmd = new OleDbCommand(checkUsernameQuery, con);
            int usernameCount = (int)cmd.ExecuteScalar();

            if(password != comPassword)
            {
                MessageBox.Show("Passwords do not match! Try again", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return;
            }
            
            if (Check(usernameCount))
            {
                
                con.Close();
                MessageBox.Show("This Username Already Exists", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password == comPassword)
            {
                string register = "INSERT INTO tbl_users VALUES ('" + username + "','" + password + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Account has been Successfully Created", "Good Luck and Have Fun!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Check(int usernameCount)
        {
            return usernameCount > 0;
        }

        public void FindAccountByName(string username,string password)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + username + "' and password= '" + password + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new Form1(new Account(username,password)).Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
                {
                    return; 
                }
            }
            con.Close();
        }
        
        
    }
}