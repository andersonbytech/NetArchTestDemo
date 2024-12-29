using NetArchTestDemo.Repositories;


namespace NetArchTestDemo.Services
{
    public class ExampleService
    {

        private readonly ExampleRepository _repository;
        public ExampleService(ExampleRepository repository)
        {
            _repository = repository;
        }

    }
}
