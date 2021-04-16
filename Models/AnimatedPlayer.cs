using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using App05MonoGame.Controllers;
using Microsoft.Xna.Framework.Graphics;

namespace App05MonoGame.Models
{
    /// <summary>
    /// This class is an AnimatedSprite whose direction
    /// can be controlled by the keyboard in four
    /// directions, up, down, left and right
    /// </summary>
    /// <authors>
    /// Derek Peacock & Andrei Cruceru
    /// Modified by Jason Huggins (16/04/2021)
    /// </authors>
    public class AnimatedPlayer : AnimatedSprite
    {
        public bool CanWalk { get; set; }

        public Bullet Bullet { get; set; }

        private readonly MovementController movement;

        public AnimatedPlayer() : base()
        {
            CanWalk = false;
            movement = new MovementController();
        }

        /// <summary>
        /// If the sprite has animations for walking in the
        /// four directions then it switches between the
        /// animations depending on the direction
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            PreviousKey = CurrentKey;
            CurrentKey = Keyboard.GetState();
            
            IsActive = false;

            Vector2 newDirection = movement.ChangeDirection(CurrentKey);

            if (newDirection != Vector2.Zero)
            {
                Direction = newDirection;
                IsActive = true;
            }

            if (CanWalk) Walk();

            if (CurrentKey.IsKeyDown(Keys.Space) && 
                PreviousKey.IsKeyUp(Keys.Space))
            {
                AddBullet();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Clones the bullet when the player fires their
        /// weapon by holding down the space bar. 
        /// </summary>
        private void AddBullet()
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.LinearVelocity = this.LinearVelocity * 2;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;

            // TODO: Fix as the bullets aren't showing up.
        }

        /// <summary>
        /// Switch between the four walk animations depending
        /// on the direction.  Will not look quite right
        /// with 45 degree directions
        /// </summary>
        private void Walk()
        {
            if (Animations.Count >= 4)
            {
                if (Direction.X > 0 && Direction.Y < Direction.X)
                    Animation = Animations["Right"];

                else if (Direction.Y > 0 && Direction.X < Direction.Y)
                    Animation = Animations["Down"];

                else if (Direction.X < 0 && Direction.X < Direction.Y)
                    Animation = Animations["Left"];

                else if (Direction.Y < 0 && Direction.Y < Direction.X)
                    Animation = Animations["Up"];
            }
        }
    }
}
