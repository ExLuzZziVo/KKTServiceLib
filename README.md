# KKTServiceLib
Библиотеки для работы с кассами АТОЛ и Меркурий посредством JSON-заданий

## ККТ АТОЛ

Работа с ККТ АТОЛ происходит при помощи драйвера **fptr**.

Пример использования:
```csharp
var fptr = new Fptr();
fptr.open();

var result = new <Операция>.Execute(fptr);

fptr.close();
```
Все доступные операции находятся в пространстве имен **KKTServiceLib.Atol.Types.Operations**

## ККТ Меркурий

Работа с ККТ Меркурий происходит при помощи службы **Inecrman**.

Пример использования:
```csharp
var sessionKey = await new OpenSessionOperation("COM2").ExecuteAsync(null);

var result = await new <Операция>.ExecuteAsync(sessionKey);

await new CloseSessionOperation().ExecuteAsync(sessionKey);
```
Все доступные операции находятся в пространстве имен **KKTServiceLib.Mercury.Types.Operations**

## Работу чего необходимо проверить

Работа следующих возможностей не проверена:
- Агенты
- Маркировка
- ЕГАИС
- Налоги

Зависимости CoreLib вы можете найти [тут](https://github.com/ExLuzZziVo/CoreLib).