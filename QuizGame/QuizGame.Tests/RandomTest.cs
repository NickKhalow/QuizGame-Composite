using Xunit.Abstractions;

namespace QuizGame.Tests;

public class RandomTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public RandomTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }
    
    // 534011718
    // 237820880
    // 1002897798
    // 1657007234
    // 1412011072
    // 929393559
    // 760389092
    // 2026928803
    // 217468053

    [Fact]
    public void Random()
    {
        var random = new Random(int.MaxValue);

        for (int i = 0; i < 100; i++)
        {
            testOutputHelper.WriteLine(random.Next().ToString());
        }
    }
}