using System;
using System;

class Program
{
    static void Main()
    {
        string[] alunos =
        {
            "Ana",
            "Bruno",
            "Carlos",
            "Daniela",
            "Eduardo"
        };

        Console.WriteLine("=== LISTA DE ALUNOS ===");
        for (int i = 0; i < alunos.Length; i++)
        {
            Console.WriteLine($"{i} - {alunos[i]}");
        }

        Console.WriteLine();
        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine();

        int indiceLinear = BuscarLinear(alunos, nome);
        int indiceBinario = BuscarBinario(alunos, nome);

        Console.WriteLine("================================");
        Console.WriteLine("RESULTADO DA PESQUISA");
        Console.WriteLine("================================");

        if (indiceLinear != -1)
        {
            Console.WriteLine($"Pesquisa Linear: aluno encontrado no índice {indiceLinear}.");
        }
        else
        {
            Console.WriteLine("Pesquisa Linear: aluno não encontrado.");
        }

        if (indiceBinario != -1)
        {
            Console.WriteLine($"Pesquisa Binária: aluno encontrado no índice {indiceBinario}.");
        }
        else
        {
            Console.WriteLine("Pesquisa Binária: aluno não encontrado.");
        }
    }

    static int BuscarLinear(string[] alunos, string nome)
    {
        for (int i = 0; i < alunos.Length; i++)
        {
            if (alunos[i].Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }

    static int BuscarBinario(string[] alunos, string nome)
    {
        int esquerda = 0;
        int direita = alunos.Length - 1;

        while (esquerda <= direita)
        {
            int meio = (esquerda + direita) / 2;

            int comparacao = string.Compare(
                alunos[meio],
                nome,
                StringComparison.OrdinalIgnoreCase);

            if (comparacao == 0)
            {
                return meio;
            }
            else if (comparacao < 0)
            {
                esquerda = meio + 1;
            }
            else
            {
                direita = meio - 1;
            }
        }
        return -1;
    }
}