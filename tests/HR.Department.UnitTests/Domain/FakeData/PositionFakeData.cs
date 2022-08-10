using Bogus;

namespace HR.Department.UnitTests.Domain.FakeData
{
    public class PositionFakeData
    {
        public PositionFakeData(int seed) =>
            Valid = Valid.UseSeed(seed);

        public Faker<Core.Entities.Position> Valid { get; }
            = new Faker<Core.Entities.Position>()
                .CustomInstantiator(f => new Core.Entities.Position(f.Lorem.Sentence(1, 3)));
    }
}
