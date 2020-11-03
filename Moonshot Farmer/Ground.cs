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
        List<List<string>> groundTiles;
        GameContent gameContent;
        Camera camera;

        public Ground(int x, int y, GameContent gameContent, Camera camera)
        {
            position = new Vector2(x, y);
            groundTiles = new List<List<string>>();
            this.camera = camera;
            this.gameContent = gameContent;

            string map = System.IO.File.ReadAllText(@"C:\Users\burke\source\repos\Moonshot Farmer\Moonshot Farmer\GroundMap.txt");
            List<string> mapListLines = new List<string>();
            mapListLines = map.Split('\n').ToList();
            foreach (string line in mapListLines)
            {
                string newLine = line.Replace("\r", null);
                groundTiles.Add(newLine.Split(' ').ToList());
            }
        }

        public void Draw()
        {
            for (int i = 0; i < groundTiles.Count; i++)
            {
                for (int j = 0; j < groundTiles[i].Count; j++)
                {
                    switch (groundTiles[i][j])
                    {
                        case "1":
                            Game1.spriteBatch.Draw(gameContent.imgGrass, new Vector2(-camera.position.X + position.X + gameContent.imgGrass.Width * j * GameContent.scale, 
                                                                                     -camera.position.Y + position.Y + gameContent.imgGrass.Height * i * GameContent.scale), 
                                null, Color.White, 0, new Vector2(0, 0), GameContent.scale, SpriteEffects.None, 0);
                            break;
                        case "2":
                            Game1.spriteBatch.Draw(gameContent.imgDirt, new Vector2(-camera.position.X + position.X +
                                gameContent.imgGrass.Width * j * GameContent.scale,
                                -camera.position.Y + position.Y + gameContent.imgGrass.Height * i * GameContent.scale),
                                null, Color.White, 0, new Vector2(0, 0), GameContent.scale, SpriteEffects.None, 0);
                            break;
                    }
                    


                }
            }
        }
    }
}
