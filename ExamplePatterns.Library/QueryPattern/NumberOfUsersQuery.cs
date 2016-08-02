using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePatterns.Library.QueryPattern
{
    public class NumberOfUsersQuery : IQuery<int>
    {
    }

    public class NumberOfUsersQueryHandler : IQueryHandler<NumberOfUsersQuery, int>
    {
        //Encapsulates the functionality of the query
        public int Handle(NumberOfUsersQuery query)
        {
            return 10;
        }
    }
}
