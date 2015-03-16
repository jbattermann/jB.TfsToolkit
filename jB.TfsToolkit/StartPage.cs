using Joerg.Battermann.TfsToolkit.Infrastructure.TeamExplorer;
using Microsoft.TeamFoundation.Controls;

namespace Joerg.Battermann.TfsToolkit
{
    [TeamExplorerPage(PageId)]
    public class StartPage : TeamExplorerBasePage
    {
        public const string PageTitle = "jB Tfs Toolkit";
        public const string PageId = "2301D914-9AB0-420F-BE49-B162C9EA3714";

        /// <summary>
        /// Initializes a new instance of the <see cref="StartPage"/> class.
        /// </summary>
        public StartPage()
        {
            this.Title = PageTitle;
        }
    }
}
