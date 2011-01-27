using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public static class Execute<ReturnType>
    {
        public delegate ReturnType BlockOfCode();
        public delegate void NonValueReturningBlockOfCode();
        public delegate Exception ExceptionFactory(Exception ex);


        public static void run(NonValueReturningBlockOfCode block_of_code, 
            ExceptionFactory exception_factory)
        {
            try
            {
                block_of_code();
            }
            catch (Exception ex)
            {
                throw exception_factory(ex);
            }
        }

        public static ReturnType run(BlockOfCode t_block_of_code, 
            ExceptionFactory exception_factory)
        {
            ReturnType return_value = default(ReturnType);

            //TODO - I want to understand this
            run(() =>
            {
                return_value = t_block_of_code();
            },exception_factory);

            return return_value;

        }
    }

}