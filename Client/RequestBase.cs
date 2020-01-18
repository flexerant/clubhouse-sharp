using System;
using System.Collections.Generic;
using System.Text;

namespace Flexerant.ClubhouseSharp
{
    public abstract class RequestBase<T> : JsonObjectBase<T>
    {
        internal abstract string Path { get; }

        //protected Uri GetEntpoint(string path)
        //{
        //    return new Uri(new Uri("https://api.clubhouse.io/api/v3/stories", UriKind.Absolute), path);
        //}
    }
}
