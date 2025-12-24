#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.KKT.GetMCUInfo
{
    [Description("Информация о принтере")]
    public class PrinterInfo
    {
        /// <summary>
        /// Название драйвера двигателя
        /// </summary>
        [Display(Name = "Название драйвера двигателя")]
        public string DriverName { get; set; }
    }
}
