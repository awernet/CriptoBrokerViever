using System.Diagnostics;
using WorkerSpace.Interfaces;
using WorkerSpace.Models;
using WorkerSpace;
using CriptoTraderHelper.Tasks;
using MexcApi.Api;
using CriptoTraderHelper.Tools;

namespace CriptoTraderHelper
{
    internal class Application
    {
        static void Main(string[] args)
        {
            CLIBTask.CreateWorker("Main Worker");

            //Задача по фьютчерсам
            TaskBuilder taskBuilder = new TaskBuilder();
            FuturesTask futuresTask = new FuturesTask();
            taskBuilder.AppendExecuteDelegateFunc(futuresTask.ExecuteAsync);

            ITask task = CLIBTask.NewTask(taskBuilder);

            //Задача телеграм бота
            TaskBuilder telegramTaskBuilder = new TaskBuilder();
            TelegramSendlerTask telegramSendlerTask = new TelegramSendlerTask();
            telegramTaskBuilder.AppendExecuteDelegateFunc(telegramSendlerTask.ExecuteAsync);
            ITask telegramTask = CLIBTask.NewTask(telegramTaskBuilder);

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
