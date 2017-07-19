using Microsoft.ProjectOxford.Face.Contract;
using Newtonsoft.Json;

namespace Function.Library
{
    public class PhotographData
    {
        private const string _schemaVersion = "1.0.0";

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public int NumberOfPeople { get; set; }
        public Face[] Faces { get; set; }
        public string SchemaVersion
        {
            get { return _schemaVersion; }
            private set { }
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}