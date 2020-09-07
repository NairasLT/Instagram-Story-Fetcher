using Newtonsoft.Json;
using Parser.Classes;
using Parser.Helpers;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Parser.Helpers.ConfigHelpers;
using static Parser.Classes.MainModule;
using static Parser.Helpers.Helpers;

namespace Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            if (userid.Text == "Instagram User Id")
                return;

            if (sessionid.Text == "Session Id")
                return;

            ListStories.Items.Clear();
            var content = await GetStoryContentAsync(sessionid.Text, userid.Text);

            if (content == null)
                return;

            foreach (var strcontent in content)
            {
                ListStories.Items.Add(strcontent.Uri);
            }
        }



        public class StoryContent
        {
            public StoryContent(string uri, bool isvideo, string id)
            {
                IsVideo = isvideo;
                Uri = uri;
                Id = id;
            }
            public bool IsVideo { get; set; }
            public string Uri { get; set; }
            public string Id { get; set; }
        }


        private void ListStories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListStories.SelectedItem == null)
                return;
            Player.LoadedBehavior = MediaState.Manual;
            Player.Visibility = Visibility.Visible;
            Player.Source = new Uri(ForceHttp(ListStories.SelectedItem.ToString()));
            Player.Play();
        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            Player.Visibility = Visibility.Hidden;
        }
        private void userid_LostFocus(object sender, RoutedEventArgs e)
        {
            var cfg = new Config<Data>(LocalConfig);
            var old = cfg.Read();
            old.UserId = userid.Text;
            cfg.Write(old);
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new ConfigHelpers().SetupFiles();

            Data data = new Config<Data>(LocalConfig).Read();


            if(data.SessionId != null)
                sessionid.Text = data.SessionId;


            if (data.UserId != null)
                userid.Text = data.UserId;

            IsAutoCheckBox.Checked -= IsAutoCheckBox_Checked; //Removing and Adding Event handlers to not Trigger the Messagebox.show
            IsAutoCheckBox.IsChecked = data.IsAuto;
            IsAutoCheckBox.Checked += IsAutoCheckBox_Checked;

            if (data.IsAuto)
                await new AutoMode(data.SessionId, data.UserId, LocalConfig, ListStories).Start(TimeSpan.FromMinutes(30));
        }
        private void sessionid_LostFocus(object sender, RoutedEventArgs e)
        {
            var cfg = new Config<Data>(LocalConfig);
            var old = cfg.Read();
            old.SessionId = sessionid.Text;
            cfg.Write(old);
        }
        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListStories.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Nothing is selected.");
                return;
            }
            List<bool> Success = new List<bool>();
            foreach(var selecteditem in ListStories.SelectedItems)
            {
                if (await DownloadVideoAsync(new StoryContent(selecteditem.ToString(), true, selecteditem.GetHashCode().ToString()), Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
                    Success.Add(true);
            }
            MessageBox.Show($"Successfully Downloaded {Success.Count} out of {ListStories.SelectedItems.Count} Items to Desktop.");
        }
        private void IsAutoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var cfg = new Config<Data>(LocalConfig);
            var old = cfg.Read();
            old.IsAuto = false;
            cfg.Write(old);
        }
        private void IsAutoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Activate 'Auto Mode' this mode checks the Instagram User with session id, downloads the story content, checks every 30 minutes, if the video/image has been already downloaded it will not download the video/image.", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (res == MessageBoxResult.No)
                return;
            
            var cfg = new Config<Data>(LocalConfig);
            var old = cfg.Read();
            old.IsAuto = true; ;
            cfg.Write(old);
            MessageBox.Show("Auto mode will be Activated when you restart the application, we recommend creating and putting this application's shortcut into the startup folder(Windows Key + R: 'shell:startup') if you use this application on a computer that is not being used.");
        }
    }
}
