using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flexerant.ClubhouseSharp
{
    public class CreateStoryRequest : RequestBase<CreateStoryRequest>
    {
        [JsonProperty("project_id")]
        public int ProjectId { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("story_type")]
        public StoryTypes StoryType { get; set; } = StoryTypes.Bug;

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        public CreateStoryRequest(int projectId, string name)
        {
            this.ProjectId = projectId;
            this.Name = name;
        }

        public CreateStoryRequest(int projectId, string name, string description) : this(projectId, name)
        {
            this.Description = description;
        }

        #region base class implementations

        internal override string Path => "stories";

        #endregion
    }
}
