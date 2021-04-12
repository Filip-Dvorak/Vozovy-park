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
    public partial class create_res : Form
    {
        public create_res()
        {
            InitializeComponent();
            dateTimePickerFrom.MinDate = DateTime.Now;
            dateTimePickerTo.MinDate = DateTime.Now;
            foreach (KeyValuePair<int, Car> c in Car.cars)
            {
                if (c.Value.isActive == true)
                {
                    listBox1.Items.Add(c.Key + "; " + c.Value.znacka + "; " + c.Value.model + "; " + c.Value.typ + "; " + c.Value.spotreba + "l/100km;");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void create_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();

            try
            {
                string auto = listBox1.SelectedItem.ToString();
                string[] _auto = auto.Split(';');
                int idAuta = int.Parse(_auto[0]);
                reservation.idAuto = idAuta;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Vyberte vůz");
                return;
            }

            bool y = true;
            Random r = new Random();
            int id;
            do
            {
                id = r.Next(1000, 10000);
                foreach (KeyValuePair<int, Car> c in Car.cars)
                {
                    if (c.Key == id)
                    {
                        y = false;
                    }
                }
            } while (y == false);

            
            reservation.idUser = User.currentUser;
            reservation.idReservation = id;

            if (DateTime.Compare(dateTimePickerTo.Value, dateTimePickerFrom.Value.Date) > 0 || DateTime.Compare(dateTimePickerTo.Value , dateTimePickerFrom.Value) == 0)
            {
                reservation.from = dateTimePickerFrom.Value;
                reservation.to = dateTimePickerTo.Value;
            }
            else
            {
                MessageBox.Show("Začátek rezervace musí být dříve než konec rezervace");
                return;
            }


            bool x = true;
            

                foreach (KeyValuePair<int, Reservation> stavajiciRezervace in Reservation.reservations)
                {
                    if (stavajiciRezervace.Value.idAuto == reservation.idAuto)
                    {
                        if (DateTime.Compare(reservation.from, stavajiciRezervace.Value.from) < 0 && DateTime.Compare(reservation.to, stavajiciRezervace.Value.from) < 0 || DateTime.Compare(reservation.from, stavajiciRezervace.Value.to) > 0)
                        {

                        }
                        else
                        {
                            x = false;
                        }
                    }
                }
                if (x == true)
                {
                    Reservation._reservations.Add(reservation.idReservation, reservation);
                    MessageBox.Show("Rezervace vytvořena");
                }
                else
                {
                    MessageBox.Show("Vůz je v daný termín již zabraný");
                    return;
                }
            

            
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
