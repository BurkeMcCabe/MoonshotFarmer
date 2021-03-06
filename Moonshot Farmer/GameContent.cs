﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Moonshot_Farmer
{
    class GameContent
    {

        public static float scale = 6;
        public static int tileSize = 8;

        public Texture2D imgGuy;
        public Texture2D imgGrass;
        public Texture2D imgDirt;
        public Texture2D imgSelection;

        public SpriteFont arial;


        public GameContent(ContentManager content)
        {
            imgGuy = content.Load<Texture2D>("imgGuy");
            imgGrass = content.Load<Texture2D>("imgGrass");
            imgDirt = content.Load<Texture2D>("imgDirt");
            imgSelection = content.Load<Texture2D>("imgSelection");

            arial = content.Load<SpriteFont>("Arial");
        }


    }
}
