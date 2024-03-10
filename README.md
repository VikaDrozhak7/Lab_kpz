# Принципи програмування в моєму коді

## 1. DRY (Don't Repeat Yourself)
Мій код написаний таким чином, що кожна частина інформації системи є єдиною і не повторюється. Наприклад, я використовую методи [`AddProduct`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9c5a1b632fc52bd73cff509725fb175515ad6d25/ConsoleApp/Program.cs#L98) в класах [`Warehouse`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L74) та [`ShoppingCart`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L98) для додавання продуктів, замість повторення цього коду в кожному класі.

## 2. KISS (Keep It Simple, Stupid)
Мій код простий і зрозумілий. Кожен клас та метод має чітке призначення, що спрощує розуміння та модифікацію коду.

## 3. SOLID
- Single Responsibility Principle: Кожен клас в моєму коді має одну відповідальність. Наприклад, клас [`Product`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L54) відповідає лише за зберігання інформації про продукт.
- Open/Closed Principle: Мій код написаний таким чином, що його можна легко розширити без модифікації існуючого коду. Наприклад, я можу додати нові типи продуктів, не змінюючи клас  [`Warehouse`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L74).
- Liskov Substitution Principle: У моєму коді всі похідні класи можуть бути замінені на їх базові класи без зміни коректності програми.
- Interface Segregation Principle: Кожен клас використовує лише ті інтерфейси, які йому потрібні. Наприклад, клас [`Product`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L54) використовує лише інтерфейс [`IMoney`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L12).
- Dependency Inversion Principle: Мій код залежить від абстракцій, а не від конкретних деталей. Наприклад, клас [`Product`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L54) залежить від абстракції [`IMoney`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L12), а не від конкретного класу [`Money`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L4).

## 4. YAGNI (You Aren't Gonna Need It)
Я не додаю функціональності до мого коду, поки вони не потрібні. Це допомагає уникнути непотрібного складності та коду.

## 5. Composition Over Inheritance
Я використовую композицію замість наслідування, коли це можливо. Наприклад, клас [`Product`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L54) має об'єкти `Money` та `Category` як частини свого стану, замість того, щоб успадковувати від них.

## 6. Program to Interfaces not Implementations
Я програмую до інтерфейсів, а не до реалізацій. Наприклад, властивість `Price` в класі [`Product`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L54) є типу [`IMoney`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L12), а не конкретного класу [`Money`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L4).

## 7. Fail Fast
Мій код швидко виявляє помилки та негайно зупиняється. Наприклад, метод [`ReducePrice`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L64) в класі [`Product`](https://github.com/VikaDrozhak7/Lab_kpz/blob/9983eab50bf0128dd6d2e8fe9e67581b698f406c/ConsoleApp/Program.cs#L54) викидає виняток, якщо спробувати зменшити ціну більше, ніж вона становить.
