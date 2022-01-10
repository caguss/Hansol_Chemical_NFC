namespace Hansol_Chemical_NFC.Models
{

    /// <summary>
    /// 해당 클래스는 데이터베이스에 따라 변경 될수 있음.
    /// </summary>
    public class User
    {
        private string name;
        private string email;
        private string phone;
        private string phoneNumber;
        private string position;

        public string ID { get; set; }
        public string Password { get; set; }
        public string NowVer { get; set; }
        public string Platform { get; set; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string PhoneNum { get => phoneNumber; set => phoneNumber = value; }
        public string Position { get => position; set => position = value; }
    }
}
