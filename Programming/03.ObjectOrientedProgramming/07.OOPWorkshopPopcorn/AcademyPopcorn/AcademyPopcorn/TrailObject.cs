using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 5 - Implement a TrailObject class. It should inherit the GameObject class and should 
    //have a constructor which takes an additional "lifetime" integer. The TrailObject should 
    //disappear after a "lifetime" amount of turns. You must NOT edit any existing .cs file. 
    
    public class TrailObject : GameObject
    {
        public int LifeTime {get; private set;}

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            : base(topLeft, body)
        {
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            LifeTime--;
            if (LifeTime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
