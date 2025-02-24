using System;
public interface ICalculator
{
    double Add(double num1, double num2);
}

public interface ILogger
{
    void LogError(string message);
    void LogInfo(string message);
}

public class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Устанавливаем красный цвет для ошибок
        Console.WriteLine($"Ошибка: {message}");
        Console.ResetColor();
    }

    public void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue; // Устанавливаем синий цвет для информации
        Console.WriteLine($"Информация: {message}");
        Console.ResetColor();
    }
}
public class SimpleCalculator : ICalculator
{
    public double Add(double num1, double num2)
    {
        return num1 + num2;
    }
}
class Program
{
    private readonly ICalculator _calculator;
    private readonly ILogger _logger;

    public Program(ICalculator calculator, ILogger logger)
    {
        _calculator = calculator;
        _logger = logger;
    }

    static void Main()
    {
        // Создаем экземпляры зависимостей
        ICalculator calculator = new SimpleCalculator();
        ILogger logger = new ConsoleLogger();

        Program program = new Program(calculator, logger);
        program.Run();
    }

    public void Run()
    {
        double number1 = 0;
        double number2 = 0;

        try
        {
            Console.WriteLine("Введите первое число:");
            number1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            number2 = double.Parse(Console.ReadLine());

            double sum = _calculator.Add(number1, number2);
            _logger.LogInfo($"Сумма {number1} и {number2} равна: {sum}");
        }
        catch (FormatException)
        {
            _logger.LogError("Некорректный формат ввода. Пожалуйста, введите числовое значение.");
        }
        catch (OverflowException)
        {
            _logger.LogError("Введенное число слишком велико или слишком мало.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Произошла непредвиденная ошибка: {ex.Message}");
        }
        finally
        {
            _logger.LogInfo("Завершение работы программы.");
        }
    }
}