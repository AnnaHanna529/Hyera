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
    public partial class register : Form
    {
        private SqlConnection sqlConnection;

        public register()
        {
            InitializeComponent();
            // Инициализация подключения к базе данных
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics; Integrated Security=True");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            // Показать скрытую форму Form1
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 != null)
            {
                form1.Show(); // Отобразить Form1
            }
            this.Close(); // Закрыть текущую форму
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            // Получение данных из текстовых полей
            string firstName = textBox1Name.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string zipCode = textBoxIndex.Text.Trim();
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string phone = textBoxNum.Text.Trim();
            string address = textBoxAdr.Text.Trim();

            // Проверка заполнения полей
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(zipCode) || string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность email
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность номера телефона (только цифры, длина 10-15 символов)
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{10,15}$"))
            {
                MessageBox.Show("Введите корректный номер телефона (только цифры, от 10 до 15 символов)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность почтового индекса (только цифры)
            if (!System.Text.RegularExpressions.Regex.IsMatch(zipCode, @"^\d+$"))
            {
                MessageBox.Show("Введите корректный почтовый индекс (только цифры)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Открытие соединения
                sqlConnection.Open();

                // Проверка на существование логина или email в базе данных
                string checkQuery = "SELECT COUNT(*) FROM Customers WHERE Login = @Login OR Email = @Email";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, sqlConnection))
                {
                    checkCommand.Parameters.AddWithValue("@Login", login);
                    checkCommand.Parameters.AddWithValue("@Email", email);

                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Логин или email уже зарегистрированы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // SQL-запрос для добавления данных
                string query = "INSERT INTO Customers (FirstName, LastName, Email, City, ZipCode, Login, Password, Phone, Address) " +
                               "VALUES (@FirstName, @LastName, @Email, @City, @ZipCode, @Login, @Password, @Phone, @Address)";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Добавление параметров
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@ZipCode", zipCode);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);

                    // Выполнение команды
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистка текстовых полей
                textBox1Name.Clear();
                textBoxLastName.Clear();
                textBoxEmail.Clear();
                textBoxCity.Clear();
                textBoxIndex.Clear();
                textBoxLogin.Clear();
                textBoxPassword.Clear();
                textBoxNum.Clear();
                textBoxAdr.Clear();

                // Переход на форму user с передачей логина
                user userForm = new user(login);  // Передаем логин в конструктор
                userForm.Show();

                // Закрытие текущей формы
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрытие соединения
                sqlConnection.Close();
            }
        }
    }
}