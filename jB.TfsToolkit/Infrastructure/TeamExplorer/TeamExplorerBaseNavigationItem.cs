using System;
using System.ComponentModel.Composition;
using System.Drawing;
using Microsoft.TeamFoundation.Controls;

namespace Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer
{
    /// <summary>
    ///     Team Explorer base navigation item class.
    /// </summary>
    [PartNotDiscoverable]
    public abstract class TeamExplorerBaseNavigationItem : TeamExplorerBase, ITeamExplorerNavigationItem
    {
        private Image _image;
        private bool _isVisible = true;
        private string _text;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TeamExplorerBaseNavigationItem" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected TeamExplorerBaseNavigationItem(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        ///     Execute this item.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        ///     Get the image to be shown for this item. This should be a 16x16 image.
        /// </summary>
        public Image Image
        {
            get { return _image; }

            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Invalidate the state of this item.
        /// </summary>
        public virtual void Invalidate()
        {
        }

        /// <summary>
        ///     Get the visibility of this item. If the visibility changes, the PropertyChanged event should be raised.
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
        ///     Get the text of this item. If the text changes, the PropertyChanged event should be raised.
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