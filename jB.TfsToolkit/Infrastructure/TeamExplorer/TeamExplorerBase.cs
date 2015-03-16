using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Joerg.Battermann.TfsToolkit.ExtensionMethods;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Controls;

namespace Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer
{
    /// <summary>
    ///     Team Explorer extension common base class.
    /// </summary>
    [PartNotDiscoverable]
    public abstract class TeamExplorerBase : INotifyPropertyChanged, IDisposable
    {
        private long _isDisposed;
        private long _isDisposing;

        /// <summary>
        /// Backing field for <see cref="ServiceProvider" />
        /// </summary>
        private IServiceProvider _serviceProvider;

        private Lazy<ITeamExplorer> _teamExplorer;
        private Lazy<ITeamFoundationContextManager> _teamFoundationContextManager;

        /// <summary>
        ///     Gets the current context.
        /// </summary>
        /// <value>
        ///     The current context.
        /// </value>
        protected ITeamFoundationContext CurrentTeamFoundationContext
        {
            get { return TeamFoundationContextManager != null ? TeamFoundationContextManager.CurrentContext : null; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        protected bool IsDisposed
        {
            get { return Interlocked.Read(ref _isDisposed) == 1; }
            set { Interlocked.Exchange(ref _isDisposed, value ? 1 : 0); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is disposing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is disposing; otherwise, <c>false</c>.
        /// </value>
        protected bool IsDisposing
        {
            get { return Interlocked.Read(ref _isDisposing) == 1; }
            set { Interlocked.Exchange(ref _isDisposing, value ? 1 : 0); }
        }

        /// <summary>
        ///     Get/set the service provider.
        /// </summary>
        public IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
            set
            {
                // Unsubscribe from Team Foundation context changes
                if (_serviceProvider != null && TeamFoundationContextManager != null)
                {
                    TeamFoundationContextManager.ContextChanged -= OnContextChanged;
                }

                _serviceProvider = value;

                _teamExplorer = new Lazy<ITeamExplorer>(() => ServiceProvider != null ? ServiceProvider.TryGetService<ITeamExplorer>() : null);
                _teamFoundationContextManager = new Lazy<ITeamFoundationContextManager>(() => ServiceProvider != null ? ServiceProvider.TryGetService<ITeamFoundationContextManager>() : null);

                RaisePropertyChanged("TeamExplorer");
                RaisePropertyChanged("TeamFoundationContextManager");
                RaisePropertyChanged("CurrentTeamFoundationContext");

                // Subscribe to Team Foundation context changes
                if (_serviceProvider != null && TeamFoundationContextManager != null)
                {
                    TeamFoundationContextManager.ContextChanged += OnContextChanged;
                }

                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the team explorer.
        /// </summary>
        /// <value>
        ///     The team explorer.
        /// </value>
        protected ITeamExplorer TeamExplorer
        {
            get { return _teamExplorer.Value; }
        }

        /// <summary>
        ///     Gets the current team foundation context manager.
        /// </summary>
        /// <value>
        ///     The current team foundation context manager.
        /// </value>
        protected ITeamFoundationContextManager TeamFoundationContextManager
        {
            get { return _teamFoundationContextManager.Value; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TeamExplorerBase" /> class.
        /// </summary>
        protected TeamExplorerBase()
        {
            _teamExplorer = new Lazy<ITeamExplorer>(() => ServiceProvider != null ? ServiceProvider.TryGetService<ITeamExplorer>() : null);
            _teamFoundationContextManager = new Lazy<ITeamFoundationContextManager>(() => ServiceProvider != null ? ServiceProvider.TryGetService<ITeamFoundationContextManager>() : null);
        }
        
        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when the <see cref="TeamFoundationContext"/> changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ContextChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnContextChanged(object sender, ContextChangedEventArgs e)
        {
        }

        /// <summary>
        ///     Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        ///     Shows the notification <see cref="message" /> inside the <see cref="TeamExplorer" />.
        /// </summary>
        /// <param name="message">The message text to display for the notification.</param>
        /// <param name="notificationType">This indicates what kind of icon the notification will get.</param>
        /// <param name="notificationFlags">These flags indicate the behavior of the notification.</param>
        /// <param name="command">
        ///     This allows the owning page/object to be called back for all embedding links instead of allowing
        ///     the default handler to attempt to handle them.
        /// </param>
        /// <returns></returns>
        protected Guid ShowNotification(string message, NotificationType notificationType = NotificationType.Information, NotificationFlags notificationFlags = NotificationFlags.None, ICommand command = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                return Guid.Empty;

            if (TeamExplorer != null)
            {
                var notificationId = Guid.NewGuid();
                TeamExplorer.ShowNotification(message, notificationType, notificationFlags, command, notificationId);
                return notificationId;
            }

            return Guid.Empty;
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            
        }

        #endregion
    }
}