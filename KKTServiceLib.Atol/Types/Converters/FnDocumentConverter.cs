using System;
using System.Collections.Generic;
using System.Linq;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Atol.Types.Operations.Fiscal.Fn.GetFnDocumentByNumber;
using KKTServiceLib.Shared.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KKTServiceLib.Atol.Types.Converters
{
    /// <summary>
    /// Конвертер для десериализации документа ФН в более читабельный вид  
    /// </summary>
    public class FnDocumentConverter : JsonConverter<GetFnDocumentByNumberResult>
    {
        /// <summary>
        /// Словарь реквизитов ФН
        /// </summary>
        /// <remarks>
        /// Неполный. Будет дополняться
        /// </remarks>
        private static readonly Dictionary<string, string> FnRequisites = new Dictionary<string, string>
        {
            { "1001", "kktAutoMode" },
            { "1002", "kktOfflineMode" },
            { "1005", "moneyTransferOperatorAddress" },
            { "1008", "buyerEmailOrPhone" },
            { "1009", "organizationAddress" },
            { "1012", "fiscalDocumentDateTime" },
            { "1016", "moneyTransferOperatorVatin" },
            { "1017", "ofdVatin" },
            { "1018", "organizationVatin" },
            { "1020", "receiptSum" },
            { "1021", "operatorName" },
            { "1023", "receiptPositionQuantity" },
            { "1026", "moneyTransferOperatorName" },
            { "1030", "receiptPositionName" },
            { "1031", "paymentCashSum" },
            { "1036", "machineNumber" },
            { "1037", "kktRegistrationNumber" },
            { "1038", "shiftNumber" },
            { "1040", "fiscalDocumentNumber" },
            { "1041", "fnNumber" },
            { "1042", "fiscalDocumentInShiftNumber" },
            { "1043", "receiptPositionAmount" },
            { "1044", "payingAgentOperation" },
            { "1046", "ofdName" },
            { "1048", "organizationName" },
            { "1054", "receiptType" },
            { "1055", "taxationType" },
            { "1056", "kktEncryption" },
            { "1057", "agents" },
            { "1059", "receiptPosition" },
            { "1060", "kktFnsUrl" },
            { "1062", "organizationTaxationTypes" },
            { "1073", "payingAgentPhones" },
            { "1074", "receivePaymentsOperatorPhones" },
            { "1075", "moneyTransferOperatorPhones" },
            { "1077", "fiscalDocumentSign" },
            { "1079", "receiptPositionPrice" },
            { "1081", "paymentElectronicallySum" },
            { "1097", "ofdNotSentCount" },
            { "1098", "ofdNotSentFirstDocNumber" },
            { "1102", "receiptWatVat20Sum" },
            { "1103", "receiptWatVat10Sum" },
            { "1104", "receiptWatVat0Sum" },
            { "1105", "receiptWatNoneSum" },
            { "1106", "receiptWatVat120Sum" },
            { "1107", "receiptWatVat110Sum" },
            { "1108", "kktInternet" },
            { "1109", "kktService" },
            { "1110", "kktBso" },
            { "1117", "organizationEmail" },
            { "1126", "kktLottery" },
            { "1162", "receiptPositionNomenclatureCode" },
            { "1171", "supplierPhones" },
            { "1173", "correctionType" },
            { "1178", "correctionBaseNumber" },
            { "1187", "paymentsAddress" },
            { "1191", "receiptPositionAdditionalAttribute" },
            { "1192", "receiptAdditionalAttribute" },
            { "1193", "kktGambling" },
            { "1197", "receiptPositionMeasurementUnit" },
            { "1199", "receiptPositionWatType" },
            { "1203", "operatorVatin" },
            { "1207", "kktExcise" },
            { "1209", "kktFfdVersion" },
            { "1212", "receiptPositionPaymentObject" },
            { "1214", "receiptPositionPaymentMethod" },
            { "1215", "paymentPrepaidSum" },
            { "1216", "paymentCreditSum" },
            { "1217", "paymentOtherSum" },
            { "1221", "kktMachineInstallation" },
            { "1222", "receiptPositionAgents" },
            { "1225", "supplierName" },
            { "1226", "supplierVatin" },
            { "1227", "buyerName" },
            { "1228", "buyerVatin" },
            { "1229", "receiptPositionExciseSum" },
            { "1230", "receiptPositionCountryCode" },
            { "1231", "receiptPositionCustomsDeclaration" },
            { "1244", "buyerCitizenship" },
            { "1245", "buyerIdentityDocumentCode" },
            { "1246", "buyerIdentityDocumentData" },
            { "1254", "buyerAddress" },
            { "1260", "receiptPositionIndustryRequisiteParams" },
            { "1261", "receiptIndustryRequisiteParams" },
            { "1262", "industryRequisiteParamsFois" },
            { "1263", "industryRequisiteParamsDate" },
            { "1264", "industryRequisiteParamsNumber" },
            { "1265", "industryRequisiteParamsIndustryAttribute" },
            { "1270", "operationParams" },
            { "1271", "operationParamsId" },
            { "1272", "operationParamsData" },
            { "1273", "operationParamsDateTime" },
            { "1291", "markingCodeParamsItemFractionalAmount" },
            { "1300", "positionCodeUndefined" },
            { "1301", "positionCodeEan8" },
            { "1302", "positionCodeEan13" },
            { "1303", "positionCodeItf14" },
            { "1304", "positionCodeGs10" },
            { "1305", "positionCodeGs1m" },
            { "1306", "positionCodeShort" },
            { "1307", "positionCodeFurs" },
            { "1308", "positionCodeEgais20" },
            { "1309", "positionCodeEgais30" },
            { "1320", "positionCodeF1" },
            { "1321", "positionCodeF2" },
            { "1322", "positionCodeF3" },
            { "1323", "positionCodeF4" },
            { "1324", "positionCodeF5" },
            { "1325", "positionCodeF6" },
            { "2000", "markingCodeParamsImc" },
            { "2003", "markingCodeParamsItemEstimatedStatus" },
            { "2004", "markingCodeParamsCheckResult" },
            { "2005", "markOperatorResponse" },
            { "2100", "markingCodeParamsImcType" },
            { "2101", "markingCodeParamsImcBarcode" },
            { "2102", "markingCodeParamsImcModeProcessing" },
            { "2105", "markingCodeParamsItemCheckResponseResult" },
            { "2106", "markingCodeParamsItemInfoCheckResult" },
            { "2108", "markingCodeParamsItemUnits" },
            { "2109", "markingCodeParamsItemStatus" }
        };

        public override void WriteJson(JsonWriter writer, GetFnDocumentByNumberResult value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override GetFnDocumentByNumberResult ReadJson(JsonReader reader, Type objectType,
            GetFnDocumentByNumberResult existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var result = new GetFnDocumentByNumberResult();

            result.RawData = jo.Property(nameof(result.RawData).ToLowerFirstChar())?.Value.ToObject<string>();

            if (jo.Property(nameof(result.DocumentTLV).ToLowerFirstChar())?.Value is JObject documentTLVJObject)
            {
                foreach (var pr in documentTLVJObject.Properties().ToArray())
                {
                    ProcessProperty(pr);

                    if (pr.Name.Equals(nameof(result.FiscalDocumentType), StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.FiscalDocumentType = pr.Value.ToObject<FiscalDocumentType>();
                        pr.Remove();
                    }
                    else if (pr.Name.Equals(nameof(result.Short), StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Short = pr.Value.ToObject<bool>();
                        pr.Remove();
                    }
                }

                result.DocumentTLV = documentTLVJObject.ToString(Formatting.Indented);
            }

            return result;
        }

        private static void ProcessProperty(JProperty property)
        {
            if (property.Value.Type == JTokenType.Array)
            {
                foreach (var jToken in property.Value)
                {
                    var jo = (JObject)jToken;

                    foreach (var pr in jo.Properties().ToArray())
                    {
                        ProcessProperty(pr);
                    }
                }
            }
            else if (property.Value.Type == JTokenType.Object)
            {
                foreach (var pr in ((JObject)property.Value).Properties().ToArray())
                {
                    ProcessProperty(pr);
                }
            }

            if (FnRequisites.TryGetValue(property.Name, out var name))
            {
                property.Replace(new JProperty(name, property.Value));
            }
        }
    }
}