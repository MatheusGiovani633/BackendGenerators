namespace BackendGenerators.Helpers
{
    using BackendGenerators.Models;
    public class Helpers
    {
        private static readonly Random _random = new();
        public static Pessoa CriarFisica()
        {
            return new Pessoa
            {
                Nome = "Teste" + _random.Next(1, 1000),
                Identificador = _random.Next(1, 10000),
                Razaosocial = null,
                Email = "Teste" + _random.Next(1, 1000) + "@email.com",
                Telefone = "(51)" + _random.Next(3000, 4000) + "-" + _random.Next(1000, 9999),
                Celular = "(51)" + _random.Next(3000, 4000) + "-" + _random.Next(1000, 9999),
                Celular2 = "(51)" + _random.Next(3000, 4000) + "-" + _random.Next(1000, 9999),
                Cpf = GerarCpfValido(),
                Cnpj = null,
                DataNascimento = DateTime.Now.AddYears(-_random.Next(18, 70)).AddDays(_random.Next(0, 365)),
                Sexo = _random.Next(0, 2) == 0,
                Cep = _random.Next(90000, 99999) + "-" + _random.Next(900, 999).ToString(),
                Logradouro = "Rua " + _random.Next(1, 1000),
                Numero = _random.Next(1, 1000).ToString(),
                Cidade = "Cidade " + _random.Next(1, 100),
                Estado = "Estado " + _random.Next(1, 50),
                Complemento = "Complemento " + _random.Next(1, 100),
                Bairro = "Bairro " + _random.Next(1, 100),
                InscricaoEstadual = null,
                InscricaoMunicipal = null,
                TipoCNPJ = 0
            };
        }

        public static Pessoa CriarJuridica()
        {
            return new Pessoa
            {
                Nome = "TesteJuridico" + _random.Next(1, 1000),
                Identificador = _random.Next(1, 10000),
                Razaosocial = "TesteJuridico" + _random.Next(1, 1000),
                Email = "Teste" + _random.Next(1, 1000) + "@email.com",
                Telefone = "(51)" + _random.Next(3000, 4000) + "-" + _random.Next(1000, 9999),
                Celular = "(51)" + _random.Next(3000, 4000) + "-" + _random.Next(1000, 9999),
                Celular2 = "(51)" + _random.Next(3000, 4000) + "-" + _random.Next(1000, 9999),
                Cpf = null,
                Cnpj = GerarCnpjValido(),
                DataNascimento = DateTime.Now.AddYears(-_random.Next(18, 70)).AddDays(_random.Next(0, 365)),
                Sexo = _random.Next(0, 2) == 0,
                Cep = _random.Next(90000, 99999) + "-" + _random.Next(900, 999).ToString(),
                Logradouro = "Rua " + _random.Next(1, 1000),
                Numero = _random.Next(1, 1000).ToString(),
                Cidade = "Cidade " + _random.Next(1, 100),
                Estado = "Estado " + _random.Next(1, 50),
                Complemento = "Complemento " + _random.Next(1, 100),
                Bairro = "Bairro " + _random.Next(1, 100),
                InscricaoEstadual = _random.Next(10000000, 99999999).ToString(),
                InscricaoMunicipal = null,
                TipoCNPJ = _random.Next(1, 5)
            };
        }
        public static Medico CriarMedico()
        {
            return new Medico
            {
                CRM = _random.Next(10000, 99999),
            };
        }
        private static string GerarCpfValido()
        {
            var rand = new Random();
            int[] cpf = new int[11];
            for (int i = 0; i < 9; i++) cpf[i] = rand.Next(0, 10);
            int soma = 0;
            for (int i = 0; i < 9; i++) soma += cpf[i] * (10 - i);
            int resto = soma % 11;
            cpf[9] = resto < 2 ? 0 : 11 - resto;
            soma = 0;
            for (int i = 0; i < 10; i++) soma += cpf[i] * (11 - i);
            resto = soma % 11;
            cpf[10] = resto < 2 ? 0 : 11 - resto;
            return string.Join("", cpf);
        }

        private static string GerarCnpjValido()
        {
            var rand = new Random();
            int[] cnpj = new int[14];
            for (int i = 0; i < 12; i++) cnpj[i] = rand.Next(0, 10);
            int soma = cnpj[0] * 5 + cnpj[1] * 4 + cnpj[2] * 3 + cnpj[3] * 2 + cnpj[4] * 9 + cnpj[5] * 8 + cnpj[6] * 7 + cnpj[7] * 6 + cnpj[8] * 5 + cnpj[9] * 4 + cnpj[10] * 3 + cnpj[11] * 2;
            int resto = soma % 11;
            cnpj[12] = resto < 2 ? 0 : 11 - resto;
            soma = cnpj[0] * 6 + cnpj[1] * 5 + cnpj[2] * 4 + cnpj[3] * 3 + cnpj[4] * 2 + cnpj[5] * 9 + cnpj[6] * 8 + cnpj[7] * 7 + cnpj[8] * 6 + cnpj[9] * 5 + cnpj[10] * 4 + cnpj[11] * 3 + cnpj[12] * 2;
            resto = soma % 11;
            cnpj[13] = resto < 2 ? 0 : 11 - resto;
            return string.Join("", cnpj);
        }
    }
}
