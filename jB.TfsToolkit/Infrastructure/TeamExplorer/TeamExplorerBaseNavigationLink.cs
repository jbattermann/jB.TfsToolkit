using System;
using System.ComponentModel.Composition;
using Microsoft.TeamFoundation.Controls;

namespace Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer
{
    /// <summary>
    ///     Team Explorer base navigation link class.
    /// </summary>
    [PartNotDiscoverable]
    public abstract class TeamExplorerBaseNavigationLink : TeamExplorerBase, ITeamExplorerNavigationLink
    {
        private bool _isEnabled = true;
        private bool _isVisible = true;
        private string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamExplorerBaseNavigationLink"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected TeamExplorerBaseNavigationLink(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Execute this link.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Invalidate the state of this item.
        /// </summary>
        public virtual void Invalidate()
        {
        }

        /// <summary>
        /// Get the enabled state of this link. If the state changes, the PropertyChanged event should be raised.
        /// </summary>
        public bool IsEnabled
        {
            get { return _isEnabled; }

            set
            {
                _isEnabled = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Get the visibility of this link. If the visibility changes, the PropertyChanged event should be raised.
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }

            set
            {
                _isVisible = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Get the text of this link. If the text changes, the PropertyChanged event should be raised.
        /// </summary>
        public string Text
        {
            get { return _text; }

            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }
    }
}