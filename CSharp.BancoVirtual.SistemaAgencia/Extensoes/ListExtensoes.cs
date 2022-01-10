using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.BancoVirtual.SistemaAgencia.Extensoes
{
    // ListExtensoes para as extensões da classe List do .Net
    // Criada a classe estática com métodos auxiliares para estender a classe List.cs e colocar o método funcionando na lista
    // static, pois somente armazenará extensões, não possuirá estado e nem será instanciada
    // Tornando o método genérico, definindo o tipo genérico na classe com o <T>

    // A classe não será mais genérica: public static class ListExtensoes<T>
    public static class ListExtensoes
    {
        // Coletar (varrendo) todos os elementos do array itens e adicionando cada um à listaDeInteiros
        // static, pois em uma classe estática, os membros também devem ser estáticos
        // Chamando um método de extensão, estendendo o tipo List por meio de um método estático em uma classe estática e inserindo o tipo que será estendido como argumento

        // AdicionarVarios() é um método de extensão onde é indicada a extensão do tipo List por meio da palavra reservada this antes do primeiro argumento

        // List<> - É necessária a existência da lista, pois ela possui o método Adicionar
        // Lista<int> - Usando o int torna possível a utilização apenas em lista de inteiros
        // List<T> - Para uso em outros tipos de lista, como int, string e ContaCorrente

        // params int[] itens - Para deixar o array com travado apenas para int
        // params T[] itens - Deixando o array para todos os tipos

        // Ao utilizar um método de extensão é necessário inserir o this no começo do primeiro argumento
        // public static void AdicionarVarios(this List<T> lista, params T[] itens) - Vou remover o this para não aparecer que se trata de um método de extensão
        // Tornando o método genérico adicionando o <T>, sendo o "T" uma convenção para nomear o tipo de argumento genérico
        // É possível ter um método genérico dentro de uma classe normal
        public static void AdicionarVarios<T>(List<T> lista, params T[] itens)
        {
            // foreach() não traz o índice, mas não é necessário aqui
            // Varrendo item por item, atribuindo uma ação para cada um deles
            // foreach (int item in itens) - Removendo o int para travar apenas com um tipo
            foreach (T item in itens)
            {
                // O tipo genérico da classe ( public static class ListExtensoes<T> ), é o mesmo tipo genérico da lista ( this List<T> lista ), tornando possível chamar o método Add com o item do array ( T[] )
                // O Add espera o T, sem determinar que precisa ser string ou int, mas que o tipo recebido no array ( T[] ) será o mesmo tipo compativel com a lista, logo será um tipo que pode ser usado no método Add
                lista.Add(item);
            }
        }

        // ----------------------------------------------------------------------------------------------

        // Teste de sintaxe
        // Argumento genérico T2
        // Método de extensão de string
        public static void TesteGenerico<T2>(this string texto)
        {

        }

        // ----------------------------------------------------------------------------------------------

        static void Teste()
        {
            // Chamando o método e testando sintaxe

            // Em função da definição na classe, é necessário sempre escrever o nome dela e informar ao compilador qual tipo utilizado na classe genérica
            // O compilador do C# sabe qual é o argumento da classe genérica ListExtensoes<int> ao definir que se trata de uma lista de int com <int>, não porque o método AdicionarVarios() é genérico, mas porque há uma classe definida como genérica, a ListExtensoes<T>
            List<int> idades = new List<int>();

            idades.Add(12);
            idades.Add(22);
            idades.Add(44);

            // Sendo um método normal, não um de extensão, para chamar o AdicionarVarios é neessário escrever o nome da classe genérica (ListExtensoes),
            // indicar o tipo genérico ( <int> ), pois nesse caso se trata de uma lista de inteiros, para preencher o T (em List<T> ) do argumento do método AdicionarVarios,
            // Chamando o método AdicionarVarios
            // (o primeiro argumento é uma lista de inteiros, o segundo argumento é um array params de inteiros)
            // O método recebe uma lista do respectivo tipo definido como argumento, ou seja, uma lista de inteiros
            // A chamada abaixo deixou de fazer sentido quando a classe ListExtensoes deixou de ser genérica
            // ListExtensoes<int>.AdicionarVarios(idades, 2, 4, 6);

            // Chamando o AdicionarVarios que é um método genérico, então é necessário colocar o tipo
            // Não é preciso escrever AdicionarVarios<int>, pois o tipo genérico T do método (AdicionarVarios<T>), é o mesmo tipo T da lista (List<T> lista), logo o compilador entende que o AdicionarVarios abaixo vai virar o AdicionarVarios de tipo genérico de int
            // () - Não é necessário preencher exatamanete o primeiro argumento, porque o primeiro argumento de um método de extensão é o objeto, a referência que está sendo extendida, no caso o "idades", então basta preencher os próximos argumentos, no caso as idades
            // idades.AdicionarVarios(33, 66, 88, 99);

            // -------------------------------------

            // TesteGenerico

            string ana = "Ana";

            // O TesteGenerico é um método genérico, então é necessário preencher o argumento genérico
            // É necessário preencher como <int>, pois a string não é uma classe genérica ( TesteGenerico<T2>(this string texto) ), logo ela não trará nehuma informação para o compilador que o tipo genérico da classe é o mesmo tipo genérico do método
            ana.TesteGenerico<int>();

            // -------------------------------------

            // O compilador do C# sabe qual é o argumento da classe genérica ListExtensoes<string> ao definir que se trata de uma lista de int com <string>, não porque o método AdicionarVarios() é genérico, mas porque há uma classe definida como genérica, a ListExtensoes<T>
            List<string> nomes = new List<string>();

            // É possível utilizar string como argumento de nome.Add(), pois é o tipo genérico definido em List<string>
            nomes.Add("Ana");
            nomes.Add("Beatriz");

            // Chamando o AdicionarVarios
            // O argumento genérico é o tipo string
            // O argumento List<T> é um List string
            // Chamando o AdicionarVarios com uma lista de string com os nomes
            // O mesmo para AdicionarVarios() recebe string como argumento, pois o compilador sabe que esse método aguarda esse tipo que foi definido em ListExtensoes<string>
            // A chamada abaixo deixou de fazer sentido quando a classe ListExtensoes deixou de ser genérica
            // ListExtensoes<string>.AdicionarVarios(nomes, "Fulano", "Beltrano");

            // A ideia do método de extensão é que não seja necessário utilizar o nome de classe para fazer as chamadas de AdicionarVarios(), e fazer com que AdicionarVarios() pareça o método da respectiva classe
            // Aqui o argumento string é carregado pelo nome da classe(ListExtensoes<string>), mas da forma abaixo, a informação não é passada, e o código não é compilado, deixando AdicionarVarios() sublinhado em vermelho
            // Assim ao tentar criar um método de extensão em uma classe estática, o compilador apontará erro na declaração da classe
            // Se o método de extensão AdicionarVarios() estivesse em uma classe genérica, a chamada dele dependeria dessa classe, com o tipo especificado, logo não teria sentido utilizar a sintaxe de método de extensão, por isso deletei <T> da declaração da classe ListExtensoes na linha 15, porém o compilador não saberá mais ao que o tipo <T> de List<T> e do array T[] se refere
            // nomes.AdicionarVarios("Sicrano", "Fulana");
        }
    }
}
