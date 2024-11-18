
using System.Collections.Generic;
using Controller.DataHandler;
using Model;

namespace Controller
{
    public class EntrenadorController
    {
        private readonly JsonDataHandler<Entrenador> _dataHandler;

        public EntrenadorController()
        {
            _dataHandler = new JsonDataHandler<Entrenador>("Assets/Entrenadores.json");
        }

        public List<Entrenador> GetEntrenadores()
        {
            return _dataHandler.GetAll();
        }

        public void SaveEntrenadores(List<Entrenador> entrenadores)
        {
            _dataHandler.SaveAll(entrenadores);
        }

        public void AddEntrenador(Entrenador entrenador)
        {
            var entrenadores = GetEntrenadores();
            entrenadores.Add(entrenador);
            SaveEntrenadores(entrenadores);
        }

        public void RemoveEntrenador(string entrenadorId)
        {
            var entrenadores = GetEntrenadores();
            entrenadores.RemoveAll(e => e.Id == entrenadorId);
            SaveEntrenadores(entrenadores);
        }

        public Entrenador GetEntrenadorById(string entrenadorId)
        {
            return _dataHandler.GetById(entrenadorId);
        }
    }
}
