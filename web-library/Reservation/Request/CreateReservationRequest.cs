using System.Text.Json.Serialization;

namespace web_library.Reservation.Request;
public class CreateReservationRequest
{
    public int book_copy_id { get; set; }
    public DateOnly reservation_start_date { get; set; }
    public CreateReservationRequest()
    {
        reservation_start_date = new();
    }
}
