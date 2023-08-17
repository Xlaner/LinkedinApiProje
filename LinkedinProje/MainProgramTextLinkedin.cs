using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace LinkedinProje
{
    internal class MainProgramTextLinkedin
    {
        [STAThread]
        static void Main(string[] args)
        {

            using (var client = new HttpClient())
            {
                LinkedInPostRequest request = new LinkedInPostRequest
                {
                    author = "urn:li:person:T6hBlHuGR-",
                    lifecycleState = "PUBLISHED",
                    specificContent = new Specificcontent
                    {
                        comlinkedinugcShareContent = new ComLinkedinUgcSharecontent
                        {
                            shareCommentary = new Sharecommentary { text = "Bu bir deneme paylaşımıdır" },
                            shareMediaCategory = "NONE"
                        }
                    },
                    visibility = new Visibility { comlinkedinugcMemberNetworkVisibility = "PUBLIC" }
                };

                var reqString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(reqString, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer AQVveVyBxQn0tBmuLC4RLARR3lC-XNZKDMycRscLH5WcN4qZuB7kZoJgFYIvQlUy8E0xZSlVDFEvxX4FwvIdWkKkbMpWWl7RlHCD-xj9TpY2aeL3jA2s002YSMi7OiQSlgu-9EuMcm_2fzfx-C5Kj8lwoiJTrsIVqwSz55o2rArzMnsa-fEoBoSCmZ6AXX72olOOnPRHbuJuobxbq67ahRwy8Ejt2MrfByiLeQi6NOWdQw44F3tjnQUa3kjVBmnENWsPkwyovNqt1UmS7q2waDceNqgfPftYVAvNgh-JrY8HHsOwsHMAsivxVNG6TiheBjG_4hh5ndxoYdNjXJmmP2M6ncas-w");
                var response = client.PostAsync("https://api.linkedin.com/v2/ugcPosts", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var respContent = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }

            }
        }
    }
}
