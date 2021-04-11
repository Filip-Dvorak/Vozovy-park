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
    public partial class admin_cancel_res : Form
    {
        public admin_cancel_res()
        {
            InitializeComponent();

            try
            {
                foreach (KeyValuePair<int, Reservation> r in Reservation.reservations)
                {
                    if (DateTime.Compare(r.Value.to, DateTime.Now) > 0 || DateTime.Compare(r.Value.to, DateTime.Now) == 0)
                    {
                        listBox1.Items.Add(r.Value.idReservation + ", " + Car.cars[r.Value.idAuto].znacka + ", " + User.users[r.Value.idUser].jmeno + ", " + User.users[r.Value.idUser].prijmeni + ", " + r.Value.from.ToShortDateString() + " - " + r.Value.to.ToShortDateString());
                    }
                }
            }
            catch(KeyNotFoundException)
            {

            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = listBox1.SelectedItem.ToString();
                string[] rezervace = s.Split(',');
                int idRezervace = int.Parse(rezervace[0]);

                Reservation._reservations.Remove(idRezervace);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Vyberte rezervaci ke zrušení");
                return;
            }
        }

        private void Return_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
