 using System;
 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class BasicDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            BasicDependencyFactory>
        {
        
        }

        [Subject(typeof(BasicDependencyFactory))]
        public class when_creating_a_dependency : concern
        {

            Establish c = () =>
            {
               sql_connection = new SqlConnection(); 
               provide_a_basic_sut_constructor_argument<Func<object>>(() => sql_connection);
            };

            Because b = () =>
                result = sut.create();


            It should_return_the_item_created_by_its_provided_factory = () =>
                result.ShouldEqual(sql_connection);

            static object result;
            static SqlConnection sql_connection;
        }
    }
}
