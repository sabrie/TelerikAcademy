using MusicStoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreClient
{
    class AlbumsCRUD
    {
        internal static Album AddNewAlbumsAsJson(HttpClient Client, string title, int year, string producer, ICollection<Song> songs, ICollection<Artist> artists)
        {
            var album = new Album() { Title = title, Year = year, Producer = producer, Songs = songs, Artists = artists }; 

            var response = Client.PostAsJsonAsync("api/Albums", album).Result;

            Album resultAlbum = response.Content.ReadAsAsync<Album>().Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
                return resultAlbum;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return new Album();
        }

        internal static void UpdateAlbumAsJson(HttpClient Client, int id, Album album)
        {
            var response = Client.PutAsJsonAsync("api/Albums/" + id, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static Album AddNewAlbumAsXml(HttpClient Client, string title, int year, string producer, ICollection<Song> songs, ICollection<Artist> artists)
        {
            var album = new Album() { Title = title, Year = year, Producer = producer, Songs = songs, Artists = artists };

            var response = Client.PostAsXmlAsync("api/Albums", album).Result;

            Album resultAlbum = response.Content.ReadAsAsync<Album>().Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
                return resultAlbum;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return new Album();
        }

        internal static void UpdateAlbumAsXML(HttpClient Client, int id, Album album)
        {
            var response = Client.PutAsXmlAsync("api/Albums/" + id, album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteAlbum(HttpClient Client, int id)
        {
            var response = Client.DeleteAsync("api/Albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void PrintAllAlbums(HttpClient Client)
        {
            HttpResponseMessage response = Client.GetAsync("api/Albums").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                
                foreach (var album in albums)
                {
                    Console.WriteLine("Name: {0}, Country: {1}, Date of birth: {2}", album.Title, album.Year, album.Producer);
                    Console.WriteLine("Artists: ");
                    foreach (var artist in album.Artists)
                    {
                        Console.WriteLine(artist.Name);
                    }

                    Console.WriteLine("Songs");
                    foreach (var song in album.Songs)
                    {
                        Console.WriteLine("Title: {0}, Year: {1}, Genre: {2}, Artist: {3}", song.Title, song.Year, song.Genre, song.Artist);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
