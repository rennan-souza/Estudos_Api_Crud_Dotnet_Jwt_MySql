using System.ComponentModel.DataAnnotations;

namespace MeuProjeto.Validations
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cpf = value.ToString();

                if (!ValidarCPF(cpf))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }

        private bool ValidarCPF(string cpf)
        {
            // Remove todos os caracteres não numéricos do CPF
            string cpfNumerico = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos
            if (cpfNumerico.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais
            if (cpfNumerico.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int digitoVerificador1 = CalcularDigitoVerificador(cpfNumerico.Substring(0, 9));

            // Calcula o segundo dígito verificador
            int digitoVerificador2 = CalcularDigitoVerificador(cpfNumerico.Substring(0, 9) + digitoVerificador1.ToString());

            // Verifica se os dígitos verificadores calculados são iguais aos dígitos verificadores informados no CPF
            if (digitoVerificador1.ToString() != cpfNumerico[9].ToString() || digitoVerificador2.ToString() != cpfNumerico[10].ToString())
            {
                return false;
            }

            return true;
        }

        private int CalcularDigitoVerificador(string parteCpf)
        {
            int soma = 0;

            for (int i = 0; i < parteCpf.Length; i++)
            {
                soma += int.Parse(parteCpf[i].ToString()) * (parteCpf.Length + 1 - i);
            }

            int resto = soma % 11;

            if (resto < 2)
            {
                return 0;
            }

            return 11 - resto;
        }
    }
}
