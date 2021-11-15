using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.VHSYS.Models.Response
{
    public abstract class VHSYSBaseResponse<T>
    {
        public int Code { get; set; }

        public String Status { get; set; }

        public T Data { get; set; }

        public bool IsValid() => Code == 200;

        public bool ShouldSerializeData()
        {
            return Data is T;
        }
    }
}