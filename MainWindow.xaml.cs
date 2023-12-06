using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WpfApp6111
{
    public partial class MainWindow : Window
    {
        private Book book;

        public MainWindow()
        {
            InitializeComponent();
            book = new Book();
            contactDataGrid.ItemsSource = book.Contacts;
            this.KeyDown += MainWindow_KeyDown;
        }

        // Обробник подій для гарячих клавіш
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.N:
                        SearchContacts();
                        break;
                    case Key.M:
                        AddContact();
                        break;
                    case Key.B:
                        SortByName();
                        break;
                    case Key.O:
                        SortByLastModified();
                        break;
                }
            }
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            AddContact();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchContacts();
        }

        private void SortByNameButton_Click(object sender, RoutedEventArgs e)
        {
            SortByName();
        }

        private void SortByLastModifiedButton_Click(object sender, RoutedEventArgs e)
        {
            SortByLastModified();
        }

        // Метод для здійснення пошуку за іменем
        private void SearchContacts()
        {
            string searchPattern = searchTextBox.Text;  // Отримання даниз з поля введення 
            List<Contact> searchResults = book.SearchContacts(searchPattern); // Метод пошуку по книзі
            contactDataGrid.ItemsSource = searchResults;  // Відображення результатів у таблиці зверху
        }

        // Метод для додавання контакту
        private void AddContact()
        {
            try
            {
                // Отримання даних з елементів форми 
                Contact newContact = new Contact(
                    nameTextBox.Text,
                    addressTextBox.Text,
                    phoneTextBox.Text,
                    workplaceTextBox.Text,
                    positionTextBox.Text,
                    relationshipTextBox.Text,
                    introductionTextBox.Text,
                    businessQualitiesTextBox.Text
                );

                book.AddContact(newContact);  // Додавання нового контакту до адресної книги.
                book.SortByLastModified();
                contactDataGrid.ItemsSource = null;
                contactDataGrid.ItemsSource = book.Contacts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні контакту: {ex.Message}",
                    "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Метод для впорядкування за іменем
        private void SortByName()
        {
            book.SortByName();
            contactDataGrid.ItemsSource = null;
            contactDataGrid.ItemsSource = book.Contacts;
        }

        // Метод для впорядкування за датою останнього коригування
        private void SortByLastModified()
        {
            book.SortByLastModified();
            contactDataGrid.ItemsSource = null;
            contactDataGrid.ItemsSource = book.Contacts;
        }

        // Метод для видалення контакту за іменем
        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameToDelete = deleteNameTextBox.Text;
                if (string.IsNullOrWhiteSpace(nameToDelete))
                {
                    MessageBox.Show("Будь ласка, введіть ім'я для видалення контакту.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Contact contactToDelete = book.Contacts.FirstOrDefault(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

                if (contactToDelete == null)
                {
                    MessageBox.Show($"Контакт з іменем '{nameToDelete}' не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                book.Contacts.Remove(contactToDelete);
                MessageBox.Show($"Контакт '{nameToDelete}' видалено успішно.", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
                contactDataGrid.ItemsSource = null;
                contactDataGrid.ItemsSource = book.Contacts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні контакту: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}



