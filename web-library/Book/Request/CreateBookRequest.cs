using System;

namespace web_library.Book.Request
{
    public class CreateBookRequest
    {
<<<<<<< HEAD
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public DateOnly publication_date { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public int numberOfCopies { get; set; }

        public CreateBookRequest() { }
        public CreateBookRequest(string type)
        {
            List<long> isbnList = new() { 9780439023528, 9780747532743, 9780451524935, 9780618260300, 9780141439600 };
            List<string> titleList = new() { "The Hunger Games", "Harry Potter and the Philosopher's Stone", "1984", "The Hobbit", "Pride and Prejudice" };
            List<string> authorList = new() { "Suzanne Collins", "J.K. Rowling", "George Orwell", "J.R.R. Tolkien", "Jane Austen" };
            List<string> publisherList = new() { "Scholastic Press", "Bloomsbury", "Harcourt Brace Jovanovich", "Houghton Mifflin", "Penguin Books" };
            List<string> publication_dateList = new() { "September 14, 2008", "June 26, 1997", "June 8, 1949", "September 21, 1937", "January 28, 1813" };
            List<string> locationList = new() { "United States", "United Kingdom", "United Kingdom", "United Kingdom", "United Kingdom" };
            List<string> descriptionList = new() { "A dystopian novel set in a post-apocalyptic society in the country of Panem.", "The first novel in the Harry Potter series and Rowling's debut novel.", "A dystopian social science fiction novel and a cautionary tale of a totalitarian regime.", "A children's fantasy novel and prelude to the Lord of the Rings series.", "A romantic novel of manners depicting the society of early 19th-century England." };
            List<int> numberOfCopiesList = new() { 5, 10, 15, 20, 25 };

            Random r = new Random();
            int bookNumber = r.Next(0, 5);
            isbn = isbnList[bookNumber].ToString();
            title = titleList[bookNumber];
            author = authorList[bookNumber];
            publisher = publisherList[bookNumber];
            publication_date = DateOnly.Parse(publication_dateList[r.Next(0, 5)]);
            location = locationList[bookNumber];
            description = descriptionList[bookNumber];
            numberOfCopies = numberOfCopiesList[bookNumber];
        }
=======
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateOnly Publication_date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
>>>>>>> master
    }
}
