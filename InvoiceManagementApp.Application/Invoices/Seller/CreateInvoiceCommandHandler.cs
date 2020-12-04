using InvoiceManagementApp.Application.Common.Interfaces;
using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Invoices.Seller
{
    class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public double MontoPago { get; private set; }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Invoice
            {


                MontoPago = request.MontoPago,
                Fecha = request.Fecha,
                Descuento = request.Descuento,
                TipoDescuento = request.TipoDescuento,
                FechaVencimiento = request.FechaVencimiento,
                From = request.From,
                FacturaNum = request.FacturaNum,
                Logo = request.Logo,
                TerminosPago = request.TerminosPago,
                Impuesto = request.Impuesto,
                TipoImpuesto = request.TipoImpuesto,
                To = request.To,
                InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
                {
                    Articulo = i.Articulo,
                    Cantidad = i.Cantidad,
                    Tarifa = i.Tarifa
                }).ToList()
            };

            _context.Invoices.Add(entity);
            await _context.SaveChangesAsync(CancellationToken);
            return entity.Id;


        }
    }
}
