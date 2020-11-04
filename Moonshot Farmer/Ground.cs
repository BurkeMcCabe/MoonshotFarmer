using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Moonshot_Farmer
{
    class Ground
    {
        Vector2 position;
        List<List<Tile>> groundTiles;
        GameContent gameContent;
        Camera camera;

        public Ground(int x, int y, GameContent gameContent, Camera camera)
        {
            position = new Vector2(x, y);
            groundTiles = new List<List<Tile>>();
            this.camera = camera;
            this.gameContent = gameContent;

            string map = System.IO.File.ReadAllText(@"C:\Users\burke\source\repos\Moonshot Farmer\Moonshot Farmer\GroundMap.txt");
            List<string> mapListLines = new List<string>();
            mapListLines = map.Split('\n').ToList();
            int counter = 0;
            foreach (string line in mapListLines)
            {
                groundTiles.Add(new List<Tile>());
                string newLine = line.Replace("\r", null);
                foreach (string tile in newLine.Split(' ').ToList())
                {
                    switch (tile)
                    {
                        case "1":
                            groundTiles[counter].Add(new Grass(gameContent));
                            break;
                        case "2":
                            groundTiles[counter].Add(new Dirt(gameContent));
                            break;
                    }
                }
                counter++;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < groundTiles.Count; i++)
            {
                for (int j = 0; j < groundTiles[i].Count; j++)
                {

                    groundTiles[i][j].Draw(new Vector2(-camera.position.X + position.X + gameContent.imgGrass.Width * j * GameContent.scale, -camera.position.Y + position.Y + gameContent.imgGrass.Height * i * GameContent.scale));
                    


                }
            }
        }
    }
}
