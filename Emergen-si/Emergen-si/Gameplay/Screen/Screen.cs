using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Emergen_si
{
    class Screen
    {
        Map map;
        Car policeCar;

        public Screen(ContentManager content)
        {
            map = new Map(content);
            policeCar = new Car(content, map);
        }

        public void Update(GameTime gameTime)
        {





            policeCar.Update(gameTime);
        }

        public void Draw(SpriteBatch sb)
        {
            map.Draw(sb);
            policeCar.Draw(sb);
        }
    }
}
