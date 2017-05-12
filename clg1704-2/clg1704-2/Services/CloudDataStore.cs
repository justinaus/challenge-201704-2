using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using clg17042.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Plugin.Connectivity;

namespace clg17042.Services
{

    class TResult {
        public IEnumerable<UserItem> Results { get; set; }
    }

    public class CloudDataStore : IDataStore<UserItem>
    {
        HttpClient client;
        IEnumerable<UserItem> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<UserItem>();
        }

        public async Task<IEnumerable<UserItem>> GetItemsAsync(string param)
        {
            //if (CrossConnectivity.Current.IsConnected)
            //{
                var json = await client.GetStringAsync( param );
                //var json = await client.GetStringAsync($"api/item");

                //string strTest = "{\"results\":[{\"name\":\"aaa\"}, {\"name\":\"bbb\"}]}";

                TResult tResult = await Task.Run(() => JsonConvert.DeserializeObject<TResult>( json ));

                items = tResult.Results;
            //}

            return items;
        }

    }
}
