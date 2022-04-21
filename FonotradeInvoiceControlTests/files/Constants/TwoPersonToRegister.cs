using FonotradeInvoiceControl.DTO;
using FonotradeInvoiceControlTest.Builder.DTO;
using System;

namespace FonotradeInvoiceControlTest.Files.Constants
{
    public static class TwoPersonToRegister
    {
        private static readonly string FIRST_CPF = "237.448.100-03";
        private static readonly string FIRST_TECHNICIAN = "Apr.FonoCli-Mai/22-220405-2-1";
        private static readonly string FIRST_DESCRIPTION = "Curso de Aprimoramento On-line – Alfabetização e Fonoaudiologia Clínica: Interface saúde e educação – Maio/2022";
        private static readonly Decimal FIRST_VALUE = new Decimal(350.22);

        private static readonly string SECOND_CPF = "806.408.840-24";
        private static readonly string SECOND_TECHNICIAN = "Apr.FonoCli-Mai/22-220405-2-2";
        private static readonly string SECOND_DESCRIPTION = "Curso de Aprimoramento On-line – Alfabetização e Fonoaudiologia Clínica: Interface saúde e educação – Maio/2022";
        private static readonly Decimal SECOND_VALUE = new Decimal(426.56);

        public static InvoiceDTO getFirstInvoiceDTO() => new InvoiceDTOBuilder()
                .WithTaxIdNumber(FIRST_CPF)
                .WithTechnician(FIRST_TECHNICIAN)
                .WithDescription(FIRST_DESCRIPTION)
                .WithValue(FIRST_VALUE)
                .Build();
        public static InvoiceDTO getSecondInvoiceDTO() => new InvoiceDTOBuilder()
                    .WithTaxIdNumber(SECOND_CPF)
                    .WithTechnician(SECOND_TECHNICIAN)
                    .WithDescription(SECOND_DESCRIPTION)
                    .WithValue(SECOND_VALUE)
                    .Build();
    }
}
