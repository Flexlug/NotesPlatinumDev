﻿**Зависимость** - это любой объект, от которого зависит другой объект. Или проще говоря, когда в одном классе есть ссылка на другой класс. Как следствие при изменении одного класса может также потребоваться внесение изменений в тот класс, в котором используется измененный класс.

**Внедрение зависимостей** - это в впервую очередь просто идея (а не технология, фреймворк). Идея обработки зависимостей вне зависимого класса, когда зависимому классу не нужно ничего делать. Т.е. вместо того, чтобы зависимый класс сам создавал экземляры других классов, ему эти экземпляры передаются во время инициализации. А ответственность за создание экземпляров возлагается на третью сторону. 

Посмотреть про инверсию управления (IoC) - https://www.youtube.com/watch?v=PNoryHkDYUc 

Зависимости следует избегать по следующим причинам:
- Чтобы изменить что-либо другой реализацией, другие зависящие классы также необходимо изменить;
- Если у класса есть зависимости, их конфигурацию должен выполнять зависящий класс. В больших проектах, когда от одного класса зависят многие классы, код конфигурации растягивается по всему приложению.
- Такая реализация плохо подходит для модульных тестов

Внедрение зависимостей устраняет эту проблему следующими способами:
- Используется интерфейс или базовый класс для абстрагирования реализации зависимостей;
- Зависимость регистрируется в конейнере сервисов. В частности ASP.NET Core предоставляет встроенный контейнер служб `IServiceProvider`. Как правило сервисы регистрируеются в приложении в методе Startup.ConfigureServices.
- Сервис внедряется в конструктор класса там, где он используется. Платформа берет на себя создание экземпляра зависимости и его удаление (???), когда он больше не нужен. 
- Не использует конкретный тип, а использует только интерфейс, который он реализует. Это упрощает изменение реализации, используемой контроллером, без изменения контроллера;
- Не создает экземпляр класса, он создается контейнером внедрения зависимостей

Внедрение зависимостей:
- `AddTransient()` - создает Transient объекты. Такие объекты создаются при каждом образении к ним
- `AddScoped()` - создает один экземпляр объекта, заданный областью временем существования;
- `AddSingleton()` - создает объект для всех последующих запросов. При этом объект создается только тогда, когда он нужен. После создания он продолжает существовать.

Получение зависимостей;
- Через конструктор (кроме конструктора `Startup`);
- Через параметр метода `Configure()` класса `Startup`;
- Через параметр метода `Invoke()` компонента middleware;
- Через свойство `RequestServices` контекста запроса `HttpContext` в компонентах middleware;
- Через свойство `ApplicationServices` объекта `IApplicationBuilder` в классе `Startup`

То, что нам нужно сейчас реализовать, это **регистрацию групп сервисов** с помощью методов расширения. У нас есть отдельные проекты. И мы хотим всё зарегистрировать в главном WebApi проекте в нашем Web-приложении. В ASP.NET Core используется соглашение, которое заключается в использовании одного метода-расширения `Add{GROUP_NAME}`. 
