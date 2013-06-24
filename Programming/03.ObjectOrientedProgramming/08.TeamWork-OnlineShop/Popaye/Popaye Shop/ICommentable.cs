using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    /// <summary>
    /// We can add comments to the products
    /// </summary>
    public interface ICommentable
    {
        List<string> Comments { get; set; }

        /// <summary>
        /// Adding a single comment to the list of comments
        /// </summary>
        /// <param name="comment">A single comment to be added</param>
        void AddComment(string comment);
    }
}
