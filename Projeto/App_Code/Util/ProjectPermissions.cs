using System.Collections.Generic;

namespace PROJETO
{	
	public static class ProjectControlPermissions
	{
		private static Dictionary<string, Dictionary<string, string>>  _permissions;
		
		public static Dictionary<string, Dictionary<string, string>> Permissions
		{
			get
			{
				if (_permissions == null) FillPermissions();
				return _permissions;
			}		
		}
		
		private static void FillPermissions()
		{
			_permissions = new Dictionary<string, Dictionary<string, string>>();

			// Permissões para página: ~/Pages/TB_HIST_EXECUCAO_ATIVIDADE_Repeater.aspx
			_permissions["32812"] = new Dictionary<string, string>();
			_permissions["32812"]["$TITLE$"] =  "Relação de Execução da Atividade";
			_permissions["32812"]["$NAME$"] =  "TB_HIST_EXECUCAO_ATIVIDADE_Repeater";
			_permissions["32812"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32812"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32812"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32812"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32812 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/HistoricodeExecucaodaAtividade.aspx
			_permissions["32779"] = new Dictionary<string, string>();
			_permissions["32779"]["$TITLE$"] =  "Histórico de Execução da Atividade";
			_permissions["32779"]["$NAME$"] =  "HistoricodeExecucaodaAtividade";
			_permissions["32779"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32779"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			
			// Permissões customizadas para: Modulo: 32779 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/CadastroAtividades.aspx
			_permissions["32776"] = new Dictionary<string, string>();
			_permissions["32776"]["$TITLE$"] =  "Cadastro de Atividades das Ações";
			_permissions["32776"]["$NAME$"] =  "CadastroAtividades";
			_permissions["32776"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32776"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32776"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32776"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32776 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32776"]["$2388101$"] = "Grid1";
			_permissions["32776"]["$2388101$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32776"]["$2388101$"];
			

			// Permissões para página: ~/Pages/ProjetosAtividades.aspx
			_permissions["32778"] = new Dictionary<string, string>();
			_permissions["32778"]["$TITLE$"] =  "Projetos e Atividades Gerenciais";
			_permissions["32778"]["$NAME$"] =  "ProjetosAtividades";
			_permissions["32778"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32778"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32778"]["$ALLOW_UPDATE$"] = "Permitir edição";
			
			// Permissões customizadas para: Modulo: 32778 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid2
			_permissions["32778"]["$2387680$"] = "Grid2";
			_permissions["32778"]["$2387680$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32778"]["$2387680$"];
			

			// Permissões para página: ~/Pages/RelacaoAcaoProjeto.aspx
			_permissions["32763"] = new Dictionary<string, string>();
			_permissions["32763"]["$TITLE$"] =  "Relação de Ações";
			_permissions["32763"]["$NAME$"] =  "RelacaoAcaoProjeto";
			_permissions["32763"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32763"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32763"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32763"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32763 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32763"]["$2387041$"] = "Grid1";
			_permissions["32763"]["$2387041$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32763"]["$2387041$"];
			

			// Permissões para página: ~/Pages/RelacaodoCadastrodeAcoes.aspx
			_permissions["32736"] = new Dictionary<string, string>();
			_permissions["32736"]["$TITLE$"] =  "Relação do Cadastro de Ações";
			_permissions["32736"]["$NAME$"] =  "RelacaodoCadastrodeAcoes";
			_permissions["32736"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32736"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32736"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32736"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32736 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32736"]["$2385869$"] = "Grid1";
			_permissions["32736"]["$2385869$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32736"]["$2385869$"];
			

			// Permissões para página: ~/Pages/TB_ITENS_PROJETO.aspx
			_permissions["32735"] = new Dictionary<string, string>();
			_permissions["32735"]["$TITLE$"] =  "Cadastro de Metas / Ações";
			_permissions["32735"]["$NAME$"] =  "TB_ITENS_PROJETO";
			_permissions["32735"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32735"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32735"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32735"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32735 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/CadastroDiretriz.aspx
			_permissions["32734"] = new Dictionary<string, string>();
			_permissions["32734"]["$TITLE$"] =  "Cadastro de Diretriz";
			_permissions["32734"]["$NAME$"] =  "CadastroDiretriz";
			_permissions["32734"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32734"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32734"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32734"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32734 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Relacao_de_Diretriz.aspx
			_permissions["32732"] = new Dictionary<string, string>();
			_permissions["32732"]["$TITLE$"] =  "Relação de Diretriz";
			_permissions["32732"]["$NAME$"] =  "Relacao_de_Diretriz";
			_permissions["32732"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32732"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32732"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32732"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32732 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32732"]["$2385778$"] = "Grid1";
			_permissions["32732"]["$2385778$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32732"]["$2385778$"];
			

			// Permissões para página: ~/Pages/TB_RESPONSAVEL.aspx
			_permissions["32731"] = new Dictionary<string, string>();
			_permissions["32731"]["$TITLE$"] =  "Cadastro de Pessoas";
			_permissions["32731"]["$NAME$"] =  "TB_RESPONSAVEL";
			_permissions["32731"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32731"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32731"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32731"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32731 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Lista_dos_Responsaveis.aspx
			_permissions["32730"] = new Dictionary<string, string>();
			_permissions["32730"]["$TITLE$"] =  "Lista dos Responsáveis";
			_permissions["32730"]["$NAME$"] =  "Lista_dos_Responsaveis";
			_permissions["32730"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32730"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32730"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32730"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32730 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32730"]["$2385592$"] = "Grid1";
			_permissions["32730"]["$2385592$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32730"]["$2385592$"];
			

			// Permissões para página: ~/Pages/CadastroCoordenacoesSetoriais.aspx
			_permissions["32729"] = new Dictionary<string, string>();
			_permissions["32729"]["$TITLE$"] =  "Cadastro de Setoriais";
			_permissions["32729"]["$NAME$"] =  "CadastroCoordenacoesSetoriais";
			_permissions["32729"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32729"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32729"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32729"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32729 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/ListaCoordenacoesSetoriais.aspx
			_permissions["32728"] = new Dictionary<string, string>();
			_permissions["32728"]["$TITLE$"] =  "Lista de Coordenção ou Setorial";
			_permissions["32728"]["$NAME$"] =  "ListaCoordenacoesSetoriais";
			_permissions["32728"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32728"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32728"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32728"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32728 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32728"]["$2385544$"] = "Grid1";
			_permissions["32728"]["$2385544$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32728"]["$2385544$"];
			

			// Permissões para página: ~/Pages/CadastroCoordenacoesGerais.aspx
			_permissions["32727"] = new Dictionary<string, string>();
			_permissions["32727"]["$TITLE$"] =  "Cadastro de Coordenações";
			_permissions["32727"]["$NAME$"] =  "CadastroCoordenacoesGerais";
			_permissions["32727"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32727"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32727"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32727"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32727 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Coordenacao_Geral.aspx
			_permissions["32726"] = new Dictionary<string, string>();
			_permissions["32726"]["$TITLE$"] =  "Coordenação Geral";
			_permissions["32726"]["$NAME$"] =  "Coordenacao_Geral";
			_permissions["32726"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32726"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32726"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32726"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32726 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32726"]["$2385493$"] = "Grid1";
			_permissions["32726"]["$2385493$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32726"]["$2385493$"];
			

			// Permissões para página: ~/Pages/CadastroDiretorias.aspx
			_permissions["32725"] = new Dictionary<string, string>();
			_permissions["32725"]["$TITLE$"] =  "Cadastro das diretorias";
			_permissions["32725"]["$NAME$"] =  "CadastroDiretorias";
			_permissions["32725"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32725"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32725"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32725"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32725 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Lista_das_Diretorias.aspx
			_permissions["32724"] = new Dictionary<string, string>();
			_permissions["32724"]["$TITLE$"] =  "Lista das Diretorias";
			_permissions["32724"]["$NAME$"] =  "Lista_das_Diretorias";
			_permissions["32724"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32724"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32724"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32724"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32724 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32724"]["$2385452$"] = "Grid1";
			_permissions["32724"]["$2385452$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32724"]["$2385452$"];
			

			// Permissões para página: ~/Pages/StartPage.aspx
			_permissions["1300"] = new Dictionary<string, string>();
			_permissions["1300"]["$TITLE$"] =  "Página inicial";
			_permissions["1300"]["$NAME$"] =  "StartPage";
			_permissions["1300"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 1300 (AspxModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Default.aspx
			_permissions["1292"] = new Dictionary<string, string>();
			_permissions["1292"]["$TITLE$"] =  "Página principal";
			_permissions["1292"]["$NAME$"] =  "Default";
			_permissions["1292"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/ErrorPage.aspx
			_permissions["1305"] = new Dictionary<string, string>();
			_permissions["1305"]["$TITLE$"] =  "Página de erro";
			_permissions["1305"]["$NAME$"] =  "ErrorPage";
			_permissions["1305"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/AboutPage.aspx
			_permissions["1303"] = new Dictionary<string, string>();
			_permissions["1303"]["$TITLE$"] =  "Sobre";
			_permissions["1303"]["$NAME$"] =  "AboutPage";
			_permissions["1303"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/Home.aspx
			_permissions["32722"] = new Dictionary<string, string>();
			_permissions["32722"]["$TITLE$"] =  "Gerenciamento de Atividades";
			_permissions["32722"]["$NAME$"] =  "Home";
			_permissions["32722"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 32722 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid2
			_permissions["32722"]["$2386074$"] = "Grid2";
			_permissions["32722"]["$2386074$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32722"]["$2386074$"];
			

			// Permissões para página: ~/Pages/Usuarios/CadastrarUsuario.aspx
			_permissions["32764"] = new Dictionary<string, string>();
			_permissions["32764"]["$TITLE$"] =  "Cadastrar Usuário";
			_permissions["32764"]["$NAME$"] =  "CadastrarUsuario";
			_permissions["32764"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32764"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32764"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32764"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32764 (DataPageModule) - Controle: FormCadastrarUsuario
			

			// Permissões para página: ~/Pages/Usuarios/EditarUsuario.aspx
			_permissions["32766"] = new Dictionary<string, string>();
			_permissions["32766"]["$TITLE$"] =  "Editar Usuário";
			_permissions["32766"]["$NAME$"] =  "EditarUsuario";
			_permissions["32766"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32766"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32766"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32766"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32766 (DataPageModule) - Controle: FormEditarUsuario
			

			// Permissões para página: ~/Pages/Usuarios/PesquisarUsuario.aspx
			_permissions["32768"] = new Dictionary<string, string>();
			_permissions["32768"]["$TITLE$"] =  "Pesquisar Usuario";
			_permissions["32768"]["$NAME$"] =  "PesquisarUsuario";
			_permissions["32768"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["32768"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["32768"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["32768"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 32768 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["32768"]["$2387380$"] = "Grid1";
			_permissions["32768"]["$2387380$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["32768"]["$2387380$"];
			

			// Permissões para página: ~/Pages/Usuarios/RecuperaSenha.aspx
			_permissions["32769"] = new Dictionary<string, string>();
			_permissions["32769"]["$TITLE$"] =  "Recuperar Senha";
			_permissions["32769"]["$NAME$"] =  "RecuperaSenha";
			_permissions["32769"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 32769 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Processos/AtualizaSituacaoAtividades.aspx
			_permissions["32791"] = new Dictionary<string, string>();
			_permissions["32791"]["$TITLE$"] =  "AtualizaAtividade";
			_permissions["32791"]["$NAME$"] =  "AtualizaSituacaoAtividades";
			_permissions["32791"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/Processos/AtualizaAcao.aspx
			_permissions["32793"] = new Dictionary<string, string>();
			_permissions["32793"]["$TITLE$"] =  "Item de processo";
			_permissions["32793"]["$NAME$"] =  "AtualizaAcao";
			_permissions["32793"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/Relatórios/RelatorioMetas.aspx
			_permissions["32808"] = new Dictionary<string, string>();
			_permissions["32808"]["$TITLE$"] =  "Relatório de Diretrizes e Metas";
			_permissions["32808"]["$NAME$"] =  "RelatorioMetas";
			_permissions["32808"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

		}
	
	}
}
