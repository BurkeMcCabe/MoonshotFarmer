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
    class Grass : Tile
    {

        GameContent gameContent;

        public Grass(GameContent gameContent)
        {
            this.gameContent = gameContent;
        }

        public void Update()
        {

        }

        public override void Draw(Vector2 position)
        {
            Game1.spriteBatch.Draw(gameContent.imgGrass, new Vector2(position.X, position.Y), null, Color.White, 0, new Vector2(0, 0), GameContent.scale, SpriteEffects.None, 0);
        }

    }
}
