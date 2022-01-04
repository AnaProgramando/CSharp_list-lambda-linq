using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.BancoVirtual.SistemaAgencia
{
    // ListExtensoes para as extensões da classe List do .Net
    // Criada a classe estática com métodos auxiliares para estender a classe List.cs e colocar o método funcionando na lista
    // static, pois somente armazenará extensões, não possuirá estado e nem será instanciada
    public static class ListExtensoes
    {
        // Coletar (varrendo) todos os elementos do array itens e adicionando cada um à listaDeInteiros
        // static, pois em uma classe estática, os membros também devem ser estáticos
        // Chamando um método de extensão, estendendo o tipo List<int> por meio de um método estático em uma classe estática e inserindo o tipo que será estendido como argumento
        // AdicionarVarios() é um método de extensão onde é indicada a extensão do tipo List<T> por meio da palavra reservada this antes do primeiro argumento
        // No momento a lógica implementada em ListExtensoes.cs só funciona com List<int>, logo não funciona com qualquer lista
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            // foreach() não traz o índice, mas não é necessário aqui
            // Varrendo item por item, atribuindo uma ação para cada um deles
            foreach (int item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }
    }
}
