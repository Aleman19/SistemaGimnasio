using System;
using System.Collections.Generic;
using Model;

using Controller.DataHandler;

namespace Controller
{
    public class ReservaController
    {
        private readonly JsonDataHandler<Reserva> _dataHandler;

        public ReservaController()
        {
            _dataHandler = new JsonDataHandler<Reserva>("Assets/Reservas.json");
        }

        public List<Reserva> GetReservas()
        {
            return _dataHandler.GetAll();
        }

        public void SaveReservas(List<Reserva> reservas)
        {
            _dataHandler.SaveAll(reservas);
        }

        public void AddReserva(Reserva reserva)
        {
            reserva.FechaReserva = DateTime.Now;
            var reservas = GetReservas();
            reservas.Add(reserva);
            SaveReservas(reservas);
        }

        public List<Reserva> GetReservasPorClase(string claseId)
        {
            var reservas = GetReservas();
            return reservas.FindAll(r => r.ClaseId == claseId);
        }
    }
}

