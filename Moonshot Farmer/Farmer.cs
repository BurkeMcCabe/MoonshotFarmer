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
    class Farmer
    {

        public Vector2 position;
        Texture2D img;
        float speed;
        GameContent gameContent;
        Camera camera;

        public Farmer(int x, int y, int speed, GameContent gameContent, Camera camera)
        {
            position = new Vector2(x, y);
            this.speed = speed;
            this.gameContent = gameContent;
            this.camera = camera;
        }

        public void Update()
        {
            if (Game1.keyboardState.IsKeyDown(Keys.W)) { position.Y -= speed; }
            if (Game1.keyboardState.IsKeyDown(Keys.A)) { position.X -= speed; }
            if (Game1.keyboardState.IsKeyDown(Keys.S)) { position.Y += speed; }
            if (Game1.keyboardState.IsKeyDown(Keys.D)) { position.X += speed; }
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(gameContent.imgGuy, new Vector2(-camera.position.X + position.X, -camera.position.Y + position.Y), null, Color.White, 0, new Vector2(0, 0), GameContent.scale, SpriteEffects.None, 0);
        }

    }
}
