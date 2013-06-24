using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogOfFreeContent
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    var book = new ContentItem(ContentItemType.Book, command.Parameters);
                    catalog.Add(book);
                    output.AppendLine("Book Added");
                    break;
                case CommandType.AddMovie:
                    var movie = new ContentItem(ContentItemType.Movie, command.Parameters);
                    catalog.Add(movie);
                    output.AppendLine("Movie added");
                    break;
                case CommandType.AddSong:
                    var song = new ContentItem(ContentItemType.Song, command.Parameters);
                    catalog.Add(song);
                    output.AppendLine("Song added");
                    break;
                case CommandType.AddApplication:
                    var application = new ContentItem(ContentItemType.Application, command.Parameters);
                    catalog.Add(application);
                    output.AppendLine("Application added");
                    break;
                case CommandType.Update:
                    ProcessUpdateCommand(catalog, command, output);
                    break;
                case CommandType.Find:
                    ProcessFindCommand(catalog, command, output);
                    break;
                default:
                    throw new InvalidOperationException("Unknown command!");
            }
        }

        private static void ProcessUpdateCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int itemsUpdated = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            output.AppendLine(String.Format("{0} items updated", itemsUpdated));
        }

        private static void ProcessFindCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }   
}
