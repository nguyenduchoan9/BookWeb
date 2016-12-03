using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookManagement
{
    public class Book : IComparable<Book>
    {
        string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _publisher;

        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public override string ToString()
        {
            string str = string.Format("ID: {0}, Name: {1}, Publisher: {2}, Price: {3}", _ID, _name, _publisher, _price);
            return str;
        }

        public Book() { }

        public Book(string id, string name, string publisher, int price)
        {
            _ID = id;
            _name = name;
            _publisher = publisher;
            _price = price;
        }

        public override bool Equals(object obj)
        {
            Book anotherBook = (Book)obj;
            return _ID.Equals(anotherBook._ID);
        }

        public int CompareTo(Book anotherBook)
        {
            return this._price.CompareTo(anotherBook._price);
        }
    }
    class NameComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class BookManager
    {
        List<Book> list = new List<Book>();

        public void addBook(string id, string name, string publisher, int price)
        {
            Book book = new Book(id, name, publisher, price);

            if (!list.Contains(book))
            {
                list.Add(book);
            }
            else
            {
                Console.WriteLine("This book is existed!");
            }
        }

        public void update(Book book, string name, string publisher, int price)
        {
            book.Name = name;
            book.Publisher = publisher;
            book.Price = price;
        }

        public void delete(Book book)
        {
            list.Remove(book);
        }

        public Book searchbyName(string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    return list[i];
                }
            }
            return null;
        }

        public void displayByName()
        {
            IComparer<Book> book = new NameComparer();
            list.Sort(book);
            displayAll();
        }

        public void displayByPrice()
        {
            list.Sort();
            displayAll();
        }

        public void displayAll()
        {
            foreach (Book b in list)
            {
                Console.WriteLine(b);
            }
        }


        public Book searchByID(string id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == id)
                {
                    return list[i];
                }
            }
            return null;
        }

    }
}


