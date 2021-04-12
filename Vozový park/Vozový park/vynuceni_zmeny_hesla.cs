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
    public partial class vynuceni_zmeny_hesla : Form
    {
        public vynuceni_zmeny_hesla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                        User._users[User.currentUser].needsToChangePassword = false;
                        MessageBox.Show("Heslo bylo změněno");
                        overview overview = new overview();
                        overview.ShowDialog();
                        this.Hide();
                        this.Close();
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
    }
}
