namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramUpdateEntities
    {
        public int Offset { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }
}