using System;
using System.ComponentModel.Composition;
using Microsoft.TeamFoundation.Controls;

namespace Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer
{
    /// <summary>
    ///     Team Explorer base section class.
    /// </summary>
    [PartNotDiscoverable]
    public abstract class TeamExplorerBaseSection : TeamExplorerBase, ITeamExplorerSection
    {
        private bool _isBusy;
        private bool _isExpanded = true;
        private bool _isVisible = true;
        private object _sectionContent;
        private string _title;

        /// <summary>
        ///     Cancel any currently running operations on this section.
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
        ///     Initialize this section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Initialize(object sender, SectionInitializeEventArgs e)
        {
            ServiceProvider = e.ServiceProvider;
        }

        /// <summary>
        ///     Get the busy state of this section. If the busy state changes, the PropertyChanged event should be raised.
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
        ///     Get the expanded state of this section. If the expanded state changes, the PropertyChanged event should be raised.
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }

            set
            {
                _isExpanded = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Get the visibility of this section. If the visibility changes, the PropertyChanged event should be raised.
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
        ///     Whenever a Section has been loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SectionLoadedEventArgs" /> instance containing the event data.</param>
        public virtual void Loaded(object sender, SectionLoadedEventArgs e)
        {
        }

        /// <summary>
        ///     Refresh this section.
        /// </summary>
        public virtual void Refresh()
        {
        }

        /// <summary>
        ///     The section should save context. This is called before navigation to another page, Team Project context switch, and
        ///     so on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void SaveContext(object sender, SectionSaveContextEventArgs e)
        {
        }

        /// <summary>
        ///     Get the content for this section. If the content changes, the PropertyChanged event should be raised.
        /// </summary>
        public object SectionContent
        {
            get { return _sectionContent; }

            set
            {
                _sectionContent = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Get the title of this section. If the title changes, the PropertyChanged event should be raised.
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