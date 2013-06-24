using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        // counts the number of added items to given Catalog instance
        public int Count
        {
            get
            {
                return this.title.KeyValuePairs.Count;
            }
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            // Performence bottleneck - finding 100 elements in 60000 items is slow
            IEnumerable<IContent> contentToList = 
                from content in this.title[title] 
                select content;

            return contentToList.Take(numberOfContentElementsToList);
        }
        
        public int UpdateContent(string oldUrl, string newUrl)
        {
            ICollection<IContent> matchedElements = this.url[oldUrl].ToList();

            int updatedElementsCount = 0;

            foreach (ContentItem content in matchedElements)
            {
                this.title.Remove(content.Title, content);
                updatedElementsCount++;
            }
            this.url.Remove(oldUrl);

            foreach (IContent content in matchedElements)
            {
                content.URL = newUrl;
            }

            foreach (IContent content in matchedElements)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return updatedElementsCount;
        }
    }
}
