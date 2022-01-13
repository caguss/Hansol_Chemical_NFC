namespace Hansol_Chemical_NFC.Models
{
    public class Approval
    {
        public string ID { get; set; } // id
        public string Location { get; set; } //위치
        public string Type { get; set; } // 종류
        public string Summary { get; set; } //
        public bool Checked { get; set; }
    }
}