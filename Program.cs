using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using ProductCatalogApi.Models;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dapper-compatible SQLite connection
builder.Services.AddScoped<IDbConnection>(_ => new SqliteConnection("Data Source=products.db"));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Create DB if not exists
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IDbConnection>();
    db.Execute("""
        CREATE TABLE IF NOT EXISTS Products (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Price REAL NOT NULL,
            Description TEXT
        );
    """);
}

// GET all
app.MapGet("/products", async (IDbConnection db) =>
    await db.QueryAsync<Product>("SELECT * FROM Products"));

// GET by id
app.MapGet("/products/{id:int}", async (int id, IDbConnection db) =>
{
    var product = await db.QuerySingleOrDefaultAsync<Product>(
        "SELECT * FROM Products WHERE Id = @Id", new { Id = id });
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

// POST
app.MapPost("/products", async (Product product, HttpContext http, IDbConnection db) =>
{
    if (!MiniValidator.TryValidate(product, out var errors))
        return Results.ValidationProblem(errors);

    var sql = @"INSERT INTO Products (Name, Price, Description)
                VALUES (@Name, @Price, @Description);
                SELECT last_insert_rowid();";
    var id = await db.ExecuteScalarAsync<int>(sql, product);
    product.Id = id;

    return Results.Created($"/products/{product.Id}", product);
});

// PUT
app.MapPut("/products/{id:int}", async (int id, Product updatedProduct, IDbConnection db) =>
{
    var sql = @"UPDATE Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";
    var rows = await db.ExecuteAsync(sql, new
    {
        Id = id,
        updatedProduct.Name,
        updatedProduct.Price,
        updatedProduct.Description
    });

    return rows == 0 ? Results.NotFound() : Results.NoContent();
});

// DELETE
app.MapDelete("/products/{id:int}", async (int id, IDbConnection db) =>
{
    var rows = await db.ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
    return rows == 0 ? Results.NotFound() : Results.NoContent();
});

app.Run();
