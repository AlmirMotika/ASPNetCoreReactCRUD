using aspnetserver.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(setupAction: options =>
{
    options.AddPolicy(name: "CORSPolicy",
        configurePolicy: builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(origins: "http://localhost:3000");
        });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction:swaggerGenOptions=>
{
    swaggerGenOptions.SwaggerDoc(name:"v1",info:new OpenApiInfo { Title="ASP.NET React Tutorial",Version="v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
app.UseSwaggerUI(setupAction: swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET React Tutorial";
    swaggerUIOptions.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Web API serving a very simple Post model.");
    swaggerUIOptions.RoutePrefix=String.Empty;
});


app.UseHttpsRedirection();
app.UseCors(policyName: "CORSPolicy");
app.MapGet(pattern: "/get-all-posts", handler: async () => await PostsRepository.GetPostsAsync())
    .WithTags(tags: "Posts Endpoints");
app.MapGet(pattern: "/get-post-by-id/{postId}", handler: async (int postId) =>
   {
       Post postToreturn = await PostsRepository.GetPostByIdAsync(postId: postId);
       if (postToreturn != null)
       {
           return Results.Ok(value: postToreturn);
       }
       else
       {
           return Results.BadRequest();
       }
   }).WithTags("Posts Endpoints");
app.MapPost(pattern: "/create-post", handler: async (Post postToCreate) =>
{
    bool createSuccessful = await PostsRepository.CreatePostAsync(postToCreate);
    if (postToCreate != null)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");
app.MapPut(pattern: "/update-post", handler: async (Post postToUpdate) =>
{
    bool updateSuccessful = await PostsRepository.UpdatePostAsync(postToUpdate);
    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");
app.MapDelete(pattern: "/delete-post-by-id/{postId}", handler: async (int postId) =>
{
    bool deleteSuccessful = await PostsRepository.DeletePostAsync(postId: postId);
    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");
app.Run();
