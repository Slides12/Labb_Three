using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model
{
    internal class ImportClass
    {
        
            [JsonPropertyName("response_code")]
            public int ResponseCode { get; set; }

            [JsonPropertyName("results")]
            public List<Question> Results { get; set; }
        
    }
}
