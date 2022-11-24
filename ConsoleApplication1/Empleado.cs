namespace ConsoleApplication1
{
    internal class Empleado
    {
        static int plus = 300;

        private string nombre;
        private int edad;
        private int salario;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        public int Plus
        {
            get { return plus; }
        }
        public int Salario
        {
            get { return salario; }
            set { salario = value; }
        }
    }
}