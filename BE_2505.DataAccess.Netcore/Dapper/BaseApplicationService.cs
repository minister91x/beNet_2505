using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.Dapper
{

    public abstract class BaseApplicationService
    {
        public BaseApplicationService(IServiceProvider serviceProvider)
        {
            DbConnection = serviceProvider.GetRequiredService<IApplicationDbConnection>(); ;
        }

        protected IApplicationDbConnection DbConnection { get; }
    }


}
