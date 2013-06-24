using System;
using System.Linq;

namespace CatalogOfFreeContent
{
    public enum CommandType
    {
        AddBook,
        AddMovie, 
        AddSong,
        AddApplication,
        Update, Find,
    }
    
    public enum ContentItemType
    {
        Book,
        Movie,
        Song,
        Application,
    }

    public enum ContentItemInfo
    {
        Title = 0,        
        Author,
        Size,
        Url,
    }
}
