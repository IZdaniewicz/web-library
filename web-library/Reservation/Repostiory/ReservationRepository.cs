namespace web_library.Reservation.Repostiory;
using Microsoft.EntityFrameworkCore;
using SharedExceptions;
using Entity;
public class ReservationRepository : IReservationRepository
{
    private readonly DataContext _context;

    public ReservationRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(Reservation entity)
    {
        _context.Reservations.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Reservation> FindAll()
    {
        return _context.Reservations
            .Include(b => b.bookCopy)
            .ThenInclude(b => b.Book)
            .ToList();
    }

    public Reservation FindByIdOrThrow(int id)
    {
        return _context.Reservations.Find(id) ?? throw new NotFoundException("Reservation " + id + " not found in repository");
    }

    public void Remove(Reservation entity)
    {
        throw new NotImplementedException();
    }
}
