using System;

namespace FonotradeInvoiceControl.DTO
{
    public class InvoiceFeedbackDTO
    {
        public int Id { get; set; }
        public int RegisteredId { get; set; }
        public int InvoiceNumber { get; set; }
        public InvoiceDTO InvoiceDTO { get; set; }
        public String Feedback { get; set; }

    }
}