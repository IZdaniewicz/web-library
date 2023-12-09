using web_library.Book.Entity;

namespace web_library.Reservation.Model
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateOnly Publication_date { get; set; }
        public int BookCopyId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ReservationModel() { }

        public ReservationModel(int reservationId, int bookId, string iSBN, string title, string author, string publisher, DateOnly publication_date, int bookCopyId, DateOnly startDate, DateOnly endDate)
        {
            ReservationId = reservationId;
            BookId = bookId;
            ISBN = iSBN;
            Title = title;
            Author = author;
            Publisher = publisher;
            Publication_date = publication_date;
            BookCopyId = bookCopyId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
