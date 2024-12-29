using NetArchTestDemo.Services;

namespace NetArchTestDemo.Controllers
{
    public class ExampleController
    {
        private readonly ExampleService _service;
        
        public ExampleController(ExampleService service)
        {

            _service = service;
        
        }

    }
}
