using AzurePipelinesToGitHubActionsConverter.Core;
using Microsoft.AspNetCore.Mvc;

namespace AzurePipelinesToGitHubActionsConverter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConvertController : ControllerBase
{
    private readonly Conversion _converter;

    public ConvertController()
    {
        _converter = new Conversion(verbose: false);
    }

    [HttpPost("pipeline")]
    public IActionResult ConvertPipeline()
    {
        try
        {
            // Read raw request body as string
            using var reader = new StreamReader(Request.Body);
            var yamlContent = reader.ReadToEndAsync().GetAwaiter().GetResult();
            
            if (string.IsNullOrWhiteSpace(yamlContent))
                return BadRequest("YAML content is empty");

            var result = _converter.ConvertAzurePipelineToGitHubAction(
                yamlContent, 
                addWorkFlowDispatch: true
            );

            return Content(result.actionsYaml, "application/x-yaml");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Conversion failed: {ex.Message}");
        }
    }
}
