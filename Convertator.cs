using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            double rateUSDtoUAH = 28.18;
            double rateUAHtoUSD = 28.50;

            double rateEURtoUAH = 31.98;
            double rateUAHtoEUR = 32.40;

            double rateEURtoUSD = 1.14;

            double compareSum = 0;
            string changeFromStr, changeToStr;
            string cycleCondition = "";

            Console.WriteLine("Конвертер валют\n");

            Console.Write("Введите количество у Вас гривен: ");
            double uahN = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите количество у Вас долларов: ");
            double usdN = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите количество у Вас евро: ");
            double eurN = Convert.ToDouble(Console.ReadLine());

            while (cycleCondition != "exit")
            {
                Console.Clear();

                Console.SetCursorPosition(13, 0);
                Console.WriteLine("Текущий курс валют:\n");
                Console.WriteLine($"Продать USD: {rateUSDtoUAH} UAH, "
                    + $"Купить USD: {rateUAHtoUSD} UAH\n"
                    + $"Продать EUR: {rateEURtoUAH} UAH, "
                    + $"Купить EUR: {rateUAHtoEUR} UAH\n");

                Console.SetCursorPosition(13, 4);
                Console.WriteLine($"Обменять EUR/USD: {rateEURtoUSD}\n");
                Console.WriteLine($"У Вас {uahN} гривен, {usdN} долларов, {eurN} евро\n");

                Console.Write("Какую валюту хотите поменять?\n" +
                    "1-гривны, 2-доллары, 3-евро: ");
                changeFromStr = Console.ReadLine();

                if (changeFromStr == "1")
                    compareSum = uahN;
                else if (changeFromStr == "2")
                    compareSum = usdN;
                else if (changeFromStr == "3")
                    compareSum = eurN;
                else
                    continue;

                Console.Write("Введите сумму обмена: ");
                double changeSum = Convert.ToDouble(Console.ReadLine());

                if (changeSum > compareSum || changeSum == 0)
                    continue;

                Console.Write("Какую валюту хотите получить?\n" +
                    "1-гривны, 2-доллары, 3-евро: ");
                changeToStr = Console.ReadLine();

                if (changeToStr == "1")
                {
                    if (changeFromStr == "2")
                    {
                        uahN += changeSum * rateUSDtoUAH;
                        usdN -= changeSum;
                    }
                    else if (changeFromStr == "3")
                    {
                        uahN += changeSum * rateEURtoUAH;
                        eurN -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (changeToStr == "2")
                {
                    if (changeFromStr == "1")
                    {
                        usdN += changeSum / rateUAHtoUSD;
                        uahN -= changeSum;
                    }
                    else if (changeFromStr == "3")
                    {
                        usdN += changeSum * rateEURtoUSD;
                        eurN -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (changeToStr == "3")
                {
                    if (changeFromStr == "1")
                    {
                        eurN += changeSum / rateUAHtoEUR;
                        uahN -= changeSum;
                    }
                    else if (changeFromStr == "2")
                    {
                        eurN += changeSum / rateEURtoUSD;
                        usdN -= changeSum;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Обмен произведён.\n" +
                    $"У Вас {uahN} гривен, {usdN} долларов, {eurN} евро\n");

                Console.WriteLine("Для продолжения нажмите Enter,\n" +
                    "для выхода из программы введите exit и нажмите Enter");

                cycleCondition = Console.ReadLine();
            }
        }
    }
}