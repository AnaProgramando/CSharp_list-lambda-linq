﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humanizer;
using System.Threading.Tasks;
using CSharp.BancoVirtual.Modelos;
using CSharp.BancoVirtual.Modelos.Funcionarios;
using CSharp.BancoVirtual.SistemaAgencia;
using CSharp.BancoVirtual.SistemaAgencia.Extensoes;
using CSharp.BancoVirtual.SistemaAgencia.Comparadores;

namespace CSharp.BancoVirtual.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(123, 12341),
                null,
                new ContaCorrente(123, 12342),
                new ContaCorrente(123, 12343),
                null,
                new ContaCorrente(123, 12343),
                new ContaCorrente(123, 1),
                new ContaCorrente(123, 99999),
                null
            };

            // contas.Sort();       --> Chamar a implementação dada em IComparable

            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            // conta => conta.Numero --> É uma expressão lambda
            // IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            // --------------------------------------------

            // if (conta == null)
            //     {
            //          Retorna as contas nulas depois
            //          return int.MaxValue;
            //     }
            //          return conta.Numero;
            //     });

            // --------------------------------------------

            // if (conta == null)
            //     {
            //          Retorna as contas nulas antes
            //          return int.MinValue;
            //     }
            //          return conta.Numero;
            //     });                    

            // ----------------------------

            // Imprime as contas nulas

            //foreach (var conta in contasOrdenadas)
            //{
            //    if (conta == null)
            //    {
            //        Console.WriteLine("Conta nula");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Conta número {conta.Numero}, agência {conta.Agencia}.");
            //    }
            //}

            // ----------------------------

            // Não imprime as contas nulas


            // ---------------------------- contasOrdenadas

            // foreach (var conta in contasOrdenadas)
            //     {
            //          if (conta != null)
            //          {
            //              Console.WriteLine($"Conta número {conta.Numero}, agência {conta.Agencia}.");
            //           }
            //     }

            // IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            // ---------------------------- listaSemNulos

            // var listaSemNulos = new List<ContaCorrente>();
            // foreach (var conta in contas)
            // {
            //      if (conta != null)
            //      {
            //          listaSemNulos.Add(conta);
            //      }

            // IOrderedEnumerable<ContaCorrente> contasOrdenadas = listaSemNulos.OrderBy(conta => conta.Numero);

            // ---------------------------- contasNaoNulas

            // var contasNaoNulas = contas.Where(conta => conta != null);

            // O IOrderedEnumerable deve ser preenchido dessa forma: public interface IOrderedEnumerable<TElement> : IEnumerable<TElement>, IEnumerable

            // Isso:
            // IOrderedEnumerable<ContaCorrente> contasOrdenadas = contasNaoNulas.OrderBy<ContaCorrente, int>(conta => conta.Numero);

            // É igual a isso, porém aqui o "ContaCorrente, int" foram inferidos:
            // IOrderedEnumerable<ContaCorrente> contasOrdenadas = contasNaoNulas.OrderBy(conta => conta.Numero);

            // Aqui fiz o encadeamento do Where: var contasNaoNulas = contas.Where(conta => conta != null);
            // Com o OrderBy: IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);
            // conta => conta.Numero --> É uma expressão lambda
            // conta => conta != null --> É uma expressão lambda que retorna booleano
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, agência {conta.Agencia}.");
            }

            Console.ReadLine();
        }

        static void TestListExtendVarSort()
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

            // ----------------------------------------------------------------------------------------------

            // _Teste de var - Chamando construtor da classe_

            //ContaCorrente conta = new ContaCorrente(123, 12345678);
            //GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();
            //List<GerenciadorBonificacao> gerenciadores = new List<GerenciadorBonificacao>();

            // Com o var é como dizer ao compilador que desejo armazenar o nome do tipo que há na expressão da atribuição no var
            // O compilador entende que "var" refere-se ao tipo atribuído, encontrado à direita do sinal de igual(=)
            // Usar o var deixa o código mais elegante, mais legível e sem repetição de nome de classe (inclusive das genéricas), que possuem nomes mais complicados
            // var conta = new ContaCorrente(123, 12345678);
            // var gerenciador = new GerenciadorBonificacao();
            // var gerenciadores = new List<GerenciadorBonificacao>();

            // conta.Depositar(321);

            // Console.WriteLine(conta);

            // Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            // _Teste de var - Com outro método_

            // var resultado = SomarVarios(2, 4, 6);

            // Console.WriteLine("Teste de somar vários: " + resultado);

            // Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            // _Teste de var - Literais da linguagem_

            // É o mesmo que:    int numIdade = 12;
            // var numIdade = 12;           
            // Console.WriteLine("Teste de var para int: " + numIdade);

            // É o mesmo que:    string nomeTeste = "Nome Teste";
            // var nomeTeste = "Nome Teste";
            // Console.WriteLine("Teste de var para srting: " + nomeTeste);

            // Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            // _Teste do Sort() - Nomes_

            var nomes = new List<string>()
            {
                "Fulano",
                "Sicrano",
                "Beltrano",
                "Ana"
            };

            // Ordenando a lista de nomes
            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            // ----------------------------------------------------------------------------------------------

            // Classe genérica List permite o uso do int como argumento genérico
            // Alterado de: List<int> idades = new List<int>(); | Para: var idades = new List<int>();
            var idades = new List<int>();

            // É criada uma lista genérica com método genérico que espera um argumento de tipo genérico
            // Add é o Adicionar
            idades.Add(2);
            idades.Add(4);
            idades.Add(6);
            idades.Add(8);
            idades.Add(10);
            idades.Add(12);

            // Remover o idades.Add(4)
            // idades.Remove(4);

            // Array de int utilizando a sintaxe de inicialização de array na qual não é necessário se preocupar com o número inicial de elementos, nem     com a     adição de item por item no array
            // idades.AddRange(new int[] { 1, 2, 3, 9 });

            // Facilitando o que foi feito com o AddRange, definindo idades sem a preocupação com a sinaxe de criar array, passar os índices e colocar      colchetes    ([])
            // ListExtensoes.AdicionarVarios(idades, 10, 20, 30, 40);

            // Otimizando o AdicionarVarios
            // Em ListExtensoes.cs o primeiro argumento de AdicionarVarios() é a listaDeInteiros, porém ela é o método que representa a classe  estendendida,    logo   está implícito o argumento utilizado, o idades
            // Assim basta preencher a partir do segundo argumento,o params int[] itens
            // Adicionando as idades como argumento de AdicionarVarios()
            // AdicionarVarios() não é um método do tipo List<T> do .NET
            // AdicionarVarios() é um método de extensão criado em ListExtensoes.cs onde é indicada a extensão do tipo List<T> por meio da palavra  reservada    this   antes do primeiro argumento

            // idades.AdicionarVarios(10, 20, 30, 40);
            // Ao escrever a referência idades, seguida por AdicionarVarios() com seus argumentos, o compilador tranformará esses dados na chamada para o     método    estático
            // No argumento, será constatado this, logo nesse caso será colocada a referência usada (idades) como primeiro argumento e os números copiados   e      colados na sequência:
            // ListExtensoes.AdicionarVarios(idades, 10, 20, 30, 40); --> Como na linha 45

            ListExtensoes.AdicionarVarios(idades, 20, 30, 40);

            // idades.AdicionarVarios(99, -1);

            // ----------------------------------------------------------------------------------------------

            // _Teste do Sort() - Números_

            // Ordenando a lista de idades
            idades.Sort();

            // Tamanho é o Count, propriedade do .NET responsável pela contagem de itens que compõem a lista
            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.ReadLine();
        }


        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar("texto teste");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestaListaDeContaCorrente()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaAna = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaAna,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaAna,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void TestaArrayDeContaCorrente()
        {
            Console.WriteLine("_Inicializador de array_");

            // Sintaxe: 
            // Tipo (ContaCorrente)
            // par de colchetes []
            // nome
            // Atribuição de valor (new)

            // Colocar o número de conta correntes desejado "new ContaCorrente[3]", ou deixar vazio e fazer com {} da forma abaixo
            // Mantendo o número dentro dos colchetes [], surge o erro "System.NullReferenceException" ao mudar a quantidade de referências, pois o o número de posições do array será equivalente ao número de atribuições realizadas
            // Ao criar o array as posições adquirem o valor padrão do tipo do array, logo recebe várias referências nulas, pois ContaCorrente é um tipo de referência, e o valor padrão de todo tipo de referência é o nulo

            // Array de conta-corrente, pois existe a classe (o tipo) ContaCorrente, logo não é necessário de criar um array para o número da conta, número da agência e saldo
            // Criando uma referência para um array de conta-corrente

            // Da forma abaixo é criada cada conta-corrente individualmente, e os objetos apenas possuem uma referência para eles no array, logo o código fica se repetindo
            // ContaCorrente[] contas = new ContaCorrente[3];
            // contas[0] = new ContaCorrente(123, 1234567);
            // contas[1] = new ContaCorrente(123, 1234568);
            // contas[2] = new ContaCorrente(123, 1234569);

            // A melhor forma de fazer é utilizando um açúcar sintático "inicialização de arrays" do C# para facilitar a criação dos arrays
            // Não é necessário identificar o número de itens do array para em seguida acessar os valores em cada índice e fazer as atribuições, basta usar as chaves {} e preenchê-la com os valores para cada posição
            ContaCorrente[] contas = new ContaCorrente[]
            {
                // Preenchendo o array com os números de agência e conta
                new ContaCorrente(123, 1234567),
                new ContaCorrente(123, 1234568),
                new ContaCorrente(123, 1234569),
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                // Ao invés de armazenar em uma variável o valor que está armazenado no índice do array:
                // Console.WriteLine($"Conta {indice} {contas[indice].Numero}");

                // É possível escrever uma expressão que retorna uma conta-corrente, acessando um valor do array e colocando o ponto "." para navegar para a propriedade Numero
                // A variável contaAtual recebe a referência de contas no indice da variável do loop, não é necessário escrever um código longo na interpolação da string, assim acesso a nova variável, a contaAtual
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ----------------------------------------------------------------------------------------------

            // Criação de variável:
            // Declaração de variável = Atribuição de valor
            // int numTeste = 15

            // ----------------------------------------------------------------------------------------------

            //int numTeste = 15;
            //int numTeste_2 = 28;
            //int numTeste_3 = 35;
            //int numTeste_4 = 50

            // Não é possível calcular a média das números de teste (numTeste) com o laço de repetição como o exemplo abaixo, pois não podemos acessar uma variável tentando juntá-la como uma string até completar o que seria o nome da variável dessa forma. O compilador precisa conhecer a variável, e a forma como as posições das variáveis foram apontadas não funciona.

            // for(int indice = 1; indice <= 5; indice++)
            // {
            //     media += numTeste[indice];
            // }

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_ARRAY de inteiros com 5 posições - De 0 a 4_");

            // Diferente dos inteiros, o array não é um tipo de valor, mas sim um tipo de referência

            // Manipulando vários dados e valores que compartilham o mesmo significado e possuem o mesmo contexto

            // Criado um objeto de array na memória do computador "new int[5]", tendo uma referência para o objeto a partir da variável "numTeste"

            // Guardando valores em posições específicas que estão indexadas na variável
            //  int[] para representar os números inteiros nas posições com acesso por meio de índices
            // Não é possível usar a variável numTeste sem que ela receba um valor, e numTeste não é um número inteiro, mas um conjunto
            // new int[] para atribuição de valores
            // int[5] informando ao compilador sobre a criação da variável que irá suportar diversos valores do tipo inteiro, no caso são cinco numTeste's, ou seja, cinco valores para colocar no pedaço de memória criado
            int[] numTeste = new int[5];

            // Os colchetes especificam os índices atribuindos para numTeste

            // Não é possível começar direto com [1], o índice fica fora dos limites da matriz, pois toda string começa a partir do índice 0 em C#, e essa característica se repete nos arrays. Exemplo:
            // texto
            // 01234
            // O índice "t" é 0, índice "e" o 1, e assim por diante

            numTeste[0] = 15;
            numTeste[1] = 28;
            numTeste[2] = 35;
            numTeste[3] = 50;
            numTeste[4] = 55;


            Console.WriteLine("Número informado no índice 0: " + numTeste[0]);
            Console.WriteLine("Número informado no índice 1: " + numTeste[1]);
            Console.WriteLine("Número informado no índice 2: " + numTeste[2]);
            Console.WriteLine("Número informado no índice 3: " + numTeste[3]);
            Console.WriteLine("Número informado no índice 4: " + numTeste[4]);

            Console.WriteLine("");
            Console.WriteLine("Aperte o Enter para continuar >>");

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Manipulação de ARRAY de inteiros com 4 posições - De 0 a 3_");

            // Criado um objeto de array na memória do computador "new int[5]", tendo uma referência para o objeto a partir da variável "Numtestes"

            int[] NumtesteDois = new int[5];
            NumtesteDois[0] = 91;
            NumtesteDois[1] = 81;
            NumtesteDois[2] = 71;

            // O compilador não aponta erro pela linha que atribui o valor na posição 3 do array estar comentada, pois não há verificação se os índices foram respeitados, ou seja, se há valor em todas as posições
            // O programa não irá imprimir "61", mas sim o "0", pois 0 é o valor padrão do inteiro
            // Numtestes[3] = 61;

            Console.WriteLine("Número informado no índice 0 de teste: " + NumtesteDois[0]);
            Console.WriteLine("Número informado no índice 1 de teste: " + NumtesteDois[1]);

            // Acessando a posição [2], guardando em uma variável para realizar a manipulação, não apenas mostrando na tela

            // int não é um tipo de referência como o Array, mas sim um tipo de valor
            // Aqui NumtestesNoIndice2 recebe um valor do array, acessa a posição 2, pega nela o valor 22 e atribui (copia) para a variável
            // Tipo_da_variavel nome_da_variavel = recebendo_o_array[acessando_o_valor_na_posição_2]
            int NumtestesNoIndice2 = NumtesteDois[2];

            Console.WriteLine("Número informado no índice 2 guardado em uma variável: " + NumtestesNoIndice2);

            int NumtestesNoIndice3 = NumtesteDois[3];
            Console.WriteLine("Número informado no índice 3, mas com a linha que atribui um valor na posição 3 do array comentada: " + NumtestesNoIndice3);

            Console.WriteLine("");
            Console.WriteLine("Aperte o Enter para continuar >>");

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Referência para o objeto de array a partir da variável outroArray_");

            // Criado um objeto de array na memória do computador "new int[5]", tendo uma referência para o objeto a partir da variável "outroArray"

            // Criando um novo array para acessar a posição [1] Numtestes
            int[] outroArray = NumtesteDois;
            Console.WriteLine("Número informado no índice 1 de teste a partir de um novo array: " + outroArray[1]);

            Console.WriteLine("");
            Console.WriteLine("Aperte o Enter para continuar >>");

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste da variável recebendo uma referência nula_");

            // Variável NumtesteTres recebendo uma referência nula

            // Com NumtesteTres recebendo uma referência nula, não é possível saber em que lugar da memória os valores (110, 111 e 112) estarão guardados e não haverá um lugar para acessar os índices
            // Ao executar o programa aparece a mensagem: System.NullReferenceException: 'Referência de objeto não definida para uma instância de um objeto.'
            int[] NumtesteTres = null;

            // Para fazer a aplicação executar é necessário fazer com que a variável NumtesteTres receba uma referência de um novo array de inteiros
            NumtesteTres = new int[5];

            NumtesteTres[0] = 110;
            NumtesteTres[1] = 111;
            NumtesteTres[2] = 112;

            Console.WriteLine("Número informado no índice 0: " + NumtesteTres[0]);
            Console.WriteLine("Número informado no índice 1: " + NumtesteTres[1]);
            Console.WriteLine("Número informado no índice 2: " + NumtesteTres[2]);

            Console.WriteLine("");
            Console.WriteLine("Aperte o Enter para continuar >>");

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_ARRAY de Boleanos_");

            // Tipo_da_variavel (bool[]) nome_da_variavel (arrayDeBoleanos) = criando_array_na_memória_do_computador (new) tipo (bool) trabalhando_com_quantidade_de_boleanos ([3])
            bool[] arrayDeBoleanos = new bool[3];

            arrayDeBoleanos[0] = true;
            arrayDeBoleanos[1] = false;
            arrayDeBoleanos[2] = false;

            Console.WriteLine("Retorno informado no índice 0: " + arrayDeBoleanos[0]);
            Console.WriteLine("Retorno informado no índice 1: " + arrayDeBoleanos[1]);
            Console.WriteLine("Retorno informado no índice 2: " + arrayDeBoleanos[2]);

            Console.WriteLine("");
            Console.WriteLine("Aperte o Enter para continuar >>");

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_ARRAY - Testes de acessos por meio de índices");

            // Índice é uma expressão que retorna um número inteiro

            int[] NumtesteIndice = new int[4];

            NumtesteIndice[0] = 200;
            NumtesteIndice[1] = 201;
            NumtesteIndice[2] = 202;
            NumtesteIndice[3] = 203;

            Console.WriteLine("Retorno com array recebendo o índice 0: " + NumtesteIndice[0]);

            int NumtesteIndiceNoIndiceUm = NumtesteIndice[1];
            Console.WriteLine("Retorno guardado em uma variável recebendo o índice 1 no NumtesteIndice: " + NumtesteIndiceNoIndiceUm);

            int indiceTesteDois = 2;
            Console.WriteLine("Retorno guardado em outra variável recebendo 2 no indiceTesteDois: " + NumtesteIndice[indiceTesteDois]);

            int indiceTesteTres = NumtesteIndice[2 + 1];
            Console.WriteLine("Retorno guardado em outra variável recebendo a soma de 2 + 1 no indiceTesteTres: " + indiceTesteTres);

            Console.WriteLine("");
            Console.WriteLine("Aperte o Enter para continuar >>");

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_ARRAY - Calculando média_");

            int[] NumtesteIdades = new int[6];
            NumtesteIdades[0] = 13;
            NumtesteIdades[1] = 23;
            NumtesteIdades[2] = 43;
            NumtesteIdades[3] = 53;
            NumtesteIdades[4] = 63;
            NumtesteIdades[5] = 73;

            // A propriedade Length representa o número de elementos que o array possui

            // Será impresso na tela o tamanho do array criado, no caso 6
            Console.WriteLine("O tamanho do ARRAY é de " + NumtesteIdades.Length + " posições.");
            Console.WriteLine("");

            // Variável acumuladora
            int acumulador = 0;

            // Laço de repetição aumentando o indiceIdades
            // Começando pela primeira posição, o NumtesteIdades[0]
            // Indo até e incluindo o NumtesteIdades[4]
            // Incrementa o indiceIdades
            // Usando a propriedade Length, não é necessário usar o "<= 6", pois calcula sozinho o tamanho do array
            // Nesse caso, como o Lenght irá retornar 6 e o índice na posição 6 vai apontar para um valor que não existe na memória, não usei o "<=", e sim o "<"
            for (int indiceIdades = 0; indiceIdades < NumtesteIdades.Length; indiceIdades++)
            {
                int idades = NumtesteIdades[indiceIdades];

                // Coloquei o $ e {} para interpolar a string e simplificar a concatenação
                Console.WriteLine($"Acessando o array idades no índice {indiceIdades}.");

                Console.WriteLine($"Valor de idades[{indiceIdades}] = {idades}");
                Console.WriteLine("");

                acumulador += idades;
            }

            // Ao invés de dividir o acumulador por 6, basta utilizar a propriedade Length junto ao nome da variável do array.
            // Assim mesmo que sejam adicionados novos elementos ao array, não é necessário contar quantos são e mexer no divisor da média, ele calculará corretamente contando automáticamente o total de elementos do array
            int media = acumulador / NumtesteIdades.Length;

            Console.WriteLine($"A média das idades é: {media}.");

            Console.ReadLine();
        }
    }
}
