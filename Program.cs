using System.Text;
using Hospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Listas para controle
List<Reserva> reservas = new();
List<Suite> suitesDisponiveis = new()
{
    new Suite("Standard", 2, 150),
    new Suite("Premium", 4, 300),
    new Suite("Luxo", 3, 450)
};

while (true)
{
    Console.Clear();
    Console.WriteLine("==== MENU PRINCIPAL ====");
    Console.WriteLine("[1] Cadastrar hóspede e reservar suíte");
    Console.WriteLine("[2] Ver hóspedes cadastrados");
    Console.WriteLine("[3] Ver suítes ocupadas");
    Console.WriteLine("[4] Ver suítes disponíveis");
    Console.WriteLine("[0] Sair");
    Console.Write("Escolha uma opção: ");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarHospede();
            break;

        case "2":
            VerHospedes();
            break;

        case "3":
            VerSuitesOcupadas();
            break;

        case "4":
            VerSuitesDisponiveis();
            break;

        case "0":
            Console.WriteLine("Saindo da aplicação...");
            return;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar...");
    Console.ReadKey();
}

// ===== FUNÇÕES =====

void CadastrarHospede()
{
    Console.Clear();
    Console.WriteLine("=== Cadastro de Hóspedes ===");
    Console.Write("Quantos hóspedes? ");
    if (!int.TryParse(Console.ReadLine(), out int qtdHospedes) || qtdHospedes <= 0)
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    List<Pessoa> hospedes = new();

    for (int i = 0; i < qtdHospedes; i++)
    {
        Console.Write($"Nome do hóspede #{i + 1}: ");
        string nome = Console.ReadLine();
        Console.Write($"Sobrenome do hóspede #{i + 1} (opcional): ");
        string sobrenome = Console.ReadLine();

        hospedes.Add(new Pessoa(nome, sobrenome));
    }

    Console.Write("Por quantos dias será a reserva? ");
    if (!int.TryParse(Console.ReadLine(), out int dias) || dias <= 0)
    {
        Console.WriteLine("Número de dias inválido.");
        return;
    }

    Console.WriteLine("\n--- Suítes Disponíveis ---");
    for (int i = 0; i < suitesDisponiveis.Count; i++)
    {
        Console.WriteLine($"[{i}] {suitesDisponiveis[i]}");
    }

    Console.Write("Escolha a suíte (número): ");
    if (!int.TryParse(Console.ReadLine(), out int indiceSuite) || indiceSuite < 0 || indiceSuite >= suitesDisponiveis.Count)
    {
        Console.WriteLine("Suíte inválida.");
        return;
    }

    try
    {
        Suite suiteEscolhida = suitesDisponiveis[indiceSuite];
        Reserva reserva = new(dias);
        reserva.CadastrarSuite(suiteEscolhida);
        reserva.CadastrarHospedes(hospedes);

        reservas.Add(reserva);
        suitesDisponiveis.RemoveAt(indiceSuite);

        Console.WriteLine("\nReserva concluída com sucesso!");
        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor total: R$ {reserva.CalcularValorDiaria():F2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao cadastrar reserva: {ex.Message}");
    }
}

void VerHospedes()
{
    Console.Clear();
    Console.WriteLine("=== Hóspedes Cadastrados ===");

    if (reservas.Count == 0)
    {
        Console.WriteLine("Nenhuma reserva encontrada.");
        return;
    }

    foreach (var reserva in reservas)
    {
        foreach (var hospede in reserva.Hospedes)
        {
            Console.WriteLine($"- {hospede.NomeCompleto}");
        }
    }
}

void VerSuitesOcupadas()
{
    Console.Clear();
    Console.WriteLine("=== Suítes Ocupadas ===");

    if (reservas.Count == 0)
    {
        Console.WriteLine("Nenhuma suíte ocupada.");
        return;
    }

    foreach (var reserva in reservas)
    {
        Console.WriteLine(reserva.Suite);
    }
}

void VerSuitesDisponiveis()
{
    Console.Clear();
    Console.WriteLine("=== Suítes Disponíveis ===");

    if (suitesDisponiveis.Count == 0)
    {
        Console.WriteLine("Nenhuma suíte disponível.");
        return;
    }

    foreach (var suite in suitesDisponiveis)
    {
        Console.WriteLine(suite);
    }
}
