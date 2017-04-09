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
    class GrannyCall : Call
    {
        public GrannyCall(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>("DialogueAvatar\\granny");

            dia = new Dialogue("CatInTree", content);

            caseIntensity = CaseIntensity.low;

            failMessage = "Grannys cat fell out and now its dead!";
            awardMessage = "Granny now has one more cat to bring home";

            missionLocation = new Vector2(15, 3);

            negativeHappiness = -2;
            negativeMoney = 0;

            PositiveHappiness = 1;
            PositivteMoney = 0;

            Initialzie();
        }

        public GrannyCall(Call call, ContentManager content, NoteBoard noteBoard, List<Interactable> stuff, string inString) : base(call, content, noteBoard, stuff, inString)
        {
            caseIntensity = CaseIntensity.low;

            failMessage = "Grannys cat fell out and now its dead!";
            awardMessage = "Granny now has one more cat to bring home";

            missionLocation = new Vector2(15, 3);

            negativeHappiness = -2;
            negativeMoney = 0;

            PositiveHappiness = 1;
            PositivteMoney = 0;
        }

        public override void Initialzie()
        {

            base.Initialzie();
        }
    }
}
