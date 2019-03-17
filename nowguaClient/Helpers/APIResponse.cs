using Newtonsoft.Json;
using nowguaClient.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace nowguaClient.Helpers
{
    /// <summary>
    /// Response de l'API
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// Détail de l'erreur 
        /// </summary>
        public APIResponseError Error { get; set; }

        /// <summary>
        /// Indique que la réponse est en erreur
        /// </summary>
        public bool OnError
        {
            get
            {
                return this.Error != null;
            }
        }

        public APIResponse(HttpResponseMessage ResponseMessage)
        {
            InitError(ResponseMessage);
        }

        internal void InitError(HttpResponseMessage ResponseMessage)
        {
            if (ResponseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                this.Error = new APIResponseError();
                this.Error.Code = (int)ResponseMessage.StatusCode;
                this.Error.Message = ResponseMessage.StatusCode.ToString();

                if (ResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var r = ResponseMessage.Content.ReadAsStringAsync();
                    r.Wait();

					if(r.Result is string)
						this.Error.Result = r.Result;
					else
						this.Error.Result = JsonConvert.DeserializeObject<APIBadRequestResult>(r.Result);
                }
				else
                {
					if (ResponseMessage.Content != null)
					{
						var r = ResponseMessage.Content.ReadAsStringAsync();
						r.Wait();

						this.Error.Message += " - " + r.Result;
					}
                }
            }
        }

        public APIResponse()
        {

        }

        public static void Parse(HttpResponseMessage ResponseMessage)
        {
            var response = new APIResponse(ResponseMessage);
            response.GenerateException();
        }

        public void GenerateException()
        {
            if (!this.OnError)
                return;

            if (this.Error.Code == 404)
                throw new NotFoundException(this.Error);
            if (this.Error.Code == 401)
                throw new UnauthorizedException(this.Error);
            if (this.Error.Code == 403)
                throw new UnauthorizedException(this.Error);
            if (this.Error.Code == 400)
                throw new BadRequestException(this.Error);
            if (this.Error.Code == 500)
                throw new InternalServerException(this.Error);
        }
    }

    /// <summary>
    /// Response de l'API typé
    /// </summary>
    /// <typeparam name="TResult">Type de retour attendu</typeparam>
    public class APIResponse<TResult> : APIResponse
    {
        /// <summary>
        /// Résultat de l'API
        /// </summary>
        public TResult Result { get; set; }

        public APIResponse(HttpResponseMessage ResponseMessage)
        {
            this.InitError(ResponseMessage);

            if (ResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var r = ResponseMessage.Content.ReadAsStringAsync();
                r.Wait();

                this.Result = JsonConvert.DeserializeObject<TResult>(r.Result);
            }
        }

        public APIResponse()
        {

        }

        public static TResult Parse(HttpResponseMessage ResponseMessage)
        {
            var response = new APIResponse<TResult>(ResponseMessage);
            response.GenerateException();

            return response.Result;
        }
    }

    /// <summary>
    /// Erreur de l'API
    /// </summary>
    public class APIResponseError
    {
        /// <summary>
        /// Code d'erreur HTTP
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message de l'erreur
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Information sur l'erreur
        /// </summary>
        public object Result { get; set; }
    }

    /// <summary>
    /// Response BadRequest 
    /// </summary>
    public class APIBadRequestResult : Dictionary<string, List<string>>
    {

    }
}
