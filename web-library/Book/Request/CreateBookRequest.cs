namespace web_library.Book.Request
{
    public class CreateBookRequest
    {
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public DateOnly publication_date { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public int numberOfCopies { get; set; }

    }
}
