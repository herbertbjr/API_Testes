using ProjetoTeste.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ContratoRepository _contratoRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IContratoRepository ContratoRepository
        {
            get
            {
                return _contratoRepo = _contratoRepo ?? new ContratoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
