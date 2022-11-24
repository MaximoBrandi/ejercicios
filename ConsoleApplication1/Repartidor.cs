namespace ConsoleApplication1
{
    internal class Repartidor : Empleado
    {
        private string zona;
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        public bool AptoPlus()
        {
            if (Edad < 25 && zona == "zona 3")
            {
                Salario = Salario + Plus;
                return true;
            }
            else
                return false;
        }

        public Repartidor(string Nombre, int Salario, int Edad, string Zona)
        {
            this.Nombre = Nombre;
            this.Salario = Salario;
            this.Edad = Edad;
            this.zona = Zona;
        }

        public Repartidor()
        {

        }
    }
}