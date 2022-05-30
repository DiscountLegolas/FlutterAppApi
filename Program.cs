//usings
using Api.Ef;
using Microsoft.EntityFrameworkCore;
using Api.RepositoryPattern.Repos.Interface;
using Api.RepositoryPattern.Repos.Class;
using Api.RepositoryPattern.Services.Interface;
using Api.RepositoryPattern.Services.Class;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var  allowallorigins = "_allowallorigins";
builder.Services.AddCors(options=> 
    options.AddPolicy(name:allowallorigins,b=>
        b.WithOrigins().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin=>true).AllowCredentials().Build()));

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "KekemelikApi", Version = "v1" });
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<KekemelikDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("KekemelikDb")));
//DIS
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<ITherapistRepo,TherapistRepo>();
builder.Services.AddScoped<IİlRepo,İlRepo>();
builder.Services.AddScoped<IİlçeRepo,İlçeRepo>();
builder.Services.AddScoped<IMessageRepo,MessageRepo>();
builder.Services.AddScoped<IPostRepo,PostRepo>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ITherapistService,TherapistService>();
builder.Services.AddScoped<IPostsService,PostsService>();

//

var app = builder.Build();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.UseHttpsRedirection();
app.UseCors(allowallorigins);

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(e=>{
    e.MapGet("/", async context =>
    {
         context.Response.Redirect("swagger");

    });
});


app.MapControllers();

app.Run();
