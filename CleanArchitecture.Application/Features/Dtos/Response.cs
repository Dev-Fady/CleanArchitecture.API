using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Dtos
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool IsSuccessded { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        public Response() { 
            DateTime = DateTime.UtcNow;

        }
        public Response(T data) : this() { 
            Data = data;
            IsSuccessded = true;
        }
        public Response(string message) : this()
        {
            Message = message;
            IsSuccessded = false;
        }
        public Response(T data, string message) : this()
        {
            Data = data;
            Message = message;
            IsSuccessded = true;
        }
    }
}
