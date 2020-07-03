using FavoDeMel.Infrastructure.Abstractions;
using FavoDeMel.Infrastructure.Data;

namespace FavoDeMel.Infrastructure.Transaction
{
    public class Uow : IUow
    {
        private readonly DatabaseContext _context;

        public Uow(DatabaseContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}