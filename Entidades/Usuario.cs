using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Usuarios")]
    public class Usuario : IEquatable<Usuario>
    {
        public long? Id { get; set; }
        
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [EmailAddress]
        // [Index(IsUnique = true)] // Podríamos haberlo usado, pero requeriría meter el paquete de NuGet de EntityFramework
        public string Email { get; set; }
        
        // TODO: Password basada en un hash
        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        [RegularExpression(@"^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*[%\\-]).{8,64})$", ErrorMessage ="Debe tener al menos un dígito, una letra minúscula y una letra mayúscula")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[\p{L} ]*$")] // TODO: Verificar si en JavaScript lo maneja bien
        public string Nombre { get; set; }

        [Required]
        public string Rol { get; set; } = "USER";

        public Carrito Carrito { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Usuario);
        }

        public bool Equals(Usuario other)
        {
            return other != null &&
                   Id == other.Id &&
                   Email == other.Email &&
                   Password == other.Password &&
                   Nombre == other.Nombre &&
                   Rol == other.Rol;
        }

        public override int GetHashCode()
        {
            int hashCode = -408757299;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rol);
            return hashCode;
        }

        public static bool operator ==(Usuario left, Usuario right)
        {
            return EqualityComparer<Usuario>.Default.Equals(left, right);
        }

        public static bool operator !=(Usuario left, Usuario right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Email}, {Password}, {Rol}";
        }
    }
}
