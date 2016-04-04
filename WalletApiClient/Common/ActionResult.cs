using System;

namespace WalletApiClient.Common
{
    /// <summary>
    /// Describes the common behaviour for every action execution (e.g. db-call, method-call which assumes some unstable result)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionResult<T> : ActionResultBase
    {
        public virtual T Value { get; set; }

        public ActionResult() { }

        public ActionResult(Status status)
        {
            Status = status;
        }

        public ActionResult(Exception exception)
            : base(exception)
        { }

        public ActionResult(T result)
        {
            Status = Status.StatusSuccess;
            Value = result;
        }

        public ActionResult(Status status, T result)
        {
            Status = status;
            Value = result;
        }
    }
}