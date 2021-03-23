## Задание с библиотекой
### Текст задания 
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры 	
- Проверку на то, является ли треугольник прямоугольным

### Пояснения к реализации
- Сама библиотека лежит в проекте Area2DCalculator
- Тестирование функционала в проекте DllTests

#### Юнит тесты
Учитывая требования к текущему функционалу, не было необходимости создавать некие объекты "фигуры", вид которых менялся бы в зависимости от конкретной реализации.
На данный момент отсутствуют верно оформленные юнит-тесты (пока лишь подобие в DllTests для тестирования функционала и проверки реакции на некорректные входные данные). 
Могу добавить их при необходимости позже, если устроит текущая реализация библиотеки.

#### Вычисление площади фигуры без знания типа фигуры
Универсальное решение для несамопересекающихся многоугольников с прямыми сторонами

## Задание с SQL запросом
### Текст задания
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. 
Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
### Пояснение к реализации ("Query Product-Category.sql")
Для этого можно создать таблицу ProductsCategories - промежуточную таблицу соответствия продуктов и категорий.
