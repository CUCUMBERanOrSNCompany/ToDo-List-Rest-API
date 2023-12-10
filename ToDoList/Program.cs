using ToDoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Setting Task Service as a Singleton,
// to ensure persistence of the tasks list
// throughout the lifespan of the app.  
builder.Services.AddSingleton<TaskService>();

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