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
    class GhostSightCall : Call
    {
        public GhostSightCall(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>("DialogueAvatar\\midlifecrisis");

            dia = new Dialogue("GhostSighting", content);

            caseIntensity = CaseIntensity.low;

            failMessage = "A man was scared to death today....";
            awardMessage = "We can all sleep well tonight";

            missionLocation = new Vector2(6, 9);

            negativeHappiness = -3;
            negativeMoney = 0;

            PositiveHappiness = 2;
            PositivteMoney = 2;

            Initialzie();
        }

        public GhostSightCall(Call call, ContentManager content, NoteBoard noteBoard, List<Interactable> stuff, string inString) : base(call, content, noteBoard, stuff, inString)
        {
            caseIntensity = CaseIntensity.low;

            failMessage = "A man was scared to death today....";
            awardMessage = "We can all sleep well tonight";

            missionLocation = new Vector2(6, 9);

            negativeHappiness = -3;
            negativeMoney = 0;

            PositiveHappiness = 2;
            PositivteMoney = 2;
        }

        public override void Initialzie()
        {

            base.Initialzie();
        }
    }
}
