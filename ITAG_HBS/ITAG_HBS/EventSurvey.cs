namespace HBS.ITAG
{
    public class EventSurvey
    {
        public int usefulness;
        public int overall;
        public int understandability;
        public int preparedness;
        public int knowledgeable;
        public string otherComments;

        public EventSurvey()
        {
            usefulness = 0;
            overall = 0;
            understandability = 0;
            preparedness = 0;
            knowledgeable = 0;
            otherComments = null;
        }

        public EventSurvey(int usefulness, int overall, int understandability, int preparedness, int knowledgeable, string otherComments)
        {
            this.usefulness = usefulness;
            this.overall = overall;
            this.understandability = understandability;
            this.preparedness = preparedness;
            this.knowledgeable = knowledgeable;
            this.otherComments = otherComments;
        }
    }
}