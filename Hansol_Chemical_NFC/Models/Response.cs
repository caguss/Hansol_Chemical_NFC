using System;

namespace Hansol_Chemical_NFC.Models
{
    public class Response
    {
        public string ResponseName; //결재 제목
        public string Description; //본문
        public DateTime Date; //일자
        public string Requester; //요청자
        public object attach; //첨부

        //결재 제목, 일자, 요청자, 결재리스트, 본문, 첨부를 확인하고 결
    }
}
