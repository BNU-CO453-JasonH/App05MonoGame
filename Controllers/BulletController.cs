using System;
using System.Collections.Generic;
using System.Text;
using App05MonoGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace App05MonoGame.Controllers
{
    /// <summary>
    /// This class creates a list of bullets which will be fired
    /// when the player presses down on the space bar in the game.
    /// </summary>
    /// <author>
    /// Jason Huggins (29/04/2021)
    /// </author>
    public class BulletController
    {
        public Texture2D BulletTexture { get; set; }

        public List<Bullet> Bullets { get; set; }

        public BulletController(Texture2D bulletTexture)
        {
            Bullets = new List<Bullet>();
            this.BulletTexture = bulletTexture;
        }


        public void UpdateBullets(GameTime gameTime)
        {
            foreach (Bullet bullet in Bullets)
            {
                bullet.Update(gameTime);
            }
        }

        public void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in Bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Clones the bullet when the player fires their
        /// weapon by holding down the space bar. 
        /// </summary>
        public void AddBullet(AnimatedPlayer player)
        {
            Bullet bullet = new Bullet(BulletTexture);

            bullet.Direction = player.Direction;
            bullet.Position = player.Position;
            bullet.LinearVelocity = player.LinearVelocity * 2;
            bullet.LifeSpan = 2f;
            bullet.Parent = player;
            
            Bullets.Add(bullet);
        }
    }
}
