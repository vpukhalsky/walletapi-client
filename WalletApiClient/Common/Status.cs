using System;

namespace WalletApiClient.Common
{
    [Serializable]
    public class Status
    {
        #region Constants

        public const int CODE_OK = 0;
        public const string MESSAGE_OK = "OK";

        public const int CODE_ERROR = -1;
        public const string MESSAGE_ERROR = "ERROR";

        #endregion

        #region Fields

        private static readonly Status _success;
        private static readonly Status _error;

        #endregion

        #region Properties

        public static Status StatusSuccess
        {
            get { return _success; }
        }

        public static Status StatusError
        {
            get { return _error; }
        }

        public int Code { get; set; }
        public string Message { get; set; }

        #endregion

        #region .ctor

        static Status()
        {
            _success = new Status { Code = CODE_OK, Message = MESSAGE_OK };
            _error = new Status { Code = CODE_ERROR, Message = MESSAGE_ERROR };
        }

        public Status() { }

        public Status(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public Status(Exception exception)
        {
            Code = CODE_ERROR;
            Message = exception.Message;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("Code: {0}; Message: {1}", Code, Message);
        }
    }
}