﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var instagram = Instagram.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Instagram
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("reels_media")]
        public ReelsMedia[] ReelsMedia { get; set; }
    }

    public partial class ReelsMedia
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("latest_reel_media")]
        public long LatestReelMedia { get; set; }

        [JsonProperty("can_reply")]
        public bool CanReply { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("can_reshare")]
        public bool CanReshare { get; set; }

        [JsonProperty("expiring_at")]
        public long ExpiringAt { get; set; }

        [JsonProperty("has_besties_media")]
        public object HasBestiesMedia { get; set; }

        [JsonProperty("has_pride_media")]
        public bool HasPrideMedia { get; set; }

        [JsonProperty("seen")]
        public long Seen { get; set; }

        [JsonProperty("user")]
        public Owner User { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("edge_story_media_viewers")]
        public EdgeStoryMediaViewers EdgeStoryMediaViewers { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("display_resources")]
        public DisplayResource[] DisplayResources { get; set; }

        [JsonProperty("display_url")]
        public Uri DisplayUrl { get; set; }

        [JsonProperty("media_preview")]
        public string MediaPreview { get; set; }

        [JsonProperty("gating_info")]
        public object GatingInfo { get; set; }

        [JsonProperty("fact_check_overall_rating")]
        public object FactCheckOverallRating { get; set; }

        [JsonProperty("fact_check_information")]
        public object FactCheckInformation { get; set; }

        [JsonProperty("media_overlay_info")]
        public object MediaOverlayInfo { get; set; }

        [JsonProperty("sensitivity_friction_info")]
        public object SensitivityFrictionInfo { get; set; }

        [JsonProperty("taken_at_timestamp")]
        public long TakenAtTimestamp { get; set; }

        [JsonProperty("expiring_at_timestamp")]
        public long ExpiringAtTimestamp { get; set; }

        [JsonProperty("story_cta_url")]
        public object StoryCtaUrl { get; set; }

        [JsonProperty("story_view_count")]
        public object StoryViewCount { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("tracking_token")]
        public string TrackingToken { get; set; }

        [JsonProperty("tappable_objects")]
        public TappableObject[] TappableObjects { get; set; }

        [JsonProperty("story_app_attribution")]
        public object StoryAppAttribution { get; set; }

        [JsonProperty("edge_media_to_sponsor_user")]
        public EdgeMediaToSponsorUser EdgeMediaToSponsorUser { get; set; }

        [JsonProperty("muting_info")]
        public object MutingInfo { get; set; }

        [JsonProperty("has_audio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasAudio { get; set; }

        [JsonProperty("overlay_image_resources")]
        public object OverlayImageResources { get; set; }

        [JsonProperty("video_duration", NullValueHandling = NullValueHandling.Ignore)]
        public double? VideoDuration { get; set; }

        [JsonProperty("video_resources", NullValueHandling = NullValueHandling.Ignore)]
        public VideoResource[] VideoResources { get; set; }
    }

    public partial class Dimensions
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class DisplayResource
    {
        [JsonProperty("src")]
        public Uri Src { get; set; }

        [JsonProperty("config_width")]
        public long ConfigWidth { get; set; }

        [JsonProperty("config_height")]
        public long ConfigHeight { get; set; }
    }

    public partial class EdgeMediaToSponsorUser
    {
        [JsonProperty("edges")]
        public object[] Edges { get; set; }
    }

    public partial class EdgeStoryMediaViewers
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("edges")]
        public object[] Edges { get; set; }
    }

    public partial class PageInfo
    {
        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("end_cursor")]
        public object EndCursor { get; set; }
    }

    public partial class Owner
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("profile_pic_url")]
        public Uri ProfilePicUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("followed_by_viewer")]
        public bool FollowedByViewer { get; set; }

        [JsonProperty("requested_by_viewer")]
        public bool RequestedByViewer { get; set; }

        [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
        public string Typename { get; set; }
    }

    public partial class TappableObject
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("rotation")]
        public double Rotation { get; set; }

        [JsonProperty("custom_title")]
        public object CustomTitle { get; set; }

        [JsonProperty("attribution")]
        public object Attribution { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
    }

    public partial class VideoResource
    {
        [JsonProperty("src")]
        public Uri Src { get; set; }

        [JsonProperty("config_width")]
        public long ConfigWidth { get; set; }

        [JsonProperty("config_height")]
        public long ConfigHeight { get; set; }

        [JsonProperty("mime_type")]
        public MimeType MimeType { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public enum MimeType { VideoMp4CodecsAvc142E01EMp4A402, VideoMp4CodecsAvc14D401EMp4A402 };

    public enum Profile { Baseline, Main };

    public partial class Instagram
    {
        public static Instagram FromJson(string json) => JsonConvert.DeserializeObject<Instagram>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Instagram self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MimeTypeConverter.Singleton,
                ProfileConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class MimeTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MimeType) || t == typeof(MimeType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "video/mp4; codecs=\"avc1.42E01E, mp4a.40.2\"":
                    return MimeType.VideoMp4CodecsAvc142E01EMp4A402;
                case "video/mp4; codecs=\"avc1.4D401E, mp4a.40.2\"":
                    return MimeType.VideoMp4CodecsAvc14D401EMp4A402;
            }
            throw new Exception("Cannot unmarshal type MimeType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MimeType)untypedValue;
            switch (value)
            {
                case MimeType.VideoMp4CodecsAvc142E01EMp4A402:
                    serializer.Serialize(writer, "video/mp4; codecs=\"avc1.42E01E, mp4a.40.2\"");
                    return;
                case MimeType.VideoMp4CodecsAvc14D401EMp4A402:
                    serializer.Serialize(writer, "video/mp4; codecs=\"avc1.4D401E, mp4a.40.2\"");
                    return;
            }
            throw new Exception("Cannot marshal type MimeType");
        }

        public static readonly MimeTypeConverter Singleton = new MimeTypeConverter();
    }

    internal class ProfileConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Profile) || t == typeof(Profile?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BASELINE":
                    return Profile.Baseline;
                case "MAIN":
                    return Profile.Main;
            }
            throw new Exception("Cannot unmarshal type Profile");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Profile)untypedValue;
            switch (value)
            {
                case Profile.Baseline:
                    serializer.Serialize(writer, "BASELINE");
                    return;
                case Profile.Main:
                    serializer.Serialize(writer, "MAIN");
                    return;
            }
            throw new Exception("Cannot marshal type Profile");
        }

        public static readonly ProfileConverter Singleton = new ProfileConverter();
    }
}