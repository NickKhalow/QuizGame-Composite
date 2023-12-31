using QuizGame.Results;
using QuizGame.Timers;
using Xunit.Abstractions;

namespace QuizGame.Tests;

public class SimpleQuizTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SimpleQuizTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private (string question, string answer, IReadOnlyList<string> fakes) Bundle()
    {
        return (
            "Who is main actor in Indiana Johns?",
            "Harrison Ford",
            new[]
            {
                "Chirstian Beil",
                "Mark H"
            }
        );
    }

    [Fact]
    public void Fact()
    {
        var bundle = Bundle();
        var quiz = new ShuffledQuiz(
            new SimpleQuiz(bundle)
        );
        Assert.IsType<AnswerResult.Correct>(quiz.Answer("HARRISON FORD"));
        Assert.IsNotType<AnswerResult.Correct>(quiz.Answer("Chirstian Beil"));
        Assert.IsNotType<AnswerResult.Correct>(quiz.Answer("Mark H"));
        Assert.IsNotType<AnswerResult.Correct>(quiz.Answer("Some Garbage"));
        Assert.IsType<AnswerResult.Correct>(quiz.Answer("harrison forD"));
        Assert.IsType<AnswerResult.Correct>(quiz.Answer(bundle.answer));
        _testOutputHelper.WriteLine(string.Join("\n", quiz.Answers));
    }

    [Fact]
    public async Task Timer()
    {
        var bundle = Bundle();
        var quiz = new TimerQuiz(
            new SimpleQuiz(bundle),
            new SimpleTimer(
                TimeSpan.Zero,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1)
            )
        );
        Assert.True(quiz.Answer(bundle.answer).IsCorrect());
        await Task.Delay(TimeSpan.FromSeconds(1.5));
        Assert.False(quiz.Answer(bundle.answer).IsCorrect());
    }

    [Fact]
    public void Attempts()
    {
        var attempts = 5;
        var bundle = Bundle();
        var quiz = new AttemptsQuiz(new SimpleQuiz(bundle), attempts);
        Assert.True(quiz.Answer(bundle.answer).IsCorrect());
        for (int i = 0; i < attempts; i++)
        {
            quiz.Answer("something");
        }
        Assert.False(quiz.Answer(bundle.answer).IsCorrect());
    }
}