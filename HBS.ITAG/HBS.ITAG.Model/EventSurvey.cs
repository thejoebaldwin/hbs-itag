using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    public class EventSurvey
    {
        public string SurveyId { get; set; }
        //public string QuestionOneAnswer { get; set; }
        //public string QuestionTwoAnswer { get; set; }
        //public string QuestionThreeAnswer { get; set; }
        //public string QuestionFourAnswer { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public string Options { get; set; }
        public int BoothId { get; set; }
        public int OrderIndex { get; set; }
        public string OtherComments { get; set; }
        public string UserDeviceId { get; set; }
        public string EventId { get; set; }
        public string Email { get; set; }

        public EventSurvey()
        {
            SurveyId = (-1).ToString();
            Question = "";
            //QuestionOneAnswer = "0";
            //QuestionTwoAnswer = "0";
            //QuestionThreeAnswer = "0";
            //QuestionFourAnswer = "No";
            Type = "";
            BoothId = 0;
            OrderIndex = 0;
            OtherComments = "";
            UserDeviceId = null;
            EventId = "";
            Email = "";
        }

        public EventSurvey(string Question,string Type, string Options,int BoothId, int OrderIndex, string OtherComments, string UserDeviceId, string EventId)
        {
            this.SurveyId = (-1).ToString();
            this.Question = Question;
            this.Type = Type;
            this.Options = Options;
            this.BoothId = BoothId;
            this.OrderIndex = OrderIndex;
            //this.QuestionOneAnswer = QuestionOneRating;
            //this.QuestionTwoAnswer = QuestionTwoRating;
            //this.QuestionThreeAnswer = QuestionThreeRating;
            //this.QuestionFourAnswer = QuestionFourAnswer;
            this.OtherComments = OtherComments;
            this.UserDeviceId = UserDeviceId;
            this.EventId = EventId;
            this.Email = "";
        }

		public EventSurvey(string Question, string Type,String Options, int BoothId,int OrderIndex,string OtherComments, string UserDeviceId, string EventId, string Email)
		{
			this.SurveyId = (-1).ToString();
            //         this.QuestionOneAnswer = QuestionOneRating;
            //         this.QuestionTwoAnswer = QuestionTwoRating;
            //         this.QuestionThreeAnswer = QuestionThreeRating;
            //this.QuestionFourAnswer = QuestionFourAnswer;
            this.Question = Question;
            this.Type = Type;
            this.Options = Options;
            this.BoothId = BoothId;
            this.OrderIndex = OrderIndex;
			this.OtherComments = OtherComments;
			this.UserDeviceId = UserDeviceId;
			this.EventId = EventId;
            this.Email = Email;
		}

        public static EventSurvey FromJson(string json)
		{
			System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Model.Utilities.ParseJson(json);

			//dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

			string surveyId = data["survey_id"];
            string question = data["question"];
            string type = data["type"];
            string options = data["options"];
            int boothId = Int32.Parse(data["booth_id"]);
            int orderIndex = Int32.Parse(data["order_index"]);
            //string QuestionOneRating = data["question_one_rating"];
            //string QuestionTwoRating = data["question_one_rating"];
            //string QuestionThreeRating = data["question_one_rating"];
            //string QuestionFourRating = data["question_one_rating"];
            //string QuestionFourAnswer = data["question_four_rating"];
            string otherComments = data["other_comments"];
            string userDeviceId = data["user_device_id"];
            string eventId = data["event_id"];
            string email = data["email"];
            return new EventSurvey(question,type,options,boothId,orderIndex,otherComments,userDeviceId,eventId,email);
		}
    }
}