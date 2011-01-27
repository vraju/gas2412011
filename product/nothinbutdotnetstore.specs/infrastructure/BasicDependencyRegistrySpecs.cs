using System;
using System.Linq;
using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
using System.Collections.Generic;

namespace nothinbutdotnetstore.specs.infrastructure
{   
	public class BasicDependencyRegistrySpecs
	{
		public abstract class concern : Observes<DependencyRegistry,BasicDependencyRegistry>
		{
        
		}


		//get_the_factory_for
		[Subject(typeof(BasicDependencyRegistry))]
		public class when_gettng_a_factory_for_a_dependency_contract : concern
		{
			Establish c = () =>
			{
				
				what_the_Result_should_equal = an<DependencyFactory>();
				all_factories = Enumerable.Range(1, 10).Select(x => an<DependencyFactory>()).ToList();

				provide_a_basic_sut_constructor_argument<IEnumerable<DependencyFactory>>(all_factories);
			};

			Because b = () =>
			{
				result = sut.get_the_factory_for<IFakeDependency>();
			};

			
			It should_Return_that_contract_factory = () =>
			{
				result.ShouldEqual(what_the_Result_should_equal);
			};

			static DependencyFactory result;
			static List<DependencyFactory> all_factories;
			static DependencyFactory what_the_Result_should_equal;
		}
	}

	
	class fakedependencyfactory : DependencyFactory
	{
		public object create()
		{
			throw new NotImplementedException();
		}
	}

	interface IFakeDependency
	{
	}


}
