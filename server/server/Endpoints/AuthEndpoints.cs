using server.Data;
using server.Dtos;
using server.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Endpoints
{
    public static class AuthEndpoints
    {
        public static RouteGroupBuilder MapAuthEndpoints(this WebApplication app)
        {
            
            var group = app
                .MapGroup("auth")
                .WithParameterValidation();
            group.MapPost("/signup", async (UserCreateDto createUser, MusicAppContext db) =>
            {
                var user = await db.Users.Where(u => u.Email == createUser.Email).ToListAsync();

                //Console.WriteLine("db user: " + user.Count);
                if (user.Count != 0)
                {
                    return Results.BadRequest("User with the same email already exists!");
                }
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUser.Password);
                var entityUser = new User()
                {
                    Name = createUser.Name,
                    Email = createUser.Email,
                    Password = hashedPassword
                };

                db.Users.Add(entityUser);
                await db.SaveChangesAsync();
                return Results.Ok(entityUser);
                //Console.WriteLine(createUser.Name);
            });
            return group;
        }
    }
}
