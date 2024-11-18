using System.Collections.Generic;
using Model;

using Controller.DataHandler;

namespace Controller
{
    public class ClaseController
    {
        private readonly JsonDataHandler<Clase> _dataHandler;

        public ClaseController()
        {
            _dataHandler = new JsonDataHandler<Clase>("Assets/Clases.json");
        }

        public List<Clase> GetClases()
        {
            return _dataHandler.GetAll();
        }

        public void SaveClases(List<Clase> clases)
        {
            _dataHandler.SaveAll(clases);
        }

        public void AddClase(Clase clase)
        {
            var clases = GetClases();
            clases.Add(clase);
            SaveClases(clases);
        }
    }
}
