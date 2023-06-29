using ReportServiceWPF.Model;
using System;
using System.Windows;

namespace ReportServiceProjectWPF.MVVM.Views
{
    public partial class AddUserForm : Window
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        public Users GetUser()
        {
            int id = int.Parse(idTextBox.Text);
            string username = usernameTextBox.Text;
            string name = nameTextBox.Text;
            string password = passwordBox.Password;
            DateTime birthdate = birthdatePicker.SelectedDate ?? DateTime.MinValue;
            int age = int.Parse(ageTextBox.Text);
            string email = emailTextBox.Text;

            // Створити новий об'єкт користувача
            Users newUser = new Users(id, username, name, password, birthdate, age, email);
            return newUser;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевірити, чи заповнені всі поля
            if (string.IsNullOrEmpty(idTextBox.Text) ||
                string.IsNullOrEmpty(usernameTextBox.Text) ||
                string.IsNullOrEmpty(nameTextBox.Text) ||
                string.IsNullOrEmpty(passwordBox.Password) ||
                birthdatePicker.SelectedDate == null ||
                string.IsNullOrEmpty(ageTextBox.Text) ||
                string.IsNullOrEmpty(emailTextBox.Text))
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
