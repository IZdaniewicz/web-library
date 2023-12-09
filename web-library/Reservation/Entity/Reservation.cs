using System.ComponentModel.DataAnnotations.Schema;

namespace web_library.Reservation.Entity;

using System.ComponentModel.DataAnnotations;
using Book.Entity;
using web_library.Book.Entity;

[Table("reservations")]
public class Reservation
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("reservation_start_date")]
    public DateOnly reservationStartDate { get; set; }

    [Column("reservation_end_date")]
    public DateOnly reservationEndDate { get; set; }

    [Column("book_copy_id")]
    public int bookCopyId { get; set; }

    public BookCopy bookCopy { get; set; } = null!;

    public Reservation() { }

    public Reservation(DateOnly reservationStartDate, DateOnly reservationEndDate, int bookCopyId)
    {
        this.reservationStartDate = reservationStartDate;
        this.reservationEndDate = reservationEndDate;
        this.bookCopyId = bookCopyId;
    }
}
