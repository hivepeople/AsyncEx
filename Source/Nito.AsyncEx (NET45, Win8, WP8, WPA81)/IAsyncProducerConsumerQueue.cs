using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Nito.AsyncEx
{
    /// <summary>
    /// An async-compatible producer/consumer queue.
    /// </summary>
    /// <typeparam name="T">The type of elements contained in the queue.</typeparam>
    public interface IAsyncProducerConsumerQueue<T>
    {
        #region Enqueue
        void Enqueue(T item);
        void Enqueue(T item, CancellationToken cancellationToken);

        Task EnqueueAsync(T item);
        Task EnqueueAsync(T item, CancellationToken cancellationToken);

        bool TryEnqueue(T item);
        bool TryEnqueue(T item, CancellationToken cancellationToken);

        Task<bool> TryEnqueueAsync(T item);
        Task<bool> TryEnqueueAsync(T item, CancellationToken cancellationToken);
        #endregion Enqueue

        #region Dequeue
        T Dequeue();
        T Dequeue(CancellationToken cancellationToken);

        Task<T> DequeueAsync();
        Task<T> DequeueAsync(CancellationToken cancellationToken);

        AsyncProducerConsumerQueue<T>.DequeueResult TryDequeue();
        AsyncProducerConsumerQueue<T>.DequeueResult TryDequeue(CancellationToken cancellationToken);

        Task<AsyncProducerConsumerQueue<T>.DequeueResult> TryDequeueAsync();
        Task<AsyncProducerConsumerQueue<T>.DequeueResult> TryDequeueAsync(CancellationToken cancellationToken);
        #endregion Dequeue

        #region CompleteAdding
        void CompleteAdding();
        Task CompleteAddingAsync();
        bool IsAddingCompleted { get; }
        bool IsCompleted { get; }
        #endregion CompleteAdding

        #region GetConsumingEnumerable
        IEnumerable<T> GetConsumingEnumerable();
        IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken);
        #endregion GetConsumingEnumerable

        #region OutputAvailable
        Task<bool> OutputAvailableAsync();
        Task<bool> OutputAvailableAsync(CancellationToken cancellationToken);
        #endregion OutputAvailable
    }
}
