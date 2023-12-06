using System;

namespace WpfApp6111
{
    // Клас, який спадковується від базового класу
    public class Contact : Person
    {
        public string Workplace { get; set; }
        public string Position { get; set; }
        public string Relationship { get; set; }
        public string MeetingPlace { get; set; }
        public string BusinessQualities { get; set; }
        public DateTime LastModified { get; set; } // Поточний час.

        // Конструктор
        public Contact(string name, string address, string phone, string workplace, string position,
                       string relationship, string place, string businessQualities) : base()
        {
            Name = name;
            Address = address;
            Phone = phone;
            Workplace = workplace;
            Position = position;
            Relationship = relationship;
            MeetingPlace = place;
            BusinessQualities = businessQualities;
            LastModified = DateTime.Now;
        }

        // Перевантаження методу 
        public override string ToString()
        {
            return $"{Name} - {Phone}";
        }
    }
}
