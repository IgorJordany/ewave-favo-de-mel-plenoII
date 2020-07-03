using Favo_de_mel.Infrastructure.Abstractions;
using Favo_de_mel.Infrastructure.Data;

namespace Favo_de_mel.Infrastructure.Transaction
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