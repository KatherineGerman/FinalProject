using InvoiceManagementApp.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagementApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice> Facturas { get; set; }
        DbSet<InvoiceItem> ArticulosFactura { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
