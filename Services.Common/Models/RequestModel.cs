namespace Services.Common.Models
{
    #region Contract
    public class RequestModel
    {
        public string _token { get; set; }
        public RequestDataModel _data { get; set; }
        public string _sendfrom { get; set; }
    }
    public class RequestDataModel
    {
        public string AgreementNo { get; set; }
    }
    #endregion Contract


    #region FileManagement
    public class RequestFileModel
    {
        public string _token { get; set; }
        public string _sendfrom { get; set; }
        public string _files { get; set; }
    }
    #endregion
}