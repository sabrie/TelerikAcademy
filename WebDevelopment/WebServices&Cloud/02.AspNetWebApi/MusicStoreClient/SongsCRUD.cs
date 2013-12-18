using MusicStoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreClient
{
    class SongsCRUD
    {
        internal static Song AddNewSongAsJson(HttpClient Client, string title, int year, string genre, Artist artist)
        {
            var song = new Song() { Title = title, Year = year, Genre = genre, Artist = artist, ArtistId = artist.ArtistId };

            var response = Client.PostAsJsonAsync("api/Songs", song).Result;

            Song resultSong = response.Content.ReadAsAsync<Song>().Result;
            
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
                return resultSong;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return new Song();
        }

        internal static void UpdateSongAsJson(HttpClient Client, int id, Song song)
        {
            var response = Client.PutAsJsonAsync("api/Songs/" + id, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static Song AddNewSongAsXML(HttpClient Client, string title, int year, string genre, Artist artist)
        {
            var album = new Song() { Title = title, Year = year, Genre = genre, Artist = artist };

            var response = Client.PostAsXmlAsync("api/Songs", album).Result;

            Song resultSong = response.Content.ReadAsAsync<Song>().Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
                return resultSong;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return new Song();
        }

        internal static void UpdateSongAsXML(HttpClient Client, int id, Song song)
        {
            var response = Client.PutAsXmlAsync("api/Songs/" + id, song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteSong(HttpClient Client, int id)
        {
            var response = Client.DeleteAsync("api/Songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void PrintAllSongs(HttpClient Client)
        {
            HttpResponseMessage response = Client.GetAsync("api/Songs").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var song in songs)
                {
                    Console.WriteLine("Title: {0}, Year: {1}, Genre: {2}, Artist: {3}", song.Title, song.Year, song.Genre, song.Artist);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
