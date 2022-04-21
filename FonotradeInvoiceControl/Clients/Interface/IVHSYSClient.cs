using RestSharp;


namespace FonotradeInvoiceControl.Clients.Interface
{
    public interface IVHSYSClient
    {
        IRestResponse Get(RestRequest request);
        IRestResponse Post(RestRequest request);
    }
}