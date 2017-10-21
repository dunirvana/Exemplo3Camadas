using Barao.Exemplo3Camadas.DAL.Context;
using Barao.Exemplo3Camadas.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.SqlServer;
using System;

namespace Barao.Exemplo3Camadas.DAL
{
    public class ClienteDAO : IDisposable
    {
        private BaseContext db = new BaseContext();

        public List<ClienteDTO> SelecionarTodos()
        {
            return db.Clientes.ToList();
        }

        public ClienteDTO SelecionarPorId(int id)
        {
            return db.Clientes.Find(id);
        }

        public bool Inserir(ClienteDTO cliente)
        {
            db.Clientes.Add(cliente);
            return db.SaveChanges() > 0; //o retorno do "SaveChanges" é o numero de registros envolvidos na operação, logo se maior que zero obteve sucesso
        }

        public bool Atualizar(ClienteDTO cliente)
        {
            db.Entry(cliente).State = EntityState.Modified;
            return db.SaveChanges() > 0; //o retorno do "SaveChanges" é o numero de registros envolvidos na operação, logo se maior que zero obteve sucesso
        }

        public bool Remover(int id)
        {
            var cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            return db.SaveChanges() > 0; //o retorno do "SaveChanges" é o numero de registros envolvidos na operação, logo se maior que zero obteve sucesso
        }

        internal static class MissingDllHack
        {
            // Must reference a type in EntityFramework.SqlServer.dll so that this dll will be
            // included in the output folder of referencing projects without requiring a direct 
            // dependency on Entity Framework. See http://stackoverflow.com/a/22315164/1141360.
            private static SqlProviderServices instance = SqlProviderServices.Instance;
        }


        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}
