using Aula128Composition.Entities.Enums;
using Aula128Composition.Entities;
using System.Globalization;

namespace Aula128Composition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //Convertendo a string digitada para a variavel do tipo enum(WorkerLevel), Console.Readline é a string a ser convertida
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Instanciando os dois objetos Department e Worker
            Department dept = new Department(deptName);//Declarando primeiro o departamento, pois o worker é associado a ele utilizando a sobrecarga
            Worker worker = new Worker(name, level, baseSalary, dept);//Declarando a classe worker com sobrecarga completa

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());//O metodo Parse pode receber esse tipo de formato de data, como aceita outros também
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));//Pega o string acima, recorta ele da posição x = 0 até a posição y = 2
            int year = int.Parse(monthAndYear.Substring(3));//Pega o string acima, recorta ele da posição x = 0 em diante, corta até o final

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department" + worker.Department.Name); //Acessa o objeto worker, o departamento e o nome do departamento
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}