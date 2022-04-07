using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FonotradeInvoiceControl.VHSYS.Models.Response
{
    public abstract class VHSYSBaseResponse<T>
    {
        public int code { get; set; }

        public String status { get; set; }

        public T Data { get; set; }

        public bool IsValid() => code == 200;

        public bool ShouldSerializeData()
        {
            return Data is T;
        }
    }
}