
using ToDoList.Entities;
using ToDoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Register the list of tasks
builder.Services.AddSingleton<List<CustomerTask>>();

// Setting Services as Singletons,
// to ensure persistence of the tasks list
// throughout the lifespan of the app, and ensuring that
// all other services have one and only instance in the app.  
builder.Services.AddSingleton<TaskService>();
builder.Services.AddSingleton<DueDateCheckerService>();
builder.Services.AddSingleton<SchedulerServices>();

// Set up a background service to run SchedulerServices at regular intervals
builder.Services.AddHostedService<SchedulerServices>();

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