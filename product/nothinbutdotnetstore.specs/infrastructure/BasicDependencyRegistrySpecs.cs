using System;
using System.Collections.Generic;
using System.Data;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class BasicDependencyRegistrySpecs
    {
        public abstract class concern : Observes<DependencyRegistry, BasicDependencyRegistry>
        {
            Establish c = () =>
            {
                all_factories = new Dictionary<Type, DependencyFactory>();
                all_factories.Add(typeof(int), an<DependencyFactory>());
                all_factories.Add(typeof(IDbConnection), an<DependencyFactory>());
                provide_a_basic_sut_constructor_argument(all_factories);
            };

            protected static IDictionary<Type, DependencyFactory> all_factories;
        }

        //get_the_factory_for
        [Subject(typeof(BasicDependencyRegistry))]
        public class when_getting_a_factory_for_a_dependency_and_it_has_the_factory : concern
        {
            Establish c = () =>
            {
                expected_factory = an<DependencyFactory>();
                all_factories.Add(typeof(IFakeDependency), expected_factory);
            };

            Because b = () =>
                result = sut.get_the_factory_for(typeof(IFakeDependency));


            It should_Return_that_contract_factory = () => 
                result.ShouldEqual(expected_factory);

            static DependencyFactory result;
            static DependencyFactory expected_factory;
        }

        public class when_attempting_to_get_a_factory_and_there_is_no_factory : concern
        {
            Because b = () =>
                catch_exception(() => sut.get_the_factory_for(typeof(IFakeDependency)));

            It should_throw_a_missing_dependency_factory_exception_with_the_correct_information = () =>
            {
                var thrown = exception_thrown_by_the_sut.ShouldBeAn<MissingDependencyFactoryException>();
                thrown.type_that_has_not_factory_to_create_it.ShouldEqual(typeof(IFakeDependency));
            };
        }
    }

    interface IFakeDependency
    {
    }
}