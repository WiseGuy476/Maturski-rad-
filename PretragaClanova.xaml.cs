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
    /// Interaction logic for PretragaClanova.xaml
    /// </summary>
    public partial class PretragaClanova : Window
    {
        public PretragaClanova()
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
        private void Prikaz() 
        {
            string query = "SELECT clan_ID, clan_broj as BrojClana, clan_ime as ImeClana, clan_prezime as PrezimeClana," +
               " clan_email as EmailClana, clan_adresa as AdresaClana, clan_telefon as BrojTelefona from bi_clanovi; ";
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

        private void txtPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "SELECT clan_ID, clan_broj as BrojClana, clan_ime as ImeClana, clan_prezime as PrezimeClana," +
                " clan_email as EmailClana, clan_adresa as AdresaClana, clan_telefon as BrojTelefona from bi_clanovi WHERE clan_broj LIKE '"+txtPretraga.Text+"%'; ";
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

        private void buttonOsvjezi_Click(object sender, RoutedEventArgs e)
        {
            txtClBroj.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtEmail.Text = "";
            txtAdresa.Text = "";
            txtBrojTel.Text = "";
            txtPretraga.Text = "";

            Prikaz();

        }
        Int64 id;
        private void gridKnjige_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selektovani_red = dg.SelectedItem as DataRowView;
            if (selektovani_red != null)
            {
                txtClBroj.Text = selektovani_red["BrojClana"].ToString();
                txtIme.Text = selektovani_red["ImeClana"].ToString();
                txtPrezime.Text = selektovani_red["PrezimeClana"].ToString();
                txtEmail.Text = selektovani_red["EmailClana"].ToString();
                txtAdresa.Text = selektovani_red["AdresaClana"].ToString();
                txtBrojTel.Text = selektovani_red["BrojTelefona"].ToString();
                id= Int64.Parse(selektovani_red["clan_ID"].ToString());
            }
        }

        private void buttonAzuriraj_Click(object sender, RoutedEventArgs e)
        {
            int parse = 0;
            string query = "UPDATE bi_clanovi SET clan_broj='"+txtClBroj.Text+"', clan_ime='"+txtIme.Text+"', clan_prezime='"+txtPrezime.Text+"'," +
                " clan_email='"+txtEmail.Text+"', clan_adresa='"+txtAdresa.Text+"', clan_telefon='"+txtBrojTel.Text+"' WHERE clan_ID='" + id +"';";

            MessageBoxResult result = MessageBox.Show("Da li želite ažurirati podatke?", "Potvrda", MessageBoxButton.OKCancel, MessageBoxImage.Question);            
            if (result == MessageBoxResult.OK)
            {
                if (txtClBroj.Text == "" || txtIme.Text == "" || txtBrojTel.Text == "" || txtPrezime.Text == "" || txtAdresa.Text == "" || txtEmail.Text == "")
                {
                    MessageBox.Show("Morate odabrati člana!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (!int.TryParse(txtBrojTel.Text, out parse))
                {
                    MessageBox.Show("Broj telefona može sadržavati samo brojeve ili je broj predugačak!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtBrojTel.Text = "";
                    return;
                }
                else 
                {
                    try
                    {
                        MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                        kon.Open();
                        MySqlCommand cmd = new MySqlCommand(query, kon);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspješno ste ažurirali podatke o članu " + txtIme.Text + " "+txtPrezime.Text+".", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        kon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            Prikaz();
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM bi_clanovi WHERE clan_ID='" + id + "';";
            MessageBoxResult result = MessageBox.Show("Da li želite obrisati podatke?", "Potvrda", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                if (txtClBroj.Text == "" || txtIme.Text == "" || txtBrojTel.Text == "" || txtPrezime.Text == "" || txtAdresa.Text == "" || txtEmail.Text == "")
                {
                    MessageBox.Show("Morate odabrati člana!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    try
                    {
                        MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                        kon.Open();
                        MySqlCommand cmd = new MySqlCommand(query, kon);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspješno ste obrisali podatke o članu " + txtIme.Text + " " + txtPrezime.Text + ".", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        kon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
            txtClBroj.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtEmail.Text = "";
            txtAdresa.Text = "";
            txtBrojTel.Text = "";
            Prikaz();
        }
    }
}
