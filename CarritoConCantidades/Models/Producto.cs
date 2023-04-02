using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarritoConCantidades.Models
{
    [Table("BEBIDAS")]
    public class Producto
    {
        [Key]
        [Column("IDBEBIDA")]
        public int IdBebida { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }


        [Column("IMAGEN")]
        public string Imagen { get; set; }


        [Column("PRECIO")]
        public int Precio { get; set; }

    }
}
