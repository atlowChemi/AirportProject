namespace Common.Interfaces
{
    /// <summary>
    /// service that notifies When changes happen.
    /// </summary>
    public interface INotifier : IFutureFlightNotifier
    {
        void Notify();
    }
}
