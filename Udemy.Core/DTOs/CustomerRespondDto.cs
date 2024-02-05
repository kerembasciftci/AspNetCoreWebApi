using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Udemy.Core.DTOs
{
    public class CustomerRespondDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public static CustomerRespondDto<T> Success(int statusCode, T data)
        {
            return new CustomerRespondDto<T> { Data = data, Errors = null, StatusCode = statusCode };

        }

        public static CustomerRespondDto<T> Success(int statusCode)
        {
            return new CustomerRespondDto<T> { StatusCode = statusCode };
        }

        public static CustomerRespondDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomerRespondDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomerRespondDto<T> Fail(int statusCode, string error)
        {
            return new CustomerRespondDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
