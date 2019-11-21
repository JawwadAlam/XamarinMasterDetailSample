namespace MasterDetail.Models
{
    public class Film
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string rt_score { get; set; }
        public string[] people { get; set; }
        public string[] species { get; set; }
        public string[] locations { get; set; }
        public string[] vehicles { get; set; }
        public string url { get; set; }
    }


}
