using praktikaDE.Admin_Folder.Add_Folder;
using praktikaDE.Admin_Folder.Edit_Folder;
using praktikaDE.DataBase_Folder;
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

namespace praktikaDE.Admin_Folder
{
    /// <summary>
    /// Логика взаимодействия для Admin_Window.xaml
    /// </summary>
    public partial class Admin_Window : Window
    {
        public Admin_Window(string FullName)
        {
            InitializeComponent();
            DGrid_Users.ItemsSource = AutoParking_DBEntities.GetContext().Пользователи.ToList();

        }

        private void Edit_Data(object sender, RoutedEventArgs e)
        {
            Edit_User_Window edit_User_Window = new Edit_User_Window((sender as Button).DataContext as Пользователи);
            edit_User_Window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_User_Window add_User_Window = new Add_User_Window();
            add_User_Window.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            DGrid_Users.ItemsSource = AutoParking_DBEntities.GetContext().Пользователи.ToList();
        }
    }
}
