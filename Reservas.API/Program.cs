using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.UseCases.Reservations.CancelReservation;
using Reservas.Application.UseCases.Reservations.CreateReservation;
using Reservas.Application.UseCases.Reservations.GetReservationById;
using Reservas.Application.UseCases.Reservations.GetReservations;
using Reservas.Application.UseCases.Reservations.UpdateReservationStatus;
using Reservas.Application.UseCases.Spaces.GetSpaces;
using Reservas.Application.UseCases.Users.GetUsers;
using Reservas.Domain.Repositories;
using Reservas.Domain.Services;
using Reservas.Infrastructure.Data;
using Reservas.Infrastructure.Repositories;
using Reservas.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ReservationsDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder
    .Services.AddControllers()
    .AddFluentValidation(
        fv => fv.RegisterValidatorsFromAssemblyContaining<CreateReservationValidator>()
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ISpaceRepository, SpaceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<CreateReservationHandler>();
builder.Services.AddScoped<GetReservationsHandler>();
builder.Services.AddScoped<CancelReservationHandler>();
builder.Services.AddScoped<UpdateReservationStatusHandler>();
builder.Services.AddScoped<GetReservationByIdHandler>();
builder.Services.AddScoped<GetSpacesHandler>();
builder.Services.AddScoped<GetUsersHandler>();
builder.Services.AddScoped<INotificationService, MockNotificationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
