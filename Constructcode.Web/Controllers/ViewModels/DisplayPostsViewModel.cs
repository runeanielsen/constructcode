using System.Collections.Generic;

namespace Constructcode.Web.Controllers.ViewModels
{
    public class DisplayPostsViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public int CurrentPageNumber { get; set; }
        public int MaxPageNumber { get; set; }
        public int NextPageNumber { get; set; }
        public int PreviousPageNumber { get; set; }

        public DisplayPostsViewModel(int maxPageNumber, int currentPageNumber)
        {
            MaxPageNumber = maxPageNumber;
            CurrentPageNumber = currentPageNumber;

            NextPageNumber = CurrentPageNumber + 1;
            PreviousPageNumber = CurrentPageNumber - 1;
        }
    }
}
