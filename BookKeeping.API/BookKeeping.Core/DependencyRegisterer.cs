using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping.Core
{
    public interface DependencyRegisterer
    {
        //void Register(ContainerBuilder builder, ITypeFinder typeFinder, AsthaITCommerceConfig config, MongoSettingsConfig mongoSettingsConfig);

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        int Order { get; }
    }
}
