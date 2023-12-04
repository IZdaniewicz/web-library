using web_library.Api.Reservation.Request;

namespace web_library.Api.Reservation.Service
{
    public interface IReservationService
    {
        void createReservation(CreateReservationRequest request);
    }
}