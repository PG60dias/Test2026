using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public static class PasswordHasher
{
	public static string HashPassword(string password)
	{
		byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

		byte[] hashed = KeyDerivation.Pbkdf2(
			password: password!,
			salt: salt,
			prf: KeyDerivationPrf.HMACSHA256,
			iterationCount: 100000,
			numBytesRequested: 256 / 8);

		return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hashed)}";
	}

	public static bool VerifyPassword(string hashedPassword, string providedPassword)
	{
		var parts = hashedPassword.Split('.', 2);
		if (parts.Length != 2) return false;

		var salt = Convert.FromBase64String(parts[0]);
		var storedHash = Convert.FromBase64String(parts[1]);

		var testHash = KeyDerivation.Pbkdf2(
			password: providedPassword,
			salt: salt,
			prf: KeyDerivationPrf.HMACSHA256,
			iterationCount: 100000,
			numBytesRequested: 256 / 8);

		return CryptographicOperations.FixedTimeEquals(storedHash, testHash);
	}
}