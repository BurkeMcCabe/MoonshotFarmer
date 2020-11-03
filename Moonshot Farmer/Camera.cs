using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Moonshot_Farmer
{
    class Camera
    {

        public Vector2 position;

        public Camera(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public void follow(Vector2 position)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
        }

        public void followCenter(Vector2 position, int screenWidth, int screenHeight, int objectHeight, int objectWidth)
        {
            this.position.X = -screenWidth / 2 + objectWidth * GameContent.scale / 2 + position.X;
            this.position.Y = -screenHeight / 2 + objectWidth * GameContent.scale / 2 + position.Y;
        }
    }
}
