using System.Collections.Generic;
using Controller.DataHandler;
using Model;

namespace Controller
{
    public class ClienteController
    {
        private readonly JsonDataHandler<Cliente> _dataHandler;

        public ClienteController()
        {
            _dataHandler = new JsonDataHandler<Cliente>("Assets/Clientes.json");
        }

        public List<Cliente> GetClientes()
        {
            return _dataHandler.GetAll();
        }

        public void SaveClientes(List<Cliente> clientes)
        {
            _dataHandler.SaveAll(clientes);
        }

        public void AddCliente(Cliente cliente)
        {
            var clientes = GetClientes();
            clientes.Add(cliente);
            SaveClientes(clientes);
        }

        public void RemoveCliente(string clienteId)
        {
            var clientes = GetClientes();
            clientes.RemoveAll(c => c.Id == clienteId);
            SaveClientes(clientes);
        }

        public Cliente GetClienteById(string clienteId)
        {
            return _dataHandler.GetById(clienteId);
        }
    }
}
