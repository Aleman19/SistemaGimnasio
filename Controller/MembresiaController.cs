
using System.Collections.Generic;
using Controller.DataHandler;
using Model;

namespace Controller
{
    public class MembresiaController
    {
        private readonly JsonDataHandler<Membresia> _dataHandler;

        public MembresiaController()
        {
            _dataHandler = new JsonDataHandler<Membresia>("Assets/Membresias.json");
        }

        public List<Membresia> GetMembresias()
        {
            return _dataHandler.GetAll();
        }

        public void SaveMembresias(List<Membresia> membresias)
        {
            _dataHandler.SaveAll(membresias);
        }

        public void AddMembresia(Membresia membresia)
        {
            var membresias = GetMembresias();
            membresias.Add(membresia);
            SaveMembresias(membresias);
        }

        public void RemoveMembresia(string membresiaId)
        {
            var membresias = GetMembresias();
            membresias.RemoveAll(m => m.Id == membresiaId);
            SaveMembresias(membresias);
        }

        public Membresia GetMembresiaById(string membresiaId)
        {
            return _dataHandler.GetById(membresiaId);
        }
    }
}

