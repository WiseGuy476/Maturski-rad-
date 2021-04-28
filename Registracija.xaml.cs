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
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }

        private void buttonZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void buttonRegistracija_Click(object sender, RoutedEventArgs e)
        {
            int parse=0;

            if (txtIme.Text == "" || txtPrezime.Text == "" || txtEmail.Text == "" || txtTel.Text == "" || passLozinka.Password.ToString() == "" || passPotvrda.Password.ToString() == "")
            {
                MessageBox.Show("Sva polja moraju biti popunjena!", "Neuspješna registracija", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (passLozinka.Password.ToString() != passPotvrda.Password.ToString())
            {
                MessageBox.Show("Lozinke se moraju poklapati!", "Neuspješna registracija", MessageBoxButton.OK, MessageBoxImage.Warning);
                passLozinka.Password = "";
                passPotvrda.Password = "";
            }
            else if (!int.TryParse(txtTel.Text, out parse))
            {
                MessageBox.Show("Broj telefona može sadržavati samo brojeve!", "Neuspješna registracija", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtTel.Text = "";
                return;            
            }
            else
            {
                string query = "INSERT INTO bi_korisnik(imeKor, prezimeKor, korisnickoIme, password, emailKor, telefonKor) "
                    + " VALUES('" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtKorIme.Text + "', '" + passLozinka.Password.ToString() + "', '" + txtEmail.Text + "', '" + txtTel.Text + "' );";
                try
                {
                    MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                    kon.Open();
                    MySqlCommand cmd = new MySqlCommand(query, kon);
                    cmd.ExecuteNonQuery();
                    kon.Close();
                    MessageBox.Show("Vaš korisnički račun je kreiran", "Uspješna registracija", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtIme.Text = "";
                    txtPrezime.Text = "";
                    txtEmail.Text = "";
                    txtTel.Text = "";
                    txtKorIme.Text = "";
                    passLozinka.Password = "";
                    passPotvrda.Password = "";
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void buttonLog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
