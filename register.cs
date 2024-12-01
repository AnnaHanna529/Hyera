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
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElectronicsStore
{
    public partial class register : Form
    {
        private SqlConnection sqlConnection;

        public register()
        {

            InitializeComponent();
            // Инициализация подключения к базе данных
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics; Integrated Security=True");

            // Добавляем обработчик события изменения размеров формы
            this.Resize += Form_Resize;

            // Центрирование панели при инициализации
            CenterPanel();

        }
        private void InitializePlaceholders()
        {
            SetPlaceholder(Names, "Введите имя");
            SetPlaceholder(LastNames, "Введите фамилию");
            SetPlaceholder(Emails, "Введите email");
            SetPlaceholder(Nums, "Введите номер телефона");
            SetPlaceholder(Adr, "Введите адрес");
            SetPlaceholder(Citys, "Введите город");
            SetPlaceholder(ndexs, "Введите индекс");
            SetPlaceholder(Logins, "Введите логин");
            SetPlaceholder(Passwords, "Введите пароль");
        }

        private void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
            }

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
        private void Form2_Load(object sender, EventArgs e)
        {   
            InitializePlaceholders();
            wind0w.BackColor = Color.Transparent; // Делаем панель прозрачной
            CenterPanel(); // Центрируем панель
            wind0w.BackColor = Color.Transparent; // Делаем панель прозрачной
            wind0w.Location = new Point(
                (this.ClientSize.Width - wind0w.Width) / 2, // Используем `wind0w.Width`
                (this.ClientSize.Height - wind0w.Height) / 2); // Используем `wind0w.Height`
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            CenterPanel(); // Центрируем панель при изменении размера окна
        }
        private void CenterPanel()
        {
            if (wind0w != null)
            {
                wind0w.Location = new Point(
                    (this.ClientSize.Width - wind0w.Width) / 2,
                    (this.ClientSize.Height - wind0w.Height) / 2
                );
            }
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
            string firstName = Names.Text.Trim();
            string lastName = LastNames.Text.Trim();
            string email = Emails.Text.Trim();
            string city = Citys.Text.Trim();
            string zipCode = ndexs.Text.Trim();
            string login = Logins.Text.Trim();
            string password = Passwords.Text.Trim();
            string phone = Nums.Text.Trim();
            string address = Adr.Text.Trim();

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
                Names.Clear();
                LastNames.Clear();
                Emails.Clear();
                Citys.Clear();
                ndexs.Clear();
                Logins.Clear();
                Passwords.Clear();
                Nums.Clear();
                Adr.Clear();

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
 
        private void wind0w_Paint(object sender, PaintEventArgs e)
        {
            // Создаем градиент для фона с более выраженным белым оттенком
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                wind0w.ClientRectangle, // Область рисования панели `wind0w`
                Color.FromArgb(200, 180, 180, 255), // Верхний цвет (светло-фиолетовый с меньшей прозрачностью)
                Color.FromArgb(100, 255, 255, 255), // Нижний цвет (светло-белый с прозрачностью)
                LinearGradientMode.Vertical))      // Вертикальный градиент
            {
                e.Graphics.FillRectangle(gradientBrush, wind0w.ClientRectangle);
            }

            // Создаем более яркую белую обводку
            using (Pen borderPen = new Pen(Color.FromArgb(220, 255, 255, 255), 2)) // Почти непрозрачный белый
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, wind0w.Width - 1, wind0w.Height - 1);
            }
        }

        private void Names_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastNames_TextChanged(object sender, EventArgs e)
        {

        }

        private void Emails_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nums_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adr_TextChanged(object sender, EventArgs e)
        {

        }

        private void Citys_TextChanged(object sender, EventArgs e)
        {

        }

        private void ndexs_TextChanged(object sender, EventArgs e)
        {

        }

        private void Logins_TextChanged(object sender, EventArgs e)
        {

        }

        private void Passwords_TextChanged(object sender, EventArgs e)
        {

        }
    }
}