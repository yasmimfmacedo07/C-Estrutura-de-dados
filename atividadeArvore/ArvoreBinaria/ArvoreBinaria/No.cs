using ArvoreBinaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    internal class No
    {
        public int Valor;
        public No Esquerda;
        public No Direita;

        public No(int valor)
        {
            Valor = valor;
            Esquerda = null;
            Direita = null;
        }
    }

    class ArvoreBinaria
    {
        public No Raiz;

        public No InserirFolha(No raiz, int chave)
        {
            if (raiz == null)
            {
                return new No(chave);
            }

            if (chave < raiz.Valor)
            {
                raiz.Esquerda = InserirFolha(raiz.Esquerda, chave);
            }

            else if (chave > raiz.Valor)
            {
                raiz.Direita = InserirFolha(raiz.Direita, chave);
            }
            return raiz;
        }

        public No Buscar(No raiz, int chave)
        {
            if (raiz == null || raiz.Valor == chave)
            {
                return raiz;
            }

            if (chave < raiz.Valor)
            {
                return Buscar(raiz.Esquerda, chave);
            }
            else
            {
                return Buscar(raiz.Direita, chave);
            }
        }
        public void ImprimirArvore(
        No raiz,
        string prefixo = "",
        bool ehEsquerda = true)
        {
            if (raiz == null)
                return;
            if (raiz.Direita != null)
            {
                ImprimirArvore(
                raiz.Direita,
                prefixo + (ehEsquerda ? "│ " : " "),
                false
                );
            }
            Console.WriteLine(
            prefixo + (ehEsquerda ? "└── " : "┌── ") + raiz.Valor
            );
            if (raiz.Esquerda != null)
            {
                ImprimirArvore(
                raiz.Esquerda,
                prefixo + (ehEsquerda ? " " : "│ "),
                true
                );
            }
        }

        //PRÉ ORDEM
        //1.Raiz.
        //2.Esquerda.
        //3.Direita
        public void PreOrdem(No raiz)
        {
            if (raiz == null) return;
            // APAGUE A LINHA "return;" QUE ESTÁ AQUI EMBAIXO!

            Console.Write(raiz.Valor + " ");

            PreOrdem(raiz.Esquerda);
            PreOrdem(raiz.Direita);
        }

        //EM ORDEM
        //1.Esquerda.
        //2.Raiz.
        //3.Direita.
        public void EmOrdem(No raiz)
        {
            if (raiz == null)
                return;

            EmOrdem(raiz.Esquerda);
            Console.Write(raiz.Valor + " ");
            EmOrdem(raiz.Direita);
        }

        //PÓS-ORDEM
        //1.Esquerda.
        //2.Direita.
        //3.Raiz.
        public void PosOrdem(No raiz)
        {
            if (raiz == null)
                return;
            PosOrdem(raiz.Esquerda);
            PosOrdem(raiz.Direita);
            Console.Write(raiz.Valor + " ");
        }

        public int ContarNos(No raiz)
        {
            if (raiz == null)
                return 0;

            return 1 + ContarNos(raiz.Esquerda) + ContarNos(raiz.Direita);
        }

        public int Altura(No raiz)
        {
            if (raiz == null)
                return -1;

            int alturaEsquerda = Altura(raiz.Esquerda);
            int alturaDireita = Altura(raiz.Direita);

            return 1 + Math.Max(alturaEsquerda, alturaDireita
            );
        }

        class Program
        {
            static void Main(string[] args)
            {
                ArvoreBinaria arvore = new ArvoreBinaria();
                // Inserir os valores
                int[] valores = { 50, 77, 25, 81, 62, 30, 20, 5, 7 };
                foreach (int valor in valores)
                {
                    arvore.Raiz =
                    arvore.InserirFolha(arvore.Raiz, valor);
                }
                // Imprimir a árvore
                Console.WriteLine("ARVORE BINARIA DE BUSCA");

                Console.WriteLine("=======================");
                arvore.ImprimirArvore(arvore.Raiz);
                // Pesquisar valores
                Console.WriteLine("\nPESQUISA");
                int chave1 = 61;
                No resultado1 = arvore.Buscar(arvore.Raiz, chave1);
                Console.WriteLine(
                resultado1 == null
                ? chave1 + " Não encontrado."
                : "Encontrado: " + resultado1.Valor
                );
                int chave2 = 81;
                No resultado2 = arvore.Buscar(arvore.Raiz, chave2);
                Console.WriteLine(
                resultado2 == null
                ? chave2 + " Não encontrado."
                : "Encontrado: " + resultado2.Valor
                );
                // Percursos
                Console.WriteLine("\nPERCURSOS");
                Console.Write("Pré-ordem: ");
                arvore.PreOrdem(arvore.Raiz);
                Console.Write("\nEm ordem: ");
                arvore.EmOrdem(arvore.Raiz);
                Console.Write("\nPós-ordem: ");
                arvore.PosOrdem(arvore.Raiz);
                // Contagem e altura
                Console.WriteLine("\n\nINFORMACOES DA ARVORE");
                Console.WriteLine(
                "Quantidade de nós: " +
                arvore.ContarNos(arvore.Raiz)
                );
                Console.WriteLine(
                "Altura da árvore: " +
                arvore.Altura(arvore.Raiz)
                );
                Console.WriteLine("\nPressione qualquer tecla para sair.");
                Console.ReadKey();
            }
        }
    }
}