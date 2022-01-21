namespace Hansol_Chemical_NFC.Models
{
    public class Approval
    {
        public string ID { get; set; } // id
        public string ApprovalName { get; set; }
        public string Requester { get; set; }
        public string Attach { get; set; }
        public string Type { get; set; } // 종류
        public string Summary { get; set; }
    }
}