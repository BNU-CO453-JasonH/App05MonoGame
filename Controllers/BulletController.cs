using System;
using System.Collections.Generic;
using System.Text;
using App05MonoGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace App05MonoGame.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BulletController
    {
        public Texture2D BulletTexture { get; set; }

        public List<Bullet> Bullets { get; set; }

        public BulletController()
        {
            Bullets = new List<Bullet>();
        }

        /// <summary>
        /// Creates a new bullet and adds it to the list.
        /// </summary>
        public void CreateBullet(Texture2D bulletTexture)
        {
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
