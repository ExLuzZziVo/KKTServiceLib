#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnStatus
{
    [Description("Результат запроса состояния ФН")]
    public class GetFnStatusResult
    {
        /// <summary>
        /// Информация о состоянии ФН
        /// </summary>
        [Display(Name = "Информация о состоянии ФН")]
        public FnStatus FnStatus { get; set; }
    }
}