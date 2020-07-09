using Newtonsoft.Json;

namespace Apod.Items.Models
{
    public class ApodModel
    {
        public string Title { get; set; }

        public string Date { get; set; }

        public string Url { get; set; }

        public string Explanation { get; set; }

        public string Copyright { get; set; }
    }
}
