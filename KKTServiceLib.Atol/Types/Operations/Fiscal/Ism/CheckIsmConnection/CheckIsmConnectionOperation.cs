#region

using System.ComponentModel;

#endregion

namespace KKTServiceLib.Atol.Types.Operations.Fiscal.Ism.CheckIsmConnection
{
    [Description("Проверка связи с сервером ИСМ")]
    public class CheckIsmConnectionOperation : Operation<CheckIsmConnectionResult>
    {
        /// <summary>
        /// Проверка связи с сервером ИСМ
        /// </summary>
        public CheckIsmConnectionOperation() : base("pingIsm") { }
    }
}