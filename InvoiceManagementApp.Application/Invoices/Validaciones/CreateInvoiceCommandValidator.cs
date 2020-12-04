using FluentValidation;
using InvoiceManagementApp.Application.Invoices.Commands;
using InvoiceManagementApp.Application.Invoices.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Application.Invoices
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(v => v.MontoPago).NotNull();
            RuleFor(v => v.Fecha).NotNull();
            RuleFor(v => v.From).NotEmpty().MinimumLength(3);
            RuleFor(v => v.To).NotEmpty().MinimumLength(3);
            RuleFor(v => v.InvoiceItems).SetValidator(new MustHaveInvoiceItemPropertyValidator());
        }
    }
}
