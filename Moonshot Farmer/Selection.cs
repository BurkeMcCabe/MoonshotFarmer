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
    class Selection
    {

        Vector2 position;
        Vector2 gridPosition;
        Camera camera;
        GameContent gameContent;

        public Selection(GameContent gameContent, Camera camera)
        {
            this.gameContent = gameContent;
            this.camera = camera;
        }

        public void Update(Vector2 position)
        {
            position.X += camera.position.X % (GameContent.tileSize * GameContent.scale);
            position.Y += camera.position.Y % (GameContent.tileSize * GameContent.scale);

            this.position.X = position.X - position.X % (GameContent.tileSize * GameContent.scale);
            this.position.Y = position.Y - position.Y % (GameContent.tileSize * GameContent.scale);

            this.position.X -= camera.position.X % (GameContent.tileSize * GameContent.scale);
            this.position.Y -= camera.position.Y % (GameContent.tileSize * GameContent.scale);

            gridPosition.Y = ((position.Y - position.Y % (GameContent.tileSize * GameContent.scale)) / (GameContent.tileSize * GameContent.scale)) + (camera.position.Y - camera.position.Y % (GameContent.tileSize * GameContent.scale)) / (GameContent.tileSize * GameContent.scale);
            gridPosition.X = ((position.X - position.X % (GameContent.tileSize * GameContent.scale)) / (GameContent.tileSize * GameContent.scale)) + (camera.position.X - camera.position.X % (GameContent.tileSize * GameContent.scale)) / (GameContent.tileSize * GameContent.scale);
        }

        public void Update()
        {

        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(gameContent.imgSelection, new Vector2(position.X, position.Y), null, Color.White, 0, new Vector2(0, 0), GameContent.scale, SpriteEffects.None, 0);
            Game1.spriteBatch.DrawString(gameContent.arial, gridPosition.X.ToString() + " " + gridPosition.Y.ToString(), new Vector2(0, 0), Color.White);


        }

    }
}
