using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CriptoBrokerViewer.TelegramBot
{
    public class TMessage
    {
        public string Message;
        public string Symbol;
    }
    public class TelegramSendler
    {
        public TelegramSendler() 
        {
            _client = new TelegramBotClient(_token);
            CoinsDataTask.Notify += AddMessageToQuen;
        }

        private readonly TelegramBotClient _client;
        private readonly string _token = "7357347521:AAGcbYV5w2QnbI7SWzrObz8E_ae_SCoXBBs";
        private readonly long _chatId = -1002220320679;

        private Queue<TMessage> message = new Queue<TMessage>();
        private void AddMessageToQuen(string msg, string symbol)
        {
            TMessage mesg = new TMessage()
            {
                Message = msg,
                Symbol = symbol
            };

            message.Enqueue(mesg);
        }


        public async Task Execute()
        {
            if (message.Count != 0)
            {
                TMessage msg = message.Dequeue();

                string imagePath = $"images/{msg.Symbol}.png"; // Укажите путь к изображению

                using (var stream = new FileStream(imagePath, FileMode.Open))
                {
                    await _client.SendPhotoAsync(
                        chatId: _chatId,
                        photo: new InputFileStream(stream),
                        caption: msg.Message,
                        parseMode: ParseMode.Html);
                }

                Console.WriteLine("Send Ok");
            }
            
            await Task.Delay(2500);
        }
    }
}
