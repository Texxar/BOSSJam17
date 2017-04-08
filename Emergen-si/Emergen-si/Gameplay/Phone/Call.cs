using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    
    class Call
    {
        Rectangle rec;
        protected Texture2D avatar;
        float rotation = 0;
        float roationValue = 0;
        float roatationSpeed = 0.03f;

        bool plusDirection = true;

        public Call()
        {
            
        }

        public void Initialzie()
        {
            rec = new Rectangle(100, 620, avatar.Width, avatar.Height);
        }

        public void Update()
        {
            if(plusDirection)
            {
                roationValue += roatationSpeed;

                if (roationValue > 1)
                    plusDirection = false;
            }
            else
            {
                roationValue -= roatationSpeed;
                if (roationValue <= 0)
                    plusDirection = true;
            }
                
            rotation = MathHelper.Lerp(-0.14f, 0.24f, roationValue);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(avatar,rec,null,Color.White, rotation,new Vector2(avatar.Width/2,avatar.Height/2),SpriteEffects.None,0);
        }
    }
}
