using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.DomainModel
{
    public class ButtonClicksCounter
    {
        [Key]
        public int Id { get; set; }
        public int Clicks { get; set; }

    }
}
