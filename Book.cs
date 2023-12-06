using System.Collections.Generic;
using System.Linq;

namespace WpfApp6111
{

    // Клас книги
    public class Book
    {
        private List<Contact> contacts;
        public Book()
        {
            contacts = new List<Contact>();  // Конструктор.
        }

        // Доступ до контактів
        public List<Contact> Contacts
        {
            get { return contacts; }
        }

        // Додавання контактів
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        // Впорядкування за датою останнього коригування
        public void SortByLastModified()
        {
            contacts = contacts.OrderByDescending(c => c.LastModified).ToList();
        }

        // Впорядкування за іменем. Алфавітний порядок
        public void SortByName()
        {
            contacts = contacts.OrderBy(c => c.Name).ToList();
        }

        // Пошук за шаблоном (за іменем контакту)
        public List<Contact> SearchContacts(string pattern)
        {
            return contacts.Where(c => c.Name.Contains(pattern) || c.Address.Contains(pattern)).ToList();
        }
    }
}
