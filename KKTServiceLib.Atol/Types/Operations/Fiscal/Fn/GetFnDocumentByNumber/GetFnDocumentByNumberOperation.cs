#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnDocumentByNumber
{
    [Description("Чтение документа из ФН")]
    public class GetFnDocumentByNumberOperation : Operation<GetFnDocumentByNumberResult>
    {
        /// <summary>
        /// Чтение документа из ФН
        /// </summary>
        /// <param name="fiscalDocumentNumber">Номер фискального документа</param>
        public GetFnDocumentByNumberOperation(uint fiscalDocumentNumber) : base("getFnDocument")
        {
            FiscalDocumentNumber = fiscalDocumentNumber;
        }

        /// <summary>
        /// Номер документа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер документа")]
        public uint FiscalDocumentNumber { get; }

        /// <summary>
        /// Возвращение 'сырых' данных документа
        /// </summary>
        [Display(Name = "Возвращение 'сырых' данных документа")]
        public bool WithRawData { get; set; } = false;
    }
}