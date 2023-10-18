#region

using System.Text.Json.Serialization;
using KKTServiceLib.Atol.Types.Common.Document;
using KKTServiceLib.Atol.Types.Enums;

#endregion

namespace KKTServiceLib.Atol.Types.Interfaces
{
    [JsonDerivedType(typeof(BarcodeDocumentParams))]
    [JsonDerivedType(typeof(PictureDocumentParams))]
    [JsonDerivedType(typeof(PixelsDocumentParams))]
    [JsonDerivedType(typeof(TextDocumentParams))]
    public interface ICommonDocumentElement
    {
        AlignmentType Alignment { get; set; }
    }
}