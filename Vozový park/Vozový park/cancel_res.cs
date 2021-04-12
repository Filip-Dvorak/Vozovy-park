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
    public partial class cancel_res : Form
    {
        public cancel_res()
        {
            InitializeComponent();
            foreach (KeyValuePair<int, Reservation> reservation in Reservation.reservations)
            {
                if (reservation.Value.idUser == User.currentUser)
                {
                    if (DateTime.Compare(reservation.Value.to, DateTime.Now) > 0 || DateTime.Compare(reservation.Value.to, DateTime.Now) == 0)
                    {
                        listBox1.Items.Add(reservation.Value.idReservation.ToString() + ", " + Car.cars[reservation.Value.idAuto].znacka + ", " + reservation.Value.from.ToShortDateString() + " - " + reservation.Value.to.ToShortDateString()
                        );
                    }
                    
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            try
            {
                string s = listBox1.SelectedItem.ToString();
                string[] rezervace = s.Split(',');
                int idRezervace = int.Parse(rezervace[0]);

                Reservation._reservations.Remove(idRezervace);
                listBox1.Items.Remove(listBox1.SelectedItem);
                MessageBox.Show("Rezervace byla zrušena");
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Vyberte rezervaci ke zrušení");
            }
            
        }

        private void return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
