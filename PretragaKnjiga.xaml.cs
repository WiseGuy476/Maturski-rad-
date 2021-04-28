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
    /// Interaction logic for PretragaKnjiga.xaml
    /// </summary>
    public partial class PretragaKnjiga : Window
    {
        public PretragaKnjiga()
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
            string query = "SELECT knjiga_kod as Kod, knjiga_naslov as Naslov_Knjige, knjiga_autor as Autor, knjiga_broj_stranica as Broj_Stranica, " +
               "knjiga_izdavac as Izdavac, cijena as Cijena, kolicina_knjiga as Kolicina FROM bi_knjige";
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
       Int64 kod;
        private void gridKnjige_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selektovani_red = dg.SelectedItem as DataRowView;
            if (selektovani_red != null) 
            {
                txtNaslov.Text = selektovani_red["Naslov_Knjige"].ToString();
                txtAutor.Text = selektovani_red["Autor"].ToString();
                txtBrStranica.Text = selektovani_red["Broj_Stranica"].ToString();
                txtIzdavac.Text = selektovani_red["Izdavac"].ToString();
                txtCijena.Text = selektovani_red["Cijena"].ToString();
                txtKolicina.Text = selektovani_red["Kolicina"].ToString();
                kod = Int64.Parse( selektovani_red["Kod"].ToString());
            }
        }

        private void buttonAzuriraj_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaslov.Text == "" || txtAutor.Text == "" || txtBrStranica.Text == "" || txtIzdavac.Text == "" || txtCijena.Text == "" || txtKolicina.Text == "")
            {
                MessageBox.Show("Morate odabrati knjigu!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    int parse1 = 0;
                    int parse2 = 0;
                    decimal cijena = System.Convert.ToDecimal(txtCijena.Text.Replace(".", ","));
                    string query = "UPDATE bi_knjige SET knjiga_naslov='" + txtNaslov.Text + "', knjiga_autor='" + txtAutor.Text + "', knjiga_broj_stranica='" + txtBrStranica.Text + "', " +
                        "knjiga_izdavac='" + txtIzdavac.Text + "', cijena='" + cijena.ToString().Replace(",", ".") + "', kolicina_knjiga='" + txtKolicina.Text + "' WHERE knjiga_kod=" + kod + "; ";

                    MessageBoxResult result = MessageBox.Show("Da li želite ažurirati podatke?", "Potvrda", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK)
                    {
                        if (!int.TryParse(txtBrStranica.Text, out parse1))
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
                            try
                            {
                                MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                                kon.Open();
                                MySqlCommand cmd = new MySqlCommand(query, kon);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Uspješno ste ažurirali podatke o knjizi " + txtNaslov.Text + ".", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                                kon.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        Prikaz();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM bi_knjige WHERE knjiga_kod=" + kod + "; ";
            MessageBoxResult result = MessageBox.Show("Da li želite obrisati podatke?", "Potvrda", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                if (txtNaslov.Text == "" || txtAutor.Text == "" || txtBrStranica.Text == "" || txtIzdavac.Text == "" || txtCijena.Text == "" || txtKolicina.Text == "")
                {
                    MessageBox.Show("Morate odabrati knjigu!", "Neuspjeh", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    try
                    {
                        MySqlConnection kon = new MySqlConnection(MainWindow.konStr);
                        kon.Open();
                        MySqlCommand cmd = new MySqlCommand(query, kon);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspješno ste obrisali podatke o knjizi " + txtNaslov.Text + ".", "Uspjeh", MessageBoxButton.OK, MessageBoxImage.Information);
                        kon.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            txtNaslov.Text = "";
            txtAutor.Text = "";
            txtBrStranica.Text = "";
            txtCijena.Text = "";
            txtKolicina.Text = "";
            txtIzdavac.Text = "";

            Prikaz();
        }

        private void txtPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "SELECT knjiga_kod as Kod, knjiga_naslov as Naslov_Knjige, knjiga_autor as Autor, knjiga_broj_stranica as Broj_Stranica, " +
                "knjiga_izdavac as Izdavac, cijena as Cijena, kolicina_knjiga as Kolicina FROM bi_knjige WHERE knjiga_naslov LIKE '" + txtPretraga.Text+"%' ;";
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
            txtPretraga.Text = "";
            txtNaslov.Text = "";
            txtAutor.Text = "";
            txtBrStranica.Text = "";
            txtCijena.Text = "";
            txtKolicina.Text = "";
            txtIzdavac.Text = "";

            Prikaz();
        }
    }
}
