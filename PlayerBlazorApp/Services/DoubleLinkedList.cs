using PlayerBlazorApp.Models;
using System;
using System.Collections.Generic;

namespace PlayerBlazorApp.Services
{
    public class DoubleLinkedList
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }
        public Nodo? NodoActual { get; set; }

        public DoubleLinkedList()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public bool IsEmpty => PrimerNodo == null;

        public string AgregarVideoAlInicio(Video.SubVideo video)
        {
            Nodo nuevoNodo = new Nodo(video);

            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;
                PrimerNodo.LigaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Video agregado al inicio...";
        }
        public List<string> ObtenerTitulos()
        {
            var titulos = new List<string>();
            var actual = PrimerNodo;

            while (actual != null)
            {
                titulos.Add(actual.Datos.Titulo); // Cambio aquí
                actual = actual.LigaSiguiente;
            }

            return titulos;
        }
        public string AgregarVideoAlFinal(Video.SubVideo video)
        {
            Nodo nuevoNodo = new Nodo(video);

            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Video agregado al final...";
        }

        public void EliminarVideoAlInicio()
        {
            if (IsEmpty)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                PrimerNodo = PrimerNodo.LigaSiguiente;
                PrimerNodo.LigaAnterior = null;
            }
        }

        public void EliminarVideoAlFinal()
        {
            if (IsEmpty)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                UltimoNodo = UltimoNodo.LigaAnterior;
                UltimoNodo.LigaSiguiente = null;
            }
        }

        public void EliminarPosicionSeleccionada()
        {
            if (IsEmpty || NodoActual == null)
            {
                Console.WriteLine("La lista está vacía o no hay un nodo actual seleccionado.");
                return;
            }

            if (NodoActual == PrimerNodo)
            {
                EliminarVideoAlInicio();
            }
            else if (NodoActual == UltimoNodo)
            {
                EliminarVideoAlFinal();
            }
            else
            {
                NodoActual.LigaAnterior.LigaSiguiente = NodoActual.LigaSiguiente;
                NodoActual.LigaSiguiente.LigaAnterior = NodoActual.LigaAnterior;
                NodoActual = null;
            }
        }

        public List<string> ObtenerEnlaces()
        {
            var enlaces = new List<string>();
            var actual = PrimerNodo;

            while (actual != null)
            {
                enlaces.Add(actual.Datos.RutaArchivo);
                actual = actual.LigaSiguiente;
            }

            return enlaces;
        }

        public Nodo? ObtenerPosicionNodo(int posicion)
        {
            if (posicion < 1)
                return null;

            int contador = 1;
            Nodo? actual = PrimerNodo;

            while (actual != null && contador < posicion)
            {
                actual = actual.LigaSiguiente;
                contador++;
            }

            return actual;
        }
    }
}
