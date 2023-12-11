
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoList.Entities;
using ToDoList.Services;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Register the list of tasks
builder.Services.AddSingleton<List<CustomerTask>>();

// Register services
builder.Services.AddSingleton<ITaskService, TaskService>();
builder.Services.AddSingleton<DueDateCheckerService>();
builder.Services.AddSingleton<SchedulerServices>();

// Set up a background service to run SchedulerServices at regular intervals
builder.Services.AddHostedService<SchedulerServices>();

// Configure logging
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    // Add any additional logging configuration you need
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Adding Swagger and Swagger UI middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    // Redirect root to Swagger
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
