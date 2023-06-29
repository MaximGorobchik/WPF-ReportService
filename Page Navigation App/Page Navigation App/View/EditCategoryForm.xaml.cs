using ReportServiceWPF.Model;
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

namespace Page_Navigation_App.View
{
    /// <summary>
    /// Логика взаимодействия для EditCategoryForm.xaml
    /// </summary>
    public partial class EditCategoryForm : Window
    {
        private Categories categories;
        public EditCategoryForm(Categories categorytoEdit)
        {
            InitializeComponent();
            categories = categorytoEdit;
            nameTextBox.Text = categories.Name;
            departmentTextBox.Text = categories.DepartmentID.ToString();
        }
        public Categories GetEditedCategory()
        {
            // Отримати відредаговані дані з форми
            categories.Name = nameTextBox.Text;
            categories.DepartmentID = Convert.ToInt32(departmentTextBox.Text);

            return categories;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевірити, чи заповнені всі поля
            if (string.IsNullOrEmpty(nameTextBox.Text) ||
                string.IsNullOrEmpty(departmentTextBox.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
            }
            else
            {
                // Оновити значення користувача
                categories.Name = nameTextBox.Text;
                categories.DepartmentID = int.Parse(departmentTextBox.Text);

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
