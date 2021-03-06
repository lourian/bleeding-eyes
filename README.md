Этот код заставит глаза кровоточить.

Что надо было сделать:

Необходимо разработать приложение для отображения расписания кинотеатров города. В компании имеются справочники кинофильмов и кинотеатров. Необходимо разработать структуру хранения расписаний с привязкой к справочникам, страницу добавления расписания и страницу отображения расписания города. Нужно уделить внимание валидации вводимых данных.


Комментарии:

- Прежде всего решение не до конца соответствует задаче. Перед разработчиком стояла задача разработать готовое приложение, а не API с описанием, в решении клиентской части я не увидел, также нет авторизации доступа, логирования и обработки ошибок, как клиентских (например, 404), так и серверных (500).

- У API-роутов было бы неплохо добавить префикс, например, /api, кроме того роуты некорректны с точки зрения REST, например есть конечная точка /cinema/add. Корректно сделать коллекцию кинотеатров доступной по адресу /api/cinema, а операцию должен определять HTTP-метод, которым запрошен ресурс, в данном случае — POST. Это замечание не критично, но работать с таким API несколько удобнее в том числе, благодаря поддержке концепций REST некоторыми инструментами;

- Немного связано с предыдущим пунктом: приложение не возвращает корректных статусов, например, в случае, если сущность не найдена в хранилище, приложение должно вернуть ответ со статусом 404.

- В решении присутствует «мертвый код», а именно — проект Cinema.WebHost, который не используется.

- Было бы неплохо почистить директивы using;

- Выбран не самый удачный нейминг. Решение называется Cinema, основной проект — тоже, на мой взгляд, корректнее было назвать его Cinema.Web.

- Интерфейсу IRepository, ровно, как и всему, что относится к DAL не место в проекте c веб-приложением (Cinema), их стоит вынести в отдельный проект;


- В методе расширения NullOrEmpty(IEnumerable) при каждом его вызове создается объект-итератор (IEnumerator), что может вызвать оверхед. Если нам необходимы какие-либо действия, кроме итерации, стоит использовать интерфейс, отличный от IEnumerable, например ICollection.


- Атрибут ValidateModelAttribute следует применять не к классу контроллера, а к тем методам, которые принимают модель, как параметр, например, в MovieController таким методом является Add; 

- Поскольку все контроллеры абсолютно идентичны всем, кроме типа возвращаемого результата, в данном случае, следует, на мой взгляд, выделить базовый generic-тип контроллера, это позволит избежать повторений в коде;

- Атрибут RouteAttribute следует применять к классу контроллера, чтобы описать общий префикс роутов, которые обслуживает контроллер, также стоит использовать подстановку [contoller], если префикс, обслуживаемых роутов совпадает с названием контроллера. К методам контроллера следует применять атрибуты Http*Attribute (HttpGet, HttpPost, …), а не RouteAttribute, при этом следует указывать относительные пути.

- На мой взгляд, из контроллеров следует возвращать IActionResult, это — более гибко, а для указания возвращаемого типа ответа пометить метод контроллера атрибутом ProducesResponseTypeAttribute;

- Все методы контроллеров возвращают Task, при этом, в методах нет ничего, кроме вызова другого асинхронного метода. Если в методах контроллера не происходит ничего, то использование async/await излишне, надо просто вернуть Task;


- Репозитории не должны зависеть от конфигурации приложения (IConfiguration), если нам необходима строка подключения, то зависимостью должна быть именно строка подключения, а не конфигурация приложения;

- Создание объекта-фильтра для выборки по id — опять же оверхед, а присутствие в фильтрах идентификатора — странное решение, т.к.  поиск по фильтру подразумевает, что под условия фильтрации могут попадать несколько объектов, выборка же по id всегда должна возвращать один объект, на мой взгляд было бы корректно объявить в интерфейсе хранилища (IRepository) два метода — GetById(id) и Search(filter), метод GetAll — частн случай метода Search, в который вместо объекта фильма передан null;

- Поскольку все репозитории абсолютно идентичны всем, кроме типа возвращаемого результата, следует, как мне кажется, выделить базовый generic-тип репозитория, это позволит избежать повторений в коде, а следовательно ошибок;

- Все реализации IRepository «глотают» исключения, следует либо пробрасывать их дальше, либо логировать. В данном случае…. 
- В репозиториях используются литеральные строки, содержащие SQL, было бы неплохо либо использовать какой-либо построитель запросов или хотя бы вынести строки в константы;


- При инициализации MVC в Startup-классе используется метод UseMvc, принимающий делегат, конфигурирующий роуты, данном случае это не корректно, т.к. во-первых мы используем атрибутивную маршрутизацию и это излишне, во вторых, если используется только маршрут по умолчанию (/{controller}/{action}/{id?}), стоит использовать метод UseMvcWithDefaultRoute;

- В Startup-классе, находящемся в проекте Cinema есть зависимость от файла appsettings.json, который находится в другом проекте (SelfHost), это неверно, как в общем-то и решение сделать компоненты приложения зависимыми от глобальной конфигурации


- Не совсем понятно назначение интерфейса IRequest, на мой взгляд это — лишняя сущность;

- Замечание субъективно, но я думаю, что не стоит использовать аннотации для валидации сущностей.
