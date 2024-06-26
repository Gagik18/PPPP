using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Выбор задачи для выполнения
        Console.WriteLine("Выберите задачу для выполнения (введите номер):");
        Console.WriteLine("1. Конвертер температуры");
        Console.WriteLine("2. Перевод времени");
        Console.WriteLine("3. Калькулятор возраста");
        Console.WriteLine("4. Обратный отсчет");
        Console.WriteLine("5. Анализ текста");
        Console.WriteLine("6. Генератор паролей");
        Console.WriteLine("7. Конвертер валют");
        Console.WriteLine("8. Обработка данных о погоде");
        Console.WriteLine("9. Простая система управления задачами");
        Console.WriteLine("10. API клиент (погода)");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                TemperatureConverter();
                break;
            case 2:
                TimeConverter();
                break;
            case 3:
                AgeCalculator();
                break;
            case 4:
                Countdown();
                break;
            case 5:
                TextAnalyzer();
                break;
            case 6:
                PasswordGenerator();
                break;
            case 7:
                CurrencyConverter();
                break;
            case 8:
                WeatherDataProcessor();
                break;
            case 9:
                TaskManager();
                break;
            case 10:
                WeatherApiClient().Wait();
                break;
            default:
                Console.WriteLine("Неправильный выбор.");
                break;
        }

        // Ожидание ввода пользователя для предотвращения закрытия консоли.
        Console.ReadLine();
    }

    // Задача 1: Конвертер температуры
    static void TemperatureConverter()
    {
        Console.WriteLine("Выберите направление конвертации: 1. Цельсий в Фаренгейт 2. Фаренгейт в Цельсий");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Введите температуру в Цельсиях:");
            double celsius = Convert.ToDouble(Console.ReadLine());
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine("Температура в Фаренгейтах: " + fahrenheit);
        }
        else if (choice == 2)
        {
            Console.WriteLine("Введите температуру в Фаренгейтах:");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());
            double celsius = (fahrenheit - 32) * 5 / 9;
            Console.WriteLine("Температура в Цельсиях: " + celsius);
        }
        else
        {
            Console.WriteLine("Неправильный выбор.");
        }
    }

    // Задача 2: Перевод времени
    static void TimeConverter()
    {
        Console.WriteLine("Выберите направление конвертации: 1. 12-часовой в 24-часовой 2. 24-часовой в 12-часовой");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Введите время в формате hh:mm AM/PM:");
            string time12 = Console.ReadLine();
            DateTime dt = DateTime.Parse(time12);
            Console.WriteLine("24-часовой формат: " + dt.ToString("HH:mm"));
        }
        else if (choice == 2)
        {
            Console.WriteLine("Введите время в формате HH:mm:");
            string time24 = Console.ReadLine();
            DateTime dt = DateTime.Parse(time24);
            Console.WriteLine("12-часовой формат: " + dt.ToString("hh:mm tt"));
        }
        else
        {
            Console.WriteLine("Неправильный выбор.");
        }
    }

    // Задача 3: Калькулятор возраста
    static void AgeCalculator()
    {
        Console.WriteLine("Введите дату рождения (формат: ГГГГ-ММ-ДД):");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());
        DateTime now = DateTime.Now;
        int years = now.Year - birthDate.Year;
        int months = now.Month - birthDate.Month;
        int days = now.Day - birthDate.Day;

        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(now.Year, now.Month);
        }
        if (months < 0)
        {
            years--;
            months += 12;
        }

        Console.WriteLine($"Возраст: {years} лет, {months} месяцев, {days} дней");
    }

    // Задача 4: Обратный отсчет
    static void Countdown()
    {
        Console.WriteLine("Введите количество секунд:");
        int seconds = Convert.ToInt32(Console.ReadLine());

        while (seconds > 0)
        {
            Console.WriteLine(seconds);
            System.Threading.Thread.Sleep(1000);
            seconds--;
        }
        Console.WriteLine("Время вышло!");
    }

    // Задача 5: Анализ текста
    static void TextAnalyzer()
    {
        Console.WriteLine("Введите текст для анализа:");
        string text = Console.ReadLine();

        int wordCount = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int sentenceCount = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int paragraphCount = text.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

        Console.WriteLine($"Количество слов: {wordCount}");
        Console.WriteLine($"Количество предложений: {sentenceCount}");
        Console.WriteLine($"Количество абзацев: {paragraphCount}");
    }

    // Задача 6: Генератор паролей
    static void PasswordGenerator()
    {
        Console.WriteLine("Введите длину пароля:");
        int length = Convert.ToInt32(Console.ReadLine());

        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
        Random rnd = new Random();
        char[] password = new char[length];
        for (int i = 0; i < length; i++)
        {
            password[i] = validChars[rnd.Next(validChars.Length)];
        }

        Console.WriteLine("Сгенерированный пароль: " + new string(password));
    }

    // Задача 7: Конвертер валют
    static void CurrencyConverter()
    {
        Console.WriteLine("Введите сумму денег для конвертации:");
        double amount = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите курс конвертации:");
        double rate = Convert.ToDouble(Console.ReadLine());

        double convertedAmount = amount * rate;
        Console.WriteLine("Сумма после конвертации: " + convertedAmount);
    }

    // Задача 8: Обработка данных о погоде
    static void WeatherDataProcessor()
    {
        List<double> temperatures = new List<double>();

        Console.WriteLine("Введите температуры за несколько дней (введите 'stop' для завершения):");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "stop")
            {
                break;
            }

            if (double.TryParse(input, out double temp))
            {
                temperatures.Add(temp);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова.");
            }
        }

        if (temperatures.Count > 0)
        {
            double average = temperatures.Average();
            double max = temperatures.Max();
            double min = temperatures.Min();

            Console.WriteLine($"Средняя температура: {average}");
            Console.WriteLine($"Максимальная температура: {max}");
            Console.WriteLine($"Минимальная температура: {min}");
        }
        else
        {
            Console.WriteLine("Нет введенных данных.");
        }
    }

    // Задача 9: Простая система управления задачами
    static void TaskManager()
    {
        List<string> tasks = new List<string>();

        while (true)
        {
            Console.WriteLine("Выберите действие: 1. Добавить задачу 2. Удалить задачу 3. Редактировать задачу 4. Просмотреть задачи 5. Выход");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите новую задачу:");
                    string newTask = Console.ReadLine();
                    tasks.Add(newTask);
                    Console.WriteLine("Задача добавлена.");
                    break;
                case 2:
                    Console.WriteLine("Введите номер задачи для удаления:");
                    int removeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (removeIndex >= 0 && removeIndex < tasks.Count)
                    {
                        tasks.RemoveAt(removeIndex);
                        Console.WriteLine("Задача удалена.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер задачи.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите номер задачи для редактирования:");
                    int editIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (editIndex >= 0 && editIndex < tasks.Count)
                    {
                        Console.WriteLine("Введите новое описание задачи:");
                        tasks[editIndex] = Console.ReadLine();
                        Console.WriteLine("Задача отредактирована.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер задачи.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Список задач:");
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }

    // Задача 10: API клиент (погода)
    static async Task WeatherApiClient()
    {
        Console.WriteLine("Введите город для получения прогноза погоды:");
        string city = Console.ReadLine();
        string apiKey = "ac0346baa98a0bfd3310ce5d659e5807";
        string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Данные о погоде: " + data);
            }
            else
            {
                Console.WriteLine("Не удалось получить данные о погоде.");
            }
        }
    }
}
