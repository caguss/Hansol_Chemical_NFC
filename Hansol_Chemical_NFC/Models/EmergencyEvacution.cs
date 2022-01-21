﻿namespace Hansol_Chemical_NFC.Models
{
    public class EmergencyEvacution
    {

        public string Name { get; set; }
        public string Image { get; set; }
        private string nfcTag = "";
        public string ID { get; set; }
        public string MaterialName { get; set; }
        public string ChemicalName { get; set; }
        public string NFCTag { get => nfcTag; set => nfcTag = value; }
        public string CASNo { get; set; }
    }
}
