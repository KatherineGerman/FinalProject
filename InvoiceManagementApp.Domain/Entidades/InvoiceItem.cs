using InvoiceManagementApp.Domain.Common;

namespace InvoiceManagementApp.Domain.Entidades
{
    public class InvoiceItem : AuditEntity
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string Articulo { get; set; }
        public double Cantidad { get; set; }
        public double Tarifa { get; set; }

        public Invoice Factura { get; set; }
    }
}
