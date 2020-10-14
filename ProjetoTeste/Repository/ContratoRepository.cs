using ProjetoTeste.Context;
using ProjetoTeste.Models;
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
    }
}
