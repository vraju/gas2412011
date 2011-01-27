using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public static class TryCatcher<ReturnType>
    {
        public delegate ReturnType TryBlock();
        public delegate Exception CatchBlock(Exception ex);
        public static ReturnType execute(TryBlock t_block, CatchBlock t_catch)
        {
            try
            {
                return t_block();
            }
            catch (Exception ex)
            {
                throw t_catch(ex);
            }
        }
    }

    /*
            TryCatcher<Dependency>.execute(dependency, new MissingDependencyFactoryException(dependency, ex))
            try
            {
                return factories[dependency];
            }
            catch (KeyNotFoundException ex)
            {
                throw new MissingDependencyFactoryException(dependency, ex);
            } */
}
