using tut4;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapGet("/animals", () => DataStore.Animals);
app.MapGet("/animals/{id}", (int id) => DataStore.Animals.FirstOrDefault(a => a.Id == id));
app.MapPost("/animals", (Animal animal) => {
    DataStore.Animals.Add(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});
app.MapPut("/animals/{id}", (int id, Animal updatedAnimal) => {
    var animal = DataStore.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null) return Results.NotFound();
    animal.Name = updatedAnimal.Name;
    animal.Category = updatedAnimal.Category;
    animal.Weight = updatedAnimal.Weight;
    animal.FurColor = updatedAnimal.FurColor;
    return Results.NoContent();
});
app.MapDelete("/animals/{id}", (int id) => {
    var animal = DataStore.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null) return Results.NotFound();
    DataStore.Animals.Remove(animal);
    return Results.Ok();
});

app.MapGet("/visits", (int animalId) => DataStore.Visits.Where(v => v.AnimalId == animalId).ToList());
app.MapPost("/visits", (Visit visit) => {
    DataStore.Visits.Add(visit);
    return Results.Created($"/visits/{visit.Id}", visit);
});

app.MapControllers();

app.Run();