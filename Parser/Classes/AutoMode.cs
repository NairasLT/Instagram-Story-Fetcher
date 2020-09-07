using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Parser.Classes.MainModule;
using static Parser.MainWindow;
using static Parser.Helpers.ConfigHelpers;
using System.Windows.Controls;
using Parser.Helpers;

namespace Parser.Classes
{
    class AutoMode
    {
        string Session;
        string User;
        string Config;
        ListBox Display;
        public AutoMode(string sessionid, string userid, string ConfigPath, ListBox display=null)
        {
            Session = sessionid;
            User = userid;
            Config = ConfigPath;
            Display = display;
        }

        public async Task Start(TimeSpan Delay)
        {
            var cfg = new Config<Data>(Config);
            while (true)
            {
                Data data = cfg.Read(); //Read Config
                List<StoryContent> CurrentStoryList = await GetStoryContentAsync(Session, User); //Download Stories
                
                if(Display != null)
                {
                    Display.Items.Clear();
                    foreach (var story in CurrentStoryList)
                        Display.Items.Add(story.Uri);
                }

                foreach(var story in CurrentStoryList)
                {
                    if (!data.IdBlackList.Contains(story.Id))
                    {
                        await DownloadVideoAsync(story, LocalFolder);
                        data.IdBlackList.Add(story.Id);
                    }
                }

                cfg.Write(data);
                await Task.Delay(Delay);
            }
        }
    }
}
