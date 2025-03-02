using CalendarAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register  services
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IVisitService, VisitService>();  

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");  
app.UseAuthorization();

app.MapControllers();

app.Run();