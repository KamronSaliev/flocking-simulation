using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using FlockingSimulation.Views;

namespace FlockingSimulation.Extensions
{
    public static class UniTaskExtensions
    {
        public static IDisposable SubscribeAwait(this IUniTaskAsyncEnumerable<AsyncUnit> enumerable,
            Func<CancellationToken, UniTask> func)
        {
            return enumerable.SubscribeAwait((unit, cancellationToken) =>
                func(cancellationToken));
        }

        public static void SubscribeAwait(this IUniTaskAsyncEnumerable<AsyncUnit> enumerable,
            Func<CancellationToken, UniTask> func, CancellationToken token)
        {
            enumerable.SubscribeAwait((unit, cancellationToken) => func(cancellationToken), token);
        }

        public static IUniTaskAsyncEnumerable<AsyncUnit> OnClickAsAsyncEnumerable(this ButtonView button,
            CancellationToken cancellationToken)
        {
            return new UnityEventHandlerAsyncEnumerable(button.PointerClicked, cancellationToken);
        }
    }
}