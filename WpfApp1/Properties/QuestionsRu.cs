﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using WpfApp1;
//
//    var QuestionsRu = QuestionsRu.FromJson(jsonString);

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class QuestionsRu
    {
        [JsonProperty("rightAnswerIndex")]
        public int RightAnswerIndex { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answers")]
        public string[] Answers { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sectionId")]
        public int SectionId { get; set; }

        [JsonProperty("imgSrc", NullValueHandling = NullValueHandling.Ignore)]
        public string ImgSrc { get; set; }

        [JsonProperty("pddSectionTarget", NullValueHandling = NullValueHandling.Ignore)]
        public string PddSectionTarget { get; set; }

        [JsonProperty("pddSectionTittle", NullValueHandling = NullValueHandling.Ignore)]
        public string PddSectionTittle { get; set; }

        [JsonProperty("sectionType", NullValueHandling = NullValueHandling.Ignore)]
        public SectionType? SectionType { get; set; }
    }

    public enum SectionType { PddPage, Razmetka, SignPage };

    public partial class QuestionsRu
    {
        public static QuestionsRu[] FromJson(string json) => JsonConvert.DeserializeObject<QuestionsRu[]>(json, WpfApp1.ConverterRu.Settings);
    }

    public static class SerializeRu
    {
        public static string ToJson(this QuestionsRu[] self) => JsonConvert.SerializeObject(self, WpfApp1.ConverterRu.Settings);
    }

    internal static class ConverterRu
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                SectionTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class SectionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SectionType) || t == typeof(SectionType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "PDD_PAGE":
                    return SectionType.PddPage;
                case "RAZMETKA":
                    return SectionType.Razmetka;
                case "SIGN_PAGE":
                    return SectionType.SignPage;
            }
            throw new Exception("Cannot unmarshal type SectionType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SectionType)untypedValue;
            switch (value)
            {
                case SectionType.PddPage:
                    serializer.Serialize(writer, "PDD_PAGE");
                    return;
                case SectionType.Razmetka:
                    serializer.Serialize(writer, "RAZMETKA");
                    return;
                case SectionType.SignPage:
                    serializer.Serialize(writer, "SIGN_PAGE");
                    return;
            }
            throw new Exception("Cannot marshal type SectionType");
        }

        public static readonly SectionTypeConverter Singleton = new SectionTypeConverter();
    }
}