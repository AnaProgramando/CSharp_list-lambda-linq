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
    // Garantindo que o método AdicionarVarios() seja acessado a partir da referência de uma lista, criando uma classe derivada do tipo List.cs e implementando nela o AdicionarVarios()
    // Derivando uma classe de List<int>, implementando AdicionarVarios(), estabelecendo params como argumento e chamando Add() no escopo, que foi definido em List<int>
    // Nesse caso de um método pontual, não é necessário criar uma classe derivada para estender o tipo List<T>, posto que em MinhaListaExtendida, somente é gerada uma classe que deriva de List<int>, para compor métodos auxiliares
    // Resolvido em ListExtensoes.cs

    //public class MinhaListaExtendida : List<int>
    //{
    //    public void AdicionarVarios(params int[] itens)
    //    {
    //        Add(1);
    //    }
    //}

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

            // Array de int utilizando a sintaxe de inicialização de array na qual não é necessário se preocupar com o número inicial de elementos, nem com a adição de item por item no array
            // idades.AddRange(new int[] { 1, 2, 3, 9 });

            // Facilitando o que foi feito com o AddRange, definindo idades sem a preocupação com a sinaxe de criar array, passar os índices e colocar colchetes ([])
            // ListExtensoes.AdicionarVarios(idades, 10, 20, 30, 40);

            // Otimizando o AdicionarVarios
            // Em ListExtensoes.cs o primeiro argumento de AdicionarVarios() é a listaDeInteiros, porém ela é o método que representa a classe estendendida, logo está implícito o argumento utilizado, o idades
            // Assim basta preencher a partir do segundo argumento,o params int[] itens
            // Adicionando as idades como argumento de AdicionarVarios()
            // AdicionarVarios() não é um método do tipo List<T> do .NET
            // AdicionarVarios() é um método de extensão criado em ListExtensoes.cs onde é indicada a extensão do tipo List<T> por meio da palavra reservada this antes do primeiro argumento

            idades.AdicionarVarios(10, 20, 30, 40);
            // Ao escrever a referência idades, seguida por AdicionarVarios() com seus argumentos, o compilador tranformará esses dados na chamada para o método estático
            // No argumento, será constatado this, logo nesse caso será colocada a referência usada (idades) como primeiro argumento e os números copiados e colados na sequência:
            // ListExtensoes.AdicionarVarios(idades, 10, 20, 30, 40); --> Como na linha 45

            // idades.Remove(4);

            // Tamanho é o Count, propriedade do .NET responsável pela contagem de itens que compõem a lista
            for (int i = 0 < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.ReadLine();
        }

        // O argumento params permite chamar AdicionarVarios() sem exigir a criação manual de um array
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
