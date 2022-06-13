namespace HWEssentials.Lesson1;

public static class Lesson1Task1
{
    /// <summary>
    /// Проверка что число простое. Возвращает true если так
    /// </summary>
    /// <param name="number">число тира long</param>
    public static bool CheckIsPrime(long number)
    {
        long d = 0;
        var i = 2;

        while (i < number)
            if (number % i == 0)
                // d++;  это как бы требуется по блок схеме, но что-то очень не хочется вычислять много лишних итераций
                return false;
            else
                i++; //ну как бы тоже лишнее: если число уже разделилось скажем на 2 зачем провыерить, что делится на 4 ??

        return true;
    }

    // Основная функция с пользовательским вводом. Вроде как в задании надо сделать все в одной функции, в т.ч. ввод, но 
    // непонятно как такое тестировать (не знаю как генерировать пользовательсикй ввод, а перенаправлять потоки, наверное сосвем не стОит 
    // в такой задаче. Поэтому разбил все на разные методы
    public static void TaskOneDotOne()
    {
        Console.WriteLine("введите число number для проверки (простое они или нет): "); // В блок-схеме нет такого
        var number = long.Parse(Console.ReadLine());
        if (CheckIsPrime(number))
            Console.WriteLine("number простое");
        else
            Console.WriteLine("number не простое");
    }


    /// <summary>
    /// Сверяет результат функции CheckIsPrime с ожидаемым результатом
    /// </summary>
    /// <param name="number">Тестовое число</param>
    /// <param name="expectPrime">Ожидаемый результат работы функции. True - просое число, false - нет</param>
    /// <returns></returns>
    public static bool AssertPrime(long number, bool expectPrime)
    {
        return CheckIsPrime(number) == expectPrime;
    }

    /// <summary>
    /// подаем заведомо простое и заведомо непростое число и ожидаемый результат выполнения функции
    /// </summary>
    public static void TestCheckIsPrime()
    {
        long number1 = 2024;
        var expectedResult1 = false;

        long number2 = 1009;
        var expectedResult2 = true;

        Console.WriteLine(
            $"Проверяем число {number1}, ожидем результат {expectedResult1} . Выполняется ли данное утвердение : {AssertPrime(number1, expectedResult1)} ");
        Console.WriteLine(
            $"Проверяем число {number2}, ожидем результат {expectedResult2} . Выполняется ли данное утвердение : {AssertPrime(number2, expectedResult2)} ");
    }
}