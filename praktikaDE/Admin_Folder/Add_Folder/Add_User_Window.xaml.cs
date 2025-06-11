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

namespace praktikaDE.Admin_Folder.Add_Folder
{
    /// <summary>
    /// Логика взаимодействия для Add_User_Window.xaml
    /// </summary>
    public partial class Add_User_Window : Window
    {
        Пользователи currentUser = new Пользователи();

        public Add_User_Window()
        {
            InitializeComponent();
            DataContext = currentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id_sot = id.Text;
            string log = login.Text;
            string pas = passowrd.Text;
            string last_in = lass_in.Text;
            string isBan = isbaned.Text;

            if (string.IsNullOrEmpty(id_sot) || string.IsNullOrEmpty(log) || string.IsNullOrEmpty(pas) || string.IsNullOrEmpty(last_in) || string.IsNullOrEmpty(isBan))
            {
                MessageBox.Show("Поля должны быть заполнены");
                return;
            }


            try
            {
                AutoParking_DBEntities.GetContext().Пользователи.Add(currentUser);
                AutoParking_DBEntities.GetContext().SaveChanges();
                MessageBox.Show("Пользователь добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
    }
}
