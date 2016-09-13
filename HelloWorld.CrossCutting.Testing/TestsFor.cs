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


        public void InjectInstanceOf<TContract>(TContract contract) where TContract : class
        {
            AutoMock.Container.Inject<TContract>(contract);
        }


        public Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(AutoMock.Get<TContract>());
        }


        public virtual void BeforeInstanceGenerated()
        {
        }
    }
}
