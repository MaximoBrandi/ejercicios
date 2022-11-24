namespace ConsoleApplication1
{
    internal class Comercial : Empleado
    {
        private double comision;
        public double Comision
        {
            get { return comision; }
            set { comision = value; }
        }
        public bool plus()
        {
            if (Edad > 35 && comision > 200)
            {
                Salario = Salario + Plus;
                return true;
            }
            else
                return false;
        }

        public Comercial(string Nombre, int Salario, int Edad, double comision)
        {
            this.Nombre = Nombre;
            this.Salario = Salario;
            this.Edad = Edad;
            this.comision = comision;
        }

        public Comercial()
        {

        }
    }
}