using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=db-mssql.pjwstk.edu.pl;Database=2019 SBD;User Id=s28605;Password=k$anak$!23;";
builder.Services.AddTransient<TeamMemberRepository>(provider => new TeamMemberRepository(connectionString));
builder.Services.AddTransient<TaskRepository>(provider => new TaskRepository(connectionString));
builder.Services.AddTransient<ProjectRepository>(provider => new ProjectRepository(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();