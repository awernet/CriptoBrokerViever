using Newtonsoft.Json;
using System;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.Wpf;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Collections;

namespace CriptoBrokerViewer
{
    public class Drawer
    {
        public async Task SaveGraph(string symbol)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(symbol);
            Console.ResetColor();
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Если нужно, чтобы браузер работал в фоновом режиме
            using (var driver = new ChromeDriver(options))
            {
                // Открываем TradingView
                driver.Navigate().GoToUrl($"https://www.binance.com/ru/trade/{symbol}");
                // Здесь вам нужно будет выполнить вход в систему, если это необходимо
                // driver.FindElement(By.Id("id_username")).SendKeys("your-username");
                // driver.FindElement(By.Id("your-password-field")).SendKeys("your-password");
                // driver.FindElement(By.Id("your-login-button")).Click();
                // Подождите, пока график загрузится
                await Task.Delay(1000); // Замените на более продвинутый метод ожидания

                // Сохраните график, например, как изображение
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile($"images/{symbol}.png", ScreenshotImageFormat.Png);

                Console.WriteLine("График сохранен как chart.png");
            }
        }
        private static readonly HttpClient client = new HttpClient();
        public async Task GetImage(string symbol)
        {
            string interval = "15m"; // Интервал графика
            string chartUrl = $"https://www.binance.com/en/trade/{symbol}?theme=dark&type=linear";

            // Устанавливаем User-Agent, чтобы имитировать браузер
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");

            try
            {
                byte[] imageBytes = await client.GetByteArrayAsync(chartUrl);
                string filePath = $"images/{symbol}.png";

                try
                {
                    BinaryWriter Writer = null;
                    // Create a new stream to write to the file
                    Writer = new BinaryWriter(File.OpenWrite(filePath));

                    // Writer raw data                
                    Writer.Write(imageBytes);
                    Writer.Flush();
                    Writer.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                /*string filePath = Path.Combine(Environment.CurrentDirectory, "image/chart.png");
                await File.WriteAllBytesAsync(filePath, imageBytes);

                Console.WriteLine($"Изображение успешно сохранено в {filePath}");*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
