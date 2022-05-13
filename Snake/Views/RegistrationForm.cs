using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var loginName = textBoxUserName.Text;
            var loginPassword = textBoxPassword.Text;

            var connection = new SqlConnection();
            connection.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SnakeGameDb; Integrated Security = True";

            if (!ValidateEntry(loginName, loginPassword))
            {
                MessageBox.Show("Loginname or Password are too long");
            }
            else
            {
                var validatePw = EncryptPassword(loginPassword);

                using var db = new SnakeGameContext();
                var user = db.GameDb
                    .Where(x => x.LoginName == loginName && x.Password == validatePw)
                    .FirstOrDefault();

                if (user is null)
                {
                    MessageBox.Show("Loginname or Password is wrong.");
                    return;
                }

                Close();
            }
        }

        private bool ValidateEntry(string loginName, string loginPassword)
        {
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginPassword))
            {
                return false;
            }

            if (loginName.Length > 20 || loginPassword.Length > 10)
            {
                return false;
            }
            return true;
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var loginName = textBoxUserName.Text;
            var loginPassword = textBoxPassword.Text;

            if (!ValidateEntry(loginName, loginPassword))
            {
                MessageBox.Show("Loginname or Password are too long");
            }
            else
            {
                using var db = new SnakeGameContext();
                var user = db.GameDb
                    .Where(x => x.LoginName == loginName)
                    .FirstOrDefault();

                if (user is null)
                {
                    var encrypedPw = EncryptPassword(loginPassword);

                    db.Add(new SnakeGameDb
                    {
                        LoginName = loginName,
                        Password = encrypedPw,
                        RegisterDate = DateTime.Now
                    });
                    db.SaveChanges();

                    FormSnakeGame main = new();
                    main.ShowDialog();
                }
            }
        }

        private static string EncryptPassword(string loginPassword)
        {
            using var sha = SHA256.Create();

            loginPassword = AddSalt(loginPassword);
            return Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(loginPassword)));
        }

        private static string AddSalt(string text)
        {
            return $"{text}supersalty";
        }
    }
}