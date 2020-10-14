using ProjetoTeste.Models;
using ProjetoTeste.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.Repository
{
    public interface IContratoRepository : IRepository<Contrato>
    {
        IEnumerable<Contrato> GetContratos();
    }
}
