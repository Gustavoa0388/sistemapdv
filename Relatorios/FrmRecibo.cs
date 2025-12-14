using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRecibo : Form
    {
        public FrmRecibo()
        {
            InitializeComponent();
        }

        private void FrmRecibo_Load(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.empresa'. Você pode movê-la ou removê-la conforme necessário.          
            this.detalhes_lancarvendasPorIdTableAdapter.Fill(vendasDataSet.detalhes_lancarvendasPorId, Convert.ToInt32(Program.idVenda));
            this.lancar_vendasPorId_VendasTableAdapter.Fill(vendasDataSet.lancar_vendasPorId_Vendas, Convert.ToInt32(Program.idVenda));
            this.reportViewer1.RefreshReport();            
        }



    }
}
