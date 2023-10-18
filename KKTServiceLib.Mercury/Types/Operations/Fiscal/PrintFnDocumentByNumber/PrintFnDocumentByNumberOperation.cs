#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.Fiscal.PrintFnDocumentByNumber
{
    [Description("Печать документа из ФН по номеру ФД")]
    public class PrintFnDocumentByNumberOperation : Operation<PrintFnDocumentByNumberResult>
    {
        /// <summary>
        /// Печать документа из ФН по номеру ФД
        /// </summary>
        /// <param name="fiscalDocumentNumber">Номер фискального документа</param>
        public PrintFnDocumentByNumberOperation(uint fiscalDocumentNumber) : base("PrintDocFromFN")
        {
            FiscalDocNum = fiscalDocumentNumber;
        }

        /// <summary>
        /// Номер фискального документа
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Display(Name = "Номер документа")]
        public uint FiscalDocNum { get; }
    }
}