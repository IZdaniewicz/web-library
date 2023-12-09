namespace web_library.Reservation.DataProvider;

using Entity;
using System.Security.Policy;
using web_library.Book.Repository;
using web_library.Reservation.Model;
using web_library.Reservation.Repostiory;

public class ReservationDataProvider : IReservationDataProvider
{
    private readonly IReservationRepository _reservationRepository;
    //private readonly IBookRepository _bookRepository;

    public ReservationDataProvider(IReservationRepository reservationRepository, IBookRepository bookRepository)
    {
        _reservationRepository = reservationRepository;
        //_bookRepository = bookRepository;
    }

    private ReservationModel getModel(Reservation entity)
    {
        return new ReservationModel(
                entity.Id,
                entity.bookCopy.Book.Id,
                entity.bookCopy.Book.ISBN,
                entity.bookCopy.Book.Title,
                entity.bookCopy.Book.Author,
                entity.bookCopy.Book.Publisher,
                entity.bookCopy.Book.Publication_date,
                entity.bookCopyId,
                entity.reservationStartDate,
                entity.reservationEndDate
            );
    }
    public IEnumerable<ReservationModel> GetAll()
    {
        List<ReservationModel> list = new();
        foreach (var item in _reservationRepository.FindAll())
        {
            list.Add(getModel(item));
        }
        return list;
    }



}
