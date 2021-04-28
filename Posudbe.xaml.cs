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
    /// Interaction logic for Posudbe.xaml
    /// </summary>
    public partial class Posudbe : Window
    {
        public Posudbe()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT knjiga_naslov FROM bi_knjige;";
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboKnjige.Items.Add(reader["knjiga_naslov"].ToString());
                }
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                  
            }
        }

        private void buttonZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        string knjiga;
        string broj;
        int clanID;
        int knjigaID;
        int brojac = 0;
        Int32 brojacPosudbi = 0;

        private void buttonPretraga_Click(object sender, RoutedEventArgs e)
        {
            string brClana = txtPretraga.Text;
            string query = "SELECT clan_broj, clan_ime, clan_prezime, clan_adresa, clan_email, clan_telefon FROM bi_clanovi WHERE clan_broj = '" + txtPretraga.Text + "';";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Pogrešan članski broj", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    broj = reader[0].ToString();
                    string ime = reader[1].ToString();
                    string prezime = reader[2].ToString();
                    string adresa = reader[3].ToString();
                    string email = reader[4].ToString();
                    string telefon = reader[5].ToString();

                    txtIme.Text = ime;
                    txtPrezime.Text = prezime;
                    txtAdresa.Text = adresa;
                    txtEmail.Text = email;
                    txtTel.Text = telefon;
                    reader.Close();
                    kon.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            PronalaženjeID();

            
        }

        private void buttonOsvjezi_Click(object sender, RoutedEventArgs e)
        {
            txtPretraga.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtAdresa.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";            
        }

        private void buttonPosudi_Click(object sender, RoutedEventArgs e)
        {
            knjiga = comboKnjige.Text;
            PronalazenjeKnjigaID();
            var datum = datePosudba.SelectedDate.Value.Date.ToString("yyy-MM-dd");
            var datumDo = datePosudba.SelectedDate.Value.Date.AddDays(15).ToString("yyy-MM-dd");
            if (txtIme.Text == "") 
            {
                MessageBox.Show("Niste odabrali člana!", "Neuspješna posudba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (datePosudba.SelectedDate == null)
            {
                MessageBox.Show("Niste unijeli datum!", "Neuspješna posudba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (comboKnjige.SelectedItem == null)
            {
                MessageBox.Show("Niste odabrali knjigu!", "Neuspješna posudba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
                ProvjeraBroja();
                if (brojac == 0)
                {
                    MessageBox.Show("Sve knjige " + comboKnjige.Text + " su već posuđene!", "Neuspješna posudba", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else if (brojacPosudbi>0) 
                {
                    MessageBox.Show("Korisnik sa ID-em " + clanID + " je već uzeo dvije knjige!", "Neuspješna posudba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Ograničenje();
                    OduzimanjeKnjige();
                    try
                    {
                        string query = "INSERT INTO bi_posudbe(clan_ID, knjiga_kod, datum_posudbe, datum_do_vracanja) VALUES('" + clanID + "', '" + knjigaID + "', '" + datum.ToString() + "', '" + datumDo.ToString() + "');";


                        MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                        kon.Open();
                        MySqlCommand cmd = new MySqlCommand(query, kon);
                        cmd.ExecuteNonQuery();
                        kon.Close();
                        MessageBox.Show("Uspješno ste posudili knjigu!", "Uspješna posudba", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtIme.Text = "";
                        txtPrezime.Text = "";
                        txtEmail.Text = "";
                        txtTel.Text = "";
                        txtAdresa.Text = "";


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                }
                
                
            }
        }
        
        private void PronalaženjeID() 
        {
            string query = "SELECT clan_ID FROM bi_clanovi WHERE clan_broj='"+broj+"';";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    clanID = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();
                kon.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PronalazenjeKnjigaID()
        {
            
            string query = "SELECT knjiga_kod FROM bi_knjige WHERE knjiga_naslov = '" + knjiga + "';";
            
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    knjigaID = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                kon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void OduzimanjeKnjige() 
        {
            string query = "UPDATE bi_knjige SET kolicina_knjiga=kolicina_knjiga-1 WHERE knjiga_kod='"+knjigaID+"';";
            
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                cmd.ExecuteNonQuery();
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProvjeraBroja() 
        {
            
            string query = "SELECT kolicina_knjiga FROM bi_knjige WHERE knjiga_kod='" + knjigaID + "';";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    brojac = Convert.ToInt32(reader[0]);
                }
                reader.Close();
                kon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                       
        }

        private void Ograničenje() 
        {
            string query = "SELECT COUNT(*) FROM bi_posudbe WHERE clan_ID='"+ clanID +"' AND datum_vracanja IS NULL;";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);


                brojacPosudbi = Convert.ToInt32( cmd.ExecuteScalar());
                
                kon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
