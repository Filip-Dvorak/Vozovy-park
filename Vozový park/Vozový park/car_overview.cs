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
    public partial class car_overview : Form
    {
        public car_overview()
        {
            InitializeComponent();

            foreach(KeyValuePair<int,Car> c in Car.cars)
            {
                listBox1.Items.Add(c.Key + "; " + c.Value.znacka + "; " + c.Value.model + "; " + c.Value.typ + "; " + c.Value.spotreba + "l/100km;");
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    listBox2.Items.Clear();
                    string s = listBox1.SelectedItem.ToString();
                    string[] car = s.Split(';');
                    int carId = int.Parse(car[0]);

                    if (Car.cars[carId].isActive == false)
                    {
                        listBox2.Items.Add("Vůz je odstaven z provozu");
                    }
                    else
                    {
                        foreach (KeyValuePair<int, Reservation> r in Reservation.reservations)
                        {
                            if (r.Value.idAuto == carId)
                            {
                                listBox2.Items.Add(r.Value.idReservation + "; " + r.Value.idUser + "; " + User.users[r.Value.idUser].jmeno + "; " + User.users[r.Value.idUser].prijmeni + "; " + Car.cars[r.Value.idAuto].znacka + "; " + r.Value.from.ToShortDateString() + " - " + r.Value.to.ToShortDateString());

                            }

                        }
                    }
                    if (listBox2.Items.Count == 0)
                    {
                        listBox2.Items.Add("Žádné rezervace");
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
            catch (KeyNotFoundException)
            {

            }
        }

        private void Return_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
