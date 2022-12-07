

function btnSalvar_OnClientClick(sender)
{
	var InicioProjeto = new DateTime();
	var FinalProjeto = new DateTime();
	var DiasProjeto = TimeSpan;

	InicioProjeto = Convert.ToDateTime(inicioPrevistoField);
	FinalProjeto = Convert.ToDateTime(terminoPrevistoField);

	DiasProjeto = FinalProjeto.Subtract(InicioProjeto);

	DiasPrevistosField = DiasProjeto.Days;
}
