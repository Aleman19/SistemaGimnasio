public class Factura
{
    public int IdFactura { get; set; }
    public int IdCliente { get; set; }
    public DateTime FechaFactura { get; set; } = DateTime.Now; // Valor predeterminado
    public decimal Monto { get; set; } = 0; // Valor predeterminado
    public string Descripcion { get; set; } = string.Empty; // Valor predeterminado
}
