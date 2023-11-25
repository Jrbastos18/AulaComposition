//Classe de departamento com propriedade Name
namespace Aula128Composition.Entities
{
    internal class Department
    {
        //Propriedade
        public string Name { get; set; }

        //Construtores
        public Department()
        {
        }

        public Department(string name)
        {
            Name = name;
        }
    }
}
