using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Api
{
    public class ErrorResponse
    {
        public ErrorResponse() { }
        public ErrorResponse(string error_message)
        {
            ErrorMessage = error_message;
        }
        public ErrorResponse(ErrorCodes? error_code, string error_message)
        {
            ErrorCode = error_code;
            ErrorMessage = error_message;
        }
        public ErrorCodes? ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
    public enum ErrorCodes
    {
        email_not_confirmed,
        account_locked
    }
}
