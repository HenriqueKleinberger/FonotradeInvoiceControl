using System;

namespace FonotradeInvoiceControl.DTO
{
    public class InvoiceDTO
    {
        public int ServiceId { get; set; }
        public String TaxIdNumber { get; set; }
        public String Description { get; set; }
        public String Technician { get; set; }
        public Decimal Value { get; set; }
        public int RegisteredId { get; set; }
        public int InvoiceNumber { get; set; }
    }
}