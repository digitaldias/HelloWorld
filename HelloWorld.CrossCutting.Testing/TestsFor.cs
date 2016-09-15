using Moq;
using StructureMap.AutoMocking.Moq;

namespace HelloWorld.CrossCutting.Testing
{
    public abstract class TestsFor<TInstance> where TInstance : class
    {
        public MoqAutoMocker<TInstance> AutoMock { get; internal set; }

        public TInstance Instance { get; set; }


        public TestsFor()
        {
            AutoMock = new MoqAutoMocker<TInstance>();

            BeforeInstanceGenerated();

            Instance = AutoMock.ClassUnderTest;
        }


        public Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(AutoMock.Get<TContract>());
        }


        /// <summary>
        /// Call this method whenever you need to modify the IoC Container configuration. 
        /// Use with <see cref=">InjectInstanceOf()"/>
        /// </summary>
        public virtual void BeforeInstanceGenerated(){
        }


        /// <summary>
        /// Inject an instance of TContract into the AutoMock configuration
        /// </summary>
        /// <typeparam name="TContract">The type of contract to inject</typeparam>
        /// <param name="contract">The instance of the TContract to inject</param>
        public void InjectInstanceOf<TContract>(TContract contract) where TContract : class
        {
            AutoMock.Container.Inject<TContract>(contract);
        }
    }
}
