using FonotradeInvoiceControl.Constants;
using FonotradeInvoiceControl.DTO;
using System;

namespace FonotradeInvoiceControlTest.Builder.DTO
{
    public class InvoiceFeedbackDTOBuilder
    {
        private InvoiceFeedbackDTO _invoiceFeedbackDTO;

        private string Feedback = InvoiceFeedback.REGISTERED;
        private InvoiceDTO InvoiceDTO = new InvoiceDTOBuilder().Build();

        public InvoiceFeedbackDTOBuilder()
        {
            Random random = new Random();

            _invoiceFeedbackDTO = new InvoiceFeedbackDTO();
            _invoiceFeedbackDTO.Id = random.Next(1, 999);
            _invoiceFeedbackDTO.Feedback = this.Feedback;
            _invoiceFeedbackDTO.InvoiceDTO = this.InvoiceDTO;
        }

        public InvoiceFeedbackDTOBuilder WithErrorFeedback(string feedback)
        {
            _invoiceFeedbackDTO.Id = 0;
            _invoiceFeedbackDTO.Feedback = feedback;
            return this;
        }

        public InvoiceFeedbackDTOBuilder WithInvoiceDTO(InvoiceDTO invoiceDTO)
        {
            _invoiceFeedbackDTO.InvoiceDTO = invoiceDTO;
            return this;
        }

        public InvoiceFeedbackDTO Build()
        {
            return _invoiceFeedbackDTO;
        }
    }
}
