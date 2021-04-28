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
    /// Interaction logic for DodavanjeKnjiga.xaml
    /// </summary>
    public partial class DodavanjeKnjiga : Window
    {
        public DodavanjeKnjiga()
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
        }

        private void buttonPretraga_Click(object sender, RoutedEventArgs e)
        {
            PretragaKnjiga pk = new PretragaKnjiga();
            pk.Show();
        }

        private void buttonDoKnjige_Click(object sender, RoutedEventArgs e)
        {
            int parse1 = 0;
            int parse2 = 0;

            if (txtNaslov.Text == "" || txtAutor.Text == "" || txtBrStranica.Text == "" || txtIzdavac.Text == "" || txtCijena.Text == "" || txtKolicina.Text == "")
            {
                MessageBox.Show("Sva polja moraju biti popunjena!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (!int.TryParse(txtBrStranica.Text, out parse1))
            {
                MessageBox.Show("Broj stranica može sadržavati samo brojeve ili je broj predugačak!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBrStranica.Text = "";
                return;
            }
            else if (!int.TryParse(txtKolicina.Text, out parse2))
            {
                MessageBox.Show("Količina može sadržavati samo brojeve ili je broj predugačak!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtKolicina.Text = "";
                return;
            }
            else 
            {
                string naslov = txtNaslov.Text;
                string autor = txtAutor.Text;
                int brojStr = System.Convert.ToInt32( txtBrStranica.Text);
                string izdavac = txtIzdavac.Text;
                decimal cijena = System.Convert.ToDecimal(txtCijena.Text.Replace(".", ","));
                int kolicina = System.Convert.ToInt32(txtKolicina.Text);

                string query = "INSERT INTO bi_knjige(knjiga_naslov, knjiga_autor, knjiga_broj_stranica, knjiga_izdavac, cijena, kolicina_knjiga)"
                    +" VALUES('" + naslov + "', '" + autor + "','" + brojStr + "','" + izdavac + "','" + cijena.ToString().Replace(",", ".") + "','" + kolicina + "');";

                try
                {
                    MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                    kon.Open();
                    MySqlCommand cmd = new MySqlCommand(query, kon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uspješno ste dodali knjigu", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                    kon.Close();
                    txtNaslov.Text = "";
                    txtAutor.Text = "";
                    txtBrStranica.Text = "";
                    txtIzdavac.Text = "";
                    txtCijena.Text = "";
                    txtKolicina.Text = "";
                }
                catch (MySqlException exc)
                {
                    MessageBox.Show("Unijeli ste već postojeći naziv knjige!", "Postojeći naziv knjige", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtNaslov.Text = "";
                    txtAutor.Text = "";
                    txtBrStranica.Text = "";
                    txtIzdavac.Text = "";
                    txtCijena.Text = "";
                    txtKolicina.Text = "";
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
