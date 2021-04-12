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
    public partial class admin_overview : Form
    {
        public admin_overview()
        {
            InitializeComponent();
            label1.Text = User.users[User.currentUser].posledniPrihlaseni.ToString();
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            add_user AddUser = new add_user();
            AddUser.ShowDialog();
        }

        private void userOverview_Click(object sender, EventArgs e)
        {
            user_overview UserOverview = new user_overview();
            UserOverview.ShowDialog();
        }

        private void addCar_Click(object sender, EventArgs e)
        {
            add_car AddCar = new add_car();
            AddCar.ShowDialog();
        }

        private void carOverview_Click(object sender, EventArgs e)
        {
            car_overview CarOverview = new car_overview();
            CarOverview.ShowDialog();
        }

        private void adminCreate_Click(object sender, EventArgs e)
        {
            admin_create_res CreateRes = new admin_create_res();
            CreateRes.ShowDialog();
        }

        private void adminCancel_Click(object sender, EventArgs e)
        {
            admin_cancel_res CancelRes = new admin_cancel_res();
            CancelRes.ShowDialog();
        }

        private void nakladyNaUdrzbu_Click(object sender, EventArgs e)
        {
            naklady_na_udrzbu NakladyNaUdrzbu = new naklady_na_udrzbu();
            NakladyNaUdrzbu.ShowDialog();
        }

        private void admin_overview_Load(object sender, EventArgs e)
        {

        }

        private void admin_overview_FormClosing(object sender, FormClosingEventArgs e)
        {
            User._users[User.currentUser].posledniPrihlaseni = DateTime.Now;

            StreamWriter uzivatele = new StreamWriter("TabulkaUzivatelu.txt");

            foreach(KeyValuePair<string,User> u in User.users)
            {
                uzivatele.WriteLine(u.Key + ";" + u.Value.jmeno + ";" + u.Value.prijmeni + ";" + u.Value.heslo + ";" + u.Value.posledniPrihlaseni.ToString() + ";" + u.Value.isAdmin + ";" + u.Value.isActice + ";" + u.Value.needsToChangePassword + ";");
            }
            uzivatele.Close();

            StreamWriter auta = new StreamWriter("TabulkaAut.txt");

            foreach(KeyValuePair<int,Car> c in Car.cars)
            {
                auta.WriteLine(c.Key + ";" + c.Value.znacka + ";" + c.Value.model + ";" + c.Value.typ + ";" + c.Value.spotreba + ";"  + c.Value.isActive + ";");
            }
            auta.Close();

            StreamWriter naklady = new StreamWriter("TabulkaNakladyNaUdrzbu.txt");

            foreach(KeyValuePair<int,NakladyNaUdrzbu> n in NakladyNaUdrzbu.naklady)
            {
                naklady.WriteLine(n.Value.idUkonu + ";" + n.Value.idAuta + ";" + n.Value.ukon + ";" + n.Value.cas.Date + ";" + n.Value.cena + ";" + n.Value.cisloFaktury + ";" );
            }
            naklady.Close();

            StreamWriter rezervace = new StreamWriter("TabulkaRezervaci.txt");

            foreach(KeyValuePair<int,Reservation> r in Reservation.reservations)
            {
                rezervace.WriteLine(r.Value.idReservation + ";" + r.Value.idAuto + ";" + r.Value.idUser + ";" + r.Value.from.Date + ";" + r.Value.to.Date + ";");
            }
            rezervace.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            admin_change_password ChangePassword = new admin_change_password();
            ChangePassword.ShowDialog();
        }

        private void return_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
