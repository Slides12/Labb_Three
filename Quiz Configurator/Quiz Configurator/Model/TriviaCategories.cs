using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model
{
    internal class TriviaCategories
    {
        [JsonPropertyName("trivia_categories")] 
        public Category[] triviaCategories { get; set; }
    }
}
