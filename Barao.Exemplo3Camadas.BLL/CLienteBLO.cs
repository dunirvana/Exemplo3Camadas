using Barao.Exemplo3Camadas.DAL;
using Barao.Exemplo3Camadas.DTO;
using System;
using System.Collections.Generic;

namespace Barao.Exemplo3Camadas.BLL
{
    public class ClienteBLO : IDisposable
    {
        private ClienteDAO dal = new ClienteDAO();

        public List<ClienteDTO> SelecionarTodos()
        {
            return dal.SelecionarTodos();
        }

        public ClienteDTO SelecionarPorId(int? id)
        {
            if (id == null || id.Value <= 0)
                return null;

            return dal.SelecionarPorId(id.Value);
        }

        public bool Inserir(ClienteDTO cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.SobreNome))
                return false;

            return dal.Inserir(cliente);
        }

        public bool Atualizar(ClienteDTO cliente)
        {
            if (cliente == null || cliente.Id <= 0 || string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.SobreNome))
                return false;

            return dal.Atualizar(cliente);
        }

        public bool Remover(int? id)
        {
            if (id == null || id.Value <= 0)
                return false;

            return dal.Remover(id.Value);
        }

        public void Dispose()
        {
            if (dal != null)
            {
                dal.Dispose();
                dal = null;
            }
        }

    }
}
