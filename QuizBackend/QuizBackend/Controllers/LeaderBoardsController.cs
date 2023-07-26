using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using QuizBackend.Domain;

namespace QuizBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaderBoardsController : ControllerBase
{
    private readonly ILeaderBoard leaderBoard;

    public LeaderBoardsController(ILeaderBoard leaderBoard)
    {
        this.leaderBoard = leaderBoard;
    }

    [HttpGet(Name = "All")]
    public IEnumerable<JsonObject> All()
    {
        return leaderBoard.All().Select(e => new JsonObject(
                new Dictionary<string, JsonNode?>
                {
                    ["player"] = e.player,
                    ["result"] = e.result
                }
            )
        );
    }

    [HttpPost(Name = "Apply")]
    public ActionResult Apply(string player, float result)
    {
        leaderBoard.Apply(player, result);
        return Ok();
    }
}