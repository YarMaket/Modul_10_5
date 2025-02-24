using System;

public interface ICalculator
{
    double Add(double num1, double num2);
}
class SimpleCalculator : ICalculator
{
    public double Add(double num1, double num2)
    {
        return num1 + num2;
    }
}

class Program
{
    static void Main()
    {
        ICalculator calculator = new SimpleCalculator();

        double number1 = 0;
        double number2 = 0;

        try
        {
            Console.WriteLine("Введите первое число:");
            number1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            number2 = double.Parse(Console.ReadLine());

            double sum = calculator.Add(number1, number2);
            Console.WriteLine($"Сумма {number1} и {number2} равна: {sum}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Некорректный формат ввода. Пожалуйста, введите числовое значение.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: Введенное число слишком велико или слишком мало.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Завершение работы программы.");
        }
    }
}