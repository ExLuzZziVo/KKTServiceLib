using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace KKTServiceLib.Shared.Types.Common
{
    [JsonArray]
    public class JsonArrayReadOnlyDictionary<TKey, TValue> : ReadOnlyDictionary<TKey, TValue>
    {
        public JsonArrayReadOnlyDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { }
    }
}