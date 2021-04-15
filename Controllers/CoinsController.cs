using App05MonoGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace App05MonoGame.Controllers
{
    public enum CoinColours
    {
        Copper = 100,
        Silver = 200,
        Gold = 500
    }

    /// <summary>
    /// This class creates a list of coins which
    /// can be updated and drawn and checked for
    /// collisions with the player sprite
    /// </summary>
    /// <authors>
    /// Derek Peacock & Andrei Cruceru
    /// Modified by Jason Huggins (15/04/2021)
    /// </authors>
    public class CoinsController
    {
        private SoundEffect coinEffect;
        private int coinValue;

        private readonly List<AnimatedSprite> Coins;        

        public CoinsController()
        {
            Coins = new List<AnimatedSprite>();
        }

        /// <summary>
        /// Create an animated sprite of a copper coin
        /// which could be collected by the player for a score
        /// </summary>
        public void CreateCoin(GraphicsDevice graphics, Texture2D coinSheet)
        {
            coinEffect = SoundController.GetSoundEffect("Coin");
            coinValue = (int)CoinColours.Copper;
            Animation animation = new Animation("coin", coinSheet, 8);

            AnimatedSprite coin = new AnimatedSprite()
            {
                Animation = animation,
                Image = animation.SetMainFrame(graphics),
                Scale = 2.0f,
                Position = new Vector2(600, 100),
                Speed = 0,
            };

            Coins.Add(coin);
        }

        public int HasCollided(AnimatedPlayer player)
        {
            foreach (AnimatedSprite coin in Coins)
            {
                if (coin.HasCollided(player) && coin.IsAlive)
                {
                    coinEffect.Play();

                    coin.IsActive = false;
                    coin.IsAlive = false;
                    coin.IsVisible = false;

                    return coinValue;
                }
            }

            return 0;
        }

        public void Update(GameTime gameTime)
        {
            foreach(AnimatedSprite coin in Coins)
            {
                coin.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (AnimatedSprite coin in Coins)
            {
                coin.Draw(spriteBatch);
            }
        }
    }
}
