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


namespace Login2
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_dodavanje_clanova.Visibility = Visibility.Collapsed;
                tt_pretraga_clanova.Visibility = Visibility.Collapsed;
                tt_dodavanje_knjiga.Visibility = Visibility.Collapsed;
                tt_pretraga_knjiga.Visibility = Visibility.Collapsed;
                tt_posudite_knjige.Visibility = Visibility.Collapsed;
                tt_vratite_knjige.Visibility = Visibility.Collapsed;
                tt_info.Visibility = Visibility.Collapsed;
                tt_odjava.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_dodavanje_clanova.Visibility = Visibility.Visible;
                tt_pretraga_clanova.Visibility = Visibility.Visible;
                tt_dodavanje_knjiga.Visibility = Visibility.Visible;
                tt_pretraga_knjiga.Visibility = Visibility.Visible;
                tt_posudite_knjige.Visibility = Visibility.Visible;
                tt_vratite_knjige.Visibility = Visibility.Visible;
                tt_info.Visibility = Visibility.Visible;
                tt_odjava.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            this.Close();
            mw.LogOut();
            mw.Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result= MessageBox.Show("Da li se želite odjaviti?", "Potvrda", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK) 
            {
                this.Close();
                MainWindow mw = new MainWindow();
                mw.LogOut();
                mw.Show();
            }
            
        }

        private void ListViewItem_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            DodavanjeClanova dc = new DodavanjeClanova();
            dc.Show();
        }

        private void ListViewItem_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            DodavanjeKnjiga dk = new DodavanjeKnjiga();
            dk.Show();
        }

        private void ListViewItem_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            PretragaKnjiga pk = new PretragaKnjiga();
            pk.Show();
        }
        MediaPlayer mp = new MediaPlayer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            mp.Open(new Uri("F:/Maturski rad/BibliotekaMaturskiRad/sl/Cloud Break - Weightless (feat. Full Skies).mp3"));
            mp.MediaEnded += new EventHandler(Media_Ended);
            mp.Play();
            
        }
        private void Media_Ended(object sender, EventArgs e)
        {
            mp.Position = TimeSpan.Zero;
            mp.Play();
        }

        private void tb_muzika_Checked(object sender, RoutedEventArgs e)
        {
            mp.Pause();
        }

        private void tb_muzika_Unchecked(object sender, RoutedEventArgs e)
        {
            mp.Play();
        }

        private void ListViewItem_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            PretragaClanova pc = new PretragaClanova();
            pc.Show();
        }

        private void ListViewItem_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            Posudbe po = new Posudbe();
            po.Show();
        }

        private void ListViewItem_MouseLeftButtonUp_6(object sender, MouseButtonEventArgs e)
        {
            VraćanjeKnjiga vk = new VraćanjeKnjiga();
            vk.Show();
        }

        private void ListViewItem_MouseLeftButtonUp_7(object sender, MouseButtonEventArgs e)
        {
            Informacije inf = new Informacije();
            inf.Show();
        }
    }
}
