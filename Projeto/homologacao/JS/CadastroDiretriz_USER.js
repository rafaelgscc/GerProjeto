
function btnSalvar_OnClientClick(sender)
{
	DateTime InicioProjeto = new DateTime();
	DateTime FinalProjeto = new DateTime();
	TimeSpan DiasProjeto;

	InicioProjeto = Convert.ToDateTime(inicioPrevistoField);
	FinalProjeto = Convert.ToDateTime(terminoPrevistoField);

	DiasProjeto = FinalProjeto.Subtract(InicioProjeto);
	//DiasProjeto = FinalProjeto - InicioProjeto;

	DiasDeProjetoField = DiasProjeto.Days;
}
