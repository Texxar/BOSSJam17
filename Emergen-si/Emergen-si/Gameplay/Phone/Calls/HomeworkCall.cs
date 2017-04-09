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
    class HomeworkCall : Call
    {
        public HomeworkCall(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>("DialogueAvatar\\kid");

            dia = new Dialogue("Homework", content);

            caseIntensity = CaseIntensity.low;

            failMessage = "The future just got darker";
            awardMessage = "You shouldn't have dropped out highschool";

            missionLocation = new Vector2(1, 1);

            negativeHappiness = -5;
            negativeMoney = 0;

            PositiveHappiness = 2;
            PositivteMoney = 1;
            Initialzie();
        }

        public HomeworkCall(Call call, ContentManager content, NoteBoard noteBoard, List<Interactable> stuff, string inString) : base(call, content, noteBoard, stuff, inString)
        {
            caseIntensity = CaseIntensity.low;

            failMessage = "The future just got darker";
            awardMessage = "You shouldn't have dropped out highschool";

            missionLocation = new Vector2(1, 1);

            negativeHappiness = -5;
            negativeMoney = 0;

            PositiveHappiness = 2;
            PositivteMoney = 1;
        }

        public override void Initialzie()
        {

            base.Initialzie();
        }
    }
}
