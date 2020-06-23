namespace WpfApp1
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GroupSection
    {
        [JsonProperty("question_sections")]
        public string[] QuestionSections { get; set; }

        [JsonProperty("categories")]
        public string Categories { get; set; }
    }

    public partial class GroupSection
    {
        public static GroupSection[] FromJson(string json) => JsonConvert.DeserializeObject<GroupSection[]>(json, WpfApp1.ConverterGroup.Settings);
    }

    public static class SerializeGroup
    {
        public static string ToJson(this GroupSection[] self) => JsonConvert.SerializeObject(self, WpfApp1.ConverterGroup.Settings);
    }

    internal static class ConverterGroup
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
