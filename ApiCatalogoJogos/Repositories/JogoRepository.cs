using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("4784B35B-BDF9-48D7-ADAB-053F2E340447"), new Jogo{Id = Guid.Parse("4784B35B-BDF9-48D7-ADAB-053F2E340447"), Nome = "Jogo1", Produtora="Produtora1", Preco = 10}},
            {Guid.Parse("04DB06AB-F920-4D67-B5C9-A04554A34F80"), new Jogo{Id = Guid.Parse("04DB06AB-F920-4D67-B5C9-A04554A34F80"), Nome = "Jogo2", Produtora="Produtora2", Preco = 15}},
            {Guid.Parse("DC0AA7F6-C8E3-43F6-84A4-BF3E3F584BC9"), new Jogo{Id = Guid.Parse("DC0AA7F6-C8E3-43F6-84A4-BF3E3F584BC9"), Nome = "Jogo3", Produtora="Produtora3", Preco = 20}},
            {Guid.Parse("C61EFB9B-64DF-476C-B3EA-EEC7474A2C83"), new Jogo{Id = Guid.Parse("C61EFB9B-64DF-476C-B3EA-EEC7474A2C83"), Nome = "Jogo4", Produtora="Produtora4", Preco = 100}},
            {Guid.Parse("5B3AFD86-61FA-4923-9082-B188B9AF87B7"), new Jogo{Id = Guid.Parse("5B3AFD86-61FA-4923-9082-B188B9AF87B7"), Nome = "Jogo5", Produtora="Produtora5", Preco = 50}},
            {Guid.Parse("AF0082FD-92DC-4F5F-A522-4F33F59981DA"), new Jogo{Id = Guid.Parse("AF0082FD-92DC-4F5F-A522-4F33F59981DA"), Nome = "Jogo6", Produtora="Produtora6", Preco = 70}},
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
