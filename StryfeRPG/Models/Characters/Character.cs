﻿using Microsoft.Xna.Framework;
using StryfeRPG.Models.Maps;
using StryfeRPG.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TiledSharp;

namespace StryfeRPG.Models.Characters
{
    public enum FacingDirection
    {
        Down, Left, Right, Up
    }

    public class Character : Maps.MapObject
    {
        public FacingDirection direction { get; set; }
        public CharacterSheet sheet { get; set; }

        public Character() { }
        public Character(TmxObject obj, Tileset tileset) : base(obj, tileset)
        {
            Console.WriteLine(String.Format("NPC: {0}", obj.Name));
            sheet = new CharacterSheet(textureId, tileset);

            if (textureId == sheet.gidUp)
                direction = FacingDirection.Up;
            else if (textureId == sheet.gidLeft)
                direction = FacingDirection.Left;
            else if (textureId == sheet.gidRight)
                direction = FacingDirection.Right;
            else
                direction = FacingDirection.Down;
        }

        public int GetSprite()
        {
            if (sheet == null)
                return textureId;

            switch (direction)
            {
                case FacingDirection.Up:
                    return sheet.gidUp;
                case FacingDirection.Down:
                    return sheet.gidDown;
                case FacingDirection.Left:
                    return sheet.gidLeft;
                case FacingDirection.Right:
                    return sheet.gidRight;
            }

            return textureId;
        }
        
        public void LookAt(Vector2 position)
        {
            if (mapPosition.X < position.X)
            {
                direction = FacingDirection.Right;
            } else if (mapPosition.X > position.X)
            {
                direction = FacingDirection.Left;
            } else if (mapPosition.Y > position.Y)
            {
                direction = FacingDirection.Up;
            } else
            {
                direction = FacingDirection.Down;
            }
        }

        public override void PerformAction()
        {
            LookAt(Global.Player.mapPosition);

            Console.WriteLine(name);
        }
    }
}
