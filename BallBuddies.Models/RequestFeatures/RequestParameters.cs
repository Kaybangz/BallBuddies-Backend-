

using Microsoft.IdentityModel.Tokens;

namespace BallBuddies.Models.RequestFeatures
{
    public abstract class RequestParameters
    {
        //Restrict our API to a maximum of 50 rows per page
        const int maxPageSize = 50;

        //Default value if not set by the caller
        public int PageNumber { get; set; } = 1;

        //Default value if not set by the caller
        private int _pageSize = 10;

        public int PageSize {
            get 
            {
                return _pageSize;
            }
            set {
                _pageSize = value; 
            } 
        }
    }
}
