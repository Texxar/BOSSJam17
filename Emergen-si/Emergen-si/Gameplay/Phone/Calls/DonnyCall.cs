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
    class DonnyCall:Call
    {
        public DonnyCall(ContentManager content):base()
        {
            avatar = content.Load<Texture2D>("DialogueAvatar\\teenagewasteland");

            dia = new Dialogue("Donny", content);

            caseIntensity = CaseIntensity.low;

            failMessage = "Where are they?";
            awardMessage = "Here are your donuts, guys!";

            missionLocation = new Vector2(2, 9);

            negativeHappiness = -5;
            negativeMoney = 2;

            PositiveHappiness = 5;
            PositivteMoney = -2;

            Initialzie();
        }

        public DonnyCall(Call call, ContentManager content, NoteBoard noteBoard, List<Interactable> stuff, string inString) : base(call,content,noteBoard,stuff,inString)
        {
            caseIntensity = CaseIntensity.low;

            failMessage = "Where are they?";
            awardMessage = "Here are your donuts, guys!";

            missionLocation = new Vector2(1, 9);

            negativeHappiness = -5;
            negativeMoney = 2;

            PositiveHappiness = 5;
            PositivteMoney = -2;
        }

        public override void Initialzie()
        {

            base.Initialzie();
        }
    }
}
