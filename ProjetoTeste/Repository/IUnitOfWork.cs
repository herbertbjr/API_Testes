using System.Threading.Tasks;

namespace ProjetoTeste.Repository
{
    public interface IUnitOfWork
    {
        IContratoRepository ContratoRepository { get; }
        Task Commit();
    }
}
