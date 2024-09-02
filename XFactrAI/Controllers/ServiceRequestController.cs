using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using XFactrAI.Models;

[Route("api/[controller]")]
[ApiController]
public class ServiceRequestController : ControllerBase
{
    private readonly IServiceRequestRepository _repository;

    public ServiceRequestController(IServiceRequestRepository repository)
    {
        _repository = repository;
    }

    // GET api/servicerequest
    [HttpGet]
    public IActionResult Get()
    {
        var requests = _repository.GetAll();
        if (!requests.Any())
            return NoContent(); // 204 No Content

        return Ok(requests); // 200 OK
    }

    // GET api/servicerequest/{id}
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var request = _repository.GetById(id);

        if (request == null)
            return NotFound(); // 404 Not Found

        return Ok(request); // 200 OK
    }

    // POST api/servicerequest
    [HttpPost]
    public IActionResult Post([FromBody] ServiceRequest newRequest)
    {
        if (newRequest == null)
            return BadRequest(); // 400 Bad Request

        _repository.Add(newRequest);

        return CreatedAtAction(nameof(Get), new { id = newRequest.Id }, newRequest); // 201 Created
    }

    // PUT api/servicerequest/{id}
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] ServiceRequest updatedRequest)
    {
        if (updatedRequest == null || id != updatedRequest.Id)
            return BadRequest(); // 400 Bad Request

        var existingRequest = _repository.GetById(id);

        if (existingRequest == null)
            return NotFound(); // 404 Not Found

        _repository.Update(updatedRequest);

        return Ok(updatedRequest); // 200 OK
    }

    // DELETE api/servicerequest/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var request = _repository.GetById(id);

        if (request == null)
            return NotFound(); // 404 Not Found

        _repository.Delete(id);

        return NoContent(); // 204 No Content
    }
}
