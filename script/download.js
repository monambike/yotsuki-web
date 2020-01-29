function avisodownload()
{
	
	alert("Download iniciado!");
}
function avancar()
{
	var elemento = document.getElementById("passo1");
	if(elemento.src.match("imagens/download_imagens/download.png"))
	{
		elemento.src = "imagens/download_imagens/manter.png";
	}
	else if(elemento.src.match("imagens/download_imagens/manter.png"))
	{
		elemento.src = "imagens/download_imagens/executar.png";
	}
	else
	{
		elemento.src = "imagens/download_imagens/download.png";
	}
}
function voltar()
{
	var elemento = document.getElementById("passo1");
	if(elemento.src.match("imagens/download_imagens/download.png"))
	{
		elemento.src = "imagens/download_imagens/executar.png";
	}
	else if(elemento.src.match("imagens/download_imagens/executar.png"))
	{
		elemento.src = "imagens/download_imagens/manter.png";
	}
	else
	{
		elemento.src = "imagens/download_imagens/download.png";
	}
}