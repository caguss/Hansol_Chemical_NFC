namespace Hansol_Chemical_NFC.Models
{
    public class Item
    {
        private string nfcTag = "";
        public string ID { get; set; }
        public string MaterialName { get; set; }
        public string ChemicalName { get; set; }
        public string NFCTag { get => nfcTag; set => nfcTag = value; }
        public string CASNo { get; set; }
        public string AttachFile { get; set; }


    }
}