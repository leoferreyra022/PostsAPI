using Microsoft.AspNetCore.Http;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Contracts.V1.Response
{
    public class CreatePostResponse : ResponseBase
    {
        public Guid CreatedPostId { get; set; }
        public CreatePostResponse() : base()
        {

        }
    }
}
