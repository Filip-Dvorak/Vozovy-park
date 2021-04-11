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
    public partial class naklady_na_udrzbu : Form
    {
        public naklady_na_udrzbu()
        {
            InitializeComponent();

            foreach(KeyValuePair<int,Car> c in Car.cars)
            {
                listBox1.Items.Add(c.Key + "; " + c.Value.znacka + "; " + c.Value.model + "; " + c.Value.typ + "; " + c.Value.spotreba + "l/100km;");
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if(textBoxNazev.Text==""|| textBoxCena.Text=="" || textBoxCisloFaktury.Text == "")
            {
                MessageBox.Show("Vyplňte všechny údaje");
                return;
            }
            NakladyNaUdrzbu nakladyNaUdrzbu = new NakladyNaUdrzbu();

            try
            {
                string s = listBox1.SelectedItem.ToString();
                string[] car = s.Split(';');
                int carId = int.Parse(car[0]);
                nakladyNaUdrzbu.idAuta = carId;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Vyberte vůz");
                return;
            }

            bool b = true;
            Random r = new Random();
            int id;
            do
            {
                 id = r.Next(1000, 10000);
                foreach(KeyValuePair<int,NakladyNaUdrzbu> x in NakladyNaUdrzbu.naklady)
                {
                    if(x.Key == id)
                    {
                        b = false;
                    }
                }
            } while (b == false);

            
            nakladyNaUdrzbu.idUkonu = id;
            
            nakladyNaUdrzbu.ukon = textBoxNazev.Text;
            nakladyNaUdrzbu.cas = dateTimePickerCas.Value;

            if(decimal.TryParse(textBoxCena.Text, out nakladyNaUdrzbu.cena) == false)
            {
                MessageBox.Show("Špatně zadaný údaj o ceně");
                return;
            }
            

            if(int.TryParse(textBoxCisloFaktury.Text, out nakladyNaUdrzbu.cisloFaktury) == false)
            {
                MessageBox.Show("Špatně zadaný údaj: Číslo faktury. (Očekává se až desetimístné číslo)");
                return;
            }
            
           

            NakladyNaUdrzbu._naklady.Add(nakladyNaUdrzbu.idUkonu, nakladyNaUdrzbu);

            listBox2.Items.Clear();
            string _s = listBox1.SelectedItem.ToString();
            string[] _car = _s.Split(';');
            int _carId = int.Parse(_car[0]);
            foreach (KeyValuePair<int, NakladyNaUdrzbu> n in NakladyNaUdrzbu.naklady)
            {
                if (n.Value.idAuta == _carId)
                {
                    listBox2.Items.Add(n.Key + "; " + n.Value.idAuta + "; " + Car.cars[n.Value.idAuta].znacka + "; " + Car.cars[n.Value.idAuta].model + "; " + n.Value.ukon + "; " + n.Value.cas.ToShortDateString() + "; " + n.Value.cena + "Kč; " + "č." + n.Value.cisloFaktury + ";");
                }

            }

            textBoxNazev.Invalidate();
            textBoxCena.Invalidate();
            textBoxCisloFaktury.Invalidate();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                string s = listBox1.SelectedItem.ToString();
                string[] car = s.Split(';');
                int carId = int.Parse(car[0]);

                foreach (KeyValuePair<int, NakladyNaUdrzbu> n in NakladyNaUdrzbu.naklady)
                {
                    if (n.Value.idAuta == carId)
                    {
                        listBox2.Items.Add(n.Key + "; " +  n.Value.idAuta + "; " + Car.cars[n.Value.idAuta].znacka + "; " + Car.cars[n.Value.idAuta].model + "; " + n.Value.ukon + "; " + n.Value.cas.ToShortDateString() + "; " + n.Value.cena + "Kč; "  + "č." + n.Value.cisloFaktury + ";");
                    }

                }

                if(listBox2.Items.Count == 0)
                {
                    listBox2.Items.Add("Žádné servisní úkony");
                }
            }
            catch(NullReferenceException)
            {

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Return_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ukon = listBox2.SelectedItem.ToString();
                string[] _ukon = ukon.Split(';');
                int id = int.Parse(_ukon[0]);

                NakladyNaUdrzbu._naklady.Remove(id);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Vyberte úkon k odebrání");
                return;
            }
            
        }
    }
}
