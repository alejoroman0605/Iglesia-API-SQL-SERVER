using Library.Service.Extensions;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.Service.Enum
{
    public class ModelEnum
    {
        #region Construtores
        public ModelEnum()
        {
          
        }

        public ModelEnum(System.Enum enumItem)
        {
            this.Nome = enumItem.GetEnumName();
            this.Descricao = enumItem.GetEnumDescription();
        }
        #endregion

        #region Propriedades

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public static implicit operator ModelEnum(MessageEnum v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }


    public class ExceptionResult
    {
        public ExceptionResult(Exception ex)
        {
            Type = ex.GetType().FullName;
            Code = $"0x{ex.HResult.ToString("X")}";
            Message = ex.Message;
            StackTrace = ex.StackTrace;
            Source = ex.Source;
        }


        public string Type { get; set; }
        public string Code { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public string StackTrace { get; set; }

    }
}
