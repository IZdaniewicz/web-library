using System;

namespace web_library.Book.Request
{
    public class CreateBookRequest
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateOnly Publication_date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
