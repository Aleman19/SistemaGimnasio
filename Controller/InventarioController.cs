using System.Collections.Generic;
using Controller.DataHandler;
using Model;

namespace Controller
{
    public class InventarioController
    {
        private readonly JsonDataHandler<Inventario> _dataHandler;

        public InventarioController()
        {
            _dataHandler = new JsonDataHandler<Inventario>("Assets/Inventario.json");
        }

        public List<Inventario> GetInventario()
        {
            return _dataHandler.GetAll();
        }

        public void SaveInventario(List<Inventario> inventario)
        {
            _dataHandler.SaveAll(inventario);
        }

        public void AddItem(Inventario item)
        {
            var inventario = GetInventario();
            inventario.Add(item);
            SaveInventario(inventario);
        }

        public void RemoveItem(string itemId)
        {
            var inventario = GetInventario();
            inventario.RemoveAll(i => i.Id == itemId);
            SaveInventario(inventario);
        }

        public Inventario GetItemById(string itemId)
        {
            return _dataHandler.GetById(itemId);
        }
    }
}
