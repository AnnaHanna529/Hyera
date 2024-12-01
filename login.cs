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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ElectronicsStore
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Центрируем панель Window в окне
            Window.Location = new Point(
                (this.ClientSize.Width - Window.Width) / 2, // Центрирование по горизонтали
                (this.ClientSize.Height - Window.Height) / 2 // Центрирование по вертикали
            );
        }

           
        
        private void MakeButtonRounded(Button button)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30; // Радиус закругления
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new Region(path);
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {

            // Применяем закругление
            MakeButtonRounded(logind);
            MakeButtonRounded(registers);
            logind.FlatStyle = FlatStyle.Flat;
            logind.FlatAppearance.BorderSize = 0;

            registers.FlatStyle = FlatStyle.Flat;
            registers.FlatAppearance.BorderSize = 0;
            Window.BackColor = Color.Transparent; // Делаем панель прозрачной
            Window.Location = new Point(
                (this.ClientSize.Width - Window.Width) / 2,
                (this.ClientSize.Height - Window.Height) / 2
            );

            this.Resize += Form1_Resize;

            // Настройка подсказок
            lgn.Text = "Введите логин"; // Подсказка для логина
            lgn.ForeColor = Color.Gray;

            psswrd.Text = "Введите пароль"; // Подсказка для пароля
            psswrd.ForeColor = Color.Gray;
            psswrd.UseSystemPasswordChar = false; // Не скрывать текст подсказки

            // Привязка событий
            lgn.Enter += lgn_Enter;
            lgn.Leave += lgn_Leave;

            psswrd.Enter += psswrd_Enter;
            psswrd.Leave += psswrd_Leave;

            // Подписываемся на событие изменения состояния CheckBox
            Passsowrds.CheckedChanged += Passsowrds_CheckedChanged;
        }

        private void Window_Paint(object sender, PaintEventArgs e)
        {
            // Создаем градиент для фона с более выраженным белым оттенком
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                Window.ClientRectangle,
                Color.FromArgb(200, 180, 180, 255), // Верхний цвет (светло-фиолетовый с меньшей прозрачностью)
                Color.FromArgb(100, 255, 255, 255), // Нижний цвет (светло-белый с прозрачностью)
                LinearGradientMode.Vertical))      // Вертикальный градиент
            {
                e.Graphics.FillRectangle(gradientBrush, Window.ClientRectangle);
            }

            // Создаем более яркую белую обводку
            using (Pen borderPen = new Pen(Color.FromArgb(220, 255, 255, 255), 2)) // Почти непрозрачный белый
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, Window.Width - 1, Window.Height - 1);
            }
        }

        private void logind_Click(object sender, EventArgs e)
        {
            string login = lgn.Text.Trim();
            string password = psswrd.Text.Trim();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True"))
                {
                    sqlConnection.Open();

                    // Проверка для администратора
                    string adminQuery = "SELECT ID FROM Administrators WHERE Login = @Login AND Password = @Password";
                    using (SqlCommand adminCommand = new SqlCommand(adminQuery, sqlConnection))
                    {
                        adminCommand.Parameters.AddWithValue("@Login", login);
                        adminCommand.Parameters.AddWithValue("@Password", password);

                        object adminResult = adminCommand.ExecuteScalar();

                        if (adminResult != null)
                        {
                            MessageBox.Show("Вы успешно зашли как Администратор!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            AdminForm adminForm = new AdminForm();
                            adminForm.Show();
                            this.Hide();
                            return;
                        }
                    }

                    // Проверка для зарегистрированных пользователей
                    string userQuery = "SELECT FirstName FROM Customers WHERE Login = @Login AND Password = @Password";
                    using (SqlCommand userCommand = new SqlCommand(userQuery, sqlConnection))
                    {
                        userCommand.Parameters.AddWithValue("@Login", login);
                        userCommand.Parameters.AddWithValue("@Password", password);

                        object userResult = userCommand.ExecuteScalar();

                        if (userResult != null)
                        {
                            string userName = userResult.ToString();
                            MessageBox.Show($"Вы успешно зашли как {userName}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            user userForm = new user(login);
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

        private void registers_Click(object sender, EventArgs e)
        {
            register form2 = new register();
            form2.Show();
            this.Hide();
        }

        private void lgn_Enter(object sender, EventArgs e)
        {
            if (lgn.Text == "Введите логин")
            {
                lgn.Text = "";
                lgn.ForeColor = Color.Black;
            }
        }

        private void lgn_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lgn.Text))
            {
                lgn.Text = "Введите логин";
                lgn.ForeColor = Color.Gray;
            }
        }

        private void psswrd_Enter(object sender, EventArgs e)
        {
            if (psswrd.Text == "Введите пароль")
            {
                psswrd.Text = "";
                psswrd.ForeColor = Color.Black;
                psswrd.UseSystemPasswordChar = true; // Включить скрытие символов
            }
        }

        private void psswrd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(psswrd.Text))
            {
                psswrd.UseSystemPasswordChar = false; // Отключить скрытие символов для подсказки
                psswrd.Text = "Введите пароль";
                psswrd.ForeColor = Color.Gray;
            }
        }
    
        private void Passsowrds_CheckedChanged(object sender, EventArgs e)
        {
            if (psswrd.Text != "Введите пароль")
            {
                psswrd.UseSystemPasswordChar = !Passsowrds.Checked;
            }
        }

        private void psswrd_TextChanged(object sender, EventArgs e)
        {

        }

        private void lgn_TextChanged(object sender, EventArgs e)
        {

        }

        private void Images_Click(object sender, EventArgs e)
        {

        }
    }
}