using System;

namespace FonotradeInvoiceControl.DTO
{
    public class InvoiceFeedbackDTO
    {
        public int Id { get; set; }
        public InvoiceDTO InvoiceDTO { get; set; }
        public String Feedback { get; set; }

    }
}