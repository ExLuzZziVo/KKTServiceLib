#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace KKTServiceLib.Atol.Types.Enums
{
    /// <summary>
    /// Тип ошибки ККТ
    /// </summary>
    public enum KKTErrorType: uint
    {
        /// <summary>
        /// Ошибок нет
        /// </summary>
        [Display(Name = "Ошибок нет")] LIBFPTR_OK = 000,

        /// <summary>
        /// Соединение не установлено
        /// </summary>
        [Display(Name = "Соединение не установлено")]
        LIBFPTR_ERROR_CONNECTION_DISABLED = 001,

        /// <summary>
        /// Нет связи
        /// </summary>
        [Display(Name = "Нет связи")] LIBFPTR_ERROR_NO_CONNECTION = 002,

        /// <summary>
        /// Порт занят
        /// </summary>
        [Display(Name = "Порт занят")] LIBFPTR_ERROR_PORT_BUSY = 003,

        /// <summary>
        /// Порт недоступен
        /// </summary>
        [Display(Name = "Порт недоступен")] LIBFPTR_ERROR_PORT_NOT_AVAILABLE = 004,

        /// <summary>
        /// Некорректные данные от устройства
        /// </summary>
        [Display(Name = "Некорректные данные от устройства")]
        LIBFPTR_ERROR_INCORRECT_DATA = 005,

        /// <summary>
        /// Внутренняя ошибка библиотеки
        /// </summary>
        [Display(Name = "Внутренняя ошибка библиотеки")]
        LIBFPTR_ERROR_INTERNAL = 006,

        /// <summary>
        /// Неподдерживаемое преобразование типа параметра
        /// </summary>
        [Display(Name = "Неподдерживаемое преобразование типа параметра")]
        LIBFPTR_ERROR_UNSUPPORTED_CAST = 007,

        /// <summary>
        /// Не найден обязательный параметр
        /// </summary>
        [Display(Name = "Не найден обязательный параметр")]
        LIBFPTR_ERROR_NO_REQUIRED_PARAM = 008,

        /// <summary>
        /// Некорректные настройки
        /// </summary>
        [Display(Name = "Некорректные настройки")]
        LIBFPTR_ERROR_INVALID_SETTINGS = 009,

        /// <summary>
        /// Драйвер не настроен
        /// </summary>
        [Display(Name = "Драйвер не настроен")]
        LIBFPTR_ERROR_NOT_CONFIGURED = 010,

        /// <summary>
        /// Не поддерживается в данной версии
        /// </summary>
        [Display(Name = "Не поддерживается в данной версии")]
        LIBFPTR_ERROR_NOT_SUPPORTED = 011,

        /// <summary>
        /// Не поддерживается в данном режиме
        /// </summary>
        [Display(Name = "Не поддерживается в данном режиме")]
        LIBFPTR_ERROR_INVALID_MODE = 012,

        /// <summary>
        /// Нeкорректное значение параметра
        /// </summary>
        [Display(Name = "Нeкорректное значение параметра")]
        LIBFPTR_ERROR_INVALID_PARAM = 013,

        /// <summary>
        /// Не удалось загрузить библиотеку
        /// </summary>
        [Display(Name = "Не удалось загрузить библиотеку")]
        LIBFPTR_ERROR_NOT_LOADED = 014,

        /// <summary>
        /// Неизвестная ошибка
        /// </summary>
        [Display(Name = "Неизвестная ошибка")] LIBFPTR_ERROR_UNKNOWN = 015,

        /// <summary>
        /// Неверная цена (сумма)
        /// </summary>
        [Display(Name = "Неверная цена (сумма)")]
        LIBFPTR_ERROR_INVALID_SUM = 016,

        /// <summary>
        /// Неверное количество
        /// </summary>
        [Display(Name = "Неверное количество")]
        LIBFPTR_ERROR_INVALID_QUANTITY = 017,

        /// <summary>
        /// Переполнение счетчика наличности
        /// </summary>
        [Display(Name = "Переполнение счетчика наличности")]
        LIBFPTR_ERROR_CASH_COUNTER_OVERFLOW = 018,

        /// <summary>
        /// Невозможно сторно последней операции
        /// </summary>
        [Display(Name = "Невозможно сторно последней операции")]
        LIBFPTR_ERROR_LAST_OPERATION_STORNO_DENIED = 019,

        /// <summary>
        /// Сторно по коду невозможно
        /// </summary>
        [Display(Name = "Сторно по коду невозможно")]
        LIBFPTR_ERROR_STORNO_BY_CODE_DENIED = 020,

        /// <summary>
        /// Невозможен повтор последней операции
        /// </summary>
        [Display(Name = "Невозможен повтор последней операции")]
        LIBFPTR_ERROR_LAST_OPERATION_NOT_REPEATABLE = 021,

        /// <summary>
        /// Повторная скидка на операцию невозможна
        /// </summary>
        [Display(Name = "Повторная скидка на операцию невозможна")]
        LIBFPTR_ERROR_DISCOUNT_NOT_REPEATABLE = 022,

        /// <summary>
        /// Невозможно начислить скидку/надбавку
        /// </summary>
        [Display(Name = "Невозможно начислить скидку/надбавку")]
        LIBFPTR_ERROR_DISCOUNT_DENIED = 023,

        /// <summary>
        /// Неверный код товара
        /// </summary>
        [Display(Name = "Неверный код товара")]
        LIBFPTR_ERROR_INVALID_COMMODITY_CODE = 024,

        /// <summary>
        /// Неверный штрихкод товара
        /// </summary>
        [Display(Name = "Неверный штрихкод товара")]
        LIBFPTR_ERROR_INVALID_COMMODITY_BARCODE = 025,

        /// <summary>
        /// Неверный формат команды
        /// </summary>
        [Display(Name = "Неверный формат команды")]
        LIBFPTR_ERROR_INVALID_COMMAND_FORMAT = 026,

        /// <summary>
        /// Неверная длина
        /// </summary>
        [Display(Name = "Неверная длина")] LIBFPTR_ERROR_INVALID_COMMAND_LENGTH = 027,

        /// <summary>
        /// ККТ заблокирована в режиме ввода даты
        /// </summary>
        [Display(Name = "ККТ заблокирована в режиме ввода даты")]
        LIBFPTR_ERROR_BLOCKED_IN_DATE_INPUT_MODE = 028,

        /// <summary>
        /// Требуется подтверждение ввода даты
        /// </summary>
        [Display(Name = "Требуется подтверждение ввода даты")]
        LIBFPTR_ERROR_NEED_DATE_ACCEPT = 029,

        /// <summary>
        /// Нет больше данных
        /// </summary>
        [Display(Name = "Нет больше данных")] LIBFPTR_ERROR_NO_MORE_DATA = 030,

        /// <summary>
        /// Нет подтверждения или отмены продажи
        /// </summary>
        [Display(Name = "Нет подтверждения или отмены продажи")]
        LIBFPTR_ERROR_NO_ACCEPT_OR_CANCEL = 031,

        /// <summary>
        /// Отчет о закрытии смены прерван
        /// </summary>
        [Display(Name = "Отчет о закрытии смены прерван")]
        LIBFPTR_ERROR_BLOCKED_BY_REPORT_INTERRUPTION = 032,

        /// <summary>
        /// Отключение контроля наличности невозможно (не настроены необходимые типы оплаты)
        /// </summary>
        [Display(Name = "Отключение контроля наличности невозможно (не настроены необходимые типы оплаты)")]
        LIBFPTR_ERROR_DISABLE_CASH_CONTROL_DENIED = 033,

        /// <summary>
        /// Вход в режим заблокирован
        /// </summary>
        [Display(Name = "Вход в режим заблокирован")]
        LIBFPTR_ERROR_MODE_BLOCKED = 034,

        /// <summary>
        /// Проверьте дату и время
        /// </summary>
        [Display(Name = "Проверьте дату и время")]
        LIBFPTR_ERROR_CHECK_DATE_TIME = 035,

        /// <summary>
        /// Переданные дата/время меньше даты/времени последнего фискального документа
        /// </summary>
        [Display(Name = "Переданные дата/время меньше даты/времени последнего фискального документа")]
        LIBFPTR_ERROR_DATE_TIME_LESS_THAN_FS = 036,

        /// <summary>
        /// Невозможно закрыть архив
        /// </summary>
        [Display(Name = "Невозможно закрыть архив")]
        LIBFPTR_ERROR_CLOSE_ARCHIVE_DENIED = 037,

        /// <summary>
        /// Товар не найден
        /// </summary>
        [Display(Name = "Товар не найден")] LIBFPTR_ERROR_COMMODITY_NOT_FOUND = 038,

        /// <summary>
        /// Весовой штрихкод с количеством <> 1.000
        /// </summary>
        [Display(Name = "Весовой штрихкод с количеством <> 1.000")]
        LIBFPTR_ERROR_WEIGHT_BARCODE_WITH_INVALID_QUANTITY = 039,

        /// <summary>
        /// Переполнение буфера чека
        /// </summary>
        [Display(Name = "Переполнение буфера чека")]
        LIBFPTR_ERROR_RECEIPT_BUFFER_OVERFLOW = 040,

        /// <summary>
        /// Недостаточное количество товара
        /// </summary>
        [Display(Name = "Недостаточное количество товара")]
        LIBFPTR_ERROR_QUANTITY_TOO_FEW = 041,

        /// <summary>
        /// Сторнируемое количество больше проданного
        /// </summary>
        [Display(Name = "Сторнируемое количество больше проданного")]
        LIBFPTR_ERROR_STORNO_TOO_MUCH = 042,

        /// <summary>
        /// Товар не найден
        /// </summary>
        [Display(Name = "Товар не найден")] LIBFPTR_ERROR_BLOCKED_COMMODITY_NOT_FOUND = 043,

        /// <summary>
        /// Нет бумаги
        /// </summary>
        [Display(Name = "Нет бумаги")] LIBFPTR_ERROR_NO_PAPER = 044,

        /// <summary>
        /// Открыта крышка
        /// </summary>
        [Display(Name = "Открыта крышка")] LIBFPTR_ERROR_COVER_OPENED = 045,

        /// <summary>
        /// Нет связи с принтером чеков
        /// </summary>
        [Display(Name = "Нет связи с принтером чеков")]
        LIBFPTR_ERROR_PRINTER_FAULT = 046,

        /// <summary>
        /// Механическая ошибка печатающего устройства
        /// </summary>
        [Display(Name = "Механическая ошибка печатающего устройства")]
        LIBFPTR_ERROR_MECHANICAL_FAULT = 047,

        /// <summary>
        /// Неверный тип чека
        /// </summary>
        [Display(Name = "Неверный тип чека")] LIBFPTR_ERROR_INVALID_RECEIPT_TYPE = 048,

        /// <summary>
        /// Недопустимое целевое устройство
        /// </summary>
        [Display(Name = "Недопустимое целевое устройство")]
        LIBFPTR_ERROR_INVALID_UNIT_TYPE = 049,

        /// <summary>
        /// Нет места в массиве картинок/штрихкодов
        /// </summary>
        [Display(Name = "Нет места в массиве картинок/штрихкодов")]
        LIBFPTR_ERROR_NO_MEMORY = 050,

        /// <summary>
        /// Неверный номер картинки/штрихкода (картинка/штрихкод отсутствует)
        /// </summary>
        [Display(Name = "Неверный номер картинки/штрихкода (картинка/штрихкод отсутствует)")]
        LIBFPTR_ERROR_PICTURE_NOT_FOUND = 051,

        /// <summary>
        /// Сумма не наличных платежей превышает сумму чека
        /// </summary>
        [Display(Name = "Сумма не наличных платежей превышает сумму чека")]
        LIBFPTR_ERROR_NONCACH_PAYMENTS_TOO_MUCH = 052,

        /// <summary>
        /// Накопление меньше суммы возврата или аннулирования
        /// </summary>
        [Display(Name = "Накопление меньше суммы возврата или аннулирования")]
        LIBFPTR_ERROR_RETURN_DENIED = 053,

        /// <summary>
        /// Переполнение суммы платежей
        /// </summary>
        [Display(Name = "Переполнение суммы платежей")]
        LIBFPTR_ERROR_PAYMENTS_OVERFLOW = 054,

        /// <summary>
        /// Предыдущая операция незавершена
        /// </summary>
        [Display(Name = "Предыдущая операция незавершена")]
        LIBFPTR_ERROR_BUSY = 055,

        /// <summary>
        /// Ошибка GSM-модуля
        /// </summary>
        [Display(Name = "Ошибка GSM-модуля")] LIBFPTR_ERROR_GSM = 056,

        /// <summary>
        /// Неверная величина скидки/надбавки
        /// </summary>
        [Display(Name = "Неверная величина скидки/надбавки")]
        LIBFPTR_ERROR_INVALID_DISCOUNT = 057,

        /// <summary>
        /// Операция после скидки/надбавки невозможна
        /// </summary>
        [Display(Name = "Операция после скидки/надбавки невозможна")]
        LIBFPTR_ERROR_OPERATION_AFTER_DISCOUNT_DENIED = 058,

        /// <summary>
        /// Неверная секция
        /// </summary>
        [Display(Name = "Неверная секция")] LIBFPTR_ERROR_INVALID_DEPARTMENT = 059,

        /// <summary>
        /// Неверный вид оплаты
        /// </summary>
        [Display(Name = "Неверный вид оплаты")]
        LIBFPTR_ERROR_INVALID_PAYMENT_TYPE = 060,

        /// <summary>
        /// Переполнение при умножении
        /// </summary>
        [Display(Name = "Переполнение при умножении")]
        LIBFPTR_ERROR_MULTIPLICATION_OVERFLOW = 061,

        /// <summary>
        /// Операция запрещена в таблице настроек
        /// </summary>
        [Display(Name = "Операция запрещена в таблице настроек")]
        LIBFPTR_ERROR_DENIED_BY_SETTINGS = 062,

        /// <summary>
        /// Переполнение итога чека
        /// </summary>
        [Display(Name = "Переполнение итога чека")]
        LIBFPTR_ERROR_TOTAL_OVERFLOW = 063,

        /// <summary>
        /// Открыт чек аннулирования – операция невозможна
        /// </summary>
        [Display(Name = "Открыт чек аннулирования – операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_ANNULATION_RECEIPT = 064,

        /// <summary>
        /// Переполнение буфера контрольной ленты
        /// </summary>
        [Display(Name = "Переполнение буфера контрольной ленты")]
        LIBFPTR_ERROR_JOURNAL_OVERFLOW = 065,

        /// <summary>
        /// Чек оплачен не полностью
        /// </summary>
        [Display(Name = "Чек оплачен не полностью")]
        LIBFPTR_ERROR_NOT_FULLY_PAID = 066,

        /// <summary>
        /// Открыт чек возврата – операция невозможна
        /// </summary>
        [Display(Name = "Открыт чек возврата – операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_RETURN_RECEIPT = 067,

        /// <summary>
        /// Смена превысила 24 часа
        /// </summary>
        [Display(Name = "Смена превысила 24 часа")]
        LIBFPTR_ERROR_SHIFT_EXPIRED = 068,

        /// <summary>
        /// Открыт чек продажи – операция невозможна
        /// </summary>
        [Display(Name = "Открыт чек продажи – операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_SELL_RECEIPT = 069,

        /// <summary>
        /// Переполнение ФП
        /// </summary>
        [Display(Name = "Переполнение ФП")] LIBFPTR_ERROR_FISCAL_MEMORY_OVERFLOW = 070,

        /// <summary>
        /// Неверный пароль
        /// </summary>
        [Display(Name = "Неверный пароль")] LIBFPTR_ERROR_INVALID_PASSWORD = 071,

        /// <summary>
        /// Идет обработка контрольной ленты
        /// </summary>
        [Display(Name = "Идет обработка контрольной ленты")]
        LIBFPTR_ERROR_JOURNAL_BUSY = 072,

        /// <summary>
        /// Смена закрыта - операция невозможна
        /// </summary>
        [Display(Name = "Смена закрыта - операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_CLOSED_SHIFT = 073,

        /// <summary>
        /// Неверный номер таблицы
        /// </summary>
        [Display(Name = "Неверный номер таблицы")]
        LIBFPTR_ERROR_INVALID_TABLE_NUMBER = 074,

        /// <summary>
        /// Неверный номер ряда
        /// </summary>
        [Display(Name = "Неверный номер ряда")]
        LIBFPTR_ERROR_INVALID_ROW_NUMBER = 075,

        /// <summary>
        /// Неверный номер поля
        /// </summary>
        [Display(Name = "Неверный номер поля")]
        LIBFPTR_ERROR_INVALID_FIELD_NUMBER = 076,

        /// <summary>
        /// Неверная дата и/или время
        /// </summary>
        [Display(Name = "Неверная дата и/или время")]
        LIBFPTR_ERROR_INVALID_DATE_TIME = 077,

        /// <summary>
        /// Неверная сумма сторно
        /// </summary>
        [Display(Name = "Неверная сумма сторно")]
        LIBFPTR_ERROR_INVALID_STORNO_SUM = 078,

        /// <summary>
        /// Подсчет суммы сдачи невозможен
        /// </summary>
        [Display(Name = "Подсчет суммы сдачи невозможен")]
        LIBFPTR_ERROR_CHANGE_CALCULATION = 079,

        /// <summary>
        /// В ККТ нет денег для выплаты
        /// </summary>
        [Display(Name = "В ККТ нет денег для выплаты")]
        LIBFPTR_ERROR_NO_CASH = 080,

        /// <summary>
        /// Чек закрыт – операция невозможна
        /// </summary>
        [Display(Name = "Документ закрыт – операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_CLOSED_RECEIPT = 081,

        /// <summary>
        /// Чек открыт – операция невозможна
        /// </summary>
        [Display(Name = "Документ открыт – операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_OPENED_RECEIPT = 082,

        /// <summary>
        /// Смена открыта, операция невозможна
        /// </summary>
        [Display(Name = "Смена открыта, операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_OPENED_SHIFT = 083,

        /// <summary>
        /// Серийный номер/MAC-дрес уже задан
        /// </summary>
        [Display(Name = "Серийный номер/MAC-дрес уже задан")]
        LIBFPTR_ERROR_SERIAL_NUMBER_ALREADY_ENTERED = 084,

        /// <summary>
        /// Исчерпан лимит перерегистраций
        /// </summary>
        [Display(Name = "Исчерпан лимит перерегистраций")]
        LIBFPTR_ERROR_TOO_MUCH_REREGISTRATIONS = 085,

        /// <summary>
        /// Неверный номер смены
        /// </summary>
        [Display(Name = "Неверный номер смены")]
        LIBFPTR_ERROR_INVALID_SHIFT_NUMBER = 086,

        /// <summary>
        /// Недопустимый серийный номер ККТ
        /// </summary>
        [Display(Name = "Недопустимый серийный номер ККТ")]
        LIBFPTR_ERROR_INVALID_SERIAL_NUMBER = 087,

        /// <summary>
        /// Недопустимый РНМ и/или ИНН
        /// </summary>
        [Display(Name = "Недопустимый РНМ и/или ИНН")]
        LIBFPTR_ERROR_INVALID_RNM_VATIN = 088,

        /// <summary>
        /// ККТ не зарегистрирована
        /// </summary>
        [Display(Name = "ККТ не зарегистрирована")]
        LIBFPTR_ERROR_FISCAL_PRINTER_NOT_ACTIVATED = 089,

        /// <summary>
        /// Не задан серийный номер
        /// </summary>
        [Display(Name = "Не задан серийный номер")]
        LIBFPTR_ERROR_SERIAL_NUMBER_NOT_ENTERED = 090,

        /// <summary>
        /// Нет отчетов
        /// </summary>
        [Display(Name = "Нет отчетов")] LIBFPTR_ERROR_NO_MORE_REPORTS = 091,

        /// <summary>
        /// Режим не активизирован
        /// </summary>
        [Display(Name = "Режим не активизирован")]
        LIBFPTR_ERROR_MODE_NOT_ACTIVATED = 092,

        /// <summary>
        /// Данные документа отсутствуют
        /// </summary>
        [Display(Name = "Данные документа отсутствуют")]
        LIBFPTR_ERROR_RECORD_NOT_FOUND_IN_JOURNAL = 093,

        /// <summary>
        /// Некорректный код защиты / лицензия или номер
        /// </summary>
        [Display(Name = "Некорректный код защиты / лицензия или номер")]
        LIBFPTR_ERROR_INVALID_LICENSE = 094,

        /// <summary>
        /// Требуется выполнение общего гашения
        /// </summary>
        [Display(Name = "Требуется выполнение общего гашения")]
        LIBFPTR_ERROR_NEED_FULL_RESET = 095,

        /// <summary>
        /// Команда не разрешена введенными кодами защиты / лицензиями ККТ
        /// </summary>
        [Display(Name = "Команда не разрешена введенными кодами защиты / лицензиями ККТ")]
        LIBFPTR_ERROR_DENIED_BY_LICENSE = 096,

        /// <summary>
        /// Невозможна отмена скидки/надбавки
        /// </summary>
        [Display(Name = "Невозможна отмена скидки/надбавки")]
        LIBFPTR_ERROR_DISCOUNT_CANCELLATION_DENIED = 097,

        /// <summary>
        /// Невозможно закрыть чек данным типом оплаты
        /// </summary>
        [Display(Name = "Невозможно закрыть чек данным типом оплаты")]
        LIBFPTR_ERROR_CLOSE_RECEIPT_DENIED = 098,

        /// <summary>
        /// Неверный номер маршрута
        /// </summary>
        [Display(Name = "Неверный номер маршрута")]
        LIBFPTR_ERROR_INVALID_ROUTE_NUMBER = 099,

        /// <summary>
        /// Неверный номер начальной зоны
        /// </summary>
        [Display(Name = "Неверный номер начальной зоны")]
        LIBFPTR_ERROR_INVALID_START_ZONE_NUMBER = 100,

        /// <summary>
        /// Неверный номер конечной зоны
        /// </summary>
        [Display(Name = "Неверный номер конечной зоны")]
        LIBFPTR_ERROR_INVALID_END_ZONE_NUMBER = 101,

        /// <summary>
        /// Неверный тип тарифа
        /// </summary>
        [Display(Name = "Неверный тип тарифа")]
        LIBFPTR_ERROR_INVALID_RATE_TYPE = 102,

        /// <summary>
        /// Неверный тариф
        /// </summary>
        [Display(Name = "Неверный тариф")] LIBFPTR_ERROR_INVALID_RATE = 103,

        /// <summary>
        /// Ошибка обмена с фискальным модулем
        /// </summary>
        [Display(Name = "Ошибка обмена с фискальным модулем")]
        LIBFPTR_ERROR_FISCAL_MODULE_EXCHANGE = 104,

        /// <summary>
        /// Необходимо провести профилактические работы
        /// </summary>
        [Display(Name = "Необходимо провести профилактические работы")]
        LIBFPTR_ERROR_NEED_TECHNICAL_SUPPORT = 105,

        /// <summary>
        /// Неверные номера смен в ККТ и ФН
        /// </summary>
        [Display(Name = "Неверные номера смен в ККТ и ФН")]
        LIBFPTR_ERROR_SHIFT_NUMBERS_DID_NOT_MATCH = 106,

        /// <summary>
        /// Нет устройства, обрабатывающего данную команду
        /// </summary>
        [Display(Name = "Нет устройства, обрабатывающего данную команду")]
        LIBFPTR_ERROR_DEVICE_NOT_FOUND = 107,

        /// <summary>
        /// Нет связи с внешним устройством
        /// </summary>
        [Display(Name = "Нет связи с внешним устройством")]
        LIBFPTR_ERROR_EXTERNAL_DEVICE_CONNECTION = 108,

        /// <summary>
        /// Ошибочное состояние ТРК
        /// </summary>
        [Display(Name = "Ошибочное состояние ТРК")]
        LIBFPTR_ERROR_DISPENSER_INVALID_STATE = 109,

        /// <summary>
        /// Недопустимое кол-во позиций в чеке
        /// </summary>
        [Display(Name = "Недопустимое кол-во позиций в чеке")]
        LIBFPTR_ERROR_INVALID_POSITIONS_COUNT = 110,

        /// <summary>
        /// Ошибочный номер ТРК
        /// </summary>
        [Display(Name = "Ошибочный номер ТРК")]
        LIBFPTR_ERROR_DISPENSER_INVALID_NUMBER = 111,

        /// <summary>
        /// Неверный делитель
        /// </summary>
        [Display(Name = "Неверный делитель")] LIBFPTR_ERROR_INVALID_DIVIDER = 112,

        /// <summary>
        /// Активация данного ФН в составе данной ККТ невозможна
        /// </summary>
        [Display(Name = "Активация данного ФН в составе данной ККТ невозможна")]
        LIBFPTR_ERROR_FN_ACTIVATION_DENIED = 113,

        /// <summary>
        /// Перегрев головки принтера
        /// </summary>
        [Display(Name = "Перегрев головки принтера")]
        LIBFPTR_ERROR_PRINTER_OVERHEAT = 114,

        /// <summary>
        /// Ошибка обмена с ФН на уровне интерфейса I2C
        /// </summary>
        [Display(Name = "Ошибка обмена с ФН на уровне интерфейса I2C")]
        LIBFPTR_ERROR_FN_EXCHANGE = 115,

        /// <summary>
        /// Ошибка формата передачи ФН
        /// </summary>
        [Display(Name = "Ошибка формата передачи ФН")]
        LIBFPTR_ERROR_FN_INVALID_FORMAT = 116,

        /// <summary>
        /// Неверное состояние ФН
        /// </summary>
        [Display(Name = "Неверное состояние ФН")]
        LIBFPTR_ERROR_FN_INVALID_STATE = 117,

        /// <summary>
        /// Неисправимая ошибка ФН
        /// </summary>
        [Display(Name = "Неисправимая ошибка ФН")]
        LIBFPTR_ERROR_FN_FAULT = 118,

        /// <summary>
        /// Ошибка КС ФН
        /// </summary>
        [Display(Name = "Ошибка КС ФН")] LIBFPTR_ERROR_FN_CRYPTO_FAULT = 119,

        /// <summary>
        /// Закончен срок эксплуатации ФН
        /// </summary>
        [Display(Name = "Закончен срок эксплуатации ФН")]
        LIBFPTR_ERROR_FN_EXPIRED = 120,

        /// <summary>
        /// Архив ФН переполнен
        /// </summary>
        [Display(Name = "Архив ФН переполнен")]
        LIBFPTR_ERROR_FN_OVERFLOW = 121,

        /// <summary>
        /// В ФН переданы неверная дата или время
        /// </summary>
        [Display(Name = "В ФН переданы неверная дата или время")]
        LIBFPTR_ERROR_FN_INVALID_DATE_TIME = 122,

        /// <summary>
        /// В ФН нет запрошенных данных
        /// </summary>
        [Display(Name = "В ФН нет запрошенных данных")]
        LIBFPTR_ERROR_FN_NO_MORE_DATA = 123,

        /// <summary>
        /// Переполнение ФН (итог чека)
        /// </summary>
        [Display(Name = "Переполнение ФН (итог чека)")]
        LIBFPTR_ERROR_FN_TOTAL_OVERFLOW = 124,

        /// <summary>
        /// Буфер переполнен
        /// </summary>
        [Display(Name = "Буфер переполнен")] LIBFPTR_ERROR_BUFFER_OVERFLOW = 125,

        /// <summary>
        /// Невозможно напечатать вторую фискальную копию
        /// </summary>
        [Display(Name = "Невозможно напечатать вторую фискальную копию")]
        LIBFPTR_ERROR_PRINT_SECOND_COPY_DENIED = 126,

        /// <summary>
        /// Требуется гашение ЭЖ
        /// </summary>
        [Display(Name = "Требуется гашение ЭЖ")]
        LIBFPTR_ERROR_NEED_RESET_JOURNAL = 127,

        /// <summary>
        /// Некорректная сумма налога
        /// </summary>
        [Display(Name = "Некорректная сумма налога")]
        LIBFPTR_ERROR_TAX_SUM_TOO_MUCH = 128,

        /// <summary>
        /// Начисление налога на последнюю операцию невозможно
        /// </summary>
        [Display(Name = "Начисление налога на последнюю операцию невозможно")]
        LIBFPTR_ERROR_TAX_ON_LAST_OPERATION_DENIED = 129,

        /// <summary>
        /// Неверный номер ФН
        /// </summary>
        [Display(Name = "Неверный номер ФН")] LIBFPTR_ERROR_INVALID_FN_NUMBER = 130,

        /// <summary>
        /// Сумма сторно налога больше суммы зарегистрированного налога данного типа
        /// </summary>
        [Display(Name = "Сумма сторно налога больше суммы зарегистрированного налога данного типа")]
        LIBFPTR_ERROR_TAX_CANCEL_DENIED = 131,

        /// <summary>
        /// Операция невозможна, недостаточно питания
        /// </summary>
        [Display(Name = "Операция невозможна, недостаточно питания")]
        LIBFPTR_ERROR_LOW_BATTERY = 132,

        /// <summary>
        /// Некорректное значение параметров команды ФН
        /// </summary>
        [Display(Name = "Некорректное значение параметров команды ФН")]
        LIBFPTR_ERROR_FN_INVALID_COMMAND = 133,

        /// <summary>
        /// Превышение размеров TLV данных ФН
        /// </summary>
        [Display(Name = "Превышение размеров TLV данных ФН")]
        LIBFPTR_ERROR_FN_COMMAND_OVERFLOW = 134,

        /// <summary>
        /// Нет транспортного соединения ФН
        /// </summary>
        [Display(Name = "Нет транспортного соединения ФН")]
        LIBFPTR_ERROR_FN_NO_TRANSPORT_CONNECTION = 135,

        /// <summary>
        /// Исчерпан ресурс КС ФН
        /// </summary>
        [Display(Name = "Исчерпан ресурс КС ФН")]
        LIBFPTR_ERROR_FN_CRYPTO_HAS_EXPIRED = 136,

        /// <summary>
        /// Ресурс хранения ФД исчерпан
        /// </summary>
        [Display(Name = "Ресурс хранения ФД исчерпан")]
        LIBFPTR_ERROR_FN_RESOURCE_HAS_EXPIRED = 137,

        /// <summary>
        /// Сообщение от ОФД не может быть принято ФН
        /// </summary>
        [Display(Name = "Сообщение от ОФД не может быть принято ФН")]
        LIBFPTR_ERROR_INVALID_MESSAGE_FROM_OFD = 138,

        /// <summary>
        /// В ФН есть неотправленные ФД
        /// </summary>
        [Display(Name = "В ФН есть неотправленные ФД")]
        LIBFPTR_ERROR_FN_HAS_NOT_SEND_DOCUMENTS = 139,

        /// <summary>
        /// Исчерпан ресурс ожидания передачи сообщения в ФН
        /// </summary>
        [Display(Name = "Исчерпан ресурс ожидания передачи сообщения в ФН")]
        LIBFPTR_ERROR_FN_TIMEOUT = 140,

        /// <summary>
        /// Продолжительность смены ФН более 24 часов
        /// </summary>
        [Display(Name = "Продолжительность смены ФН более 24 часов")]
        LIBFPTR_ERROR_FN_SHIFT_EXPIRED = 141,

        /// <summary>
        /// Неверная разница во времени между двумя операциями ФН
        /// </summary>
        [Display(Name = "Неверная разница во времени между двумя операциями ФН")]
        LIBFPTR_ERROR_FN_INVALID_TIME_DIFFERENCE = 142,

        /// <summary>
        /// Некорректная СНО
        /// </summary>
        [Display(Name = "Некорректная СНО")] LIBFPTR_ERROR_INVALID_TAXATION_TYPE = 143,

        /// <summary>
        /// Недопустимый номер ставки налога
        /// </summary>
        [Display(Name = "Недопустимый номер ставки налога")]
        LIBFPTR_ERROR_INVALID_TAX_TYPE = 144,

        /// <summary>
        /// Недопустимый тип оплаты товара
        /// </summary>
        [Display(Name = "Недопустимый тип оплаты товара")]
        LIBFPTR_ERROR_INVALID_COMMODITY_PAYMENT_TYPE = 145,

        /// <summary>
        /// Недопустимый тип кода товара
        /// </summary>
        [Display(Name = "Недопустимый тип кода товара")]
        LIBFPTR_ERROR_INVALID_COMMODITY_CODE_TYPE = 146,

        /// <summary>
        /// Недопустима регистрация подакцизного товара
        /// </summary>
        [Display(Name = "Недопустима регистрация подакцизного товара")]
        LIBFPTR_ERROR_EXCISABLE_COMMODITY_DENIED = 147,

        /// <summary>
        /// Ошибка программирования реквизита
        /// </summary>
        [Display(Name = "Ошибка программирования реквизита")]
        LIBFPTR_ERROR_FISCAL_PROPERTY_WRITE = 148,

        /// <summary>
        /// Неверный тип счетчика
        /// </summary>
        [Display(Name = "Неверный тип счетчика")]
        LIBFPTR_ERROR_INVALID_COUNTER_TYPE = 149,

        /// <summary>
        /// Ошибка отрезчика
        /// </summary>
        [Display(Name = "Ошибка отрезчика")] LIBFPTR_ERROR_CUTTER_FAULT = 150,

        /// <summary>
        /// Снятие отчета прервалось
        /// </summary>
        [Display(Name = "Снятие отчета прервалось")]
        LIBFPTR_ERROR_REPORT_INTERRUPTED = 151,

        /// <summary>
        /// Недопустимое значение отступа слева
        /// </summary>
        [Display(Name = "Недопустимое значение отступа слева")]
        LIBFPTR_ERROR_INVALID_LEFT_MARGIN = 152,

        /// <summary>
        /// Недопустимое значение выравнивания
        /// </summary>
        [Display(Name = "Недопустимое значение выравнивания")]
        LIBFPTR_ERROR_INVALID_ALIGNMENT = 153,

        /// <summary>
        /// Недопустимое значение режима работы с налогом
        /// </summary>
        [Display(Name = "Недопустимое значение режима работы с налогом")]
        LIBFPTR_ERROR_INVALID_TAX_MODE = 154,

        /// <summary>
        /// Файл не найден или неверный формат
        /// </summary>
        [Display(Name = "Файл не найден или неверный формат")]
        LIBFPTR_ERROR_FILE_NOT_FOUND = 155,

        /// <summary>
        /// Размер картинки слишком большой
        /// </summary>
        [Display(Name = "Размер картинки слишком большой")]
        LIBFPTR_ERROR_PICTURE_TOO_BIG = 156,

        /// <summary>
        /// Не удалось сформировать штрихкод
        /// </summary>
        [Display(Name = "Не удалось сформировать штрихкод")]
        LIBFPTR_ERROR_INVALID_BARCODE_PARAMS = 157,

        /// <summary>
        /// Неразрешенные реквизиты
        /// </summary>
        [Display(Name = "Неразрешенные реквизиты")]
        LIBFPTR_ERROR_FISCAL_PROPERTY_DENIED = 158,

        /// <summary>
        /// Ошибка интерфейса ФН
        /// </summary>
        [Display(Name = "Ошибка интерфейса ФН")]
        LIBFPTR_ERROR_FN_INTERFACE = 159,

        /// <summary>
        /// Дублирование данных
        /// </summary>
        [Display(Name = "Дублирование данных")]
        LIBFPTR_ERROR_DATA_DUPLICATE = 160,

        /// <summary>
        /// Не указаны обязательные реквизиты
        /// </summary>
        [Display(Name = "Не указаны обязательные реквизиты")]
        LIBFPTR_ERROR_NO_REQUIRED_FISCAL_PROPERTY = 161,

        /// <summary>
        /// Ошибка чтения документа из ФН
        /// </summary>
        [Display(Name = "Ошибка чтения документа из ФН")]
        LIBFPTR_ERROR_FN_READ_DOCUMENT = 162,

        /// <summary>
        /// Переполнение чисел с плавающей точкой
        /// </summary>
        [Display(Name = "Переполнение чисел с плавающей точкой")]
        LIBFPTR_ERROR_FLOAT_OVERFLOW = 163,

        /// <summary>
        /// Неверное значение параметра ККТ
        /// </summary>
        [Display(Name = "Неверное значение параметра ККТ")]
        LIBFPTR_ERROR_INVALID_SETTING_VALUE = 164,

        /// <summary>
        /// Внутренняя ошибка ККТ
        /// </summary>
        [Display(Name = "Внутренняя ошибка ККТ")]
        LIBFPTR_ERROR_HARD_FAULT = 165,

        /// <summary>
        /// ФН не найден
        /// </summary>
        [Display(Name = "ФН не найден")] LIBFPTR_ERROR_FN_NOT_FOUND = 166,

        /// <summary>
        /// Невозможно записать реквизит агента
        /// </summary>
        [Display(Name = "Невозможно записать реквизит агента")]
        LIBFPTR_ERROR_INVALID_AGENT_FISCAL_PROPERTY = 167,

        /// <summary>
        /// Недопустимое сочетание реквизитов 1002 и 1056
        /// </summary>
        [Display(Name = "Недопустимое сочетание реквизитов 1002 и 1056")]
        LIBFPTR_ERROR_INVALID_FISCAL_PROPERTY_VALUE_1002_1056 = 168,

        /// <summary>
        /// Недопустимое сочетание реквизитов 1002 и 1017
        /// </summary>
        [Display(Name = "Недопустимое сочетание реквизитов 1002 и 1017")]
        LIBFPTR_ERROR_INVALID_FISCAL_PROPERTY_VALUE_1002_1017 = 169,

        /// <summary>
        /// Ошибка скриптового движка ККТ
        /// </summary>
        [Display(Name = "Ошибка скриптового движка ККТ")]
        LIBFPTR_ERROR_SCRIPT = 170,

        /// <summary>
        /// Неверный номер пользовательской ячейки памяти
        /// </summary>
        [Display(Name = "Неверный номер пользовательской ячейки памяти")]
        LIBFPTR_ERROR_INVALID_USER_MEMORY_INDEX = 171,

        /// <summary>
        /// Кассир не зарегистрирован
        /// </summary>
        [Display(Name = "Кассир не зарегистрирован")]
        LIBFPTR_ERROR_NO_ACTIVE_OPERATOR = 172,

        /// <summary>
        /// Отчет о регистрации ККТ прерван
        /// </summary>
        [Display(Name = "Отчет о регистрации ККТ прерван")]
        LIBFPTR_ERROR_REGISTRATION_REPORT_INTERRUPTED = 173,

        /// <summary>
        /// Отчет о закрытии ФН прерван
        /// </summary>
        [Display(Name = "Отчет о закрытии ФН прерван")]
        LIBFPTR_ERROR_CLOSE_FN_REPORT_INTERRUPTED = 174,

        /// <summary>
        /// Отчет об открытии смены прерван
        /// </summary>
        [Display(Name = "Отчет об открытии смены прерван")]
        LIBFPTR_ERROR_OPEN_SHIFT_REPORT_INTERRUPTED = 175,

        /// <summary>
        /// Отчет о состоянии расчетов прерван
        /// </summary>
        [Display(Name = "Отчет о состоянии расчетов прерван")]
        LIBFPTR_ERROR_OFD_EXCHANGE_REPORT_INTERRUPTED = 176,

        /// <summary>
        /// Закрытие чека прервано
        /// </summary>
        [Display(Name = "Закрытие чека прервано")]
        LIBFPTR_ERROR_CLOSE_RECEIPT_INTERRUPTED = 177,

        /// <summary>
        /// Получение документа из ФН прервано
        /// </summary>
        [Display(Name = "Получение документа из ФН прервано")]
        LIBFPTR_ERROR_FN_QUERY_INTERRUPTED = 178,

        /// <summary>
        /// Сбой часов
        /// </summary>
        [Display(Name = "Сбой часов")] LIBFPTR_ERROR_RTC_FAULT = 179,

        /// <summary>
        /// Сбой памяти
        /// </summary>
        [Display(Name = "Сбой памяти")] LIBFPTR_ERROR_MEMORY_FAULT = 180,

        /// <summary>
        /// Сбой микросхемы
        /// </summary>
        [Display(Name = "Сбой микросхемы")] LIBFPTR_ERROR_CHIP_FAULT = 181,

        /// <summary>
        /// Ошибка шаблонов документов
        /// </summary>
        [Display(Name = "Ошибка шаблонов документов")]
        LIBFPTR_ERROR_TEMPLATES_CORRUPTED = 182,

        /// <summary>
        /// Недопустимое значение MAC-адреса
        /// </summary>
        [Display(Name = "Недопустимое значение MAC-адреса")]
        LIBFPTR_ERROR_INVALID_MAC_ADDRESS = 183,

        /// <summary>
        /// Неверный тип (номер) шаблона
        /// </summary>
        [Display(Name = "Неверный тип (номер) шаблона")]
        LIBFPTR_ERROR_INVALID_SCRIPT_NUMBER = 184,

        /// <summary>
        /// Загруженные шаблоны повреждены или отсутствуют
        /// </summary>
        [Display(Name = "Загруженные шаблоны повреждены или отсутствуют")]
        LIBFPTR_ERROR_SCRIPTS_FAULT = 185,

        /// <summary>
        /// Несовместимая версия загруженных шаблонов
        /// </summary>
        [Display(Name = "Несовместимая версия загруженных шаблонов")]
        LIBFPTR_ERROR_INVALID_SCRIPTS_VERSION = 186,

        /// <summary>
        /// Ошибка в формате клише
        /// </summary>
        [Display(Name = "Ошибка в формате клише")]
        LIBFPTR_ERROR_INVALID_CLICHE_FORMAT = 187,

        /// <summary>
        /// Требуется перезагрузка ККТ
        /// </summary>
        [Display(Name = "Требуется перезагрузка ККТ")]
        LIBFPTR_ERROR_WAIT_FOR_REBOOT = 188,

        /// <summary>
        /// Подходящие лицензии не найдены
        /// </summary>
        [Display(Name = "Подходящие лицензии не найдены")]
        LIBFPTR_ERROR_NO_LICENSE = 189,

        /// <summary>
        /// Неверная версия ФФД
        /// </summary>
        [Display(Name = "Неверная версия ФФД")]
        LIBFPTR_ERROR_INVALID_FFD_VERSION = 190,

        /// <summary>
        /// Параметр доступен только для чтения
        /// </summary>
        [Display(Name = "Параметр доступен только для чтения")]
        LIBFPTR_ERROR_CHANGE_SETTING_DENIED = 191,

        /// <summary>
        /// Неверный тип кода товара
        /// </summary>
        [Display(Name = "Неверный тип кода товара")]
        LIBFPTR_ERROR_INVALID_NOMENCLATURE_TYPE = 192,

        /// <summary>
        /// Неверное значение GTIN
        /// </summary>
        [Display(Name = "Неверное значение GTIN")]
        LIBFPTR_ERROR_INVALID_GTIN = 193,

        /// <summary>
        /// Отрицательный результат математической операции
        /// </summary>
        [Display(Name = "Отрицательный результат математической операции")]
        LIBFPTR_ERROR_NEGATIVE_MATH_RESULT = 194,

        /// <summary>
        /// Недопустимое сочетание реквизитов
        /// </summary>
        [Display(Name = "Недопустимое сочетание реквизитов")]
        LIBFPTR_ERROR_FISCAL_PROPERTIES_COMBINATION = 195,

        /// <summary>
        /// Не удалось зарегистрировать кассира
        /// </summary>
        [Display(Name = "Не удалось зарегистрировать кассира")]
        LIBFPTR_ERROR_OPERATOR_LOGIN = 196,

        /// <summary>
        /// Данный канал Интернет отсутствует в ККТ
        /// </summary>
        [Display(Name = "Данный канал Интернет отсутствует в ККТ")]
        LIBFPTR_ERROR_INVALID_INTERNET_CHANNEL = 197,

        /// <summary>
        /// Дата и время не синхронизированы
        /// </summary>
        [Display(Name = "Дата и время не синхронизированы")]
        LIBFPTR_ERROR_DATETIME_NOT_SYNCRONIZED = 198,

        /// <summary>
        /// Ошибка электронного журнала
        /// </summary>
        [Display(Name = "Ошибка электронного журнала")]
        LIBFPTR_ERROR_JOURNAL = 199,

        /// <summary>
        /// Документ открыт - операция невозможна
        /// </summary>
        [Display(Name = "Документ открыт - операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_OPENED_DOC = 200,

        /// <summary>
        /// Документ закрыт - операция невозможна
        /// </summary>
        [Display(Name = "Документ закрыт - операция невозможна")]
        LIBFPTR_ERROR_DENIED_IN_CLOSED_DOC = 201,

        /// <summary>
        /// Нет места для сохранения лицензий
        /// </summary>
        [Display(Name = "Нет места для сохранения лицензий")]
        LIBFPTR_ERROR_LICENSE_MEMORY_OVERFLOW = 202,

        /// <summary>
        /// Произошла критичная ошибка, документ необходимо отменить
        /// </summary>
        [Display(Name = "Произошла критичная ошибка, документ необходимо отменить")]
        LIBFPTR_ERROR_NEED_CANCEL_DOCUMENT = 203,

        /// <summary>
        /// Регистры ККТ еще не инициализированы
        /// </summary>
        [Display(Name = "Регистры ККТ еще не инициализированы")]
        LIBFPTR_ERROR_REGISTERS_NOT_INITIALIZED = 204,

        /// <summary>
        /// Требуется регистрация итога
        /// </summary>
        [Display(Name = "Требуется регистрация итога")]
        LIBFPTR_ERROR_TOTAL_REQUIRED = 205,

        /// <summary>
        /// Сбой таблицы настроек
        /// </summary>
        [Display(Name = "Сбой таблицы настроек")]
        LIBFPTR_ERROR_SETTINGS_FAULT = 206,

        /// <summary>
        /// Сбой счетчиков и регистров ККТ
        /// </summary>
        [Display(Name = "Сбой счетчиков и регистров ККТ")]
        LIBFPTR_ERROR_COUNTERS_FAULT = 207,

        /// <summary>
        /// Сбой пользовательской памяти
        /// </summary>
        [Display(Name = "Сбой пользовательской памяти")]
        LIBFPTR_ERROR_USER_MEMORY_FAULT = 208,

        /// <summary>
        /// Сбой сервисных регистров
        /// </summary>
        [Display(Name = "Сбой сервисных регистров")]
        LIBFPTR_ERROR_SERVICE_COUNTERS_FAULT = 209,

        /// <summary>
        /// Сбой реквизитов ККТ
        /// </summary>
        [Display(Name = "Сбой реквизитов ККТ")]
        LIBFPTR_ERROR_ATTRIBUTES_FAULT = 210,

        /// <summary>
        /// ККТ уже в режиме обновления конфигурации
        /// </summary>
        [Display(Name = "ККТ уже в режиме обновления конфигурации")]
        LIBFPTR_ERROR_ALREADY_IN_UPDATE_MODE = 211,

        /// <summary>
        /// Конфигурация не прошла проверку
        /// </summary>
        [Display(Name = "Конфигурация не прошла проверку")]
        LIBFPTR_ERROR_INVALID_FIRMWARE = 212,

        /// <summary>
        /// Аппаратный канал отсутствует, выключен или ещё не проинициализирован
        /// </summary>
        [Display(Name = "Аппаратный канал отсутствует, выключен или ещё не проинициализирован")]
        LIBFPTR_ERROR_INVALID_CHANNEL = 213,

        /// <summary>
        /// Сетевой интерфейс не подключен или на нём не получен IP-адрес
        /// </summary>
        [Display(Name = "Сетевой интерфейс не подключен или на нём не получен IP-адрес")]
        LIBFPTR_ERROR_INTERFACE_DOWN = 214,

        /// <summary>
        /// Недопустимое сочетание реквизитов 1212 и 1030
        /// </summary>
        [Display(Name = "Недопустимое сочетание реквизитов 1212 и 1030")]
        LIBFPTR_ERROR_INVALID_FISCAL_PROPERTY_VALUE_1212_1030 = 215,

        /// <summary>
        /// Некорректный признак способа расчета
        /// </summary>
        [Display(Name = "Некорректный признак способа расчета")]
        LIBFPTR_ERROR_INVALID_FISCAL_PROPERTY_VALUE_1214 = 216,

        /// <summary>
        /// Некорректный признак предмета расчета
        /// </summary>
        [Display(Name = "Некорректный признак предмета расчета")]
        LIBFPTR_ERROR_INVALID_FISCAL_PROPERTY_VALUE_1212 = 217,

        /// <summary>
        /// Ошибка синхронизации времени
        /// </summary>
        [Display(Name = "Ошибка синхронизации времени")]
        LIBFPTR_ERROR_SYNC_TIME = 218,

        /// <summary>
        /// В одном чеке одновременно не может быть позиций с НДС 18% (18/118) и НДС 20% (20/120)
        /// </summary>
        [Display(Name = "В одном чеке одновременно не может быть позиций с НДС 18% (18/118) и НДС 20% (20/120)")]
        LIBFPTR_ERROR_VAT18_VAT20_IN_RECEIPT = 219,

        /// <summary>
        /// Картинка не закрыта
        /// </summary>
        [Display(Name = "Картинка не закрыта")]
        LIBFPTR_ERROR_PICTURE_NOT_CLOSED = 220,

        /// <summary>
        /// Сетевой интерфейс занят
        /// </summary>
        [Display(Name = "Сетевой интерфейс занят")]
        LIBFPTR_ERROR_INTERFACE_BUSY = 221,

        /// <summary>
        /// Неверный номер картинки
        /// </summary>
        [Display(Name = "Неверный номер картинки")]
        LIBFPTR_ERROR_INVALID_PICTURE_NUMBER = 222,

        /// <summary>
        /// Ошибка проверки контейнера
        /// </summary>
        [Display(Name = "Ошибка проверки контейнера")]
        LIBFPTR_ERROR_INVALID_CONTAINER = 223,

        /// <summary>
        /// Архив ФН закрыт
        /// </summary>
        [Display(Name = "Архив ФН закрыт")] LIBFPTR_ERROR_ARCHIVE_CLOSED = 224,

        /// <summary>
        /// Нужно выполнить регистрацию/перерегистрацию
        /// </summary>
        [Display(Name = "Нужно выполнить регистрацию/перерегистрацию")]
        LIBFPTR_ERROR_NEED_REGISTRATION = 225,

        /// <summary>
        /// Операция невозможна, идет обновление ПО ККТ
        /// </summary>
        [Display(Name = "Операция невозможна, идет обновление ПО ККТ")]
        LIBFPTR_ERROR_DENIED_DURING_UPDATE = 226,

        /// <summary>
        /// Неверный итог чека
        /// </summary>
        [Display(Name = "Неверный итог чека")] LIBFPTR_ERROR_INVALID_TOTAL = 227,

        /// <summary>
        /// Запрещена одновременная передача КМ и реквизита 1162
        /// </summary>
        [Display(Name = "Запрещена одновременная передача КМ и реквизита 1162")]
        LIBFPTR_ERROR_MARKING_CODE_CONFLICT = 228,

        /// <summary>
        /// Набор записей по заданному идентификатору не найден
        /// </summary>
        [Display(Name = "Набор записей по заданному идентификатору не найден")]
        LIBFPTR_ERROR_INVALID_RECORDS_ID = 229,

        /// <summary>
        /// Ошибка цифровой подписи
        /// </summary>
        [Display(Name = "Ошибка цифровой подписи")]
        LIBFPTR_ERROR_INVALID_SIGNATURE = 230,

        /// <summary>
        /// Некорректная сумма акциза
        /// </summary>
        [Display(Name = "Некорректная сумма акциза")]
        LIBFPTR_ERROR_INVALID_EXCISE_SUM = 231,

        /// <summary>
        /// Заданный диапазон документов не найден в БД документов
        /// </summary>
        [Display(Name = "Заданный диапазон документов не найден в БД документов")]
        LIBFPTR_ERROR_NO_DOCUMENTS_FOUND_IN_JOURNAL = 232,

        /// <summary>
        /// Неподдерживаемый тип скрипта
        /// </summary>
        [Display(Name = "Неподдерживаемый тип скрипта")]
        LIBFPTR_ERROR_INVALID_SCRIPT_TYPE = 233,

        /// <summary>
        /// Некорректный идентификатор скрипта
        /// </summary>
        [Display(Name = "Некорректный идентификатор скрипта")]
        LIBFPTR_ERROR_INVALID_SCRIPT_NAME = 234,

        /// <summary>
        /// Кол-во позиций с реквизитом 1162/1163 в автономном режиме превысило разрешенный лимит
        /// </summary>
        [Display(Name = "Кол-во позиций с реквизитом 1162/1163 в автономном режиме превысило разрешенный лимит")]
        LIBFPTR_ERROR_INVALID_POSITIONS_COUNT_WITH_1162 = 235,

        /// <summary>
        /// Универсальный счетчик с заданными параметрами недоступен
        /// </summary>
        [Display(Name = "Универсальный счетчик с заданными параметрами недоступен")]
        LIBFPTR_ERROR_INVALID_UC_COUNTER = 236,

        /// <summary>
        /// Неподдерживаемый тег для универсальных счетчиков
        /// </summary>
        [Display(Name = "Неподдерживаемый тег для универсальных счетчиков")]
        LIBFPTR_ERROR_INVALID_UC_TAG = 237,

        /// <summary>
        /// Некорректный индекс для универсальных счетчиков
        /// </summary>
        [Display(Name = "Некорректный индекс для универсальных счетчиков")]
        LIBFPTR_ERROR_INVALID_UC_IDX = 238,

        /// <summary>
        /// Неверный размер универсального счетчика
        /// </summary>
        [Display(Name = "Неверный размер универсального счетчика")]
        LIBFPTR_ERROR_INVALID_UC_EMPTY_FILTER = 239,

        /// <summary>
        /// Неверная конфигурация универсальных счетчиков
        /// </summary>
        [Display(Name = "Неверная конфигурация универсальных счетчиков")]
        LIBFPTR_ERROR_INVALID_UC_CONFIG = 240,

        /// <summary>
        /// Соединение с ККТ потеряно
        /// </summary>
        [Display(Name = "Соединение с ККТ потеряно")]
        LIBFPTR_ERROR_CONNECTION_LOST = 241,

        /// <summary>
        /// Ошибка универсальных счетчиков
        /// </summary>
        [Display(Name = "Ошибка универсальных счетчиков")]
        LIBFPTR_ERROR_UNIVERSAL_COUNTERS_FAULT = 242,

        /// <summary>
        /// Некорректная сумма налога
        /// </summary>
        [Display(Name = "Некорректная сумма налога")]
        LIBFPTR_ERROR_INVALID_TAX_SUM = 243,

        /// <summary>
        /// Некорректное значение типа кода маркировки
        /// </summary>
        [Display(Name = "Некорректное значение типа кода маркировки")]
        LIBFPTR_ERROR_INVALID_MARKING_CODE_TYPE = 244,

        /// <summary>
        /// Аппаратная ошибка при сохранении лицензии
        /// </summary>
        [Display(Name = "Аппаратная ошибка при сохранении лицензии")]
        LIBFPTR_ERROR_LICENSE_HARD_FAULT = 245,

        /// <summary>
        /// Подпись лицензии некорректна
        /// </summary>
        [Display(Name = "Подпись лицензии некорректна")]
        LIBFPTR_ERROR_LICENSE_INVALID_SIGN = 246,

        /// <summary>
        /// Лицензия не подходит для данной ККТ
        /// </summary>
        [Display(Name = "Лицензия не подходит для данной ККТ")]
        LIBFPTR_ERROR_LICENSE_INVALID_SERIAL = 247,

        /// <summary>
        /// Срок действия лицензии истёк
        /// </summary>
        [Display(Name = "Срок действия лицензии истёк")]
        LIBFPTR_ERROR_LICENSE_INVALID_TIME = 248,

        /// <summary>
        /// Документ был отменен
        /// </summary>
        [Display(Name = "Документ был отменен")]
        LIBFPTR_ERROR_DOCUMENT_CANCELED = 249,

        /// <summary>
        /// Некорректные параметры скрипта
        /// </summary>
        [Display(Name = "Некорректные параметры скрипта")]
        LIBFPTR_ERROR_INVALID_SCRIPT_PARAMS = 250,

        /// <summary>
        /// Длина клише превышает максимальное значение
        /// </summary>
        [Display(Name = "Длина клише превышает максимальное значение")]
        LIBFPTR_ERROR_CLICHE_TOO_LONG = 251,

        /// <summary>
        /// Ошибка таблицы товаров
        /// </summary>
        [Display(Name = "Ошибка таблицы товаров")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_FAULT = 252,

        /// <summary>
        /// Общая ошибка таблицы товаров
        /// </summary>
        [Display(Name = "Общая ошибка таблицы товаров")]
        LIBFPTR_ERROR_COMMODITIES_TABLE = 253,

        /// <summary>
        /// Некорректный тег для таблицы товаров
        /// </summary>
        [Display(Name = "Некорректный тег для таблицы товаров")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_INVALID_TAG = 254,

        /// <summary>
        /// Некорректный размер тега для таблицы товаров
        /// </summary>
        [Display(Name = "Некорректный размер тега для таблицы товаров")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_INVALID_TAG_SIZE = 255,

        /// <summary>
        /// Нет данных по тегу в таблице товаров
        /// </summary>
        [Display(Name = "Нет данных по тегу в таблице товаров")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_NO_TAG_DATA = 256,

        /// <summary>
        /// Нет места в динамической области памяти таблицы товаров
        /// </summary>
        [Display(Name = "Нет места в динамической области памяти таблицы товаров")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_NO_FREE_MEMORY = 257,

        /// <summary>
        /// Ошибка чтения/записи данных кеша
        /// </summary>
        [Display(Name = "Ошибка чтения/записи данных кеша")]
        LIBFPTR_ERROR_INVALID_CACHE = 258,

        /// <summary>
        /// Функции планировщика заданий не доступны
        /// </summary>
        [Display(Name = "Функции планировщика заданий не доступны")]
        LIBFPTR_ERROR_SCHEDULER_NOT_READY = 259,

        /// <summary>
        /// Неизвестный тип задания планировщика
        /// </summary>
        [Display(Name = "Неизвестный тип задания планировщика")]
        LIBFPTR_ERROR_SCHEDULER_INVALID_TASK = 260,

        /// <summary>
        /// Отсутствует позиция оплаты
        /// </summary>
        [Display(Name = "Отсутствует позиция оплаты")]
        LIBFPTR_ERROR_MINIPOS_NO_POSITION_PAYMENT = 261,

        /// <summary>
        /// Таймаут выполнения команды истек
        /// </summary>
        [Display(Name = "Таймаут выполнения команды истек")]
        LIBFPTR_ERROR_MINIPOS_COMMAND_TIME_OUT = 262,

        /// <summary>
        /// Режим ФР выключен
        /// </summary>
        [Display(Name = "Режим ФР выключен")] LIBFPTR_ERROR_MINIPOS_MODE_FR_DISABLED = 263,

        /// <summary>
        /// Не найдена запись в OTP
        /// </summary>
        [Display(Name = "Не найдена запись в OTP")]
        LIBFPTR_ERROR_ENTRY_NOT_FOUND_IN_OTP = 264,

        /// <summary>
        /// Подакцизный товар без акциза зарегистрирован в чеке
        /// </summary>
        [Display(Name = "Подакцизный товар без акциза зарегистрирован в чеке")]
        LIBFPTR_ERROR_EXCISABLE_COMMODITY_WITHOUT_EXCISE = 265,

        /// <summary>
        /// Данный тип штрихкода не поддерживается
        /// </summary>
        [Display(Name = "Данный тип штрихкода не поддерживается")]
        LIBFPTR_ERROR_BARCODE_TYPE_NOT_SUPPORTED = 266,

        /// <summary>
        /// Размер данных штрихкода и текста превышает допустимый
        /// </summary>
        [Display(Name = "Размер данных штрихкода и текста превышает допустимый")]
        LIBFPTR_ERROR_OVERLAY_DATA_OVERFLOW = 267,

        /// <summary>
        /// Ошибка чтения адреса модуля и сегмента
        /// </summary>
        [Display(Name = "Ошибка чтения адреса модуля и сегмента")]
        LIBFPTR_ERROR_INVALID_MODULE_ADDRESS = 268,

        /// <summary>
        /// Данная модель ККТ не поддерживается
        /// </summary>
        [Display(Name = "Данная модель ККТ не поддерживается")]
        LIBFPTR_ERROR_ECR_MODEL_NOT_SUPPORTED = 269,

        /// <summary>
        /// Оплата по данному чеку не требуется
        /// </summary>
        [Display(Name = "Оплата по данному чеку не требуется")]
        LIBFPTR_ERROR_PAID_NOT_REQUIRED = 270,

        /// <summary>
        /// Непечатаемые символы в реквизите
        /// </summary>
        [Display(Name = "Непечатаемые символы в реквизите")]
        LIBFPTR_ERROR_NON_PRINTABLE_CHAR = 271,

        /// <summary>
        /// Неизвестный пользовательский тег
        /// </summary>
        [Display(Name = "Неизвестный пользовательский тег")]
        LIBFPTR_ERROR_INVALID_USER_TAG = 272,

        /// <summary>
        /// Перебор окончен без найденных данных
        /// </summary>
        [Display(Name = "Перебор окончен без найденных данных")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_ITERATION_STOPPED = 273,

        /// <summary>
        /// Некорректный формат CSV
        /// </summary>
        [Display(Name = "Некорректный формат CSV")]
        LIBFPTR_ERROR_COMMODITIES_TABLE_INVALID_CSV_FORMAT = 274,

        /// <summary>
        /// Нет файла на USB-носителе
        /// </summary>
        [Display(Name = "Нет файла на USB-носителе")]
        LIBFPTR_ERROR_MINIPOS_NO_FILE_ON_USB_STORE = 275,

        /// <summary>
        /// Не задан признак агента по предмету расчета
        /// </summary>
        [Display(Name = "Не задан признак агента по предмету расчета")]
        LIBFPTR_ERROR_MINIPOS_NO_AGENT_FISCAL_PROPERTY = 276,

        /// <summary>
        /// Отсутствует подключение к сервису печати
        /// </summary>
        [Display(Name = "Отсутствует подключение к сервису печати")]
        LIBFPTR_ERROR_NO_CONNECTION_WITH_PRINT_SERVICE = 277,

        /// <summary>
        /// Процедура проверки КМ уже запущена
        /// </summary>
        [Display(Name = "Процедура проверки КМ уже запущена")]
        LIBFPTR_ERROR_MARKING_CODE_VALIDATION_IN_PROGRESS = 401,

        /// <summary>
        /// Ошибка соединения с сервером
        /// </summary>
        [Display(Name = "Ошибка соединения с сервером")]
        LIBFPTR_ERROR_NO_CONNECTION_WITH_SERVER = 402,

        /// <summary>
        /// Процедура проверки КМ прервана
        /// </summary>
        [Display(Name = "Процедура проверки КМ прервана")]
        LIBFPTR_ERROR_MARKING_CODE_VALIDATION_CANCELED = 403,

        /// <summary>
        /// Некорректное значение статуса КМ
        /// </summary>
        [Display(Name = "Некорректное значение статуса КМ")]
        LIBFPTR_ERROR_INVALID_MARKING_CODE_STATUS = 404,

        /// <summary>
        /// Неверный код GS1
        /// </summary>
        [Display(Name = "Неверный код GS1")] LIBFPTR_ERROR_INVALID_GS1 = 405,

        /// <summary>
        /// Запрещена работа с маркированным товарами
        /// </summary>
        [Display(Name = "Запрещена работа с маркированным товарами")]
        LIBFPTR_ERROR_MARKING_WORK_DENIED = 406,

        /// <summary>
        /// Работа с маркированными товарами временно заблокирована
        /// </summary>
        [Display(Name = "Работа с маркированными товарами временно заблокирована")]
        LIBFPTR_ERROR_MARKING_WORK_TEMPORARY_BLOCKED = 407,

        /// <summary>
        /// Переполнена таблица хранения КМ
        /// </summary>
        [Display(Name = "Переполнена таблица хранения КМ")]
        LIBFPTR_ERROR_MARKS_OVERFLOW = 408,

        /// <summary>
        /// Некорректный код маркировки
        /// </summary>
        [Display(Name = "Некорректный код маркировки")]
        LIBFPTR_ERROR_INVALID_MARKING_CODE = 409,

        /// <summary>
        /// Неверное состояние
        /// </summary>
        [Display(Name = "Неверное состояние")] LIBFPTR_ERROR_INVALID_STATE = 410,

        /// <summary>
        /// Ошибка обмена с сервером ОФД или ИСМ
        /// </summary>
        [Display(Name = "Ошибка обмена с сервером ОФД или ИСМ")]
        LIBFPTR_ERROR_OFD_EXCHANGE = 411,

        /// <summary>
        /// Некорректное значение единиц измерения
        /// </summary>
        [Display(Name = "Некорректное значение единиц измерения")]
        LIBFPTR_ERROR_INVALID_MEASUREMENT_UNIT = 412,

        /// <summary>
        /// Операция не разрешена в данной версии ФФД
        /// </summary>
        [Display(Name = "Операция не разрешена в данной версии ФФД")]
        LIBFPTR_ERROR_OPERATION_DENIED_IN_CURRENT_FFD = 413,

        /// <summary>
        /// Операция не разрешена, при регистрации не был установлен признак ТМТ
        /// </summary>
        [Display(Name = "Операция не разрешена, при регистрации не был установлен признак ТМТ")]
        LIBFPTR_ERROR_MARKING_OPERATION_DENIED = 414,

        /// <summary>
        /// Нет данных для отправки
        /// </summary>
        [Display(Name = "Нет данных для отправки")]
        LIBFPTR_ERROR_NO_DATA_TO_SEND = 415,

        /// <summary>
        /// Нет маркированных позиций в чеке
        /// </summary>
        [Display(Name = "Нет маркированных позиций в чеке")]
        LIBFPTR_ERROR_NO_MARKED_POSITION = 416,

        /// <summary>
        /// Имеются неотправленные уведомления
        /// </summary>
        [Display(Name = "Имеются неотправленные уведомления")]
        LIBFPTR_ERROR_HAS_NOT_SEND_NOTICES = 417,

        /// <summary>
        /// Требуется повторное проведение процедуры обновления ключей
        /// </summary>
        [Display(Name = "Требуется повторное проведение процедуры обновления ключей")]
        LIBFPTR_ERROR_UPDATE_KEYS_REQUIRED = 418,

        /// <summary>
        /// Ошибка сервиса обновления ключей проверки КМ
        /// </summary>
        [Display(Name = "Ошибка сервиса обновления ключей проверки КМ")]
        LIBFPTR_ERROR_UPDATE_KEYS_SERVICE = 419,

        /// <summary>
        /// КМ не проверен в ФН
        /// </summary>
        [Display(Name = "КМ не проверен в ФН")]
        LIBFPTR_ERROR_MARK_NOT_CHECKED = 420,

        /// <summary>
        /// Истёк таймаут проверки КМ
        /// </summary>
        [Display(Name = "Истёк таймаут проверки КМ")]
        LIBFPTR_ERROR_MARK_CHECK_TIMEOUT_EXPIRED = 421,

        /// <summary>
        /// Данный КМ отсутствует в таблице
        /// </summary>
        [Display(Name = "Данный КМ отсутствует в таблице")]
        LIBFPTR_ERROR_NO_MARKING_CODE_IN_TABLE = 422,

        /// <summary>
        /// Выполняется проверка КМ
        /// </summary>
        [Display(Name = "Выполняется проверка КМ")]
        LIBFPTR_ERROR_CHEKING_MARK_IN_PROGRESS = 423,

        /// <summary>
        /// Настройки адреса сервера не заданы
        /// </summary>
        [Display(Name = "Настройки адреса сервера не заданы")]
        LIBFPTR_ERROR_INVALID_SERVER_ADDRESS = 424,

        /// <summary>
        /// Истёк таймаут обновления ключей проверки
        /// </summary>
        [Display(Name = "Истёк таймаут обновления ключей проверки")]
        LIBFPTR_ERROR_UPDATE_KEYS_TIMEOUT = 425,

        /// <summary>
        /// Данный реквизит разрешён только для маркированной позиции
        /// </summary>
        [Display(Name = "Данный реквизит разрешён только для маркированной позиции")]
        LIBFPTR_ERROR_PROPERTY_FOR_MARKING_POSITION_ONLY = 426,

        /// <summary>
        /// Ошибка парсинга запроса
        /// </summary>
        [Display(Name = "Ошибка парсинга запроса")]
        LIBFPTR_ERROR_RECEIPT_PARSE_ERROR = 501,

        /// <summary>
        /// Выполнение прервано из-за предыдущих ошибок
        /// </summary>
        [Display(Name = "Выполнение прервано из-за предыдущих ошибок")]
        LIBFPTR_ERROR_INTERRUPTED_BY_PREVIOUS_ERRORS = 502,

        /// <summary>
        /// Ошибка скрипта драйвера
        /// </summary>
        [Display(Name = "Ошибка скрипта драйвера")]
        LIBFPTR_ERROR_DRIVER_SCRIPT_ERROR = 503,

        /// <summary>
        /// Функция проверки задания не найдена
        /// </summary>
        [Display(Name = "Функция проверки задания не найдена")]
        LIBFPTR_ERROR_VALIDATE_FUNC_NOT_FOUND = 504,

        /// <summary>
        /// Устройство на сервере удалённого подключения занято другим клиентом
        /// </summary>
        [Display(Name = "Устройство на сервере удалённого подключения занято другим клиентом")]
        LIBFPTR_ERROR_RCP_SERVER_BUSY = 601,

        /// <summary>
        /// Некорректная версия протокола обмена с сервером удалённого подключения
        /// </summary>
        [Display(Name = "Некорректная версия протокола обмена с сервером удалённого подключения")]
        LIBFPTR_ERROR_RCP_SERVER_VERSION = 602,

        /// <summary>
        /// Ошибка обмена с сервером удалённого подключения
        /// </summary>
        [Display(Name = "Ошибка обмена с сервером удалённого подключения")]
        LIBFPTR_ERROR_RCP_SERVER_EXCHANGE = 603
    }
}