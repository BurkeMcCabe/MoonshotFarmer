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
        int width;
        int height;
        List<List<string>> groundTiles;
        GameContent gameContent;
        Camera camera;

        public Ground(int x, int y, int width, int height, GameContent gameContent, Camera camera)
        {
            position = new Vector2(x, y);
            this.width = width;
            this.height = height;
            groundTiles = new List<List<string>>();
            this.camera = camera;
            this.gameContent = gameContent;

            for (int i = 0; i < width; i++)
            {
                List<string> xGroundTiles = new List<string>();
                for (int j = 0; j < height; j++)
                {
                    xGroundTiles.Add("grass");
                }
                groundTiles.Add(xGroundTiles);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    Game1.spriteBatch.Draw(gameContent.imgGrass, new Vector2(-camera.position.X + position.X + gameContent.imgGrass.Width * i * GameContent.scale, -camera.position.Y + position.Y + gameContent.imgGrass.Height * j * GameContent.scale), null, Color.White, 0, new Vector2(0, 0), GameContent.scale, SpriteEffects.None, 0);


                }
            }
        }
    }
}
