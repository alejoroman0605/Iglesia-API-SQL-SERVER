using Library.Service.Extensions;

namespace Library.Service.Enum
{
    public class ModelEnumAcademic
    {
        #region Construtores
        public ModelEnumAcademic()
        {

        }

        public ModelEnumAcademic(System.Enum enumItem)
        {
            this.Codigo = enumItem.GetEnumValue();
            this.Nome = enumItem.GetEnumName();
            this.Descricao = enumItem.GetEnumDescription();
        }
        #endregion

        #region Propriedades
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
        #endregion
    }
}