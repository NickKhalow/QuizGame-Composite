using QuizGame.Timers;

namespace QuizGame.Tests.Timers;

public class SimpleTimerTest
{
    [Fact]
    public async Task Real()
    {
        var timer = new SimpleTimer(TimeSpan.FromSeconds(5));
        await Task.Delay(TimeSpan.FromSeconds(2));
        Assert.False(timer.Over);
        await Task.Delay(TimeSpan.FromSeconds(4));
        Assert.True(timer.Over);
    }

    [Fact]
    public void Over()
    {
        Assert.True(new SimpleTimer(-TimeSpan.FromSeconds(1)).Over);
        Assert.False(new SimpleTimer(TimeSpan.FromSeconds(1)).Over);
    }

    [Fact]
    public void Reward()
    {
        var timer = new SimpleTimer(-TimeSpan.FromSeconds(2));
        timer.RewardTime();
        Assert.False(timer.Over);
    }

    [Fact]
    public void Penalty()
    {
        var timer = new SimpleTimer(TimeSpan.FromSeconds(3));
        timer.PenaltyTime();
        Assert.True(timer.Over);
    }
}