namespace CriptoTraderHelper
{
    public class Events
    {
        public delegate void ContractHandler(string message, string symbol);
        public static event ContractHandler MessageToTelegram;

        public static void InvokeMessageToTelegram(string message, string symbol)
        {
            MessageToTelegram?.Invoke(message, symbol);
        }
    }
}
