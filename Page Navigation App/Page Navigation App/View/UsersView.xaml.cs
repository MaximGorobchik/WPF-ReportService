using ReportServiceWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ReportServiceProjectWPF.MVVM.Views
{
    public partial class UsersView
    {
        private List<Users> userList;

        public UsersView()
        {
            InitializeComponent();
            userList = GetUserList(); // Отримати список користувачів з бази даних
            userGrid.ItemsSource = userList; // Прив'язка списку користувачів до DataGrid
        }

        private List<Users> GetUserList()
        {
            List<Users> users = new List<Users>();

            string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string username = reader.GetString(1);
                    string name = reader.GetString(2);
                    string password = reader.GetString(3);
                    DateTime birthdate = reader.GetDateTime(4);
                    int age = reader.GetInt32(5);
                    string email = reader.GetString(6);

                    Users user = new Users(id, username, name, password, birthdate, age, email);
                    users.Add(user);
                }

                reader.Close();
            }

            return users;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() == true)
            {
                Users newUser = addUserForm.GetUser();

                // Підключення до бази даних
                string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Створення SQL-запиту INSERT для додавання нового користувача
                    string query = "INSERT INTO Users (ID, Username, Name, Password, Birthdate, Age, Email) VALUES (@ID, @Username, @Name, @Password, @Birthdate, @Age, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передача значень параметрів в запит
                        command.Parameters.AddWithValue("@ID", newUser.ID);
                        command.Parameters.AddWithValue("@Username", newUser.Username);
                        command.Parameters.AddWithValue("@Name", newUser.Name);
                        command.Parameters.AddWithValue("@Password", newUser.Password);
                        command.Parameters.AddWithValue("@Birthdate", newUser.Birthdate);
                        command.Parameters.AddWithValue("@Age", newUser.Age);
                        command.Parameters.AddWithValue("@Email", newUser.Email);

                        // Виконання запиту INSERT
                        command.ExecuteNonQuery();
                    }
                }

                // Додавання нового користувача до списку та оновлення DataGrid
                userList.Add(newUser);
                userGrid.ItemsSource = null;
                userGrid.ItemsSource = userList;
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUser = userGrid.SelectedItem as Users;
            EditUserForm editUserForm = new EditUserForm(selectedUser);
            if (selectedUser != null)
            {
                if (editUserForm.ShowDialog() == true)
                {
                    Users updatedUser = editUserForm.GetEditedUser();

                    // Підключення до бази даних
                    string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Створення SQL-запиту UPDATE для оновлення користувача
                        string query = "UPDATE Users SET Username = @Username, Name = @Name, Password = @Password, Birthdate = @Birthdate, Age = @Age, Email = @Email WHERE ID = @ID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Передача значень параметрів в запит
                            command.Parameters.AddWithValue("@ID", updatedUser.ID);
                            command.Parameters.AddWithValue("@Username", updatedUser.Username);
                            command.Parameters.AddWithValue("@Name", updatedUser.Name);
                            command.Parameters.AddWithValue("@Password", updatedUser.Password);
                            command.Parameters.AddWithValue("@Birthdate", updatedUser.Birthdate);
                            command.Parameters.AddWithValue("@Age", updatedUser.Age);
                            command.Parameters.AddWithValue("@Email", updatedUser.Email);

                            // Виконання запиту UPDATE
                            command.ExecuteNonQuery();
                        }
                    }

                    // Оновлення відповідного користувача в списку та оновлення DataGrid
                    int index = userList.FindIndex(user => user.ID == updatedUser.ID);
                    if (index != -1)
                    {
                        userList[index] = updatedUser;
                        userGrid.ItemsSource = null;
                        userGrid.ItemsSource = userList;
                    }
                }
            }
        }


        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUser = userGrid.SelectedItem as Users;
            if (selectedUser != null)
            {
                // Підключення до бази даних
                string connectionString = "Data Source=FSB\\MYSERVER;Initial Catalog=ReportService;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Створення SQL-запиту DELETE для видалення користувача
                    string query = "DELETE FROM Users WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передача значення параметра в запит
                        command.Parameters.AddWithValue("@ID", selectedUser.ID);

                        // Виконання запиту DELETE
                        command.ExecuteNonQuery();
                    }
                }

                // Видалення користувача зі списку та оновлення DataGrid
                userList.Remove(selectedUser);
                userGrid.ItemsSource = null;
                userGrid.ItemsSource = userList;
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
                List<Users> searchResults = userList.Where(user =>
                    user.Username.Contains(searchText) ||
                    user.Name.Contains(searchText) ||
                    user.Email.Contains(searchText) ||
                    user.Age.ToString().Contains(searchText) ||
                    user.Password.Contains(searchText) ||
                    user.Birthdate.ToString().Contains(searchText) ||
                    user.ID.ToString().Contains(searchText)).ToList();

                userGrid.ItemsSource = searchResults;
            }
            else
            {
                userGrid.ItemsSource = userList;
            }
        }

    }
}
