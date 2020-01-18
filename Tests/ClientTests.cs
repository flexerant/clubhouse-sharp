using Flexerant.ClubhouseSharp;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    public class ClientTests
    {
        [Fact]
        public void ExecuteClient()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
               .Build();

            Client client = new Client(config["ApiKey"]);

            var response = client.CreateStoryAsync(new CreateStoryRequest(4, "test name", "test description") { ExternalId = Guid.NewGuid().ToString() }).Result;

            Uri uri = response.AppUrl;
        }
    }
}
