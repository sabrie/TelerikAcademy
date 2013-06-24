using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogOfFreeContent
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds a content item to the catalog
        /// </summary>
        /// <param name="contentItem"></param>
        void Add(IContent contentItem);

        /// <summary>
        /// Finds all content items in the catalog that match the specified title. 
        /// Returns no more than numberOfContentElementsToList elements.
        /// The order of returned elements is alphabetical regarding their
        /// ToString() representation
        /// </summary>
        /// <param name="title">the title of the elements we search</param>
        /// <param name="numberOfContentElementsToList">
        /// the maximal number of returned elements</param>
        /// <remarks>This method can return less than all matching elements
        /// in the catalog. For exmaple: if we have 30 matching elements but only
        /// 10 requestedq the method will return 10 elements, and vice versa
        /// if we have requested 10 elements but only 3 mathes are found
        /// than only 3 elements will be returned</remarks>
        /// <returns></returns>
        IEnumerable<IContent> GetListContent(string title, 
            Int32 numberOfContentElementsToList);
        
        /// <summary>
        /// Updates the url by replacing the old url with the new url
        /// </summary>
        /// <param name="oldUrl"></param>
        /// <param name="newUrl"></param>
        /// <returns></returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
