namespace web_library.Reservation.Service;
using Book.Entity;
using Book.Repository;
using Entity;
using Repostiory;
using Request;
using web_library.Book.Entity;
using web_library.Book.Repository;
using web_library.Reservation.Entity;
using web_library.Reservation.Repostiory;
using web_library.Reservation.Request;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IBookCopyRepository _bookCopyRepository;

    public ReservationService(IReservationRepository reservationRepository, IBookCopyRepository bookCopyRepository)
    {
        _reservationRepository = reservationRepository;
        _bookCopyRepository = bookCopyRepository;
    }

    public void createReservation(CreateReservationRequest request)
    {
        BookCopy bookCopy = _bookCopyRepository.FindByIdOrThrow(request.book_copy_id);
        Reservation reservation = new(request.reservation_start_date, request.reservation_end_date, request.book_copy_id);
        _reservationRepository.Add(reservation);
    }
}
