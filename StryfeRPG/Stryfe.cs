﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TiledSharp;
using StryfeRPG.Managers;
using StryfeRPG.Models.Characters;
using StryfeRPG.System;

namespace StryfeRPG
{
    public class Stryfe : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Stryfe()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Global.SetContent(Content);
        }

        protected override void Initialize()
        {
            CameraManager.Instance.Bounds = GraphicsDevice.Viewport.Bounds;
            CameraManager.Instance.Zoom = 2;
        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.DefaultFont = Content.Load<SpriteFont>("MyFont");

            MapManager.Instance.spriteBatch = spriteBatch;
            MapManager.Instance.LoadMap("exampleMap");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardManager.Instance.Update(gameTime.ElapsedGameTime.TotalSeconds);
            MapManager.Instance.Update(gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            CameraManager.Instance.Position = Global.Player.currentPosition;

            spriteBatch.Begin(samplerState: SamplerState.PointWrap, transformMatrix: CameraManager.Instance.TransformMatrix);
            MapManager.Instance.Draw(gameTime.ElapsedGameTime.TotalSeconds);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
