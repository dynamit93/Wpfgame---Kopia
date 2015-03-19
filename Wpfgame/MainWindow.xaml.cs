using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfApplication1;

namespace Wpfgame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            username_txt.MaxLength = 32;
            password_txt.MaxLength = 255;
        }

        private void Login1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string myConnection = "datasource=localhost;port=3306;username=root;password=geiiwfjr";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand SelectCommand = new MySqlCommand("SELECT * FROM world.accounts WHERE name='" + this.username_txt.Text + "' AND password='" + this.password_txt.Password + "' ;", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {
                    this.Hide();
                    CharacterList f2 = new CharacterList();
                    f2.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password. Access is denied.");
                }
                else
                    MessageBox.Show("Username and password is incorrect. Please try again.");
                myConn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void username_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void password_txt_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
