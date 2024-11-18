using System;
using System.Collections.Generic;
using Model;

using Controller.DataHandler;

namespace Controller
{
    public class FacturaController
    {
        private readonly JsonDataHandler<Factura> _dataHandler;

        public FacturaController()
        {
            _dataHandler = new JsonDataHandler<Factura>("Assets/Facturas.json");
        }

        public List<Factura> GetFacturas()
        {
            return _dataHandler.GetAll();
        }

        public void SaveFacturas(List<Factura> facturas)
        {
            _dataHandler.SaveAll(facturas);
        }

        public void GenerarFactura(Factura factura)
        {
            factura.FechaEmision = DateTime.Now;
            var facturas = GetFacturas();
            facturas.Add(factura);
            SaveFacturas(facturas);
        }
    }
}

