using FonotradeInvoiceControl.DTO;

namespace FonotradeInvoiceControl.VHSYS.Services.Interfaces
{
    public interface IVHSYSClientService
    {
        public ClientDTO getClientByCnpj(string cpfCnpj);
    }
}
