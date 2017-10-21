using Barao.Exemplo3Camadas.DTO;
using System.Data.Entity;

namespace Barao.Exemplo3Camadas.DAL.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext()
            : base("exemplo3camadas")
        {
        }

        public DbSet<ClienteDTO> Clientes { get; set; }
    }
}
