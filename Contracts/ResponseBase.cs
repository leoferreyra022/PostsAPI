using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Contracts
{
    public class ResponseBase
    {
        public string CustomMessage { get; set; }
    }
}
