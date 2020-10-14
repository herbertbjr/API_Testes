using ProjetoTeste.Context;
using ProjetoTeste.Models;
using ProjetoTeste.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Repository
{
    public class ContratoRepository: Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public IEnumerable<Contrato> GetContratos()
        {
            return Get().ToList();
        }
    }
}
