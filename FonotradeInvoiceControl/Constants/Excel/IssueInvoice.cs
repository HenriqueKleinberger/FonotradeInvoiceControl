namespace FonotradeInvoiceControl.Constants.Excel.IssueInvoice
{
    public static class IssueInvoiceCollumns
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
        public static readonly int INVOICE_NUMBER = 13;
    }

    public static class IssueInvoiceActions
    {
        public static readonly string ISSUE = "EMITIR";
    }

    public static class IssueInvoiceFeedback
    {
        public static readonly string ISSUED = "EMITIDO";
    }
}
