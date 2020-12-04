<%@ Page Title="Me da G1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MeDaG1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<main class="container">
		<div class="row align-content-center align-items-center">
			<ul class="col-6">
				<li>
					<div class="row mb-5">
						<h4 class="text-center col-12">Faça a requisição lentamente...</h4>
					</div>
				</li>
				<li class="row align-content-center justify-content-center">
					<div class="row col-12 mb-3  justify-content-center">
						<asp:TextBox ID="SlowInput" CssClass="col-8" AutoCompleteType="None" runat="server"></asp:TextBox>
					</div>
					<div class="col-3 row">
						<asp:Button ID="SVerificador"
							Text="Buscar"
							OnClick="HasWordBtn_Click"
							CssClass="col-12 slow"
							runat="server" />
					</div>
				</li>
			</ul>

			<ul class="col-6">
				<li>
					<div class="row mb-5">
						<h4 class="text-center col-12">Requisição rápida</h4>
					</div>
				</li>
				<li class="row align-content-center justify-content-center">
					<div class="row col-12 mb-3  justify-content-center">
						<asp:TextBox ID="FastInput" AutoCompleteType="None" CssClass="col-8" runat="server"></asp:TextBox>
					</div>
					<div class="col-3 row">
						<asp:Button ID="FVerificador"
							Text="Buscar"
							OnClientClick="GetResponse(); return false;"
							CssClass="col-12 classic"
							runat="server" />
					</div>
				</li>
			</ul>
		</div>

		<div class="container row justify-content-center">
			<div class="row jumbotron bg-white">
				<h3 class="col-12  text-center">
					<asp:Label
						ID="ResponseLabel"
						Text="Faça uma busca na página inicial do G1"
						CssClass=" <%# ResponseColor%>"
						runat="server" />
				</h3>
			</div>
		</div>

		<script type="text/javascript">
			function GetResponse() {
				document
					.getElementById('MainContent_ResponseLabel')
					.innerHTML = "Funções Ajax não estão funcionando dentro do Web Forms. Sentimos por isso 🥺";

				//var input = $('#MainContent_FastInput').val();
				//$.ajax({
				//	type: "POST",
				//	url: "Controllers/ResquestFromG1/HasWordWeb",
				//	data: `{input: "${input}"}`,
				//	contentType: "application/json: charset=utf-8",
				//	success: function (data) {
				//		$('#MainContent_ResponseLabel').val(
				//			(data == "True")
				//				? `A palavra ${input} está na página inicial do G1.`
				//				: `A palavra ${input} não está na página inicial do G1.`
				//		);
				//	},
				//	error: function (ex) {
				//		$('#MainContent_ResponseLabel').val("Houve um erro na solicitação " + ex.statusCode());
				//	}
				//});
			}
		</script>
	</main>
</asp:Content>