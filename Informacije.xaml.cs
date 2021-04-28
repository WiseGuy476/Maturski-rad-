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
using System.Data;

namespace Login2
{
    /// <summary>
    /// Interaction logic for Informacije.xaml
    /// </summary>
    public partial class Informacije : Window
    {
        public Informacije()
        {
            InitializeComponent();
        }

        private static int aktivan;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void gridKnjige_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd. MM. yyyy.";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikazSvega();
            BrojanjeUkupnihKnjiga();
            BrojanjePosudenih();
            BrojanjeClanova();
            Najaktivniji();
        }

        private void PrikazSvega() 
        {
            string query = "SELECT p.posudba_ID, c.clan_ID, c.clan_broj as ClanskiBroj, k.knjiga_kod as KodKnjige, " +
                "k.knjiga_naslov as NaslovKnjige, c.clan_ime as ImeClana, c.clan_prezime as PrezimeClana, " +
                "c.clan_email as EmailClana, c.clan_adresa as AdresaClana, c.clan_telefon as BrojTelefona, " +
                "k.knjiga_naslov as NaslovKnjige, k.knjiga_autor as AutorKnjige, k.knjiga_izdavac as IzdavacKnjige, " +
                "k.cijena as CijenaKnjige, k.kolicina_knjiga as KolicinaKnjige, datum_posudbe as DatumPosudbe, " +
                "datum_do_vraćanja as DatumIsteka, datum_vracanja as DatumVracanja "+
                "FROM bi_posudbe p, bi_clanovi c, bi_knjige k WHERE c.clan_ID = p.clan_ID AND k.knjiga_kod = p.knjiga_kod"+
                " ORDER BY p.datum_vracanja ASC; ";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridKnjige.ItemsSource = dt.DefaultView;
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrikazPosudenih()
        {
            string query = "SELECT p.posudba_ID, c.clan_ID, c.clan_broj as ClanskiBroj, k.knjiga_kod as KodKnjige, " +
                "k.knjiga_naslov as NaslovKnjige, c.clan_ime as ImeClana, c.clan_prezime as PrezimeClana, " +
                "c.clan_email as EmailClana, c.clan_adresa as AdresaClana, c.clan_telefon as BrojTelefona, " +
                "k.knjiga_naslov as NaslovKnjige, k.knjiga_autor as AutorKnjige, k.knjiga_izdavac as IzdavacKnjige, " +
                "k.cijena as CijenaKnjige, k.kolicina_knjiga as KolicinaKnjige, datum_posudbe as DatumPosudbe, " +
                "datum_do_vraćanja as DatumIsteka, datum_vracanja as DatumVracanja " +
                "FROM bi_posudbe p, bi_clanovi c, bi_knjige k WHERE c.clan_ID = p.clan_ID AND k.knjiga_kod = p.knjiga_kod " +
                "AND p.datum_vracanja IS NOT NULL " +
                "ORDER BY p.posudba_ID ASC; ";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridKnjige.ItemsSource = dt.DefaultView;
                kon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void PrikazVracenih()
        {
            string query = "SELECT p.posudba_ID, c.clan_ID, c.clan_broj as ClanskiBroj, k.knjiga_kod as KodKnjige, " +
                "k.knjiga_naslov as NaslovKnjige, c.clan_ime as ImeClana, c.clan_prezime as PrezimeClana, " +
                "c.clan_email as EmailClana, c.clan_adresa as AdresaClana, c.clan_telefon as BrojTelefona, " +
                "k.knjiga_naslov as NaslovKnjige, k.knjiga_autor as AutorKnjige, k.knjiga_izdavac as IzdavacKnjige, " +
                "k.cijena as CijenaKnjige, k.kolicina_knjiga as KolicinaKnjige, datum_posudbe as DatumPosudbe, " +
                "datum_do_vraćanja as DatumIsteka, datum_vracanja as DatumVracanja " +
                "FROM bi_posudbe p, bi_clanovi c, bi_knjige k WHERE c.clan_ID = p.clan_ID AND k.knjiga_kod = p.knjiga_kod " +
                "AND p.datum_vracanja IS NULL " +
                "ORDER BY p.posudba_ID ASC; ";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, kon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridKnjige.ItemsSource = dt.DefaultView;
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

        private void buttonOsv_Click(object sender, RoutedEventArgs e)
        {
            PrikazSvega();
        }

        private void buttonPos_Click(object sender, RoutedEventArgs e)
        {
           
            PrikazVracenih();
        }

        private void buttonVra_Click(object sender, RoutedEventArgs e)
        {
            PrikazPosudenih();
        }

        private void BrojanjeUkupnihKnjiga() 
        {
            int brojacKnjiga;
            string query = "SELECT SUM(kolicina_knjiga) FROM bi_knjige;";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);


                brojacKnjiga = Convert.ToInt32(cmd.ExecuteScalar());

                kon.Close();
                txtBrojKnj.Text = brojacKnjiga.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BrojanjePosudenih() 
        {
            int brojacPos;
            string query = "SELECT COUNT(*) FROM bi_posudbe WHERE datum_vracanja IS NULL;";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);


                brojacPos = Convert.ToInt32(cmd.ExecuteScalar());

                kon.Close();
                txtBrojacPos.Text = brojacPos.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BrojanjeClanova() 
        {
            int brojacCln;
            string query = "SELECT COUNT(*) FROM bi_clanovi;";
            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);


                brojacCln = Convert.ToInt32(cmd.ExecuteScalar());

                kon.Close();
                txtBrClan.Text = brojacCln.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Najaktivniji() 
        {
            
            string najaktivniji;
            string query = "SELECT clan_ID, COUNT(clan_ID) AS value_occurrence " +
                "FROM bi_posudbe " +
                "GROUP BY clan_ID " +
                "ORDER BY value_occurrence DESC " +
                "LIMIT 1;";

            

            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    aktivan = Convert.ToInt32(reader[0]);
                }                
                reader.Close();
                kon.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string query1 = "SELECT CONCAT(clan_ime,' ', clan_prezime) FROM bi_clanovi WHERE clan_ID='" + aktivan + "';";

            try
            {
                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query1, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    najaktivniji = reader[0].ToString();
                    txtNaj.Text = najaktivniji;
                }
                reader.Close();
                kon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
