using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ProjetoMVCEvento.Model;
using ProjetoMVCEvento.View;

namespace ProjetoMVCEvento.Controller
{
    public class EventoController
    {
        private const string ArquivoBancoDados = "listaEvento.csv";

        private EventoView _view;

        public EventoController()
        {
            _view = new EventoView();
        }

        public void CadastrarEvento()
        {
            Evento evento = _view.CriarEvento();

            try
            {
                using (StreamWriter sw = new StreamWriter(ArquivoBancoDados, true))
                {
                    sw.WriteLine($"{evento.Nome},{evento.Descricao},{evento.Data.ToString("dd/MM/yyyy")}");
                }

                Console.WriteLine("Evento cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar evento: {ex.Message}");
            }
        }

        public void ListarEventos()
        {
            try
            {
                List<Evento> eventos = new List<Evento>();

                using (StreamReader sr = new StreamReader(ArquivoBancoDados))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');

                        if (dados.Length >= 3)
                        {
                            eventos.Add(new Evento
                            {
                                Nome = dados[0],
                                Descricao = dados[1],
                                Data = DateTime.ParseExact(dados[2], "dd/MM/yyyy", CultureInfo.InvariantCulture)
                            });
                        }
                    }
                }

                _view.ListarEventos(eventos.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar eventos: {ex.Message}");
            }
        }
    }
}














