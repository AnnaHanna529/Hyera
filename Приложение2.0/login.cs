using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Приложение
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            register form2 = new register();
            form2.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.Trim(); // Логин
            string password = textBox2.Text.Trim(); // Пароль

            // Проверка для администратора
            if (login == "admin" && password == "admin")
            {
                MessageBox.Show("Вы успешно зашли как Администратор!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AdminForm adminForm = new AdminForm(); // Форма для администратора
                adminForm.Show();
                this.Hide();
                return;
            }

            // Проверка для зарегистрированных пользователей
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True"))
                {
                    sqlConnection.Open();

                    string query = "SELECT FirstName FROM Customers WHERE Login = @Login AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);

                        // Проверка, есть ли пользователь
                        object result = command.ExecuteScalar();

                        if (result != null) // Если пользователь найден
                        {
                            string userName = result.ToString(); // Получаем имя пользователя
                            MessageBox.Show($"Вы успешно зашли как {userName}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Переход на форму пользователя
                            user userForm = new user(login); // Передаем логин
                            userForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при проверке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}