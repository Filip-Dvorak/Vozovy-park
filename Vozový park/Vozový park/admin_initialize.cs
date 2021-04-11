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
    public partial class admin_initialize : Form
    {
        public admin_initialize()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxJmeno.Text == "" || textBoxPrijmeni.Text == "" || textBoxHeslo.Text == "")
            {
                MessageBox.Show("Vypňte všechny údaje");
                return;
            }
            User user = new User();
            user.username = textBoxUsername.Text;
            user.jmeno = textBoxJmeno.Text;
            user.prijmeni = textBoxPrijmeni.Text;
            user.heslo = textBoxHeslo.Text.GetHashCode().ToString();
            user.posledniPrihlaseni = DateTime.Now;
            user.isAdmin = true;
            user.isActice = true;
            user.needsToChangePassword = false;

            User._users.Add(textBoxUsername.Text, user);

            MessageBox.Show("Administrátorský účet byl vytvořen, můžete se přihlásit");

            this.Close();
        }
    }
}
