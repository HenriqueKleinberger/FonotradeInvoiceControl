using System;

namespace FonotradeInvoiceControl.DTO
{
    public class InvoiceDTO
    {

        public int Batch { get; set; }
        public String TaxIdNumber { get; set; }
        public String Description { get; set; }
        public String Technician { get; set; }
        public Decimal Value { get; set; }
    }
}