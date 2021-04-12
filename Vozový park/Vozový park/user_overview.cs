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
    public partial class user_overview : Form
    {
        public user_overview()
        {
            InitializeComponent();

            foreach(KeyValuePair<string ,User> u in User.users)
            {
                {
                    listBox1.Items.Add(u.Value.username + "; "  + u.Value.jmeno + "; " + u.Value.prijmeni);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                string s = listBox1.SelectedItem.ToString();
                string[] user = s.Split(';');
                string userId = user[0];

                if (User.users[userId].isActice == false)
                {
                    listBox2.Items.Add("Uživatel je deaktivován");
                }
                else
                {
                    foreach (KeyValuePair<int, Reservation> r in Reservation.reservations)
                    {
                        if (r.Value.idUser == userId)
                        {
                            listBox2.Items.Add(r.Value.idReservation.ToString() + "; " + Car.cars[r.Value.idAuto].znacka + "; " + r.Value.from.ToShortDateString()  + " - " + r.Value.to.ToShortDateString());

                        }

                    }
                }

                if (listBox2.Items.Count == 0)
                {
                    listBox2.Items.Add("Žádné rezervace");
                }
            }
            catch(NullReferenceException)
            { }

        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
