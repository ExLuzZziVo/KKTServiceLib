#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KKTServiceLib.Shared.Resources;

#endregion

namespace AtolKKTServiceLib.Types.Operations.Fiscal.Fn.PrintFnDocumentByNumber
{
    [Description("Печать документа из ФН по номеру ФД")]
    public class PrintFnDocumentByNumberOperation : Operation<bool>
    {
        /// <summary>
        /// Печать документа из ФН по номеру ФД
        /// </summary>
        /// <param name="fiscalDocumentNumber">Номер фискального документа</param>
        public PrintFnDocumentByNumberOperation(uint fiscalDocumentNumber) : base("printFnDocument")
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
    }
}