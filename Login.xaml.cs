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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Login2
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string konStr= "Server=localhost; Port=3306; Database=biblioteka; Uid=root;" +
            "Pwd=root";
        public static string ID;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void buttonZatvori_Click(object sender, RoutedEventArgs e)
        {
            
            LogOut();
            this.Close();
            Application.Current.Shutdown();
        }

        

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string query= "SELECT korisnickoIme, password, CONCAT(imeKor,' ',PrezimeKor), Korisnik_ID, status_login FROM bi_korisnik WHERE korisnickoIme='" + txtUsername.Text + "' ;";
            try
            {
                MySqlConnection kon = new MySqlConnection(konStr);
                kon.Open();
                MySqlCommand cmd = new MySqlCommand(query, kon);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                reader.Read();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Pogrešno korisničko ime!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else 
                {
                    string korIme = reader[0].ToString();
                    string password = reader[1].ToString();
                    string punoIme = reader[2].ToString();
                    ID = reader[3].ToString();
                    int status_login = Convert.ToInt32(reader[4]);

                    if (status_login == 1)
                    {
                        MessageBox.Show("Korisnik je vec ulogovan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {

                        if (password == passLozinka.Password.ToString())
                        {
                            LogIn();
                            Dashboard db = new Dashboard();
                            this.Hide();
                            db.Show();
                        }
                        else
                        {
                            MessageBox.Show("Netačna lozinka korisniče " + punoIme + ".", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                kon.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogIn()
        {
            string query = "UPDATE bi_korisnik SET status_login=1 WHERE Korisnik_ID='" + ID + "';";

            try
            {
                MySqlConnection kon = new MySqlConnection(konStr);
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


        public void LogOut()
        {
            string query = "UPDATE bi_korisnik SET status_login=0 WHERE Korisnik_ID='" + ID + "';";

            try
            {
                MySqlConnection kon = new MySqlConnection(konStr);
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

        private void buttonRegistracija_Click(object sender, RoutedEventArgs e)
        {
            Registracija reg = new Registracija();
            this.Hide();
            reg.Show();
        }

    }
}
