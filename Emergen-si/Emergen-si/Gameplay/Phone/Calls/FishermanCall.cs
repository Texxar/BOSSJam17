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
    class FishermanCall:Call
    {
        
        public FishermanCall(ContentManager content):base()
        {
            avatar = content.Load<Texture2D>("DialogueAvatar\\Calling");

            dia = new Dialogue("TvHead", content);

            caseIntensity = CaseIntensity.low;



            Initialzie();
        }

        public FishermanCall(Call call,ContentManager content,NoteBoard noteBoard, List<Interactable> stuff,string inString) : base(call,content,noteBoard,stuff,inString)
        {
           
        }

        public override void Initialzie()
        {

            base.Initialzie();
        }

    }
}
