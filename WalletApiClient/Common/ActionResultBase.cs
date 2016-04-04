using System;

namespace WalletApiClient.Common
{
    /// <summary>
    /// Describes the common behaviour for every action execution (e.g. db-call, method-call which assumes some unstable result)
    /// </summary>
    public class ActionResultBase
    {
        public bool Success
        {
            get
            {
                return Status != null && Status.Code >= 0;
            }
        }

        public Status Status { get; set; }

        protected ActionResultBase() { }

        protected ActionResultBase(Exception exception)
        {
            Status = new Status(exception);
        }
    }
}