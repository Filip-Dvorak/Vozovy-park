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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            
        }

        public void login_Load(object sender, System.EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            foreach(var v in User.users)
            {
                if(textBoxUsername.Text == v.Key)
                {
                    b = true;
                }
            }

            if (b == true)
            {
                if (User.users[textBoxUsername.Text].heslo == textBoxHeslo.Text.GetHashCode().ToString()) 
                {
                    if (User.users[textBoxUsername.Text].isActice == true)
                    {


                        if (User.users[textBoxUsername.Text].isAdmin == true)
                        {
                            User._currentUser = textBoxUsername.Text;
                            admin_overview adminMenu = new admin_overview();
                            adminMenu.ShowDialog();
                        }
                        else
                        {
                            if (User.users[textBoxUsername.Text].needsToChangePassword == true)
                            {
                                User._currentUser = textBoxUsername.Text;
                                vynuceni_zmeny_hesla vynuceni = new vynuceni_zmeny_hesla();
                                vynuceni.ShowDialog();
                            }
                            else
                            {
                                User._currentUser = textBoxUsername.Text;
                                overview menu = new overview();
                                menu.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Účet je deaktivován");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Špatné přihlašovací jméno, nebo heslo");
                }
            }
            else
            {
                MessageBox.Show("Špatné přihlašovací jméno, nebo heslo");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load_1(object sender, EventArgs e)
        {
            try
            {
                StreamReader uzivatele = new StreamReader("TabulkaUzivatelu.txt");




                string[] entry;


                while (!uzivatele.EndOfStream)
                {
                    User u = new User();
                    entry = uzivatele.ReadLine().Split(';');
                    u.username = entry[0];
                    u.jmeno = entry[1];
                    u.prijmeni = entry[2];
                    u.heslo = entry[3];
                    u.posledniPrihlaseni = DateTime.Parse(entry[4]);
                    u.isAdmin = bool.Parse(entry[5]);
                    u.isActice = bool.Parse(entry[6]);
                    u.needsToChangePassword = bool.Parse(entry[7]);

                    User._users.Add(u.username, u);
                }
                uzivatele.Close();

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nenašel se soubor TabulkaUzivatelu.txt");
            }

            if(User.users.Count == 0)
            {
                admin_initialize inicializace = new admin_initialize();
                inicializace.ShowDialog();
                return;
            }

            try
            {
                StreamReader rezervace = new StreamReader("TabulkaRezervaci.txt");

                string[] entry2;
                while (!rezervace.EndOfStream)
                {
                    Reservation r = new Reservation();
                    entry2 = rezervace.ReadLine().Split(';');
                    r.idReservation = int.Parse(entry2[0]);
                    r.idAuto = int.Parse(entry2[1]);
                    r.idUser = entry2[2];
                    r.from = DateTime.Parse(entry2[3]);
                    r.to = DateTime.Parse(entry2[4]);

                    Reservation._reservations.Add(r.idReservation, r);

                }
                rezervace.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nenašel se soubor TabulkaRezervaci.txt");
            }


            try
            {
                StreamReader auta = new StreamReader("TabulkaAut.txt");

                string[] entry3;

                while (!auta.EndOfStream)
                {
                    Car c = new Car();
                    entry3 = auta.ReadLine().Split(';');
                    c.id = int.Parse(entry3[0]);
                    c.znacka = entry3[1];
                    c.model = entry3[2];
                    c.typ = entry3[3];
                    c.spotreba = double.Parse(entry3[4]);
                    c.isActive = bool.Parse(entry3[5]);

                    Car._cars.Add(c.id, c);
                }
                auta.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nenašel se soubor TabulkaAut.txt");
            }

            try
            {
                StreamReader naklady = new StreamReader("TabulkaNakladyNaUdrzbu.txt");

                string[] entry4;

                while (!naklady.EndOfStream)
                {
                    NakladyNaUdrzbu n = new NakladyNaUdrzbu();
                    entry4 = naklady.ReadLine().Split(';');
                    n.idUkonu = int.Parse(entry4[0]);
                    n.idAuta = int.Parse(entry4[1]);
                    n.ukon = entry4[2];
                    n.cas = DateTime.Parse(entry4[3]);
                    n.cena = decimal.Parse(entry4[4]);
                    n.cisloFaktury = int.Parse(entry4[5]);

                    NakladyNaUdrzbu._naklady.Add(n.idUkonu, n);
                }
                naklady.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nenašel se soubor TabulkaNakladyNaUdrzbu.txt");
            }

        }
    }
}
