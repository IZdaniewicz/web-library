using web_library.Reservation.Model;

namespace web_library.Reservation.DataProvider
{
    public interface IReservationDataProvider
    {
        IEnumerable<ReservationModel> GetAll();
    }
}