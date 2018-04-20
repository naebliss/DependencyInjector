namespace DependencyInjector
{
    class Foo : IFoo
    {
        private readonly IBar _bar;

        public Foo(IBar bar)
        {
            _bar = bar;
        }

        public IBar GetBar()
        {
            return _bar;
        }
    }
}