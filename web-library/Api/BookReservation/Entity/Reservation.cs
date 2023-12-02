using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Api.BookReservation.Entity
{
    using System.ComponentModel.DataAnnotations;
    using web_library.Api.Book.Entity;
    [Table("reservations")]
    public class Reservation
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("reservation_start_date")]
        public DateOnly reservationStartDate { get; }
        [Column("reservation_end_date")]
        public DateOnly reservationEndDate { get; }
        [Column("book_copy_id")]
        public int bookCopyId { get; set; }
        public BookCopy bookCopy { get; set; } = null!;

        public Reservation()
        {
            reservationStartDate = new();
            reservationEndDate = reservationStartDate.AddMonths(+1);
        }
        public Reservation(BookCopy book)
        {
            bookCopy = book;
        }
    }
}
