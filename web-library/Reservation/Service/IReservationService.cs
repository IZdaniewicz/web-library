using web_library.Reservation.Request;

namespace web_library.Reservation.Service
{
    public interface IReservationService
    {
        void createReservation(CreateReservationRequest request);
    }
}