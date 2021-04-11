using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vozový_park
{
    public partial class add_user : Form
    {
        public add_user()
        {
            InitializeComponent();
            
            foreach(KeyValuePair<string, User> u in User.users)
            {
                if (u.Value.username != User.currentUser)
                {
                    listBox1.Items.Add(u.Value.username + "; " + u.Value.jmeno + "; " +  u.Value.prijmeni + "; admin:" + u.Value.isAdmin + ";");
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text == "" || textBoxJmeno.Text == "" || textBoxPrijmeni.Text == "" || textBoxHeslo.Text =="")
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
            user.isAdmin = checkBox1.Checked;
            user.isActice = true;
            user.needsToChangePassword = false;

            foreach (var entry in User.users)
            {
                if (textBoxUsername.Text == entry.Key)
                {
                    MessageBox.Show("Uživatelské jméno je již zabrané");
                    return;
                }
               
            }
            
                User._users.Add(textBoxUsername.Text, user);

            listBox1.Items.Add(user.username + "; " + user.jmeno + "; " + user.prijmeni + "; ");

            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string user = listBox1.SelectedItem.ToString();
                string[] id = user.Split(';');


                foreach (KeyValuePair<int, Reservation> r in Reservation.reservations.ToList())
                {
                    if (r.Value.idUser == User.users[id[0]].username)
                    {
                        Reservation._reservations.Remove(r.Key);
                    }
                }



                User._users.Remove(id[0]);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch(NullReferenceException)
            { }

        }

        private void deaktivovat_Click(object sender, EventArgs e)
        {
            try
            {
                string user = listBox1.SelectedItem.ToString();
                string[] id = user.Split(';');


                foreach (KeyValuePair<int, Reservation> r in Reservation.reservations.ToList())
                {
                    if (r.Value.idUser == User.users[id[0]].username)
                    {
                        if (DateTime.Compare(r.Value.from, DateTime.Now) > 0)
                        {
                            Reservation._reservations.Remove(r.Key);
                        }
                    }
                }



                User._users[id[0]].isActice = false;
                MessageBox.Show("Uživatel byl deaktivován");
            }
            catch(NullReferenceException)
            {

            }
        }

        private void reaktivovat_Click(object sender, EventArgs e)
        {
            try
            {
                string user = listBox1.SelectedItem.ToString();
                string[] id = user.Split(';');

                User._users[id[0]].isActice = true;
                MessageBox.Show("Uživatel byl aktivován");
            }
            catch(NullReferenceException)
            {

            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
