using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTeste.Migrations
{
    public partial class PopulaDb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Contrato(Data, QtdeParcelas, VlrFinanciado) values ('10/10/2019', 3, 6000)");
            mb.Sql("insert into Contrato(Data, QtdeParcelas, VlrFinanciado) values ('10/10/2019', 12, 15000)");
            mb.Sql("insert into Contrato(Data, QtdeParcelas, VlrFinanciado) values ('10/10/2019', 6, 8000)");

            mb.Sql("Insert into Prestacao(ContratoId,DtVencimento,DtPagamento,Valor) values (1, '10/10/2019', '10/10/2019', 2000)");
            mb.Sql("Insert into Prestacao(ContratoId,DtVencimento,DtPagamento,Valor) values (1, '10/11/2019', null, 2000)");
            mb.Sql("Insert into Prestacao(ContratoId,DtVencimento,DtPagamento,Valor) values (1, '10/12/2019', null, 2000)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from prestacao");
            mb.Sql("delete from contrato");
        }
    }
}
