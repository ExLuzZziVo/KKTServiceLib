#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnInfo
{
    [Description("Результат запроса информации о ФН")]
    public class GetFnInfoResult
    {
        /// <summary>
        /// Информация о ФН
        /// </summary>
        [Display(Name = "Информация о ФН")]
        public FnInfo FnInfo { get; set; }
    }
}