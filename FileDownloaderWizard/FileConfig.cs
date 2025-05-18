using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FileDownloaderWizard
{
    public class FileConfig
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("imageURL")]
        public string ImageUrl { get; set; }

        [JsonProperty("fileURL")]
        public string FileUrl { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("validators")]
        public JObject Validators { get; set; }
    }
}
