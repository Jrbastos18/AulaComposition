using System.Collections.Generic;
using Aula128Composition.Entities.Enums;

namespace Aula128Composition.Entities
{
    internal class Worker
    {
        //Atributos
        public string Name { get; set; }
        //Declarando a propriedade do tipo WorkerLevel que é um enum
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        //Fazendo associação entre duas classes diferentes
        public Department Department { get; set; }
        //Classe contratos, como são vários, tem que ser uma lista de contratos
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//Já instanciando a lista para garantir que ela não seja nula


        //Construtores
        public Worker()
        {
        }

        //Sempre que houver associações para-muitos, não é usual passar uma lista instanciada em um construtor do objetos, pois inicia vazia e depois vai atribui-la
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }


        //Métodos do objeto
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);//Método para adicionar contrato na lista de contratos
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);//Método para remover contrato na lista de contratos
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary; //Iniciar com BaseSalary porque o trabalhador ganha o salário base menos sem o bonus dos contratos
            foreach (HourContract contract in Contracts) //Para cada HourContract contract na lista de Contratos
            {
                if(contract.Date.Year == year && contract.Date.Month == month) //Se o ano do contrato for igual ao ano e o mes for igual, então entra na soma
                {
                    sum += contract.TotalValue(); 
                }
            }
            return sum; 
        }

    }
}
