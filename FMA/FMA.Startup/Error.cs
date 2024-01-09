using FMA.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FMA.Startup
{
    public class Error
    {
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.InternalServerError;
        public string Result { get; private set; } = "Er is een onverwachte fout opgetreden. Neem contact op met de ondersteuning.";

        public Error(Exception exception)
        {
            if (exception is ValidationException)
            {
                var validationException = (ValidationException)exception;
                var stringBuilder = new StringBuilder();
                validationException.ReadErrors().ForEach(x => stringBuilder.AppendLine(x));

                Result = stringBuilder.ToString();
                StatusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is NotFoundException)
            {
                Result = exception.Message;
                StatusCode = HttpStatusCode.NotFound;
            }
        }
    }
}
