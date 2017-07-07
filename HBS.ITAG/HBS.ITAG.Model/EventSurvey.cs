using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    public class EventSurvey
    {
        public string SurveyId;
        public int QuestionOneRating;
        public int QuestionTwoRating;
        public int QuestionThreeRating;
        public string QuestionFourAnswer;
        public string OtherComments;
        public string UserDeviceId;
        public string EventId;
        public string Email;

        public EventSurvey()
        {
            SurveyId = (-1).ToString();
            QuestionOneRating = 0;
            QuestionTwoRating = 0;
            QuestionThreeRating = 0;
            QuestionFourAnswer = "No";
            OtherComments = "";
            UserDeviceId = null;
            EventId = "";
            Email = "";
        }

        public EventSurvey(int QuestionOneRating, int QuestionTwoRating, int QuestionThreeRating, string QuestionFourAnswer, string OtherComments, string UserId, string EventId)
        {
            this.SurveyId = (-1).ToString();
            this.QuestionOneRating = QuestionOneRating;
            this.QuestionTwoRating = QuestionTwoRating;
            this.QuestionThreeRating = QuestionThreeRating;
            this.QuestionFourAnswer = QuestionFourAnswer;
            this.OtherComments = OtherComments;
            this.UserDeviceId = UserId;
            this.EventId = EventId;
            this.Email = "";
        }

		public EventSurvey(int QuestionOneRating, int QuestionTwoRating, int QuestionThreeRating, string QuestionFourAnswer, string OtherComments, string UserId, string EventId, string Email)
		{
			this.SurveyId = (-1).ToString();
			this.QuestionOneRating = QuestionOneRating;
			this.QuestionTwoRating = QuestionTwoRating;
			this.QuestionThreeRating = QuestionThreeRating;
			this.QuestionFourAnswer = QuestionFourAnswer;
			this.OtherComments = OtherComments;
			this.UserDeviceId = UserId;
			this.EventId = EventId;
            this.Email = Email;
		}
    }
}