namespace FonotradeInvoiceControl.Constants.Excel.RegisterInvoice
{
    public static class RegisterInvoiceCollumns
    {
        public static readonly int FIRST_TABLE_ROW = 2;
        public static readonly int TAX_ID_NUMBER = 5;
        public static readonly int DESCRIPTION = 6;
        public static readonly int TECHNICIAN = 7;
        public static readonly int VALUE = 8;
        public static readonly int ACTION = 9;
        public static readonly int FEEDBACK = 10;
        public static readonly int REGISTERED_ID = 11;
        public static readonly int SERVICE_ID = 12;
    }

    public static class RegisterInvoiceActions
    {
        public static readonly string REGISTER = "CADASTRAR";
    }

    public static class RegisterInvoiceFeedback
    {
        public static readonly string REGISTERED = "CADASTRADO";
    }
}
