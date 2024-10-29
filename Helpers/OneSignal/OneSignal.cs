using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using RestSharp;

namespace EvaluationBackend.Helpers.OneSignal
{
    public class OneSignal
    {
        public static bool  SendNoitications(Notification notification , string to)
        {
            IConfiguration configuration = ConfigurationProvider.Configuration;
            
            var client = new RestClient(configuration["onesginel:Url"]!);
            var request = new RestRequest(configuration["onesginel:Url"], Method.POST);
            request.AddHeader("Authorization", configuration["onesginel:Authorization"]!);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "__cfduid=d8a2aa2f8395ad68b8fd27b63127834571600976869");
            try
            {
                var body = new
                {
                    app_id = configuration["onesginel:app_id"],
                    headings = new { en = notification.Title, ar = notification.Title },
                    contents = new { en = notification.Body, ar = notification.Body },
                    included_segments = new[] { to },
                };
                request.AddJsonBody(body);
                client.Execute(request);


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}