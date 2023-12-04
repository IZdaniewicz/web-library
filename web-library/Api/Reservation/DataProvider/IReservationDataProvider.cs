using web_library.Api.Reservation.Model;

namespace web_library.Api.Reservation.DataProvider
{
    public interface IReservationDataProvider
    {
        IEnumerable<ReservationModel> GetAll();
    }
}