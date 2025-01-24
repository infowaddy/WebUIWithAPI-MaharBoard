namespace MB.Model
{
    public class Mahaboard
    {
        /// <summary>
        /// Birthdate shall be in UTC format with ISO 8601 standard.
        /// E.g. yyyy-MM-ddTHH:mm:ssZ
        /// </summary>
        public DateOnly BirthDate { get; set; }
        /// <summary>
        /// BirthDay is the Person birth day such as Monday, Tuesday, Wednesday and so on.
        /// </summary>
        public string BirthDay { get; set; } = "မွေးရက်";
        /// <summary>
        /// MahaboardName is the name of Maharboard Result such as Adipadi, Raza, Puti and so on.
        /// </summary>
        public string MahaboardName { get; set; } = "အဖွားအမည်";
        /// <summary>
        /// MahaboardResult is the result of Mahaboard.
        /// </summary>
        string MahaboardResult { get; set; } = "မဟာဘုတ် အဟော";
        /// <summary>
        /// Gender of the Person.
        /// </summary>
        string Gender { get; set; } = "ယောက်ျား/မိန်းမ";
    }
}
