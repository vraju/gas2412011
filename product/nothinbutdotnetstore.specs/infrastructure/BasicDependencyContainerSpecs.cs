 using System;
 using System.Data;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class BasicDependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {
        
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_fetching_a_dependency : concern
        {
            Establish e = () =>
            {
                dependency_registry = the_dependency<DependencyRegistry>();
                factory = an<DependencyFactory>();
                dependency_registry.Stub(x => x.lookup<IDummy>()).Return(factory);
                dependency = new Dummy();
                factory.Stub(x => x.create()).Return(dependency);

            };

            Because b = () =>
                result = sut.a<IDummy>();
                

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(dependency);

            static IDummy result,expected;
            static DependencyRegistry dependency_registry;
            static IDummy dependency;
            static DependencyFactory factory;
        }

        public class when_the_factory_for_a_dependency_throws_an_exception : concern
        {
            Establish e = () =>
            {
                dependency_registry = the_dependency<DependencyRegistry>();
                an_exception = new Exception();
                factory = an<DependencyFactory>();
                dependency_registry.Stub(x => x.lookup<IDummy>()).Return(factory);
                factory.Stub(x => x.create()).Throw(an_exception);

            };

            Because b = () =>
                catch_exception(() => sut.a<IDummy>());

            It should_throw_a_dependency_creation_exception_with_the_correct_information = () =>
            {
                var exception_thrown = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                exception_thrown.InnerException.ShouldEqual(an_exception);
                exception_thrown.type_that_could_not_be_created_correctly.ShouldEqual(typeof(IDummy));
            };

            static IDummy result,expected;
            static DependencyRegistry dependency_registry;
            static IDummy dependency;
            static DependencyFactory factory;
            static Exception an_exception;
        }
    }

    interface IDummy
    {

    }

    public class Dummy:IDummy
    {
          

    }

    public class FailDummy : IDummy
    {
        public IDbConnection connection { get; set; }
        public FailDummy(IDbConnection connection)
        {
           this.connection = connection; 
        }

    }
}
