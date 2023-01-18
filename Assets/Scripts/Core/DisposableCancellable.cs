using System.Threading;

namespace FlockingSimulation.Core
{
    public abstract class DisposableCancellable : Disposable
    {
        protected CancellationToken CancellationToken => _cancellation.Token;

        private readonly CancellationTokenSource _cancellation;

        protected DisposableCancellable()
        {
            _cancellation = new CancellationTokenSource();
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _cancellation.Cancel();
            _cancellation.Dispose();
        }
    }
}