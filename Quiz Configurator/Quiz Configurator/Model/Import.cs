using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace Quiz_Configurator.Model
{
    class Import
    {

        private static readonly HttpClient client = new HttpClient();


        public async Task<string> ImportAsync(int amount = 10, int category = 9, string difficulty = "medium")
        {
            string url = $"https://opentdb.com/api.php?amount={amount}&category={category}&difficulty={difficulty}&type=multiple";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Request error: {e.Message}");
                return null;
            }
        }


        public async Task<string> ImportCategorysAsync()
        {
            string url = $"https://opentdb.com/api_category.php";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    return await client.GetStringAsync(url);
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Request error: {e.Message}");
                    return null;
                }
            }
        }
    }
}
