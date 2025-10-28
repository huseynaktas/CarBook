using CarBook_1.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook_1.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook_1.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook_1.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook_1.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook_1.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook_1.Application.Features.RepositoryPattern;
using CarBook_1.Application.Interfaces;
using CarBook_1.Application.Interfaces.BlogInterfaces;
using CarBook_1.Application.Interfaces.CarDescriptionInterfaces;
using CarBook_1.Application.Interfaces.CarFeatureInterfaces;
using CarBook_1.Application.Interfaces.CarInterfaces;
using CarBook_1.Application.Interfaces.CarPricingInterfaces;
using CarBook_1.Application.Interfaces.RentACarInterfaces;
using CarBook_1.Application.Interfaces.ReviewInterfaces;
using CarBook_1.Application.Interfaces.StatisticsInterfaces;
using CarBook_1.Application.Interfaces.TagCloudInterfaces;
using CarBook_1.Application.Services;
using CarBook_1.Application.Tools;
using CarBook_1.Persistence.Context;
using CarBook_1.Persistence.Repositories;
using CarBook_1.Persistence.Repositories.BlogRepositories;
using CarBook_1.Persistence.Repositories.CarDescriptionRepositories;
using CarBook_1.Persistence.Repositories.CarFeatureRepositories;
using CarBook_1.Persistence.Repositories.CarPricingRepositories;
using CarBook_1.Persistence.Repositories.CarRepository;
using CarBook_1.Persistence.Repositories.CommentRepositories;
using CarBook_1.Persistence.Repositories.RentACarRepositories;
using CarBook_1.Persistence.Repositories.ReviewRepositories;
using CarBook_1.Persistence.Repositories.StatisticsRepositories;
using CarBook_1.Persistence.Repositories.TagCloudRepositories;
using CarBook_1.WebApi.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

#region //Mediator Registirations
// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
#endregion

#region //CQRS Registirations
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
#endregion

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<CarHub>("/carhub");

app.Run();
