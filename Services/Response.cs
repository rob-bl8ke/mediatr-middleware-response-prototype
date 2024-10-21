using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default) => new Response<T>(data, message, true);
        public static Response<T> Ok<T>(T data, string message) => new Response<T>(data, message, false);
    }

    // Wrapper for return data and then supply middleware
    public class Response<T>
    {
        public Response(T data, string msg, bool error)
        {
            Data = data;
            Message = msg;
            Error = error;
        }

        public T Data { get; set; }
        public string Message { get; set; } // structured message like JSON string???
        public bool Error { get; set; }
    }
}
