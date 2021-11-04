using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Productos")]
    public class Producto : IEquatable<Producto>
    {
        public long? Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression(@"(\d+,?\d*)", ErrorMessage = "El número debe ser sólo dígitos con o sin decimales con coma")]
        [Range(0.0,1000000.0)]
        public decimal Precio { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "2021-11-01", "2021-11-30")]
        [Display(Name = "Fecha de caducidad")]
        public DateTime? FechaCaducidad { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-z0-9_]+(\.jpg|\.png)$", ErrorMessage = "Sólo ficheros jpg o png y con letras, números o guiones bajos")]
        public string Foto { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Producto);
        }

        public bool Equals(Producto other)
        {
            return other != null &&
                   Id == other.Id &&
                   Nombre == other.Nombre &&
                   Precio == other.Precio &&
                   FechaCaducidad == other.FechaCaducidad;
        }

        public override int GetHashCode()
        {
            int hashCode = -1261291979;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + Precio.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaCaducidad.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Precio}, {FechaCaducidad}";
        }

        public static bool operator ==(Producto left, Producto right)
        {
            return EqualityComparer<Producto>.Default.Equals(left, right);
        }

        public static bool operator !=(Producto left, Producto right)
        {
            return !(left == right);
        }
    }
}
