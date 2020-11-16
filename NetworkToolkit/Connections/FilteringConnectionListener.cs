﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkToolkit.Connections
{
    /// <summary>
    /// A connection listener that filters another connection.
    /// </summary>
    public abstract class FilteringConnectionListener : ConnectionListener
    {
        /// <summary>
        /// The base connection listener.
        /// </summary>
        protected ConnectionListener BaseListener { get; }

        /// <inheritdoc/>
        public override EndPoint? EndPoint => BaseListener.EndPoint;

        /// <summary>
        /// Instantiates a new <see cref="FilteringConnectionListener"/>.
        /// </summary>
        /// <param name="baseListener">The base connection listener for the <see cref="FilteringConnectionListener"/>.</param>
        public FilteringConnectionListener(ConnectionListener baseListener)
        {
            BaseListener = baseListener ?? throw new ArgumentNullException(nameof(baseListener));
        }

        /// <inheritdoc/>
        protected override ValueTask DisposeAsyncCore(CancellationToken cancellationToken)
            => BaseListener.DisposeAsync(cancellationToken);
    }
}
