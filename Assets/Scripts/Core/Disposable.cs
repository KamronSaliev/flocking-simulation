using System;

namespace FlockingSimulation.Core
{
    public abstract class Disposable : IDisposable
    {
        protected bool IsDisposed;

        protected void ThrowOnDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public virtual void Dispose()
        {
            ThrowOnDisposed();

            IsDisposed = true;
        }
    }
}