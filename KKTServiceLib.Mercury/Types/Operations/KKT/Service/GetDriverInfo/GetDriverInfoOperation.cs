#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Mercury.Types.Operations.KKT.Service.GetDriverInfo
{
    [Description("Получение информации о драйвере ККТ")]
    public class GetDriverInfoOperation : Operation<GetDriverInfoResult>
    {
        public GetDriverInfoOperation() : base("GetDriverInfo")
        {
            IsSessionKeyRequired = false;
        }

        /// <summary>
        /// Сессионный ключ
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Сессионный ключ")]
        [Required(AllowEmptyStrings = true)]
        public override string SessionKey { get; protected set; } = string.Empty;
    }
}