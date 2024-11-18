using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.DataHandler;


namespace Controller
{
    public class ClienteController
    {
        private readonly JsonDataHandler<Cliente> _dataHandler;
        private readonly string _fileName = "Clientes.json";

        public ClienteController()
        {
            _dataHandler = new JsonDataHandler<Cliente>();
        }

        public List<Cliente> GetClientes()
        {
            var data = _dataHandler.ReadData(_fileName);
            return string.IsNullOrEmpty(data) ? new List<Cliente>() : Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cliente>>(data);
        }

        public void SaveClientes(List<Cliente> clientes)
        {
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(clientes, Newtonsoft.Json.Formatting.Indented);
            _dataHandler.WriteData(_fileName, jsonData);
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
    }
}
