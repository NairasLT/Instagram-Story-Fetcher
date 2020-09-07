using QuickType;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
                string DecodedUrl = "{\"reel_ids\":[\"" + UserId + "\"],\"tag_names\":[],\"location_ids\":[],\"highlight_reel_ids\":[],\"precomposed_overlay\":false,\"show_story_viewer_list\":true,\"story_viewer_fetch_count\":50,\"story_viewer_cursor\":\"\",\"stories_video_dash_manifest\":false}";

                var client = new RestClient($"https://www.instagram.com/graphql/query/?query_hash=90709b530ea0969f002c86a89b4f2b8d&variables={HttpUtility.UrlEncode(DecodedUrl)}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddCookie("sessionid", SessionId);
                IRestResponse response = await client.ExecuteAsync(request);
                Instagram instagram = Instagram.FromJson(response.Content);

                if (instagram.Data.ReelsMedia.Length <= 0)
                    return null;

                if (instagram.Data.ReelsMedia[instagram.Data.ReelsMedia.Length - 1].Items.Length <= 0)
                    return null;

                foreach (var Story in instagram.Data.ReelsMedia[0].Items)
                {

                    if (Story.IsVideo)
                        if (Story.VideoResources.Length > 0)
                            storyContents.Add(new StoryContent(Story.VideoResources[Story.VideoResources.Length - 1].Src.ToString(), true, Story.Id));

                    if (!Story.IsVideo)
                        if (Story.DisplayResources.Length > 0)
                            storyContents.Add(new StoryContent(Story.DisplayResources[Story.DisplayResources.Length - 1].Src.ToString(), false, Story.Id));
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
