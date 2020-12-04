using InvoiceManagementApp.Application.Invoices.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Application.Invoices.Consultas
{
    public class GetConsultaFactura: IRequest<List<InvoiceVm>>
    {
        public string User { get; set; }
    }
}
