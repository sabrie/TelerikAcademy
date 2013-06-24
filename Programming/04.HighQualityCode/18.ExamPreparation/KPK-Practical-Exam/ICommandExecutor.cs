using System;
using System.Linq;
using System.Text;

namespace CatalogOfFreeContent
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, 
            ICommand command, StringBuilder output);
    }
}
