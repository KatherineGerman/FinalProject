using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Application.Invoices.ViewModel
{
    public class InvoiceItemVm
    {
        public int Id { get; set; }
        public string Articulo { get; set; }
        public double Cantidad { get; set; }
        public double Tarifa { get; set; }

        public double Monto
        {
            get
            {
                return Cantidad * Tarifa;
            }
        }
    }
}
