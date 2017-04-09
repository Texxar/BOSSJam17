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

            failMessage = "The fishes have dried out and are dead..";
            awardMessage = "THANK YOU FOR SAVING MY FISHIES";

            missionLocation = new Vector2(1, 1);

            negativeHappiness = -3;
            negativeMoney = 0;

            PositiveHappiness = 3;
            PositivteMoney = 0;

            Initialzie();

        }

        public FishermanCall(Call call,ContentManager content,NoteBoard noteBoard, List<Interactable> stuff,string inString) : base(call,content,noteBoard,stuff,inString)
        {
            caseIntensity = CaseIntensity.low;

            missionLocation = new Vector2(1, 1);

            failMessage = "The fishes have dried out and are dead..";
            awardMessage = "THANK YOU FOR SAVING MY FISHIES";

            negativeHappiness = -3;
            negativeMoney = 0;

            PositiveHappiness = 3;
            PositivteMoney = 0;
    }

        public override void Initialzie()
        {

            base.Initialzie();
        }

    }
}
