using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Consultas;
using InvoiceManagementApp.Application.Invoices.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Invoices.Handler
{
    class GetConsultaFacturaHandler: IRequestHandler<GetConsultaFactura, IList<InvoiceVm>>
    {
        private readonly IApplicationDbContext _context;
        public GetConsultaFacturaHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<InvoiceVm>> Handle(GetConsultaFactura request, CancellationToken cancellationToken)
        {
            var resultado = new List<InvoiceVm>();
            var invoices = await _context.Invoices.Includes(x => x.InvoiceItems)
                .Where(x => x.CreatedBy == request.User).ToListAsync();
            if(invoices != null)
            {
                resultado = invoices.Select(x => new InvoiceVm
                {
                    PagoMonto = x.PagoMonto,
                    Created = x.created,
                    Fecha = x.Fecha,
                    Descuento = x.Descuento,
                    TipoDescuento = x.TipoDescuento,
                    FechaVencimiento = x.FechaVencimiento,
                    From = x.From,
                    Id = x.Id,
                    FacturaNum = x.FacturaNum,
                    Logo = x.Logo,
                    TerminosPago = x.TerminosPago,
                    Impuesto = x.Impuesto,
                    TipoImpuesto = x.TipoImpuesto,
                    To = x.To,
                    InvoiceItems = x.InvoiceItems.Select(item => new InvoiceItemVm
                    {
                        Id = item.Id,
                        Articulo = item.Articulo,
                        Cantidad = item.Cantidad,
                        Tarifa = item.Tarifa
                    }).ToList()

                }).ToList();
                
            }

            return resultado;
        }

        Task<IList<InvoiceVm>> IRequestHandler<GetConsultaFactura, IList<InvoiceVm>>.Handle(GetConsultaFactura request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
   
}
