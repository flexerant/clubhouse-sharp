using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Flexerant.ClubhouseSharp
{
    public partial class CreateStoryResponse : ResponseBase<CreateStoryResponse>
    {       
        public Uri AppUrl => new Uri(base.JsonObject.Value<string>("app_url"));
    }
}
