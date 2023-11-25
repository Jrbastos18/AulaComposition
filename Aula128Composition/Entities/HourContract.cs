using System;

namespace Aula128Composition.Entities
{
    internal class HourContract
    {
        //Propriedade
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        //Construtores
        //Construtor padrão
        public HourContract()
        {
        }

        //Construtores com argumentos
        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        //Método do valor total do contrato, na qual são as horas trabalhadas multiplicado pelo valor por hora do contrato
        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }

    }
}
