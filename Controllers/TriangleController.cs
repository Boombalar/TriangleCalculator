using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/triangle")]
public class TriangleController : ControllerBase {
    readonly TriangleRepository triangleRepository = new();

    [HttpGet]
    public IActionResult getTriangleType([FromBody] Triangle triangle) {
        try {
            string triangleType = triangleRepository.getTriangleType(triangle);
            return Ok(triangleType);
        } catch (TriangleNotValidException e) {
            return BadRequest(e.Message);
        }
    }
}