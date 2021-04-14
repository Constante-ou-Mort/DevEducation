using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnitTestProject2;
using Console = System.Console;

namespace FirstLesson
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            Queue<int> patients = new Queue<int>();

            Console.WriteLine("Patient admission has begun.");

            for (int i = 1; i < 1000; i++)
            {
                patients.Enqueue(i);

                Console.WriteLine($"The patient {i} entered the doctor's office.");
                await Task.Delay(GetRandom());

                Console.WriteLine($"The patient {i} left the office.");
            }
        }
        static int GetRandom()
        {
            Random rnd = new Random();
            int delay = rnd.Next(5000, 15000);
            return delay;
        }

        //public class SimpleSettingModel
        //{
        //    public string EnvironmentId { get; set; }
        //    public string Key { get; set; }
        //    public string Value { get; set; }

        //    public Guid Guid { get; } = Guid.NewGuid();
        //}

        //private static double DoMathematicsOperation(string val1, string val2, string @operator)
        //{
        //    double res;

        //    switch (@operator)
        //    {
        //        case "+":
        //            res = double.Parse(val1) + double.Parse(val2);
        //            break;
        //        default: throw new ArgumentException("");
        //    }

        //    return res;
        //}

        //private static string EnterValue()
        //{
        //    return Console.ReadLine();
        //}

        //static void Plus(ref int a, ref int b)
        //{
        //    a = a + 25;
        //}


        //static void Name2(string name)
        //{
        //    name = "";
        //}

        //static bool TryParse(string value, out int parse)
        //{
        //    bool isParsed = false;
        //    try
        //    {
        //        parse = int.Parse(value);
        //        isParsed = true;
        //    }
        //    catch
        //    {
        //        parse = 0;
        //    }

        //    return isParsed;
        //}
    }
















    //var array = new[, ,] { { { "(((&Y@#06u%^&", "m6u%$^s!t", " t0" }, { "k@!!^n0!@w", "?*()h0&&w", "!t#$!0*" }, { " !@#w0)(r&*(&k ", "&*w*i6t^h%", "a@#$r$$$$r@ay#%s" }, { "!@a@!##@n!@#!@d##", "w*i6t^h%", "!@#!$%$c!@#!y^&*^&*c$%^l$%^e$%^s!#@!@" } } };
    //string str = string.Empty;

    //for (int j = 0; j < 4; j++)
    //{
    //    for (int k = 0; k < 3; k++)
    //    {
    //        str += $"{RemoveSpecialCharacters(array[0, j, k].Trim().Replace("0", "o").Replace("6", ""))} ";
    //    }
    //}

    //Console.WriteLine(str.Trim());

    //static string RemoveSpecialCharacters(string str)
    //{
    //    return Regex.Replace(str, @"[^a-zA-Z\._]", string.Empty);
    //}



    //Console.WriteLine("Enter the product price:");
    //var productPrice = int.Parse(Console.ReadLine());

    //if (productPrice > 500 && productPrice <= 1000)
    //    productPrice  -= 50;
    //else if(productPrice > 1000)
    //    productPrice -= 100;

    //Console.WriteLine($"Price of product is: {productPrice}.");
    //////////////////////////
    //Console.WriteLine("Enter date in format dd.MM.yyyy:");
    //var dateAString = Console.ReadLine();

    //if (DateTime.TryParse(dateAString, new CultureInfo("de-DE"), DateTimeStyles.None, out var date))
    //    if (date > DateTime.Now)
    //        Console.WriteLine("Date cannot be in the future.");
    //    else
    //        Console.WriteLine(date.DayOfWeek);
    //else
    //    Console.WriteLine("Incorrect date.");

    //var fnumber = double.Parse(row.Split(' ')[1].Split(' ')[0].Trim());
    //var snumber = double.Parse(row.Split(' ')[1].Split(' ').Last());
    //var oper = row.Split(' ')[0].Trim();
    //double res;
    //switch (oper)
    //{
    //    case "подели": //        res = fnumber / snumber; break;
    //    case "умнож": res = fnumber * snumber; break;
    //    case "прибавь": res = fnumber + snumber; break;
    //    case "отними": res = fnumber - snumber; break;
    //    default: throw new Exception();
    //}

    //Console.WriteLine(res);

    ////Создание объекта для генерации чисел
    //var random = new Random();

    //while (true)
    //{
    //    Console.WriteLine("Введите орел или решка:");
    //    var userValue = Console.ReadLine();

    //    if (userValue != "орел" && userValue != "решка")
    //    {
    //        Console.WriteLine("Неверное значение");
    //        continue;
    //    }

    //    var compValue = random.Next(0, 2) == 0 ? "орел" : "решка";

    //    Console.WriteLine($"Выпала {compValue}");

    //    var userWin = userValue.Equals(compValue);
    //    Console.WriteLine($"Ты {(userWin ? "победил" : "проиграл")}!");

    //    Console.WriteLine("Хочешь сыграть ещё раз?(Да/Нет)");
    //    var userAnswer = Console.ReadLine();

    //    if (!userAnswer.ToLower().Equals("да"))
    //        return;
    //}
}
