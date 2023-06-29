using Page_Navigation_App.View;
using ReportServiceWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ReportServiceProjectWPF.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView
    {
        private List<Categories> categoryList;
        public CategoriesView()
        {
            InitializeComponent();
            categoryList = GetCategoryList();
            userGrid.ItemsSource = categoryList;
        }
        private List<Categories> GetCategoryList()
        {
            List<Categories> categories = new List<Categories>();

            string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categories";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int departmentId = reader.GetInt32(2);

                    Categories newCategory = new Categories(id, name, departmentId);
                    categories.Add(newCategory);
                }

                reader.Close();
            }

            return categories;
        }
        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryForm categoryForm = new AddCategoryForm();
            if (categoryForm.ShowDialog() == true)
            {
                Categories newCategory = categoryForm.GetCategories();

                // Підключення до бази даних
                string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Створення SQL-запиту INSERT для додавання нового користувача
                    string query = "INSERT INTO Categories (ID, Name, DepartmentID) VALUES (@ID, @Name, @DepartmentID)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передача значень параметрів в запит
                        command.Parameters.AddWithValue("@ID", newCategory.ID);
                        command.Parameters.AddWithValue("@Name", newCategory.Name);
                        command.Parameters.AddWithValue("@DepartmentID", newCategory.DepartmentID);

                        // Виконання запиту INSERT
                        command.ExecuteNonQuery();
                    }
                }

                // Додавання нового користувача до списку та оновлення DataGrid
                categoryList.Add(newCategory);
                userGrid.ItemsSource = null;
                userGrid.ItemsSource = categoryList;
            }
        }
        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Categories selectedCategory = userGrid.SelectedItem as Categories;
            EditCategoryForm editCategoryForm = new EditCategoryForm(selectedCategory);
            if (selectedCategory != null)
            {
                if (editCategoryForm.ShowDialog() == true)
                {
                    Categories updatedCategory = editCategoryForm.GetEditedCategory();

                    // Підключення до бази даних
                    string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Створення SQL-запиту UPDATE для оновлення користувача
                        string query = "UPDATE Categories SET Name = @Name, DepartmentID = @DepartmentID WHERE ID = @ID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Передача значень параметрів в запит
                            command.Parameters.AddWithValue("@ID", updatedCategory.ID);
                            command.Parameters.AddWithValue("@Name", updatedCategory.Name);
                            command.Parameters.AddWithValue("@DepartmentID", updatedCategory.DepartmentID);

                            // Виконання запиту UPDATE
                            command.ExecuteNonQuery();
                        }
                    }

                    // Оновлення відповідного користувача в списку та оновлення DataGrid
                    int index = categoryList.FindIndex(user => user.ID == updatedCategory.ID);
                    if (index != -1)
                    {
                        categoryList[index] = updatedCategory;
                        userGrid.ItemsSource = null;
                        userGrid.ItemsSource = categoryList;
                    }
                }
            }
        }
        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Categories selectedCategory = userGrid.SelectedItem as Categories;
            if (selectedCategory != null)
            {
                // Підключення до бази даних
                string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Створення SQL-запиту DELETE для видалення користувача
                    string query = "DELETE FROM Categories WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передача значення параметра в запит
                        command.Parameters.AddWithValue("@ID", selectedCategory.ID);

                        // Виконання запиту DELETE
                        command.ExecuteNonQuery();
                    }
                }

                // Видалення користувача зі списку та оновлення DataGrid
                categoryList.Remove(selectedCategory);
                userGrid.ItemsSource = null;
                userGrid.ItemsSource = categoryList;
            }
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchUsers(searchTextBox.Text.Trim());
        }

        private void SearchUsers(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                List<Categories> searchResults = categoryList.Where(category =>
                    category.Name.Contains(searchText) ||
                    category.DepartmentID.ToString().Contains(searchText)).ToList();
                userGrid.ItemsSource = searchResults;
            }
            else
            {
                userGrid.ItemsSource = categoryList;
            }
        }
    }
}
