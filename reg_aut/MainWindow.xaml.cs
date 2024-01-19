using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Reg_Autor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      public  string Right_Log {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
        string directoty = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string path = System.IO.Path.GetDirectoryName(directoty);
            string currentPath = $"{path}\\2072011.png";
            BUTN_PAS.Background = new ImageBrush(new BitmapImage(new Uri(currentPath)));
        }
        bool a = false;

        private void aut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            autores win = new autores();
            win.Show();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if(a == true)
            {
                tbpass.Password = tbpass1.Text;
            }

            if (Log_Email.IsChecked == true)
            {
                var pochta = tblog.Text;
                var Pas = tbpass.Password.ToString();
                var context = new AppDbContext();
                var user1 = context.Users.SingleOrDefault(x => x.pochta == pochta);
                var user2 = context.Users.SingleOrDefault(x => x.Password == Pas);
                if (user1 is null)
                {
                    tbans.Text = "Такой почты нет";
                    tblog.Background = Brushes.Red;
                }
                else
                {
                    tblog.Background = Brushes.Green;

                }
                if (user2 is null)
                {
                    tbans1.Text = "Такого пароля нет";
                    tbpass.Background = Brushes.Red;
                }
                else
                {
                    tbpass.Background = Brushes.Green;

                }
                var user = context.Users.SingleOrDefault(x => x.pochta == pochta && x.Password == Pas);
                if (user is null)
                {
  
                }
                else
                {
                    MessageBox.Show("Здравствуйте " + tblog.Text);
                    tblog.Background = Brushes.Green;
                    tbpass.Background = Brushes.Green;
                    this.Hide();
                    Client win = new Client();
                    win.Show();
                }
            }
            else
            {
                var login = tblog.Text;
                var Pas = tbpass.Password.ToString();
                var context = new AppDbContext();
                var user1 = context.Users.SingleOrDefault(x => x.Login == login);
                var user2 = context.Users.SingleOrDefault(x => x.Password == Pas);
                if (user1 is null)
                {
                    tbans.Text = "Такого логина нет";
                    tblog.Background = Brushes.Red;
                    
                }
                else
                {
                    tblog.Background = Brushes.Green;
                }
                if (user2 is null)
                {
                    tbans1.Text = "Такого пароля нет";
                    tbpass.Background = Brushes.Red;
                }
                else
                {
                    tbpass.Background = Brushes.Green;
                }
                var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == Pas);
                var a1 = context.Users.Select(x => x.Login);
                if (user is null)
                {

                }
                else
                {
                    MessageBox.Show("Здравствуйте " + tblog.Text);
                    tblog.Background = Brushes.Green;
                    tbpass.Background = Brushes.Green;
                    this.Hide();
                    Client win = new Client();
                    win.Show();
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(a == false)
            {
                a = true;
            }
            else if(a == true)
            {
                a = false;
            }

            string directoty = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = System.IO.Path.GetDirectoryName(directoty);
            string currentPath = $"{path}\\2072011.png";
            string currentPath1 = $"{path}\\2072008.png";
            if (a == true)
            {
                tbpass1.Text = tbpass.Password;
                tbpass1.Visibility = Visibility.Visible;
                tbpass.Visibility = Visibility.Hidden;
                BUTN_PAS.Background = new ImageBrush(new BitmapImage(new Uri(currentPath1)));
            }
            else
            {
                tbpass.Password = tbpass1.Text;
                tbpass1.Visibility = Visibility.Hidden;
                tbpass.Visibility = Visibility.Visible;
                BUTN_PAS.Background = new ImageBrush(new BitmapImage(new Uri(currentPath)));
            }
        }
    }
}