using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicStoreData;
using System.Runtime.Serialization;

namespace MusicStoreWebApi.Controllers
{
    public class AlbumsController : ApiController
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public AlbumsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Albums
        public IEnumerable<Album> GetAlbums()
        {
            return db.Albums.AsEnumerable();
        }

        // GET api/Albums/5
        public Album GetAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (ModelState.IsValid && id == album.AlbumId)
            {
                db.Entry(album).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Albums
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        private Artist CreateOrUpdateArtist(Artist artist)
        {
            var existingArtist = db.Artists.Where(a => a.ArtistId == artist.ArtistId &&
                                                        a.Name == artist.Name &&
                                                        a.Country == artist.Country &&
                                                        a.DateOfBirth == artist.DateOfBirth)
                                                        .FirstOrDefault();
            if (existingArtist != null)
            {
                return existingArtist;
            }
            else
            {

                Artist newArtist = db.Artists.Add(artist);
                db.SaveChanges();
                return newArtist;
            }
        }

        private Song CreateOrUpdateSong(Song song)
        {
            var existingSong = db.Songs.Where(s => s.SongId == song.SongId)
                                                        .FirstOrDefault();
            if (existingSong != null)
            {
                return existingSong;
            }
            else
            {
                Song newSong = db.Songs.Add(song);
                db.SaveChanges();

                return newSong;
            }
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}