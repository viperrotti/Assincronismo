using System.Diagnostics;

namespace Assincronismo
{
    public partial class Frm1 : Form
    {
        public Frm1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private async Task<string> FolhaDePagamento()
        {
            await Task.Delay(4000);
            double folha = 5000.00 - (5000 * 0.225) - (5000 * 0.11);
            return $"Folha de Pagamento: R$ {folha.ToString("F2")}\r\n";
        }

        private async Task<string> Impostos()
        {
            await Task.Delay(2000);
            double imposto = 5000.00 * 0.225;
            return $"Impostos: R$ {imposto.ToString("F2")}\r\n";
        }

        private async Task<string> Receitas()
        {
            await Task.Delay(3000);
            double receitas = 5000.00;
            return $"Receitas: R$ {receitas.ToString("F2")}\r\n";
        }

        private async Task<string> Despesas()
        {
            await Task.Delay(1000);
            double despesas = 5000 * 0.11;
            return $"Despesas: R$ {despesas.ToString("F2")}\r\n";
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            lblMensagem.Text = "Cálculos sendo realizados, aguarde...";
            btnCalcular.Enabled = false;
            var tarefa1 = FolhaDePagamento();
            var tarefa2 = Impostos();
            var tarefa3 = Receitas();
            var tarefa4 = Despesas();
            await tarefa1;
            await tarefa2;
            await tarefa3;
            await tarefa4;
            lbxResultados.Text += tarefa1.Result;
            lbxResultados.Text += tarefa2.Result;
            lbxResultados.Text += tarefa3.Result;
            lbxResultados.Text += tarefa4.Result;
            btnCalcular.Enabled = true;
            stopwatch.Stop();
            lblMensagem.Text = $"Concluído. Tempo decorrido: {stopwatch.ElapsedMilliseconds/1000} s.";
        }
    }
}