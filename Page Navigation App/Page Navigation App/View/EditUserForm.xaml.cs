
using ReportServiceWPF.Model;
using System;
using System.Windows;

namespace ReportServiceProjectWPF.MVVM.Views
{
    public partial class EditUserForm : Window
    {
        private Users user;

        public EditUserForm(Users userToEdit)
        {
            InitializeComponent();
            user = userToEdit;

            // Заповнити поля форми існуючими значеннями користувача
            usernameTextBox.Text = user.Username;
            nameTextBox.Text = user.Name;
            passwordBox.Password = user.Password;
            birthdatePicker.SelectedDate = user.Birthdate;
            ageTextBox.Text = user.Age.ToString();
            emailTextBox.Text = user.Email;

        }
        public Users GetEditedUser()
        {
            // Отримати відредаговані дані з форми
            user.Username = usernameTextBox.Text;
            user.Name = nameTextBox.Text;
            user.Password = passwordBox.Password;
            user.Birthdate = birthdatePicker.SelectedDate ?? DateTime.MinValue;
            user.Age = Convert.ToInt32(ageTextBox.Text);
            user.Email = emailTextBox.Text;

            return user;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Перевірити, чи заповнені всі поля
            if (string.IsNullOrEmpty(usernameTextBox.Text) ||
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
                // Оновити значення користувача
                user.Username = usernameTextBox.Text;
                user.Name = nameTextBox.Text;
                user.Password = passwordBox.Password;
                user.Birthdate = birthdatePicker.SelectedDate ?? DateTime.MinValue;
                user.Age = int.Parse(ageTextBox.Text);
                user.Email = emailTextBox.Text;

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
