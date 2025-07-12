using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Reservas.Application.UseCases.Reservations.CancelReservation;
using Reservas.Application.UseCases.Reservations.CreateReservation;
using Reservas.Application.UseCases.Reservations.GetReservations;
using Reservas.Domain.Repositories;
using Reservas.Infrastructure.Data;
using Reservas.Infrastructure.Repositories;

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
builder.Services.AddScoped<CreateReservationHandler>();
builder.Services.AddScoped<GetReservationsHandler>();
builder.Services.AddScoped<CancelReservationHandler>();

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
