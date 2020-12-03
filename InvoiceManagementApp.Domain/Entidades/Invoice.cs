using InvoiceManagementApp.Domain.Common;
using InvoiceManagementApp.Domain.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Domain.Entidades
{
    public class Invoice: AuditEntity
    {
        public Invoice()
        {
            this.InvoiceItems = new List<InvoiceItem>();
        }
        public int Id { get; set; }
        public string FacturaNum { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Fecha { get; set; }
        public string TerminosPago { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public double Descuento { get; set; }
        public TipoDescuento TipoDescuento { get; set; }
        public double Impuesto { get; set; }
        public TipoImpuesto TipoImpuesto { get; set; }
        public double MontoPago { get; set; }

        public IList<InvoiceItem> InvoiceItems { get; set; }


    }
}
