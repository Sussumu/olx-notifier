using System;

namespace OlxNotifier.Domain.Configurations
{
    public class OlxConfiguration
    {
        private string url;
        private string entriesClassName;
        private string titleRegex;
        private string priceRegex;
        private string dateRegex;
        private string urlRegex;

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

        public string EntriesClassName
        {
            get => entriesClassName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Entries class name cannot be empty! Fill here with the classes used on the list of entries.");

                entriesClassName = value;
            }
        }

        public string TitleRegex
        {
            get => titleRegex;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title regex cannot be empty! Set a regex that is able to filter just the title of the whole entry here.");

                titleRegex = value;
            }
        }

        public string PriceRegex
        {
            get => priceRegex;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Price regex cannot be empty! Set a regex that is able to filter just the price of the whole entry here.");

                priceRegex = value;
            }
        }

        public string DateRegex
        {
            get => dateRegex;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Date regex cannot be empty! Set a regex that is able to filter just the date of the whole entry here.");

                dateRegex = value;
            }
        }

        public string UrlRegex
        {
            get => urlRegex;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Url regex cannot be empty! Set a regex that is able to filter just the url of the whole entry here.");

                urlRegex = value;
            }
        }
    }
}
