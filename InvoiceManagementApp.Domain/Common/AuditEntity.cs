using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Domain.Common
{
    public class AuditEntity
    {
        public string createBy { get; set; }

        public DateTime created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
