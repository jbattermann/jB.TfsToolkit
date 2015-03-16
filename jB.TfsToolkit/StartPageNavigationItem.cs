using System;
using System.ComponentModel.Composition;
using Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer;
using Microsoft.TeamFoundation.Controls;
using Microsoft.VisualStudio.Shell;

namespace Joerg.Battermann.TfsToolkit
{
    [TeamExplorerNavigationItem(ItemId, 1000)]
    public class StartPageNavigationItem : TeamExplorerBaseNavigationItem
    {
        public const string ItemId = "68512897-D53B-4B77-A95A-44C748127349";

        /// <summary>
        /// Initializes a new instance of the <see cref="StartPageNavigationItem"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        [ImportingConstructor]
        public StartPageNavigationItem([Import(typeof(SVsServiceProvider))] IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Text = StartPage.PageTitle;
            Image = Resources.PickAxe_32xMD;
            IsVisible = true;
        }

        #region Overrides of TeamExplorerBaseNavigationLink

        /// <summary>
        /// Execute this link.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }

        public override void Invalidate()
        {
            base.Invalidate();
            this.IsVisible = true;
        }
        #endregion
    }
}