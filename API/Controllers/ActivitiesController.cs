using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

//Uses Base Controller
public class ActivitiesController : BaseAPIController
{
    private readonly ApplicationDbContext _dbContext;

    public ActivitiesController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
    {
        return await _dbContext.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await _dbContext.Activities.FindAsync(id);

        if (activity == null) return NotFound();

        return activity;
    }

}
