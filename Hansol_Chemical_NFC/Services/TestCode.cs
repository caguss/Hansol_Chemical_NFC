using System.Collections.Generic;
namespace Hansol_Chemical_NFC.TestCode
{
    public class TestCode_Login
    {

        readonly string AuthId = "admin";
        readonly string AuthPw = "1";
        string AuthOtpNumber = "123456";
        string TwoFAToken = "";
        /// <summary>
        /// 아이디 비밀번호 입력 인증 테스트코드.
        /// </summary>
        /// <param name="id">기본 : admin</param>
        /// <param name="pw">기본 : 1</param>
        /// <returns>id와 pw가 모두 올바르면 true</returns>
        public bool OneFA(string id, string pw)
        {
            return id == AuthId && pw == AuthPw;
        }
        /// <summary>
        /// 2차 로그인 인증키를 입력
        /// </summary>
        /// <param name="otpNumber">123456</param>
        /// <returns></returns>
        public bool TryAuth_2FA(string otpNumber)
        {
            // OTP 자리수는 6자리이다.
            if (otpNumber.Length != 6) return false;

            return otpNumber == AuthOtpNumber;
        }
        public void Send2FAOTPNumber(string userToken, int sendType)
        {
            // DB에 userToken 날리고 인증키 생성후 반환받기
            AuthOtpNumber = Get2FAOTP(userToken);

            // 2FA Library를 활용하여 SMS 혹은 Email을 보내여야함.
            switch (sendType) // sendType이 아닌 Regex를 이용하여 이메일인지, 핸드폰인지 판단할 수 있지만 클라이언트단에서 그건 미리 판단해서 타입으로 보내는거도 괜찮을듯
            {
                case 1:
                    // 이메일로 보내기
                    break;
                case 2:
                    // 휴대폰으로 보내기
                    break;
            }


        }
        public string Get2FAOTP(string userToken)
        {
            return "135790";
        }
    }
    public class TestCode_NFCRegister
    {
        public class NFCEntity
        {
            public int DBSequence { get; set; }
            public string NfcTagName { get; set; }
            public string NfcTagCode { get; set; }
            public char UseYN { get; set; }
        }
        Dictionary<int, NFCEntity> nfcList = new Dictionary<int, NFCEntity>();
        Dictionary<int, NFCEntity> nfcList2 = new Dictionary<int, NFCEntity>();
        /// <summary>
        /// NFC 태그 생성기. 기존 List는 초기화한다.
        /// </summary>
        /// <param name="howMany">생성할 갯수</param>
        /// <returns></returns>
        public Dictionary<int, NFCEntity> GetNFCEntities(int howMany)
        {
            nfcList.Clear();
            for (int i = 0; i < howMany; i++)
            {
                nfcList.Add(i, new NFCEntity()
                {
                    DBSequence = i,
                    NfcTagName = $"태그{i}",
                    NfcTagCode = $"TAG{i}",
                    UseYN = 'Y'
                });
            }

            return nfcList; //
        }
        /// <summary>
        /// 특정 태그의 사용유무를 업데이트한다.
        /// </summary>
        /// <param name="_pDBSeq"></param>
        /// <param name="_pUseYN"></param>
        /// <returns></returns>
        public NFCEntity updateNFCEntity(int _pDBSeq, char _pUseYN) //
        {
            // DB 업데이트

            // DB 재조회

            // 이전값이랑 같으면 or DB처리 안되었으면 Exception 처리
            // 잘 바뀌었으면 재조회한 값 return
            return null;
        }
    }


}
