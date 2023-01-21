//using Library.Data.Enum;
using Library.Service.Enum;
using Library.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

using System.Net;

namespace Library.Service.Common
{
    public class ReturnBase<T> : ActionResult
    {
        #region CONSTRUTORES
        public ReturnBase()
        {

        }

        public ReturnBase(bool success, MessageEnum message)
        {
            this.message = new ModelEnum
            {
                Nome = message.GetEnumName(),
                Descricao = message.GetEnumDescription()
            };
        }

        public ReturnBase(bool success, MessageEnum message, T dados) : this(success, message) => this.Dados = dados;


        private static ObjectResult StatusCode([ActionResultStatusCode] int statusCode, [ActionResultObjectValue] object? value)
        {
            return new ObjectResult(value)
            {
                StatusCode = statusCode
            };
        }

        public static ActionResult<T> Result(T dados, HttpStatusCode Code, ModelEnum message)
        {
            var ret = new ReturnBase<T>
            {
                Dados = dados,
                message = message
            };

            return StatusCode(Convert.ToInt32(Code), ret);
        }

        public static ActionResult<T> Result(T dados, HttpStatusCode Code, ModelEnum message, Exception ex = null)
        {
            var ret = new ReturnBase<T>
            {
                Dados = dados,
                message = message
            };

            if (ex != null)
                ret.exception = new ExceptionResult(ex);


            return StatusCode(Convert.ToInt32(Code), ret);
        }

        public ReturnBase(bool success, string messageDetailed)
        {
            this.message = new ModelEnum
            {
                Descricao = messageDetailed
            };
        }
        #endregion

        public T Dados { get; set; }
        public ModelEnum message { get; set; }
        public ExceptionResult exception { get; set; }

    }
}
