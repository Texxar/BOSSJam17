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
    class PostIt : Interactable
    {
        Texture2D tex;
        public float scale;
        NoteBoard noteBoard;

        public PostIt(ContentManager content, NoteBoard noteBoard) : base()
        {
            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(0, 0, tex.Width, tex.Height);
            hitBox = rec;
            scale = 1;
            this.noteBoard = noteBoard;
        }

        public void Update(GameTime gameTime)
        {
            if (!rec.Intersects(noteBoard.rec) && rec.Y < 500 && !held)
            {
                rec.Y += 20;
                hitBox.Y += 20;
            }
        }



        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(
                tex,
                new Vector2(rec.X, rec.Y), 
                null, 
                Color.Yellow, 
                0,                                              //rotation
                new Vector2(tex.Width*0.5f, tex.Height*0.5f),   //origin
                scale,                                          //scale
                SpriteEffects.None, 
                0 );
        }
    }
}
