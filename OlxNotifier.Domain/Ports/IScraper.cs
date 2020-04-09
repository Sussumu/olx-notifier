using OlxNotifier.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlxNotifier.Domain.Ports
{
    public interface IScraper
    {
        Task<List<Entry>> GetEntries();
    }
}
