using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flexerant.ClubhouseSharp
{
    public class ResponseBase<T> : JsonObjectBase<T>
    {
        internal JObject JsonObject = new JObject();
    }
}
