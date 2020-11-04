using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Moonshot_Farmer
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        GameContent gameContent;
        Farmer farmer;
        Ground ground;
        Selection selection;
        public static KeyboardState keyboardState;
        Camera playerCamera;
        Vector2 mousePosition;
        MouseState mouseState;
        int smallScreenWidth;
        int smallScreenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            smallScreenWidth = 1280;
            smallScreenHeight = 720;

            graphics.PreferredBackBufferWidth = smallScreenWidth;
            graphics.PreferredBackBufferHeight = smallScreenHeight;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;
            Window.AllowUserResizing = true;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameContent = new GameContent(Content);

            playerCamera = new Camera(0, 0);
            farmer = new Farmer(0, 0, 5, gameContent, playerCamera);
            ground = new Ground(0, 0, gameContent, playerCamera);
            selection = new Selection(gameContent, playerCamera);

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.F11))
            {
                if (graphics.PreferredBackBufferWidth == GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width)
                {
                    graphics.PreferredBackBufferWidth = smallScreenWidth;
                    graphics.PreferredBackBufferHeight = smallScreenHeight;

                    graphics.ToggleFullScreen();
                    graphics.ApplyChanges();
                }
                else
                {
                    smallScreenHeight = graphics.PreferredBackBufferHeight;
                    smallScreenWidth = graphics.PreferredBackBufferWidth;
                    graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                    graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

                    graphics.ToggleFullScreen();
                    graphics.ApplyChanges();
                }
            }

            mouseState = Mouse.GetState();
            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;

            farmer.Update();
            playerCamera.followCenter(farmer.position, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, gameContent.imgGuy.Width, gameContent.imgGuy.Height);
            selection.Update(mousePosition);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

            ground.Draw();
            selection.Draw();
            farmer.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
