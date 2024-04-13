namespace PlayerBlazorApp.Models
{
    public class Video
    {
        public string Titulo { get; set; }
        public string RutaArchivo { get; set; }

        public class SubVideo // Cambia el nombre de la clase interna
        {
            public string Titulo { get; set; }
            public string RutaArchivo { get; set; }

            public SubVideo(string titulo, string rutaArchivo)
            {
                Titulo = titulo;
                RutaArchivo = rutaArchivo;
            }
        }

        // Método para actualizar el título del video
        public void ActualizarTitulo(string nuevoTitulo)
        {
            Titulo = nuevoTitulo;
        }

        // Método para actualizar la ruta del archivo del video
        public void ActualizarRutaArchivo(string nuevaRuta)
        {
            RutaArchivo = nuevaRuta;
        }
    }
}

namespace PlayerBlazorApp.Models
{
    public class Nodo
    {
        public Nodo? LigaAnterior { get; set; }
        public Video.SubVideo Datos { get; set; } // Cambia el tipo de Datos a Video.SubVideo
        public Nodo? LigaSiguiente { get; set; }

        // Cambia el constructor para aceptar Video.SubVideo
        public Nodo(Video.SubVideo datos)
        {
            LigaAnterior = null;
            Datos = datos;
            LigaSiguiente = null;
        }

        // Método para obtener el nodo anterior
        public Nodo? ObtenerNodoAnterior()
        {
            return LigaAnterior;
        }

        // Método para obtener el nodo siguiente
        public Nodo? ObtenerNodoSiguiente()
        {
            return LigaSiguiente;
        }

        // Método para verificar si el nodo tiene un nodo anterior
        public bool TieneNodoAnterior()
        {
            return LigaAnterior != null;
        }

        // Método para verificar si el nodo tiene un nodo siguiente
        public bool TieneNodoSiguiente()
        {
            return LigaSiguiente != null;
        }

        // Método para insertar un nuevo nodo después del nodo actual
        public void InsertarNodoDespues(Nodo nuevoNodo)
        {
            if (this.LigaSiguiente != null)
            {
                nuevoNodo.LigaAnterior = this;
                nuevoNodo.LigaSiguiente = this.LigaSiguiente;
                this.LigaSiguiente.LigaAnterior = nuevoNodo;
                this.LigaSiguiente = nuevoNodo;
            }
            else
            {
                this.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = this;
            }
        }

        // Método para insertar un nuevo nodo antes del nodo actual
        public void InsertarNodoAntes(Nodo nuevoNodo)
        {
            if (this.LigaAnterior != null)
            {
                nuevoNodo.LigaSiguiente = this;
                nuevoNodo.LigaAnterior = this.LigaAnterior;
                this.LigaAnterior.LigaSiguiente = nuevoNodo;
                this.LigaAnterior = nuevoNodo;
            }
            else
            {
                this.LigaAnterior = nuevoNodo;
                nuevoNodo.LigaSiguiente = this;
            }
        }

        // Método para eliminar este nodo de la lista
        public void EliminarNodo()
        {
            if (this.LigaAnterior != null)
            {
                this.LigaAnterior.LigaSiguiente = this.LigaSiguiente;
            }
            if (this.LigaSiguiente != null)
            {
                this.LigaSiguiente.LigaAnterior = this.LigaAnterior;
            }
        }
    }
}
