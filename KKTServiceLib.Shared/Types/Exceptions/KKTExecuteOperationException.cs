#region

using System;

#endregion

namespace KKTServiceLib.Shared.Types.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при ошибке взаимодействия с ККТ
    /// </summary>
    public class KKTExecuteOperationException: Exception
    {
        /// <summary>
        /// Исключение, возникающее при ошибке взаимодействия с ККТ
        /// </summary>
        /// <param name="errorCode">Код ошибки ККТ</param>
        /// <param name="message">Сообщение об ошибке ККТ</param>
        public KKTExecuteOperationException(int errorCode, string message): base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Код ошибки ККТ
        /// </summary>
        public int ErrorCode { get; }
    }
}