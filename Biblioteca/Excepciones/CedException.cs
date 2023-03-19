namespace Biblioteca.Excepcion
{
    [Serializable]
    class CedException : Exception
    {
        public CedException() { }
        public CedException(string name)
            : base(String.Format("Cedula Invalida: {0}", name))
        {

        }
    }
}
