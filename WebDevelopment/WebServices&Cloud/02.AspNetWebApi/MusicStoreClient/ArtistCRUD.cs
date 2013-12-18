using MusicStoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreClient
{
    class ArtistCRUD
    {
        internal static Artist AddNewArtistAsJson(HttpClient Client, string name, string country, DateTime dateOfBirth)
        {
            var artist = new Artist { Name = name, Country = country, DateOfBirth = dateOfBirth };

            var response = Client.PostAsJsonAsync("api/Artists", artist).Result;

            Artist resultArtist = response.Content.ReadAsAsync<Artist>().Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
                return resultArtist;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return new Artist();
        }

        internal static void UpdateArtistAsJson(HttpClient Client, int id, Artist artist)
        {
            var response = Client.PutAsJsonAsync("api/Artists/" + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static Artist AddNewArtistAsXml(HttpClient Client, string name, string country, DateTime dateOfBirth)
        {
            var artist = new Artist { Name = name, Country = country, DateOfBirth = dateOfBirth };

            var response = Client.PostAsXmlAsync("api/Artists", artist).Result;

            Artist resultArtist = response.Content.ReadAsAsync<Artist>().Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
                return resultArtist;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return new Artist();
        }

        internal static void UpdateArtistAsXML(HttpClient Client, int id, Artist artist)
        {
            var response = Client.PutAsXmlAsync("api/Artists/" + id, artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteArtist(HttpClient Client, int id)
        {
            var response = Client.DeleteAsync("api/Artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void PrintAllArtists(HttpClient Client)
        {
            HttpResponseMessage response = Client.GetAsync("api/Artists").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var artist in artists)
                {
                    Console.WriteLine("Name: {0}, Country: {1}, Date of birth: {2}", artist.Name, artist.Country, artist.DateOfBirth);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
