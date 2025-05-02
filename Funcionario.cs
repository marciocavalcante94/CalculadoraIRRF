namespace CalculadoraIRRF
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public double SalarioBruto { get; set; }

        public Funcionario(string nome, double salarioBruto)
        {
            Nome = nome;
            SalarioBruto = salarioBruto;
        }

        public double DescontoINSS()
        {
            double salario = SalarioBruto;
            double desconto = 0;

            if (salario <= 1518.00)
                desconto = salario * 0.075;
            else if (salario <= 2793.88)
                desconto = (1518.00 * 0.075) + ((salario - 1518.00) * 0.09);
            else if (salario <= 4190.83)
                desconto = (1518.00 * 0.075) + (1275.88 * 0.09) + ((salario - 2793.88) * 0.12);
            else if (salario <= 8157.41)
                desconto = (1518.00 * 0.075) + (1275.88 * 0.09) + (1396.95 * 0.12) + ((salario - 4190.83) * 0.14);
            else
                desconto = 1051.14; // Teto do INSS em 2025

            return Math.Round(desconto, 2);
        }

        public double BaseCalculoIRRF()
        {
            return SalarioBruto - DescontoINSS();
        }

        public double DescontoIRRF()
        {
            double baseCalculo = BaseCalculoIRRF();
            double aliquota = 0;
            double deducao = 0;

            if (baseCalculo <= 2428.80)
            {
                aliquota = 0;
                deducao = 0;
            }
            else if (baseCalculo <= 2826.65)
            {
                aliquota = 0.075;
                deducao = 182.16;
            }
            else if (baseCalculo <= 3751.05)
            {
                aliquota = 0.15;
                deducao = 394.16;
            }
            else if (baseCalculo <= 4664.68)
            {
                aliquota = 0.225;
                deducao = 675.49;
            }
            else
            {
                aliquota = 0.275;
                deducao = 908.73;
            }

            double irrf = baseCalculo * aliquota - deducao;
            return Math.Round(irrf > 0 ? irrf : 0, 2);
        }
    }
}
