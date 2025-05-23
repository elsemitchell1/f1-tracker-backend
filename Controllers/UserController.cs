using Microsoft.AspNetCore.Mvc;
using F1TrackerApi.DTOs;
using F1TrackerApi.Data;
using F1TrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace F1TrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("favorites")]
        public IActionResult SaveFavoriteDriver([FromBody] FavoriteDriverDto favoriteDriverDto)
        {
            foreach(var claim in User.Claims){
                Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "User ID claim is missing from the token" });
            }

            var userId = int.Parse(userIdClaim.Value);

            var favoriteDriver = new FavoriteDriver
            {
                UserId = userId,
                DriverName = favoriteDriverDto.DriverName
            };

            _context.FavoriteDrivers.Add(favoriteDriver);
            _context.SaveChanges();

            return Ok(new { message = "Favorite driver saved successfully" });
        }

        [HttpGet("favorites")]
        public IActionResult GetFavoriteDrivers()
        {
            var userId = int.Parse(User.FindFirst("id")?.Value); // Extract user ID from JWT token

            var favoriteDrivers = _context.FavoriteDrivers
                .Where(fd => fd.UserId == userId)
                .Select(fd => fd.DriverName)
                .ToList();

            return Ok(new { drivers = favoriteDrivers });
        }
        [HttpDelete("favorites/{driverName}")]
        public IActionResult DeleteFavoriteDriver(string driverName){
            var userId = int.Parse(User.FindFirst("id")?.Value);
            var favoriteDriver = _context.FavoriteDrivers
                .FirstOrDefault(fd => fd.UserId == userId && fd.DriverName == driverName);
            if(favoriteDriver == null){
                return NotFound(new { message = "Favorite driver not found" });
            }
            _context.Database.ExecuteSqlRaw("DELETE FROM FavoriteDrivers WHERE DriverName IS NULL OR DriverName = ''");
            _context.FavoriteDrivers.Remove(favoriteDriver);
            _context.SaveChanges();
            return Ok(new {message = "Favorite driver deleted successfully"});
        }
    }
}
