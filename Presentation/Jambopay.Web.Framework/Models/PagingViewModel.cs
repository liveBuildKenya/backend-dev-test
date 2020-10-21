namespace Jambopay.Web.Framework.Models
{

    public class PagingViewModel
    {
        /// <summary>
        /// Gets or set sthe page number
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public int PageSize { get; set; } = 3;
    }
}
