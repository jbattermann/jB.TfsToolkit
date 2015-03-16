using System;
using System.ComponentModel.Composition;
using Microsoft.TeamFoundation.Controls;

namespace Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer
{
    /// <summary>
    ///     Team Explorer page base class.
    /// </summary>
    [PartNotDiscoverable]
    public abstract class TeamExplorerBasePage : TeamExplorerBase, ITeamExplorerPage
    {
        private bool _isBusy;
        private object _pageContent;
        private string _title;

        /// <summary>
        ///     Cancel any currently running operations on this page.
        /// </summary>
        public virtual void Cancel()
        {
        }

        /// <summary>
        ///     Get the requested extensibility service for this page.
        /// </summary>
        /// <param name="serviceType">Service type</param>
        /// <returns>
        ///     The service instance if found, null otherwise.
        /// </returns>
        public virtual object GetExtensibilityService(Type serviceType)
        {
            return null;
        }

        /// <summary>
        ///     Initialize this page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Initialize(object sender, PageInitializeEventArgs e)
        {
            ServiceProvider = e.ServiceProvider;
        }

        /// <summary>
        ///     Get the busy state of this page. If the busy state changes, the PropertyChanged event should be raised.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }

            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The page and all sections have been created and initialized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Loaded(object sender, PageLoadedEventArgs e)
        {
        }

        /// <summary>
        ///     Get the content for this page. If the content changes, the PropertyChanged event should be raised.
        /// </summary>
        public object PageContent
        {
            get { return _pageContent; }

            set
            {
                _pageContent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Refresh this page.
        /// </summary>
        public virtual void Refresh()
        {
        }

        /// <summary>
        ///     The page should save context. This is called before navigation to another page, Team Project context switch, and so
        ///     on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void SaveContext(object sender, PageSaveContextEventArgs e)
        {
        }

        /// <summary>
        ///     Get the title of this page. If the title changes, the PropertyChanged event should be raised.
        /// </summary>
        public string Title
        {
            get { return _title; }

            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
    }
}