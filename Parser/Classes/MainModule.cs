using QuickType;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using static Parser.MainWindow;

namespace Parser.Classes
{
    class MainModule
    {



        public static async Task<List<StoryContent>> GetStoryContentAsync(string SessionId, string UserId)
        {
            try
            {
                List<StoryContent> storyContents = new List<StoryContent>();

                var client = new RestClient($"https://i.instagram.com/api/v1/feed/user/{UserId}/reel_media/");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("host", "i.instagram.com");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("Accept", "*/*");
                request.AddHeader("X-IG-Capabilities", "3wo=");
                request.AddHeader("Accept-Language", "en-US;q=1");
                request.AddHeader("Accept-Encoding", "gzip, deflate");
                client.UserAgent = "Instagram 9.5.1 (iPhone9,2; iOS 10_0_2; en_US; en-US; scale=2.61; 1080x1920) AppleWebKit/420+";
                request.AddHeader("X-IG-Connection-Type", "WiFi");
                request.AddCookie("sessionid", SessionId);
                IRestResponse response = await client.ExecuteAsync(request);

                Instagram instagram = Instagram.FromJson(response.Content);

                if (instagram.Items == null)
                    return null;

                foreach (var Story in instagram.Items)
                {

                    if (Story.MediaType == MediaType.Video)
                        if (Story.VideoVersions.Length >= 0)
                            storyContents.Add(new StoryContent(Story.VideoVersions[0].Url.ToString(), true, Story.Id));

                    if (Story.MediaType == MediaType.Image)
                        if (Story.ImageVersions2.Candidates.Length >= 0)
                            storyContents.Add(new StoryContent(Story.ImageVersions2.Candidates[0].Url.ToString(), false, Story.Id));
                }
                return storyContents;
            }
            catch (Exception) { return null; }
        }

        
        public static async Task<bool> DownloadVideoAsync(StoryContent story, string FolderDestinationPath)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(story.Uri);
                var filetype = response.Content.Headers.ContentType.MediaType;
                string FileTitle = $"{DateTime.Now.Year} {DateTime.Now.Month} {DateTime.Now.Day} [ {DateTime.Now.Hour}h {DateTime.Now.Minute}m {DateTime.Now.Second}s ] Id[{story.Id}]";
                byte[] Response = await response.Content.ReadAsByteArrayAsync();
                if (filetype.Contains("image"))
                {
                    File.WriteAllBytes($"{FolderDestinationPath}\\{FileTitle}.jpeg", Response);
                    return true;
                }
                else if (filetype.Contains("video"))
                {
                    File.WriteAllBytes($"{FolderDestinationPath}\\{FileTitle}.mp4", Response);
                    return true;
                }
                else
                {
                    File.WriteAllBytes($"{FolderDestinationPath}\\{FileTitle}.unknownfiletype", Response);
                    return true;
                }
            }
            catch (Exception) { return false; }

        }
    }
}
