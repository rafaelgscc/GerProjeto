

function cmbCoordenacaoFiltro_OnClientSelectedIndexChanged()
{
	ExecuteCommandRequest("ATUALIZAGRID","","",false);
}


//workaraound
function buttonAlert(){
	alert("Atualização:\nVersão 1.0.11: Adicionado barra ANO em diretriz\nVersão 1.0.12: Adicionado item STATUS em ação");
}
