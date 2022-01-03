using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.BancoVirtual.Modelos;
using CSharp.BancoVirtual.Modelos.Funcionarios;
using Humanizer;

namespace CSharp.BancoVirtual.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Classe genérica List permite o uso do int como argumento genérico
            List<int> idades = new List<int>();

            // É criada uma lista genérica com método genérico que espera um argumento de tipo genérico
            // Add é o Adicionar
            idades.Add(2);
            idades.Add(4);
            idades.Add(6);
            idades.Add(8);
            idades.Add(10);
            idades.Add(12);

            idades.AddRange

            // idades.Remove(4);

            // Tamanho é o Count, propriedade do .NET responsável pela contagem de itens que compõem a lista
            for (int i = 0 < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.ReadLine();
        }
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Add(item);
            }
        }

        Console.ReadLine();
    }
}
