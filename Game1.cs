using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HexGrid
{
    /// <summary>
    /// sample Hex Grid
    /// Original code from Microsoft XNA 4.0 Game Development Cookbook
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        //TODO: modify the hardcode to allow for more flexible determination of
        //these values
        Texture2D hexagon;
        int leftHexWidth = 76;
        int topHexagonHeight = 44;
        int hexagonHeight = 88;
        int hexagonSlopeHeight = 25;
        float hexagonSlope;
        Vector2 scrollOffset;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            hexagon = Content.Load<Texture2D>("Hex");
            hexagonSlope = (float)topHexagonHeight / (float)hexagonSlopeHeight;
            scrollOffset = new Vector2();
            IsMouseVisible = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int positionX = (int)((leftHexWidth * x) + scrollOffset.X);
                    int alternate = x % 2;
                    int positionY = (int)((hexagonHeight * y) + (alternate * topHexagonHeight) + scrollOffset.Y);
                    Vector2 position = new Vector2(positionX, positionY);

                    spriteBatch.Draw(hexagon, position, Color.White);
                }

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
