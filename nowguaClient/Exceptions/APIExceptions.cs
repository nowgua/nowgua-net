using nowguaClient.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace nowguaClient.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(APIResponseError APIResponseError)
            :base(APIResponseError.Message)
        {

        }
    }

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(APIResponseError APIResponseError)
            : base(APIResponseError.Message)
        {

        }
    }

    public class BadRequestException : Exception
    {
        public APIBadRequestResult Errors { get; set; }

        public BadRequestException(APIResponseError APIResponseError)
            : base(APIResponseError.Message)
        {
            this.Errors = APIResponseError.Result as APIBadRequestResult;
        }
    }

    public class InternalServerException : Exception
    {
        public InternalServerException(APIResponseError APIResponseError)
            : base(APIResponseError.Message)
        {

        }
    }
}
