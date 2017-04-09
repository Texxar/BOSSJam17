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
    class HumanSightCall : Call
    {
        public HumanSightCall(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>("DialogueAvatar\\ghostofforestmanor");

            dia = new Dialogue("HumanSighting", content);

            caseIntensity = CaseIntensity.low;

            failMessage = "A fight for the minority was lost";
            awardMessage = "Undead? Yes. Unperson? No!";

            missionLocation = new Vector2(8, 9);

            negativeHappiness = 0;
            negativeMoney = -5;

            PositiveHappiness = 0;
            PositivteMoney = 5;

            Initialzie();
        }

        public HumanSightCall(Call call, ContentManager content, NoteBoard noteBoard, List<Interactable> stuff, string inString) : base(call, content, noteBoard, stuff, inString)
        {
            caseIntensity = CaseIntensity.low;

            failMessage = "A fight for the minority was lost";
            awardMessage = "Undead? Yes. Unperson? No!";

            missionLocation = new Vector2(8, 9);

            negativeHappiness = 0;
            negativeMoney = -5;

            PositiveHappiness = 0;
            PositivteMoney = 5;
        }

        public override void Initialzie()
        {

            base.Initialzie();
        }
    }
}
