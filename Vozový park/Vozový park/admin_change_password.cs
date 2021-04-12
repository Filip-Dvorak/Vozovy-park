using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vozový_park
{
    public partial class admin_change_password : Form
    {
        public admin_change_password()
        {
            InitializeComponent();
            foreach (KeyValuePair<string, User> u in User.users)
            {
                listBox1.Items.Add(u.Value.username + "; " + u.Value.jmeno + "; " + u.Value.prijmeni);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user = listBox1.SelectedItem.ToString();
                string[] _user = user.Split(';');
                string id = _user[0];
                if (textBoxPassword.Text == "")
                {
                    MessageBox.Show("Vyplňte všechny údaje");
                    return;
                }
                if (User._users[id].heslo != textBoxPassword.Text.GetHashCode().ToString())
                {
                    User._users[id].heslo = textBoxPassword.Text.GetHashCode().ToString();
                    MessageBox.Show("Heslo bylo změněno");
                }
                else
                {
                    MessageBox.Show("Nové heslo musí být jiné než stávající");
                    return;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Vyberte uživatele");
                return;
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forceChange_Click(object sender, EventArgs e)
        {
            try
            {
                string user = listBox1.SelectedItem.ToString();
                string[] _user = user.Split(';');
                string id = _user[0];
                User._users[id].needsToChangePassword = true;
                MessageBox.Show("Vynucení proběhlo");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Vyberte uživatele");
                return;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
