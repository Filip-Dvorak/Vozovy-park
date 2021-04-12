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
    public partial class overview : Form
    {
        public overview()
        {
            InitializeComponent();
            label2.Text = User.users[User.currentUser].posledniPrihlaseni.ToString();
            labelUsername.Text = User.currentUser;

            string s;
            foreach (KeyValuePair<int, Reservation> reservation in Reservation.reservations)
            {
                if (reservation.Value.idUser == User.currentUser)
                {
                    s = ( reservation.Value.idReservation.ToString() + "; " + Car.cars[reservation.Value.idAuto].znacka + "; " + reservation.Value.from.ToShortDateString() + " - " +  reservation.Value.to.ToShortDateString()
                        );
                    listBox1.Items.Add(s);
                }
            }
              
        }

        private void CreateRes_Click(object sender, EventArgs e)
        {
            create_res Create = new create_res();
            Create.ShowDialog();
        }

        private void CancelRes_Click(object sender, EventArgs e)
        {
            cancel_res Cancel = new cancel_res();
            Cancel.ShowDialog();
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            
            change_password changePassword = new change_password();
            changePassword.ShowDialog();
        }

        private void logOff_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void overview_Load(object sender, EventArgs e)
        {
           
        }

        private void overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            User._users[User.currentUser].posledniPrihlaseni = DateTime.Now;

            StreamWriter uzivatele = new StreamWriter("TabulkaUzivatelu.txt");

            foreach (KeyValuePair<string, User> u in User.users)
            {
                uzivatele.WriteLine(u.Key + ";" + u.Value.jmeno + ";" + u.Value.prijmeni + ";" + u.Value.heslo + ";" + u.Value.posledniPrihlaseni.ToString() + ";" + u.Value.isAdmin + ";" + u.Value.isActice + ";" + u.Value.needsToChangePassword + ";");
            }
            uzivatele.Close();

            StreamWriter auta = new StreamWriter("TabulkaAut.txt");

            foreach (KeyValuePair<int, Car> c in Car.cars)
            {
                auta.WriteLine(c.Key + ";" + c.Value.znacka + ";" + c.Value.model + ";" + c.Value.typ + ";" + c.Value.spotreba + ";" + c.Value.isActive + ";");
            }
            auta.Close();

            StreamWriter rezervace = new StreamWriter("TabulkaRezervaci.txt");

            foreach (KeyValuePair<int, Reservation> r in Reservation.reservations)
            {
                rezervace.WriteLine(r.Value.idReservation + ";" + r.Value.idAuto + ";" + r.Value.idUser + ";" + r.Value.from.Date + ";" + r.Value.to.Date + ";");
            }
            rezervace.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string s;
            foreach (KeyValuePair<int, Reservation> reservation in Reservation.reservations)
            {
                if (reservation.Value.idUser == User.currentUser)
                {
                    s = (reservation.Value.idReservation.ToString() + ", " + Car.cars[reservation.Value.idAuto].znacka + ", " + reservation.Value.from.ToShortDateString() + " - " + reservation.Value.to.ToShortDateString()
                        );
                    listBox1.Items.Add(s);
                }
            }
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
