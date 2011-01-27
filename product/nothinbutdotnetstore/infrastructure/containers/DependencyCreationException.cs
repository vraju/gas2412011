using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DependencyCreationException : Exception
    {
        string message;
        public Type type_that_could_not_be_created_correctly { get; private set; }
        public DependencyCreationException(Type dependency,Exception inner,String message):base(message,inner)
        {
            type_that_could_not_be_created_correctly = dependency;
        }
        
    }
}