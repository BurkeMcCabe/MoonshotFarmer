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
        public static KeyboardState keyboardState;
        Camera playerCamera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameContent = new GameContent(Content);

            playerCamera = new Camera(100, 100);
            farmer = new Farmer(10, 10, 5, gameContent, playerCamera);
            ground = new Ground(10, 10, gameContent, playerCamera);

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();

            farmer.Update();
            playerCamera.followCenter(farmer.position, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, gameContent.imgGuy.Width, gameContent.imgGuy.Height);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

            ground.Draw();
            farmer.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
