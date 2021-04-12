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
    public partial class change_password : Form
    {
        public change_password()
        {
            InitializeComponent();
        }
        
        private void change_Click(object sender, EventArgs e)
        {
            if (textBoxNoveHeslo.Text == "")
            {
                MessageBox.Show("Vyplňte všechny údaje");
                return;
            }
            else
            {
                if (textBoxstavajiciHeslo.Text.GetHashCode().ToString() == User.users[User.currentUser].heslo)
                {
                    if (textBoxNoveHeslo.Text.GetHashCode().ToString() != User.users[User.currentUser].heslo)
                    {
                        User._users[User.currentUser].heslo = textBoxNoveHeslo.Text.GetHashCode().ToString();
                        MessageBox.Show("Heslo bylo změněno");
                    }
                    else
                    {
                        MessageBox.Show("Nové heslo musí být jiné než stávající");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Stávající hesla se neshodují");
                    return;
                }
            }
            
        }

        private void Return_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
