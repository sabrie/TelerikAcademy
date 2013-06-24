using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // The normal ball without trail
            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            
            //engine.AddObject(theBall);

            // Exercise 7: Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.
            MeteoriteBall theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theMeteoriteBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // Exercise 1 - Add left and right side walls
            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(row, 1));

                engine.AddObject(leftWallBlock);
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(rightWallBlock);
            }

            // Exercise 1 - Add ceiling wall
            for (int col = 1; col < WorldCols; col++)
            {
                IndestructibleBlock upperWallBlock = new IndestructibleBlock(new MatrixCoords(1, col));

                engine.AddObject(upperWallBlock);
            }
            // Exercise 5 - test the trailObject by adding an instance of TrailObject in the engine
            // it appears in the middle of the game screen and disappears after a certain period of time
            TrailObject trailObject = new TrailObject(new MatrixCoords((WorldRows / 2), (WorldCols / 2)), new char[,] { { '*' } }, 10);
            engine.AddObject(trailObject);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 500);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
