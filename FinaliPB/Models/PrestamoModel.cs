using System.ComponentModel.DataAnnotations;

namespace FinaliPB.Models
{
    public class PrestamoModel
    {
        public int IdPrestamo { get; set; }
        public string Titulo { get; set; }
        public string Usuario { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_de_Prestamo { get; set; }
        
        public DateTime Fecha_de_Entrega { get; set; }
        
        public char Estatus { get; set; }
        
    }
}
