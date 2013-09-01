namespace Blog.WebAPI.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Blog.Data;
    using Blog.WebAPI.Models;

    public class TagsController : BaseApiController
    {
        public HttpResponseMessage GetAll(string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var keyExists = context.Users
                    .Any(user => user.SessionKey == sessionKey);

                if (!keyExists)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                var tagModels = context.Tags.Select(tag =>
                    new TagModel()
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        Posts = tag.Posts.Count
                    }
                );

                return tagModels
                    .OrderBy(model => model.Name);
            });

            return responseMessage;
        }
    }
}
