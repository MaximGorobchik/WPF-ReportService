using ReportServiceWPF.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Page_Navigation_App.View
{
    /// <summary>
    /// Логика взаимодействия для AddCategoryForm.xaml
    /// </summary>
    public partial class AddCategoryForm: Window
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }
        public Categories GetCategories()
        {
            int id = int.Parse(idTextBox.Text);
            string name = nameTextBox.Text;
            int departmentID = int.Parse(departmentTextBox.Text);

            // Створити новий об'єкт користувача
            Categories newCategory = new Categories(id, name, departmentID);
            return newCategory;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевірити, чи заповнені всі поля
            if (string.IsNullOrEmpty(idTextBox.Text) ||
                string.IsNullOrEmpty(nameTextBox.Text) ||
                string.IsNullOrEmpty(departmentTextBox.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
            }
            else
            {
                DialogResult = true;
                Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
