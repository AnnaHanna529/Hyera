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
    public partial class AdminForm : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True");

        public AdminForm()
        {
          
            InitializeComponent();
            LoadTablesIntoComboBox();
            ConfigureLayout();
        }
        private void ConfigureLayout()
        {
            // Установка стиля формы
            this.Text = "Admin Panel";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);

            // Настройка DataGridView
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Центрирование ComboBox и других элементов
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FILTARR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Создание панели для кнопок управления
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                Padding = new Padding(10),
                WrapContents = false
            };

           
         

            // Добавление кнопок в панель
            buttonPanel.Controls.Add(Add);
            buttonPanel.Controls.Add(Delete);
            buttonPanel.Controls.Add(Update);
            buttonPanel.Controls.Add(edit); // Добавляем кнопку "Редактировать"
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
            filterPanel.Controls.Add(comboBox1);
            filterPanel.Controls.Add(search);
            filterPanel.Controls.Add(FILTARR);

            // Добавление элементов в макет
            layout.Controls.Add(new Label
            {
                Text = "Admin Panel",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 16, FontStyle.Bold)
            }, 0, 0);
            layout.Controls.Add(filterPanel, 0, 1);
            layout.Controls.Add(dataGridView1, 0, 2);
            layout.Controls.Add(buttonPanel, 0, 3);

            // Добавление макета на форму
            this.Controls.Add(layout);
        }
        private void AdjustLayout()
        {
            // Центрирование DataGridView
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Центрирование таблицы относительно формы
            dataGridView1.Width = width - 40;
            dataGridView1.Height = height - 200;
            dataGridView1.Left = (width - dataGridView1.Width) / 2;
            dataGridView1.Top = (height - dataGridView1.Height) / 2;
        }
        private void LoadTablesIntoComboBox()
        {
            try
            {
                sqlConnection.Open();
                FILTARR.Visible = false;
                // Добавляем опцию "Сбросить таблицу" в начале
                comboBox1.Items.Add("Сбросить таблицу");

                // Изменённый запрос: исключаем sysdiagrams
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME != 'sysdiagrams'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["TABLE_NAME"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке таблиц: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если выбрана опция "Сбросить таблицу"
            if (comboBox1.SelectedItem?.ToString() == "Сбросить таблицу")
            {
                comboBox1.SelectedIndex = -1; // Сброс выбора
                dataGridView1.DataSource = null; // Очистка DataGridView
                FILTARR.Visible = false; // Скрываем фильтр
                MessageBox.Show("Таблица сброшена.");
                return;
            }

            // Если выбранная таблица валидна
            string selectedTable = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedTable))
            {
                LoadTableIntoDataGridView(selectedTable);

                // Показать FILTARR только для таблиц Orders, Payments и Warehouse
                if (selectedTable == "Orders" || selectedTable == "Payments" || selectedTable == "Warehouse")
                {
                    FILTARR.Visible = true;

                    // Очистить элементы в FILTARR и заполнить их в зависимости от выбранной таблицы
                    FILTARR.Items.Clear();
                    if (selectedTable == "Orders")
                    {
                        FILTARR.Items.Add("All");
                        FILTARR.Items.Add("Pending");
                        FILTARR.Items.Add("Shipped");
                        FILTARR.Items.Add("Delivered");
                        FILTARR.Items.Add("Cancelled");
                    }
                    else if (selectedTable == "Payments")
                    {
                        FILTARR.Items.Add("All");
                        FILTARR.Items.Add("Credit Card");
                        FILTARR.Items.Add("PayPal");
                        FILTARR.Items.Add("Bank Transfer");
                  
                    }
                    else if (selectedTable == "Warehouse")
                    {
                        FILTARR.Items.Add("All");
                        FILTARR.Items.Add("Los Angeles");
                        FILTARR.Items.Add("New York");
                        FILTARR.Items.Add("Chicago");
                        FILTARR.Items.Add("Houston");
                        FILTARR.Items.Add("Phoenix");
                    }
                    FILTARR.SelectedIndex = 0; // Установить "All" как выбранный элемент по умолчанию
                }
                else
                {
                    FILTARR.Visible = false; // Скрываем фильтр для других таблиц
                }
            }
        }
        private void LoadTableIntoDataGridView(string tableName)
        {
            try
            {
                sqlConnection.Open();

                string query = $"SELECT * FROM [{tableName}]";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                // Растягиваем таблицу под размер DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Автоматическое растягивание колонок
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;  // Подгоняем высоту строк под содержимое

                // Отключаем ширину и высоту по умолчанию
                dataGridView1.Dock = DockStyle.Fill; // Растягиваем таблицу по форме

                // Настройка стиля
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Текст переносится
                dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 14); // Настройка шрифта
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста

                // Скрытие колонок с "ID" (если нужно)
                if (tableName != "Inventory" && tableName != "OrderItems")
                {
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Name.IndexOf("ID", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            column.Visible = false; // Скрываем колонку с ID
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных таблицы: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTable = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedTable))
                {
                    MessageBox.Show("Выберите таблицу перед добавлением данных.");
                    return;
                }

                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                DataRow newRow = dataTable.NewRow();
                dataTable.Rows.Add(newRow);

                MessageBox.Show("Добавлена новая строка. Заполните данные и нажмите 'Обновить' для сохранения.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Предупреждение и запрос подтверждения
                    var result = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранные строки? Это действие нельзя отменить.",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning
                    );

                    // Обработка выбора пользователя
                    if (result == DialogResult.No || result == DialogResult.Cancel)
                    {
                        MessageBox.Show("Удаление отменено.");
                        return; // Если пользователь выбрал "Нет" или "Отмена", завершаем выполнение
                    }

                    // Если пользователь выбрал "Да", удаляем строки
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }

                    MessageBox.Show("Удаление выполнено. Нажмите 'Обновить' для применения изменений.");
                }
                else
                {
                    MessageBox.Show("Выберите строки для удаления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTable = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedTable))
                {
                    MessageBox.Show("Выберите таблицу перед обновлением данных.");
                    return;
                }

                // Подтверждение сохранения
                var result = MessageBox.Show(
                    "Вы уверены, что хотите сохранить изменения?",
                    "Подтверждение сохранения",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM [{selectedTable}]", sqlConnection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                DataTable dataTable = (DataTable)dataGridView1.DataSource;

                sqlDataAdapter.Update(dataTable); // Сохраняем изменения в базе данных

                MessageBox.Show("Изменения успешно сохранены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

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
        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что таблица загружена
                if (dataGridView1.DataSource == null)
                {
                    MessageBox.Show("Таблица не загружена. Выберите таблицу для редактирования.");
                    return;
                }

                // Предупреждение и запрос подтверждения
                var result = MessageBox.Show(
                    "Вы хотите включить режим редактирования? Изменения будут зафиксированы только после сохранения.",
                    "Подтверждение редактирования",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                // Обработка выбора пользователя
                if (result == DialogResult.No || result == DialogResult.Cancel)
                {
                    MessageBox.Show("Редактирование отменено.");
                    return; // Если пользователь выбрал "Нет" или "Отмена", завершаем выполнение
                }

                // Включаем редактирование ячеек
                dataGridView1.ReadOnly = false; // Отключаем режим только для чтения
                dataGridView1.AllowUserToAddRows = false; // Отключаем добавление новых строк через DataGridView
                dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2; // Редактирование при нажатии клавиш или F2

                MessageBox.Show("Редактирование включено. Измените данные и нажмите 'Сохранить изменения' для фиксации в базе данных.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при включении режима редактирования: {ex.Message}");
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            if (form1 != null)
            {
                form1.Show();
            }
            this.Close();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Настройка шрифта
            dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14);

            // Прозрачный фон (визуальный эффект)
            dataGridView1.BackgroundColor = this.BackColor; // Установка фона DataGridView такой же, как у формы
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Цвет текста
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void FILTARR_SelectedIndexChanged(object sender, EventArgs e)
        {   
            string selectedTable = comboBox1.SelectedItem?.ToString();
            string filterValue = FILTARR.SelectedItem?.ToString();

            if (dataGridView1.DataSource is DataTable dataTable)
            {
                if (selectedTable == "Orders" && !string.IsNullOrEmpty(filterValue))
                {
                    if (filterValue == "All")
                    {
                        dataTable.DefaultView.RowFilter = ""; // Сброс фильтра
                    }
                    else
                    {
                        dataTable.DefaultView.RowFilter = $"Status LIKE '%{filterValue}%'";
                    }
                }
                else if (selectedTable == "Payments" && !string.IsNullOrEmpty(filterValue))
                {
                    if (filterValue == "All")
                    {
                        dataTable.DefaultView.RowFilter = ""; // Сброс фильтра
                    }
                    else
                    {
                        dataTable.DefaultView.RowFilter = $"PaymentMethod LIKE '%{filterValue}%'";
                    }
                }
                else if (selectedTable == "Warehouse" && !string.IsNullOrEmpty(filterValue))
                {
                    if (filterValue == "All")
                    {
                        dataTable.DefaultView.RowFilter = ""; // Сброс фильтра
                    }
                    else
                    {
                        dataTable.DefaultView.RowFilter = $"Location LIKE '%{filterValue}%'";
                    }
                }
            }
        }

    }

    }

    
