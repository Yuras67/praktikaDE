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

namespace praktikaDE.Authorization_Folder
{
    /// <summary>
    /// Логика взаимодействия для Change_Password_Window.xaml
    /// </summary>
    public partial class Change_Password_Window : Window
    {
        public Change_Password_Window(Пользователи user_id)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoParking_DBEntities db = new AutoParking_DBEntities();
            string oldPassword = OldPassword.Password;
            string newPassword = NewPassword.Password;
            string confirmPassword = ConfirmPassword.Password;

            var User = db.Пользователи.FirstOrDefault(u => u.Пароль == oldPassword);

            if (User == null)
            {
                MessageBox.Show("Неверный старый пароль");
                return;
            }


            if ((newPassword == confirmPassword) && (newPassword != oldPassword) && (confirmPassword != oldPassword))
            {
                if (User.Сотрудники.Код_специальности == 1)
                {
                    Admin_Folder.Admin_Window admin_Window = new Admin_Folder.Admin_Window(User.Сотрудники.ФИО);
                    UpdateData(db, User, confirmPassword);
                    this.Close();
                    admin_Window.Show();
                }
                else if (User.Сотрудники.Код_специальности == 2)
                {
                    Dispatcher_Folder.Dispatcher_Window dispatcher_Window = new Dispatcher_Folder.Dispatcher_Window(User.Сотрудники.ФИО);
                    UpdateData(db, User, confirmPassword);
                    this.Close();
                    dispatcher_Window.Show();
                }
                else if (User.Сотрудники.Код_специальности == 3)
                {
                    Worker_Folder.Worker_Window worker_Window = new Worker_Folder.Worker_Window(User.Сотрудники.ФИО);
                    UpdateData(db, User, confirmPassword);
                    this.Close();
                    worker_Window.Show();
                }
                else if (User.Сотрудники.Код_специальности == 4)
                {
                    Drivers_Folder.Driver_Window driver_Window = new Drivers_Folder.Driver_Window(User.Сотрудники.ФИО);
                    UpdateData(db, User, confirmPassword);
                    this.Close();
                    driver_Window.Show();
                }
            }
            else if ((newPassword == oldPassword) || (confirmPassword == oldPassword))
            {
                MessageBox.Show("Новый пароль не должен быть похож на старый");
                return;
            }
            else
            {
                MessageBox.Show("Новый пароль не совпадает с подтверждением");
                return;
            }


        }

        private void UpdateData(
    AutoParking_DBEntities autoParking_DBEntities, Пользователи user, string confirmPassword)
        {
            user.Дата_последнего_входа = DateTime.Now;
            user.Пароль = confirmPassword;
            autoParking_DBEntities.SaveChanges();
        }
    }
}
