using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Login2
{
    /// <summary>
    /// Interaction logic for DodavanjeClanova.xaml
    /// </summary>
    public partial class DodavanjeClanova : Window
    {
        public DodavanjeClanova()
        {
            InitializeComponent();
        }

        private void buttonZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void buttonDoClana_Click(object sender, RoutedEventArgs e)
        {
            int parse = 0;
            if (txtBrojC.Text == "" || txtIme.Text == "" || txtPrezime.Text == "" || txtAdresa.Text == "" || txtEmail.Text == "" || txtTel.Text == "")
            {
                MessageBox.Show("Sva polja moraju biti popunjena!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (!int.TryParse(txtTel.Text, out parse))
            {
                MessageBox.Show("Broj telefona može sadržavati samo brojeve ili je broj predugačak!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtTel.Text = "";
                return;
            }
            else 
            {
                string brojC = txtBrojC.Text;
                string ime = txtIme.Text;
                string prezime = txtPrezime.Text;
                string adresa = txtAdresa.Text;
                string email = txtEmail.Text;
                string telefon = txtTel.Text;

                string query = "INSERT INTO bi_clanovi(clan_broj, clan_ime, clan_prezime, clan_adresa, clan_email, clan_telefon)"
                    + " VALUES('" + brojC + "', '" + ime + "','" + prezime + "','" + adresa + "','" + email + "','" + telefon + "');";

                try
                {
                    MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                    kon.Open();
                    MySqlCommand cmd = new MySqlCommand(query, kon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uspješno ste dodali člana", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    kon.Close();
                    txtBrojC.Text = "";
                    txtIme.Text = "";
                    txtPrezime.Text = "";
                    txtAdresa.Text = "";
                    txtEmail.Text = "";
                    txtTel.Text = "";
                }
                catch (MySqlException exc) 
                {
                    MessageBox.Show("Unijeli ste već postojeći članski broj", "Postojeći članski broj", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtBrojC.Text = "";
                    txtIme.Text = "";
                    txtPrezime.Text = "";
                    txtAdresa.Text = "";
                    txtEmail.Text = "";
                    txtTel.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonPretragaC_Click(object sender, RoutedEventArgs e)
        {
            PretragaClanova pc = new PretragaClanova();
            pc.Show();
        }
    }
}
