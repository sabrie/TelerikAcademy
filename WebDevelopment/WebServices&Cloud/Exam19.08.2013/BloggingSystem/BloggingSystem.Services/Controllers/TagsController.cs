using BloggingSystem.DataLayer;
using BloggingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        // GET api/tags?sessionKey=...
        [HttpGet]
        public IQueryable<GetAllTagsModel> GetAll(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var tagEntities = context.Tags;

                IQueryable<GetAllTagsModel> models =
                    (from postEntity in tagEntities
                     select new GetAllTagsModel()
                     {
                         Id = postEntity.Id,
                         Name = postEntity.Name,
                         Posts = postEntity.Posts.Count(),
                     });

                return models.OrderByDescending(t => t.Id);
            });

            return responseMsg;
        }

        //// GET api/tags/{tagId}/posts?sessionKey=...
        //[HttpGet]
        //public IQueryable<GetAllTagsModel> GetAllPostsForTag(string sessionKey, int tagId)
        //{
        //    var responseMsg = this.PerformOperationAndHandleExceptions(() =>
        //    {
        //        var context = new BloggingSystemContext();                

        //        var postEntities = context.Posts.Where(p => p = ;

        //        IQueryable<GetAllTagsModel> models =
        //            (from postEntity in postEntities
        //             select new GetAllTagsModel()
        //             {
        //                 Id = postEntity.Id,
        //                 Name = postEntity.Name,
        //                 Posts = postEntity.Posts.Count(),
        //             });

        //        return models.OrderByDescending(t => t.Id);
        //    });

        //    return responseMsg;
        //}        
    }
}
