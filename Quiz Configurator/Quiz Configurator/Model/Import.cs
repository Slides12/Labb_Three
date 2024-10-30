using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model
{
    class Import
    {
        HttpClient _httpClient;
        public Import()
        {
            _httpClient = new HttpClient();

        }



        public async Task<string> DownloadQuizAsync()
        {
            string questions = "https://opentdb.com/api.php?amount=10";
            string json;
            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync(questions);
            }
            return json;
        }
    }
}
