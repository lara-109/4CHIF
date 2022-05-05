using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_sqlite
{
    [Table(Name = "Book")]
    public class Book
    {
        [Column(IsPrimaryKey = true)] public int? ID { get; set; }
        [Column] public string Titel { get; set; }
        [Column] public int Year { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=try.db";

            SqliteConnection connection = new SqliteConnection(cs);
            DataContext db = new DataContext(connection);
            Table<Book> books = db.GetTable<Book>();

            var query = from p in books select p;
            foreach(var book in query)
            {
                Console.WriteLine(book.ID + " " + book.Titel + " " + book.Year);
            }

            books.InsertOnSubmit(new Book() { Titel = "text", Year = 1221 });
            db.SubmitChanges();

            foreach (var book in query)
            {
                Console.WriteLine(book.ID + " " + book.Titel + " " + book.Year);
            }

            Console.ReadKey();

        }
    }
}
