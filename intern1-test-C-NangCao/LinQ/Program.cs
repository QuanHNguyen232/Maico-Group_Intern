using System;
using System.Collections.Generic;
using System.Linq;


namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinQ test:");

            var bookList = new List<Book>() {
                new Book(1, "Ca phe buoi sang", 90.502, "Tuoi Tre", 2019),
                new Book(2, "Tren duong bang", 101.208, "Tuoi Tre", 2020),
                new Book(3, "Harvard 4 ruoi sang", 119.901, "Nha Nam", 2018),
                new Book(4, "Think and Grow Rich", 150.008, "First News", 2015),
                new Book(5, "Nha gia kim", 84.101, "Nha Nam", 2019),
                new Book(6, "Hanh trinh ve phuong dong", 94.005, "First News", 2019),
                new Book(7, "Nha dau tu thong minh", 201.020, "Nha Nam", 2017),
            };

            Console.WriteLine("Published after 2018: ");
            var list = bookList.myQuery(b => b.PublishingYear > 2018);
            foreach (var _book in list)
            {
                Console.WriteLine(_book);
            }

            Console.WriteLine("\nCheaper than 100.000 VND: ");
            var list2 = bookList.Where(b => b.Price < 100.000).Select(b => $"{b.Name}: {b.Price}");
            foreach (var b in list2)
            {
                Console.WriteLine(b);
            }
        }
    }

    public class Book
    {
        public int ID { set; get; }
        public string Name { set; get; }         // ten sach
        public double Price { set; get; }        // gia
        public string Publisher { set; get; }    // nha xuat ban
        public int PublishingYear { set; get; }  // nam phat hanh
        public Book(int id, string name, double price, string publisher, int pubYear)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Publisher = publisher;
            this.PublishingYear = pubYear;
        }

        override public string ToString()
           => $"Book no.{ID}: {Name}, co gia: {Price}(VND), phat hanh boi NXB {Publisher} ({PublishingYear})";

    }

    public static class Book_Brand
    {
        public static IEnumerable<T> myQuery<T>(this IEnumerable<T> list, Func<T, bool> myCondition)
        {
            foreach (var item in list)
            {
                if (myCondition(item)) yield return item;
            }
        }
    }
}
