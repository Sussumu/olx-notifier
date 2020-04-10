namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramResult
    {
        public bool Ok { get; set; }

        public object Result { get; set; }

        public string Description { get; set; }
    }
}
