using System.ComponentModel.DataAnnotations;

namespace iTechArt.SurveysSite.Repositories
{
    public sealed class ButtonClicksCounter
    {
        [Key]
        public int Id { get; set; }
        public int Clicks { get; set; }

    }
}