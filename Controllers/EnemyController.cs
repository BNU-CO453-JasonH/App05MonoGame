using System;
using System.Collections.Generic;
using System.Text;
using App05MonoGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace App05MonoGame.Controllers
{
    /// <summary>
    /// This class handles the control of enemy sprites in
    /// the game. They act as non-playable characters (NPCs)
    /// that will chase after the player if they walk into
    /// their set field of view.
    /// </summary>
    public class EnemyController
    {
        public AnimatedSprite Enemy { get; set; }

        public EnemyController() { }

        public AnimatedSprite CreateEnemy(GraphicsDevice graphics,
            Texture2D enemySheet)
        {
            AnimationController controller = new
                AnimationController(graphics, enemySheet, 4, 3);

            string[] keys = new string[] { "Down", "Left", "Right", "Up" };
            controller.CreateAnimationGroup(keys);

            Enemy = new AnimatedSprite()
            {
                Scale = 2.0f,

                Position = new Vector2(1000, 200),
                Direction = new Vector2(-1, 0),
                Speed = 50,

                Rotation = MathHelper.ToRadians(0),
            };

            controller.AppendAnimationsTo(Enemy);
            Enemy.PlayAnimation("Left");

            return Enemy;
        }

        public void StartEnemy()
        {
            Enemy.Position = new Vector2(1000, 200);
            Enemy.Direction = new Vector2(-1, 0);
            Enemy.Speed = 50;
        }
    }
}
