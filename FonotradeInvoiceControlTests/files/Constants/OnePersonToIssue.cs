using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControlTest.Builder.DTO;
using System;

namespace FonotradeInvoiceControlTest.Files.Constants
{
    public static class OnePersonToIssue
    {
        private static readonly string CPF = "001.477.870-09";
        private static readonly string TECHNICIAN = "Apr.FonoCli-Abr/22-220405-1-1";
        private static readonly string DESCRIPTION = "Curso de Aprimoramento On-line – Alfabetização e Fonoaudiologia Clínica: Interface saúde e educação - Abril/2022";
        private static readonly Decimal VALUE = new Decimal(350.22);
        private static readonly int SERVICE_ID = 4321;

        public static InvoiceDTO getInvoiceDTO() => new InvoiceDTOBuilder()
                .WithServiceId(SERVICE_ID)
                .WithTaxIdNumber(CPF)
                .WithTechnician(TECHNICIAN)
                .WithDescription(DESCRIPTION)
                .WithValue(VALUE)
                .Build();
    }
}
