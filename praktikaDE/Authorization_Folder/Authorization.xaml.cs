using praktikaDE.DataBase_Folder;
using System;
using System.Collections.Generic;
using System.Data;
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


namespace praktikaDE.Authorization_Folder
{
    public partial class Authorization : Window
    {
        int isFailed = 0;

        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoParking_DBEntities db = new AutoParking_DBEntities();
            string Login = LoginBox.Text;
            string Password = PasswordBox.Password;

            if (string.IsNullOrEmpty(Login) || (string.IsNullOrEmpty(Password)))
            {
                MessageBox.Show("Поля должны быть заполнены");
                return;
            }

            var User = db.Пользователи.FirstOrDefault(u => u.Логин == Login && u.Пароль == Password);
            var Users = db.Пользователи.FirstOrDefault(u => u.Логин == Login || u.Пароль == Password);
            
            var currentUser = db.Пользователи.Find(Users.Код_пользователя);

            if (isFailed >= 3 || currentUser.Заблокитрован == true || ((TimeSpan)(DateTime.Now - currentUser.Дата_последнего_входа)).TotalDays > 30)
            {
                currentUser.Заблокитрован = true;
                db.SaveChanges();
                MessageBox.Show("Ваш аккаунт заблокирован. Пожалуйста, обратитесь к администратору");
                return;
            }

            if (User == null)
            {
                isFailed += 1;
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            else
            {
                Change_Password_Window change_Password_Window = new Change_Password_Window(User);
                this.Close();
                change_Password_Window.Show();
            }
 
        }
    }
}
