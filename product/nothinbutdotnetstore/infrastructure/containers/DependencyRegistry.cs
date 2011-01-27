namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface DependencyRegistry
    {
        DependencyFactory lookup<DependencyContract>();
    }
}