namespace FinaliPB.Models
{
    public class LibroModel
    {
        public int IdLibro { get; set; }

        public string Nombre { get; set; }

        public string Autor { get; set; }

        public int Cantidad { get; set; }

        public string ISBN { get; set; }

        public DateTime Fecha_de_Compra { get; set; }

        public DateTime Fecha_de_Adquisicion { get; set; }
    }
}
