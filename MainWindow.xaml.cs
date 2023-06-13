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
using System.Data.SqlClient;

namespace FinalyDem
{
    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            var _login = Login_Reg.Text.Trim();
            var _password1 = Password1_Reg.Password.Trim();
            var _password2 = Password2_Reg.Password.Trim();

            if (_login == "" || _password1 == "" || _password2 == "")
            {
                MessageBox.Show("Не все поля заполнены !", "Уведомление");
            }
            else
            {
                if (_password1 == _password2)
                {
                    string request = $"insert into Registration(login, password) values('{_login}','{_password1}')";

                    SqlCommand command = new SqlCommand(request, dataBase.GetConnection());

                    dataBase.OpenConnection();

                    if(command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Регистрация успешна!","Уведомление");
                        Hide();
                        new AutoWindow().ShowDialog();
                        ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Регистрация не успешна!", "Уведомление");
                    }

                    dataBase.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!","Уведомление");
                }
            }


        }

        private void Auton_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new AutoWindow().ShowDialog();
            ShowDialog();
        }
    }
}
