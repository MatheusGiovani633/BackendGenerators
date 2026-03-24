namespace BackendGenerators.Services
{
    using BackendGenerators.Interfaces;
    using BackendGenerators.Models;
    using BackendGenerators.Repository;
    

    public class AuthService
    {
        private readonly AuthRepository _repo;
        private readonly IPasswordHasher _hasher;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public AuthService(
            AuthRepository repo,
            IPasswordHasher hasher,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _repo = repo;
            _hasher = hasher;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<string> RegisterAsync(string username, string password)
        {
            var exists = await _repo.GetByUsernameAsync(username);
            if (exists != null) throw new InvalidOperationException("Usuário já existe.");

            var usuario = new Usuario
            {
                Username = username,
                PasswordHash = _hasher.HashPassword(password)
            };

            await _repo.AddAsync(usuario);
            return usuario.Username;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var usuario = await _repo.GetByUsernameAsync(username);
            if (usuario == null || !_hasher.VerifyPassword(password, usuario.PasswordHash))
                throw new InvalidOperationException("Credenciais inválidas.");

            usuario.RefreshToken = _refreshTokenGenerator.Generate();
            usuario.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _repo.SaveChangesAsync();
            return usuario.Username;
        }

        public async Task<bool> LogoutAsync(string username)
        {
            var usuario = await _repo.GetByUsernameAsync(username);
            if (usuario == null) throw new InvalidOperationException("Usuário não encontrado.");

            usuario.RefreshToken = null;
            usuario.RefreshTokenExpiryTime = null;

            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> RefreshTokenAsync(string username, string refreshToken)
        {
            var usuario = await _repo.GetByUsernameAsync(username);
            if (usuario == null) throw new InvalidOperationException("Usuário não encontrado.");

            var expired = !usuario.RefreshTokenExpiryTime.HasValue ||
                          usuario.RefreshTokenExpiryTime.Value <= DateTime.UtcNow;

            if (usuario.RefreshToken != refreshToken || expired)
                throw new InvalidOperationException("Token inválido ou expirado.");

            usuario.RefreshToken = _refreshTokenGenerator.Generate();
            usuario.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _repo.SaveChangesAsync();
            return usuario;
        }
    }
}