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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Приложение
{
    public partial class user : Form
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True");
        private string currentUserLogin; // Логин текущего пользователя
        private int currentCustomerId; // ID текущего пользователя

        private void ConfigureLayout()
        {
            // Установка стиля формы
            this.Text = "User Panel";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);

            // Настройка DataGridView
            dataGridViewUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Центрирование ComboBox и других элементов
            tables.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Filtar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Создание панели для кнопок управления
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Padding = new Padding(10),
                WrapContents = false
            };

            buttonPanel.Controls.Add(Back); // Добавляем кнопку "Назад"

            // Создание основного макета
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10)); // Верхний блок
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 10)); // Фильтры и поиск
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 70)); // Таблица
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));    // Кнопки управления

            // Панель для фильтров
            var filterPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight
            };
            filterPanel.Controls.Add(tables);
            filterPanel.Controls.Add(search);
            filterPanel.Controls.Add(Filtar);

            // Добавление элементов в макет
            layout.Controls.Add(new Label
            {
                Text = "User Panel",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 16, FontStyle.Bold)
            }, 0, 0);
            layout.Controls.Add(filterPanel, 0, 1);
            layout.Controls.Add(dataGridViewUser, 0, 2);
            layout.Controls.Add(buttonPanel, 0, 3);

            // Добавление макета на форму
            this.Controls.Add(layout);
        }
    

        public user(string login)
        {
            InitializeComponent();
            ConfigureLayout();
            currentUserLogin = login;

            // Инициализация DataGridView
            InitializeDataGridView();

            // Получение текущего CustomerID
            GetCurrentCustomerId();

            // Инициализация ComboBox с названиями таблиц
            tables.Items.Add("Сбросить таблицу");
            tables.Items.Add("Customers");
            tables.Items.Add("Orders");
            tables.Items.Add("OrderItems");
            tables.Items.Add("Product");
            tables.Items.Add("Category");
            tables.Items.Add("Payments");

            tables.SelectedIndexChanged += tables_SelectedIndexChanged;
            Filtar.SelectedIndexChanged += Filtar_SelectedIndexChanged; // Подключаем обработчик

            // Скрываем ComboBox Filtar при загрузке формы
            Filtar.Visible = false;
        }
        private void InitializeDataGridView()
        {
            // Общие настройки DataGridView
            dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Установка шрифта для ячеек
            dataGridViewUser.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridViewUser.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста


            // Настройка прозрачности
            dataGridViewUser.BackgroundColor = this.BackColor; // Установить фон такой же, как у формы


        }
        private void GetCurrentCustomerId()
        {
            try
            {
                sqlConnection.Open();

                string query = "SELECT CustomerID FROM Customers WHERE Login = @Login";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@Login", currentUserLogin);

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    currentCustomerId = Convert.ToInt32(result);
                }
                else
                {
                    MessageBox.Show("Ошибка: пользователь не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении CustomerID: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = tables.SelectedItem.ToString();

            if (selectedTable == "Сбросить таблицу")
            {
                dataGridViewUser.DataSource = null; // Сбрасываем данные
                dataGridViewUser.Rows.Clear(); // Очищаем строки
                dataGridViewUser.Refresh(); // Обновляем DataGridView
                Filtar.Items.Clear(); // Очищаем фильтры
                Filtar.Visible = false; // Скрываем ComboBox фильтра
            }
            else
            {
                LoadTableData(selectedTable); // Загружаем данные для выбранной таблицы

                // Очистка и настройка фильтров для конкретной таблицы
                Filtar.Items.Clear();
                Filtar.Items.Add("All"); // Добавляем "All" в список фильтров

                if (selectedTable == "Payments")
                {
                    Filtar.Items.Add("Credit Card");
                    Filtar.Items.Add("PayPal");
                    Filtar.Items.Add("Bank Transfer");
                    Filtar.Visible = true; // Отображаем ComboBox фильтра
                }
                else if (selectedTable == "Category")
                {
                    Filtar.Items.Add("Laptops");
                    Filtar.Items.Add("Smartphones");
                    Filtar.Items.Add("Tablets");
                    Filtar.Items.Add("Accessories");
                    Filtar.Items.Add("Cameras");
                    Filtar.Visible = true; // Отображаем ComboBox фильтра
                }
                else if (selectedTable == "OrderItems")
                {
                    Filtar.Items.Add("UnitPrice < 1500");
                    Filtar.Items.Add("UnitPrice >= 2500");
                    Filtar.Visible = true; // Отображаем ComboBox фильтра
                }
                else if (selectedTable == "Product")
                {
                    Filtar.Items.Add("Mobile");
                    Filtar.Items.Add("Monitor");
                    Filtar.Items.Add("Keyboard");
                    Filtar.Items.Add("Laptop");
                    Filtar.Items.Add("Mouse");
                    Filtar.Items.Add("Printer");
                    Filtar.Items.Add("Photo");
                    Filtar.Items.Add("JBL Bluetooth Speaker");
                    Filtar.Items.Add("Watch ");

                    Filtar.Visible = true; // Отображаем ComboBox фильтра
                }
                else
                {
                    Filtar.Visible = false; // Скрываем ComboBox фильтра для других таблиц
                }
            }
        }
        private void LoadTableData(string tableName)
        {
            try
            {
                sqlConnection.Open();

                string query;

                // Условие для отображения таблиц
                if (tableName == "Orders" || tableName == "Customers")
                {
                    query = $"SELECT * FROM [{tableName}] WHERE CustomerID = @CustomerID";
                }
                else if (tableName == "Payments")
                {
                    query = $"SELECT TOP (1000) [PaymentID], [OrderID], [PaymentDate], [Amount], [PaymentMethod] FROM [Electronics].[dbo].[Payments]";
                }
                else
                {
                    query = $"SELECT * FROM [{tableName}]";
                }

                SqlCommand command = new SqlCommand(query, sqlConnection);

                // Добавление параметра для фильтрации, если необходимо
                if (query.Contains("@CustomerID"))
                {
                    command.Parameters.AddWithValue("@CustomerID", currentCustomerId);
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                dataGridViewUser.DataSource = dataTable;

                // Установка автоматической ширины столбцов
                dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Скрытие столбцов с "ID" в названии
                foreach (DataGridViewColumn column in dataGridViewUser.Columns)
                {
                    if (column.Name.ToLower().Contains("id"))
                    {
                        column.Visible = false;
                    }
                }

                // Настройка стилей
                dataGridViewUser.DefaultCellStyle.Font = new Font("Times New Roman", 14);
                dataGridViewUser.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблицы: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUser.DataSource == null)
            {
                MessageBox.Show("Таблица сброшена. Данные не отображаются.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Ваш существующий код обработки ячеек
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

        private void search_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridViewUser.DataSource;

            if (dataTable != null)
            {
                string filterExpression = "";

                // Перебираем все колонки таблицы и добавляем условия фильтрации
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (filterExpression.Length > 0)
                    {
                        filterExpression += " OR ";
                    }

                    filterExpression += string.Format("CONVERT([{0}], System.String) LIKE '%{1}%'", column.ColumnName, search.Text);
                }

                // Применяем фильтр
                dataTable.DefaultView.RowFilter = filterExpression;
            }
        }

        private void Filtar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridViewUser.DataSource;

            if (dataTable != null)
            {
                string selectedFilter = Filtar.SelectedItem.ToString();

                if (selectedFilter == "All")
                {
                    // Сбрасываем фильтр
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    string filterExpression = "";

                    if (tables.SelectedItem.ToString() == "Payments")
                    {
                        filterExpression = $"PaymentMethod LIKE '%{selectedFilter}%'";
                    }
                    else if (tables.SelectedItem.ToString() == "Category")
                    {
                        filterExpression = $"CategoryName LIKE '%{selectedFilter}%'";
                    }
                    else if (tables.SelectedItem.ToString() == "Product")
                    {
                        // Универсальный фильтр для поиска слов в ProductName
                        filterExpression = $"ProductName LIKE '%{selectedFilter}%'";
                    }
                    else if (tables.SelectedItem.ToString() == "OrderItems")
                    {
                        if (selectedFilter == "UnitPrice < 1500")
                        {
                            filterExpression = "UnitPrice < 1500";
                        }
                        else if (selectedFilter == "UnitPrice >= 2500")
                        {
                            filterExpression = "UnitPrice >= 2500";
                        }
                    }

                    if (!string.IsNullOrEmpty(filterExpression))
                    {
                        try
                        {
                            dataTable.DefaultView.RowFilter = filterExpression;
                            Console.WriteLine($"Filter applied: {filterExpression}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при применении фильтра: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void user_Load(object sender, EventArgs e)
        {

        }
    }
}