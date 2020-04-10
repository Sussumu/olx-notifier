using System;

namespace OlxNotifier.Domain.Configurations
{
    public class OlxConfiguration
    {
        private string url;

        public string Url
        {
            get => url;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Url cannot be empty!");

                url = value;
            }
        }
    }
}
