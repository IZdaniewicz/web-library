
namespace web_library.Api.Reservation.Request;
public class CreateReservationRequest
{
    public int book_copy_id { get; set; }
    public DateOnly reservation_start_date { get; set; }
    public DateOnly reservation_end_date { get; set; }
    public CreateReservationRequest()
    {
        reservation_start_date = new();
        reservation_end_date = new();
    }
}
