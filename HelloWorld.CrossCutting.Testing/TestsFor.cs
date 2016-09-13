using Moq;
using StructureMap.AutoMocking.Moq;

namespace HelloWorld.CrossCutting.Testing
{
    public class TestsFor<TInstance> where TInstance : class
    {
        public MoqAutoMocker<TInstance> AutoMock { get; internal set; }

        public TInstance Instance { get; set; }


        public TestsFor()
        {
            AutoMock = new MoqAutoMocker<TInstance>();

            Instance = AutoMock.ClassUnderTest;
        }


        public Mock<TContract> GetMockFor<TContract>() where TContract : class
        {
            return Mock.Get(AutoMock.Get<TContract>());
        }
    }
}
