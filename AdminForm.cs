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

namespace ElectronicsStore
{
    public partial class AdminForm : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True");

        public AdminForm()
        {
            InitializeComponent();
            LoadTablesIntoComboBox();
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

                // Устанавливаем свойства для DataGridView
                dataGridView1.DataSource = dataTable;

                // Настройка стиля
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 14);
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

                // Скрываем первичные ключи
                HidePrimaryKeyColumns(tableName);

                AdjustDataGridViewSize(dataGridView1);
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


        private void HidePrimaryKeyColumns(string tableName)
        {
            // Список первичных ключей для каждой таблицы
            var primaryKeys = new Dictionary<string, List<string>>()
    {
        { "Customers", new List<string> { "CustomerID" } },
        { "Suppliers", new List<string> { "SupplierID" } },
        { "Orders", new List<string> { "OrderID" } },
        { "OrderItems", new List<string> { "OrderItemID" } },  // Correct primary key for OrderItems
        { "Payments", new List<string> { "PaymentID" } },
        { "Warehouse", new List<string> { "WarehouseID" } },
        { "Category", new List<string> { "CategoryID" } },
        { "Deliveries", new List<string> { "DeliveryID" } },
        { "Inventory", new List<string> { "InventoryID" } },
        { "Product", new List<string> { "ProductID" } }
    };

            // Проверяем, есть ли информация о первичных ключах для данной таблицы
            if (primaryKeys.ContainsKey(tableName))
            {
                // Получаем список первичных ключей для текущей таблицы
                List<string> primaryKeyColumns = primaryKeys[tableName];

                // Перебираем все столбцы в DataGridView
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    // Если имя столбца совпадает с первичным ключом, скрываем его
                    if (primaryKeyColumns.Contains(column.Name))
                    {
                        column.Visible = false;
                    }
                }
            }
        }
        private void AdjustDataGridViewSize(DataGridView dgv)
        {
            // Вычисляем размеры для DataGridView
            int totalHeight = dgv.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dgv.ColumnHeadersHeight;
            int totalWidth = dgv.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            // Устанавливаем размеры DataGridView, добавляя отступы
            dgv.Height = totalHeight + 20; // 20 - запас для прокрутки или границ
            dgv.Width = totalWidth + 20;

            // Ограничиваем размеры в пределах родительского контейнера
            if (dgv.Parent != null)
            {
                dgv.Width = Math.Min(dgv.Width, dgv.Parent.Width - 10); // 10 - запас для отступов
                dgv.Height = Math.Min(dgv.Height, dgv.Parent.Height - 10);

                // Центрируем DataGridView относительно родительского контейнера
                dgv.Left = (dgv.Parent.Width - dgv.Width) / 2; // Расчет позиции по горизонтали
                dgv.Top = (dgv.Parent.Height - dgv.Height) / 2; // Расчет позиции по вертикали
            }
        }
        // Метод для получения первичных ключей



        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли таблица
                string selectedTable = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedTable))
                {
                    MessageBox.Show("Выберите таблицу перед добавлением данных.");
                    return;
                }

                if (dataGridView1.DataSource is DataTable dataTable)
                {
                    // Создаем новую строку
                    DataRow newRow = dataTable.NewRow();

                    // Проверяем автоинкрементные столбцы и заполняем их значениями
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        // Если столбец является автоинкрементным или первичным ключом, пропускаем его
                        if (column.AutoIncrement || IsPrimaryKeyOrForeignKey(column))
                        {
                            continue;
                        }

                        // Заполняем столбцы значениями по умолчанию
                        newRow[column] = GetDefaultValueForColumn(column);
                    }

                    // Если есть автоинкрементные столбцы, получаем следующее значение
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (column.AutoIncrement)
                        {
                            string query = $"SELECT MAX([{column.ColumnName}]) FROM {selectedTable}";
                            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                            sqlConnection.Open();
                            object result = sqlCommand.ExecuteScalar();
                            sqlConnection.Close();

                            // Если результат не null, увеличиваем на 1
                            if (result != DBNull.Value)
                            {
                                newRow[column] = Convert.ToInt32(result) + 1;
                            }
                            else
                            {
                                newRow[column] = 1; // Если строк в таблице нет, начинаем с 1
                            }
                        }
                    }

                    // Добавляем строку в DataTable
                    dataTable.Rows.Add(newRow);

                    MessageBox.Show($"Добавлена новая строка в таблицу {selectedTable}. Заполните данные и нажмите 'Обновить' для сохранения.");
                }
                else
                {
                    MessageBox.Show("Нет данных для добавления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
            }
        }
        private bool IsPrimaryKeyOrForeignKey(DataColumn column)
        {
            // Логика для определения, является ли столбец первичным или внешним ключом
            // Это можно делать на основе имен столбцов, если структура базы данных известна
            string[] primaryKeys = { "CustomerID", "OrderID", "PaymentID", "WarehouseID", "CategoryID", "DeliveryID", "SupplierID", "OrderItemID", "InventoryID", "CategoryID" }; // Пример имён столбцов первичных ключей
            string[] foreignKeys = { "CustomerID", "OrderID", "PaymentID", "WarehouseID", "CategoryID", "DeliveryID", "SupplierID", "OrderItemID", "InventoryID", "CategoryID" }; // Пример имён столбцов внешних ключей

            return primaryKeys.Contains(column.ColumnName) || foreignKeys.Contains(column.ColumnName);
        }
        // Метод для получения значения по умолчанию
        private object GetDefaultValueForColumn(DataColumn column)
        {
            if (column.DataType == typeof(string))
                return string.Empty;
            if (column.DataType == typeof(int))
                return 0;
            if (column.DataType == typeof(DateTime))
                return DateTime.Now;

            return DBNull.Value;
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
                if (dataGridView1.DataSource is DataTable dataTable)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Electronics;Integrated Security=True"))
                    {
                        sqlConnection.Open();

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM {comboBox1.SelectedItem}", sqlConnection))
                        {
                            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter)
                            {
                                ConflictOption = ConflictOption.OverwriteChanges
                            };

                            // Обновляем данные в базе данных
                            sqlDataAdapter.Update(dataTable);
                        }
                    }

                    MessageBox.Show("Данные успешно обновлены.");
                }
                else
                {
                    MessageBox.Show("Нет данных для обновления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
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

                // Проверяем текущий режим DataGridView
                if (!dataGridView1.ReadOnly)
                {
                    // Если редактирование включено, выключаем его
                    var result = MessageBox.Show(
                        "Вы хотите выйти из режима редактирования? Несохраненные изменения будут потеряны.",
                        "Подтверждение выхода",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Выходим из режима редактирования
                        dataGridView1.ReadOnly = true;
                        dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

                        MessageBox.Show("Режим редактирования выключен.");
                    }
                }
                else
                {
                    // Если редактирование выключено, включаем его
                    var result = MessageBox.Show(
                        "Вы хотите включить режим редактирования? Изменения будут зафиксированы только после сохранения.",
                        "Подтверждение редактирования",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Включаем режим редактирования
                        dataGridView1.ReadOnly = false;
                        dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

                        MessageBox.Show("Режим редактирования включен.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при переключении режима редактирования: {ex.Message}");
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

            

        }

    }

}


