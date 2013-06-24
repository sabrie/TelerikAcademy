using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popaye_Shop
{
    public class Game : ElectronicProduct
    {
        private string gameGenre;

        public Game(int price, string model, string manufacturer, string gameGenre) 
            : base(price, model, manufacturer)
        {
            this.gameGenre = gameGenre;
        }

        public string GameGenre
        {
            get
            {
                return this.gameGenre;
            }
            set
            {
                this.gameGenre = value;
            }
        }

        public List<Game> SellProduct(List<Game> games, Game game)
        {
            games.Remove(game);
            return games;
        }

        public override string ToString()
        {
            return string.Format("Game:{0} ,developed by {1} , Genre:{2} , price:{3}", 
                this.name, this.manufacturer, this.gameGenre, this.price);
        }
    }
}
