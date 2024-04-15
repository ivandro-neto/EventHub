using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace EventHub.Infrastructure.Entities;
public class Account
{
    private string passwordHash;
    [Key]
    [Column("AccountID")]
    public Guid AccountID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public string PasswordHash
    {
        get { return passwordHash; }
        set { passwordHash = HashPassword(value); }
    }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    [ForeignKey("CreatorID")]
    public List<Event> Events { get; set; } = new List<Event>();

   

    private string HashPassword(string password)
    {
        // Gera um salt aleatório
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        // Cria o hash da senha com o salt usando SHA-256
        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt)));

            // Combina o salt e o hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Converte para uma string base64
            string passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }
    }

    public bool VerifyPassword(string inputPassword)
    {
        // Extrai o salt dos bytes do hash
        byte[] hashBytes = Convert.FromBase64String(passwordHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

        // Calcula o hash da senha de entrada com o salt extraído
        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword + Convert.ToBase64String(salt)));

            // Compara os hashes
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
