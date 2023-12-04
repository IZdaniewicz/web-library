using Microsoft.EntityFrameworkCore;

namespace web_library.Api.Reservation.Repostiory
{
    using Entity;
    using Shared;

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
            return _context.Reservations.Find(id) ?? throw new NotFoundException("Reservation not found repository");
        }

        public void Remove(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
