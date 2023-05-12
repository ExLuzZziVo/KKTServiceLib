# KKTServiceLib
Библиотеки для работы с кассами АТОЛ и Меркурий посредством JSON-заданий

<b>ККТ АТОЛ</b>

Работа с ККТ АТОЛ происходит при помощи драйвера <b>fptr</b>.
<br/>
Пример использования:
```csharp
var fptr = new Fptr();
fptr.open();

var result = new <Операция>.Execute(fptr);

fptr.close();
```
Все доступные операции находятся в пространстве имен <b>KKTServiceLib.Atol.Types.Operations</b>

<b>ККТ Меркурий</b>

Работа с ККТ Меркурий происходит при помощи службы <b>Inecrman</b>.
<br/>
Пример использования:
```csharp
var sessionKey = await new OpenSessionOperation("COM2").ExecuteAsync(null);

var result = await new <Операция>.ExecuteAsync(sessionKey);

await new CloseSessionOperation().ExecuteAsync(sessionKey);
```
Все доступные операции находятся в пространстве имен <b>KKTServiceLib.Mercury.Types.Operations</b>

<b>Работу чего необходимо проверить</b>

Работа следующих возможностей не проверена:
<ul>
<li>Агенты</li>
<li>Маркировка</li>
<li>ЕГАИС</li>
<li>Налоги</li>
</ul>
