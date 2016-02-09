﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TiledSharp;
using StryfeRPG.Managers;
using StryfeRPG.Models.Characters;
using StryfeRPG.System;
using StryfeRPG.Models.Utils;
using System.Collections.Generic;

namespace StryfeRPG
{
    public class Stryfe : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Stryfe()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            Global.SetContent(Content);
        }

        protected override void Initialize()
        {
            CameraManager.Instance.Bounds = GraphicsDevice.Viewport.Bounds;
        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.MapFont = Content.Load<SpriteFont>("DialogFont"); //TODO: get this straight
            Global.DialogFont = Content.Load<SpriteFont>("DialogFont");
            Global.Viewport = GraphicsDevice.Viewport;

            MapManager.Instance.spriteBatch = spriteBatch;
            MapManager.Instance.LoadMap("exampleMap");

            Utils.LoadDialogs();
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

            CameraManager.Instance.Position = Global.Player.CurrentPosition;

            // Maps (and everything in them)
            spriteBatch.Begin(samplerState: SamplerState.PointWrap, transformMatrix: CameraManager.Instance.TransformMatrix);
            MapManager.Instance.Draw(gameTime.ElapsedGameTime.TotalSeconds);
            HUDManager.Instance.DrawObjectNames(spriteBatch);
            spriteBatch.End();

            // Dialogs
            spriteBatch.Begin();
            DialogManager.Instance.Draw(spriteBatch, gameTime.ElapsedGameTime.TotalSeconds);

            // HUD
            HUDManager.Instance.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
