using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Loger;

namespace CriptoTraderHelper.Tasks
{
    public class TelegramSendlerTask
    {
        public TelegramSendlerTask()
        {
            _client = new TelegramBotClient(_token);
            Events.MessageToTelegram += AddMessageToQuen;
        }

        private void AddMessageToQuen(string msg, string symbol)
        {
            TMessage mesg = new TMessage()
            {
                Message = msg,
                Symbol = symbol
            };

            message.Enqueue(mesg);
        }
        public async Task ExecuteAsync()
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

                LogVisualisator.Log(Loger.Enums.LogType.Warning, "Message Send!");
            }

            await Task.Delay(2500);
        }

        private readonly TelegramBotClient _client;
        private readonly string _token = "7357347521:AAGcbYV5w2QnbI7SWzrObz8E_ae_SCoXBBs";
        private readonly long _chatId = -1002220320679;

        private Queue<TMessage> message = new Queue<TMessage>();


    }

    public class TMessage
    {
        public string Message;
        public string Symbol;
    }
}
