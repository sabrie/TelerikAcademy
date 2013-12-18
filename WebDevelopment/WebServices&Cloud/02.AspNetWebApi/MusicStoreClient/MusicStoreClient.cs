using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreData;
using MusicStoreWebApi;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MusicStoreClient
{
    class MusicStoreClient
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:55081/") };

        internal static void Main()
        {
            // ARTIST OPERATIONS
            //-------------------------

            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            // Adds artists - JSON format
            Artist michaelJackson = ArtistCRUD.AddNewArtistAsJson(Client, "Michael Jackson", "USA", new DateTime(1958, 8, 29));
            Artist roxette = ArtistCRUD.AddNewArtistAsJson(Client, "Roxette", "Sweden", new DateTime(1986, 1, 1));
            Artist abba = ArtistCRUD.AddNewArtistAsJson(Client, "ABBA", "Sweden", new DateTime(1972, 1, 1));

            // Updates an artist by id - JSON format
            Artist UpdatedArtistJson = new Artist() { ArtistId = roxette.ArtistId, Name = "Vassil Naidenov", Country = "Bulgaria", DateOfBirth = new DateTime(1952, 5, 3) };
            ArtistCRUD.UpdateArtistAsJson(Client, roxette.ArtistId, UpdatedArtistJson);

            // Add an Accept header for XML format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));

            // Adds artists - XML format
            Artist grafa = ArtistCRUD.AddNewArtistAsXml(Client, "Grafa", "Bulgaria", new DateTime(1980, 5, 6));
            Artist mariaIlieva = ArtistCRUD.AddNewArtistAsXml(Client, "Maria Ilieva", "Bulgaria", new DateTime(1981, 1, 5));
            Artist miro = ArtistCRUD.AddNewArtistAsXml(Client, "Miro", "Bulgaria", new DateTime(1978, 1, 1));

            // Updates an artist by id - XML format
            Artist UpdatedArtistXml = new Artist() { ArtistId = abba.ArtistId, Name = "Margarita Hranova", Country = "Bulgaria", DateOfBirth = new DateTime(1957, 5, 3) };
            ArtistCRUD.UpdateArtistAsJson(Client, abba.ArtistId, UpdatedArtistXml);

            // Lists all artists
            Console.WriteLine();
            Console.WriteLine("All Artists:");
            ArtistCRUD.PrintAllArtists(Client);
            Console.WriteLine();

            // Deletes artists by id
            ArtistCRUD.DeleteArtist(Client, mariaIlieva.ArtistId);

            // Adds an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // SONG OPERATIONS
            //------------------------

            // Adds songs
            Song myGirlSong = SongsCRUD.AddNewSongAsJson(Client, "My Girl", 1975, "Pop", michaelJackson);
            Song gotToBeThere = SongsCRUD.AddNewSongAsJson(Client, "Got to Be There", 1975, "Pop", michaelJackson);
            Song ben = SongsCRUD.AddNewSongAsJson(Client, "Ben", 1975, "Pop", michaelJackson);
            Song withAChildsHeart = SongsCRUD.AddNewSongAsJson(Client, "With a Child's Heart", 1975, "Pop", michaelJackson);
            Song oneDayInYourLife = SongsCRUD.AddNewSongAsJson(Client, "One Day In Your Life", 1975, "Pop", michaelJackson);
            Song aintNoSunshine = SongsCRUD.AddNewSongAsJson(Client, "Ain't No Sunshine", 1975, "Pop", michaelJackson);

            // Update a song
            Song updatedBen = new Song() {SongId = ben.SongId, Title = "BEN", Year = 1975, Genre = "Pop", Artist = michaelJackson};
            SongsCRUD.UpdateSongAsJson(Client, ben.SongId, updatedBen);
            
            // Gets all songs
            Console.WriteLine("All songs:");
            SongsCRUD.PrintAllSongs(Client);

            // Delete a song
            SongsCRUD.DeleteSong(Client, gotToBeThere.SongId);

            // ALBUM OPERATIONS
            //------------------------

            IList<Song> michaelJacksonSongs = new List<Song>()
            {
                myGirlSong,
                gotToBeThere,
                ben,
                withAChildsHeart,
                oneDayInYourLife,
                aintNoSunshine
            };

            IList<Artist> michaelJacksonAlbumArtists = new List<Artist>()
            {
                michaelJackson
            };

            // Add an album with list of songs and artists
            Album michaelJacksonAlbum = AlbumsCRUD.AddNewAlbumsAsJson(
                Client, "The Best of Michael Jackson", 1975, "Producer1", michaelJacksonSongs, michaelJacksonAlbumArtists);

            // Update an album
            Album updatedMichaelJacksonAlbum = new Album() { AlbumId = michaelJacksonAlbum.AlbumId, Title = "The Best of Michael Jackson", Year = 1975, Producer = "Sony Music", Songs = michaelJacksonSongs, Artists = michaelJacksonAlbumArtists };
            AlbumsCRUD.UpdateAlbumAsJson(Client, michaelJacksonAlbum.AlbumId, updatedMichaelJacksonAlbum);

            // Get all albums
            Console.WriteLine("All Albums:");
            AlbumsCRUD.PrintAllAlbums(Client);
            Console.WriteLine();

            // Delete an album
            AlbumsCRUD.DeleteAlbum(Client, updatedMichaelJacksonAlbum.AlbumId);

            Client.Dispose();
        }
    }
}
