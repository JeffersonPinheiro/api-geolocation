 REST APIGEOLOCATION

Este é um exemplo de API que consulta os serviços de Geolocalização do GoogleMaps.

Para rodar a api é necessario abrir o VisualStudio e apertar o botão F5.

Os retornos das requisições swagger são:
	Get/	-> Retorna todos os endereços cadastrados no banco de dados.
	Get/Id	-> Retorna um endereço específico.
	Post	-> Envia os dados do endereço que o usuario deseja cadastrar e retorna um JSON com a latitude, longitude do endereço. Faz a comparação de distancia dos endereços e retorna
				os endereços mais perto e os mais distantes.
	Put		-> Atualiza/Edita o endereço desejado.
	Delete	-> Remove o endereço desejado.

Os testes são executados clicando no botão direito do mouse em cima do projeto GeolocationTests e na opção executar testes.	