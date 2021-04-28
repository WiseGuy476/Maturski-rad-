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
    /// Interaction logic for VraćanjeKnjiga.xaml
    /// </summary>
    public partial class VraćanjeKnjiga : Window
    {
        public VraćanjeKnjiga()
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
        
        private void Prikaz()
        {
            string query = "SELECT p.posudba_ID as ID, c.clan_ID, c.clan_broj as BrojClana, c.clan_ime as ImeClana, c.clan_prezime as PrezimeClana," +
               " c.clan_telefon as BrojTelefona, k.knjiga_kod as KodKnjige,  k.knjiga_naslov as NaslovKnjige, k.knjiga_autor as Autor, k.kolicina_knjiga as Kolicina, "
               +" p.posudba_ID, p.datum_posudbe as DatumPosudbe, p.datum_do_vracanja as DatumIsteka, p.datum_vracanja as DatumVracanja "
               + "FROM bi_clanovi c, bi_knjige k, bi_posudbe p WHERE p.clan_ID=c.clan_ID AND p.knjiga_kod=k.knjiga_kod AND p.datum_vracanja IS NULL;";
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
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Prikaz();
        }
        int ID;
        int KnjigaID;
        string datum;
        private void gridKnjige_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selektovani_red = dg.SelectedItem as DataRowView;
            if (selektovani_red != null)
            {
                KnjigaID = Convert.ToInt32(selektovani_red["KodKnjige"]);
                ID = Convert.ToInt32(selektovani_red["ID"]);
                txtNaslov.Text = selektovani_red["NaslovKnjige"].ToString();
                dateDatumPos.Text = selektovani_red["DatumPosudbe"].ToString();
                dateDatumIsteka.Text = selektovani_red["DatumIsteka"].ToString();
                
            }
        }

        private void gridKnjige_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd. MM. yyyy.";
        }

        private void buttonOsvjezi_Click(object sender, RoutedEventArgs e)
        {
            txtNaslov.Text = "";
            dateDatumPos.SelectedDate = null;
            dateDatumIsteka.SelectedDate = null;
            Prikaz();
        }

        private void txtPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "SELECT c.clan_ID, c.clan_broj as BrojClana, c.clan_ime as ImeClana, c.clan_prezime as PrezimeClana," +
               " c.clan_telefon as BrojTelefona, k.knjiga_kod as KodKnjige,  k.knjiga_naslov as NaslovKnjige, k.knjiga_autor as Autor, k.kolicina_knjiga as Kolicina, "
               + " p.posudba_ID, p.datum_posudbe as DatumPosudbe, p.datum_do_vracanja as DatumIsteka, p.datum_vracanja as DatumVracanja "
               + "FROM bi_clanovi c, bi_knjige k, bi_posudbe p WHERE p.clan_ID=c.clan_ID AND p.knjiga_kod=k.knjiga_kod AND p.datum_vracanja IS NULL AND clan_broj LIKE '" + txtPretraga.Text + "%' ;";
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

        private void buttonVrati_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                datum = dateVracanje.SelectedDate.Value.Date.ToString("yyy-MM-dd");
                DateTime datumVracanja = dateVracanje.SelectedDate.Value.Date;
                DateTime datumIsteka = dateDatumIsteka.SelectedDate.Value.Date;
                TimeSpan razmak = datumVracanja.Subtract(datumIsteka);
                if (txtNaslov.Text == "")
                {
                    MessageBox.Show("Niste odabrali knjigu!", "Neuspješno vraćanje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }               
                else if (dateVracanje.SelectedDate.Value < dateDatumPos.SelectedDate.Value)
                {
                    MessageBox.Show("Datum vraćanja nije validan", "Neuspješno vraćanje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (dateVracanje.SelectedDate.Value > dateDatumIsteka.SelectedDate.Value)
                {
                    MessageBox.Show("Član je prekoračio datum isteka posudbe za " + razmak.ToString("%d") + " dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    VracanjeKnjige();
                    MessageBox.Show("Uspješno ste vratili knjigu", "Uspješno vraćanje", MessageBoxButton.OK, MessageBoxImage.Information);
                    Prikaz();
                }
                else
                {
                    VracanjeKnjige();
                    DodavanjeKnjige();
                    MessageBox.Show("Uspješno ste vratili knjigu", "Uspješno vraćanje", MessageBoxButton.OK, MessageBoxImage.Information);
                    Prikaz();
                }
            }
            catch (InvalidOperationException ex) 
            {
                MessageBox.Show("Niste odabrali knjigu!", "Neuspješno vraćanje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void DodavanjeKnjige()
        {
            string query = "UPDATE bi_knjige SET kolicina_knjiga=kolicina_knjiga+1 WHERE knjiga_kod='" + KnjigaID + "';";

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

        private void VracanjeKnjige() 
        {
            
            string query = "UPDATE bi_posudbe SET datum_vracanja = '"+datum+"' WHERE posudba_ID='"+ID+"'; ";
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
    }
}
