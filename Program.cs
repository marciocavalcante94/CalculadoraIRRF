using System;

namespace CalculadoraIRRF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o salário bruto: ");
            double salario = double.Parse(Console.ReadLine());

            Funcionario f = new Funcionario(nome, salario);

            Console.WriteLine($"\nNome: {f.Nome}");
            Console.WriteLine($"Salário Bruto: R$ {f.SalarioBruto:F2}");
            Console.WriteLine($"Desconto INSS: R$ {f.DescontoINSS():F2}");
            Console.WriteLine($"Base de Cálculo IRRF: R$ {f.BaseCalculoIRRF():F2}");
            Console.WriteLine($"Desconto IRRF: R$ {f.DescontoIRRF():F2}");
        }
    }
}
