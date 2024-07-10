#region

using System.Text.Json.Serialization;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип ШК
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BarcodeType: byte
    {
        EAN8,
        EAN13,
        UPCA,
        UPCE,
        CODE39,
        CODE93,
        CODE128,
        CODABAR,
        ITF,
        ITF14,
        GS1_128,
        PDF417,
        QR,
        CODE39_EXTENDED
    }
}