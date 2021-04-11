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
    public partial class add_car : Form
    {
        public add_car()
        {
            InitializeComponent();

            foreach(KeyValuePair<int,Car> c in Car.cars)
            {
                listBox1.Items.Add(c.Key + "; " + c.Value.znacka + "; " + c.Value.model + "; " + c.Value.typ + "; " + c.Value.spotreba + "l/100km" + ";");
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if(textBoxID.Text =="" || textBoxZnacka.Text == "" || textBoxModel.Text == "" || textBoxSpotreba.Text=="")
            {
                MessageBox.Show("Vyplňte všechny údaje");
                return;
            }
            Car car = new Car();
            if(int.TryParse(textBoxID.Text, out car.id) == false)
            {
                MessageBox.Show("Špatná hodnota id (očekává se číslo)");
            }
            
            car.znacka = textBoxZnacka.Text;
            car.model = textBoxModel.Text;
            try
            {
                car.typ = comboBox1.SelectedItem.ToString();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Vybrte typ vozu");
                return;
            }
            car.isActive = true;

            if(double.TryParse(textBoxSpotreba.Text, out car.spotreba)){
                car.spotreba = double.Parse(textBoxSpotreba.Text);
            }
            else
            {
                MessageBox.Show("Špatná hodnota spotřeby");
                return;
            }

            foreach (var entry in Car.cars)
            {
                if (int.Parse(textBoxID.Text) == entry.Key)
                {
                    MessageBox.Show("Id je již zabrané");
                    return;
                }

            }

            Car._cars.Add(int.Parse(textBoxID.Text), car);
            listBox1.Items.Add(car.id + "; " + car.znacka + "; " + car.model + "; " + car.typ + "; " + car.spotreba + "l/100km" + ";");
        }

        private void odstavit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] car = listBox1.SelectedItem.ToString().Split(';');
                int id = int.Parse(car[0]);


                foreach (KeyValuePair<int, Reservation> r in Reservation.reservations.ToList())
                {
                    if (r.Value.idAuto == Car.cars[id].id)
                    {
                        if (DateTime.Compare(r.Value.from, DateTime.Now) > 0)
                        {
                            Reservation._reservations.Remove(r.Key);
                        }
                    }
                }



                Car._cars[id].isActive = false;
                MessageBox.Show("Vůz byl odstaven");
            }
            catch(NullReferenceException)
            { }
        }

        private void aktivovat_Click(object sender, EventArgs e)
        {
            try
            {
                string[] car = listBox1.SelectedItem.ToString().Split(';');
                int id = int.Parse(car[0]);

                Car._cars[id].isActive = true;
                MessageBox.Show("Vůz byl přidán do provozu");
            }
            catch(NullReferenceException)
            { }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] car = listBox1.SelectedItem.ToString().Split(';');
                int id = int.Parse(car[0]);


                foreach (KeyValuePair<int, Reservation> r in Reservation.reservations.ToList())
                {
                    if (r.Value.idAuto == Car.cars[id].id)
                    {
                        Reservation._reservations.Remove(r.Key);
                    }
                }

                foreach (KeyValuePair<int, NakladyNaUdrzbu> n in NakladyNaUdrzbu.naklady.ToList())
                {
                    if (n.Value.idAuta == Car.cars[id].id)
                    {
                        NakladyNaUdrzbu._naklady.Remove(n.Key);
                    }

                }



                Car._cars.Remove(id);
                listBox1.Items.Remove(listBox1.SelectedItem);
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
