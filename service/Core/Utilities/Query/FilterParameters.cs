using System.Reflection;
using System.Text;

namespace Core.Utilities.Query
{
    public class FilterParameters : IFilterParameters
    {
        public string OrderBy { get; set; }
        public string Filter { get; set; }

        protected string CreateSortWithType(Type type)
        {
            var orderQuery = String.Empty;

            if (string.IsNullOrWhiteSpace(OrderBy))
            {
                orderQuery = "Created";
                return orderQuery;
            }

            var orderRequest = OrderBy.Trim().Split("_");
            var orderParams = orderRequest[0];
            string orderType = String.Empty;
            
            if (orderRequest.Length <= 1)
            {
                orderType = "asc";
            }
            else
            {
                orderType = orderRequest[1];
            }

            if (orderType != "desc" && orderType != "asc")
            {
                orderQuery = "Created";
                return orderQuery;
            }

            var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(orderParams))
            {
                orderQuery = "Created";
                return orderQuery;
            }

            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(orderParams, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
            {
                orderQuery = "Created";
                return orderQuery;
            }

            orderQueryBuilder.Append(objectProperty.Name.ToString());

            orderQuery = orderQueryBuilder.ToString() + " " + orderType;

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                orderQuery = "Created";
                return orderQuery;
            }

            return orderQuery;
        }
    }
}