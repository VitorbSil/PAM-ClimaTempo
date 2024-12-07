using ClimaTempo.Models;
using ClimaTempo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimaTempo.ViewModels
{
    public partial class PrevisaoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string cidade;
        [ObservableProperty]
        private string estado;
        [ObservableProperty]
        private string atualizado_Em;
        [ObservableProperty]
        private DateTime data;
        [ObservableProperty]
        private string condicao;
        [ObservableProperty]
        private string condicao_Desc;
        [ObservableProperty]
        private double max;
        [ObservableProperty]
        private double min;
        [ObservableProperty]
        private double indiceuv;

        [ObservableProperty]
        private List<Clima> proximosDias;

        private Previsao previsao;
        private Previsao proxPrevisao;

        [ObservableProperty]
        private string cidade_pesquisada;

        [ObservableProperty]
        private string previsao_cidade;

        [ObservableProperty]
        private List<Cidade> cidade_list;

        public ICommand BuscarPrevisaoCommand{ get; }
        public ICommand BuscarCidadesCommand { get; }

        public PrevisaoViewModel()
        {
            BuscarPrevisaoCommand = new Command<int>(BuscarPrevisao);
            BuscarCidadesCommand = new Command(BuscarCidades);
        }

        public async void BuscarPrevisao(int id)
        {
            previsao = await new PrevisaoService().GetPrevisaoById(id);
            Max = previsao.Clima[0].Max;
            Min = previsao.Clima[0].Max;
        }

        public async void BuscarCidades()
        {
            Cidade_list = new List<Cidade>();
            Cidade_list = await new CidadeService().GetCidadesByName(Cidade_pesquisada);
        }

         /* Estado = previsao.Estado;
            Cidade = previsao.Cidade;
            Atualizado_Em = previsao.Atualizado_Em.ToString();
            Data = previsao.Clima[0].Data;
            Condicao = previsao.Clima[0].Condicao;
            Condicao_Desc = previsao.Clima[0].Condicao_desc;
            Max = previsao.Clima[0].Max;
            Min = previsao.Clima[0].Min;*/



    }
}
