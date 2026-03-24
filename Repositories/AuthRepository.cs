namespace BackendGenerators.Repository
{
    using BackendGenerators.Data;
    using BackendGenerators.Models;
    using Microsoft.EntityFrameworkCore;

    public class AuthRepository
    {
        private readonly AppDbContext _db;

        public AuthRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<Usuario> GetByUsernameAsync(string username)
        {
            return _db.Usuario.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(Usuario usuario)
        {
            _db.Usuario.Add(usuario);
            await _db.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}