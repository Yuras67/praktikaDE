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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1(Пользователи selectedUser)
        {
            InitializeComponent();
            //DataContext = currentUser;

            //if (selectedUser != null)
            //    currentUser = selectedUser;
            //DataContext = currentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    AutoParking_DBEntities.GetContext().Пользователи.Add(currentUser);
            //    AutoParking_DBEntities.GetContext().SaveChanges();
            //}
            //catch (Exception ex) {
            //    MessageBox.Show(ex.ToString());
            //        }
        }
    }
}
