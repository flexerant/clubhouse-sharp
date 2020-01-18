using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Flexerant.ClubhouseSharp
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StoryTypes
    {
        [EnumMember(Value = "bug")] Bug,
        [EnumMember(Value = "chore")] Chore,
        [EnumMember(Value = "feature")] Feature
    }
}
