# 🌱 ESGApp — Sistema de Gestão ESG (DevOps Challenge)

🧩 Projeto desenvolvido como parte do Desafio de DevOps (ESGApp) — Aplicação ASP.NET Core containerizada com pipeline CI/CD e deploy automatizado no Azure ☁

Aplicação *ASP.NET Core + MongoDB* containerizada com *Docker, pipeline **CI/CD via GitHub Actions* e deploy automatizado no *Azure App Service*.

---

## 🚀 Sumário
- [📦 Sobre o Projeto](#-sobre-o-projeto)
- [🧩 Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [⚙ Como Rodar Localmente](#-como-rodar-localmente)
- [🐳 Docker e Docker Compose](#-docker-e-docker-compose)
- [🔁 Pipeline CI/CD (GitHub Actions)](#-pipeline-cicd-github-actions)
- [☁ Deploy no Azure](#-deploy-no-azure)
- [🧠 Estrutura do Projeto](#-estrutura-do-projeto)
- [📄 Evidências e Prints](#-evidências-e-prints)
- [👨‍💻 Autor](#-autor)

---

## 📦 Sobre o Projeto

O *ESGApp* é uma *API REST* desenvolvida em *.NET 8* para gestão de indicadores ESG (Environmental, Social and Governance).

O foco do projeto é aplicar práticas de *DevOps*, com:
- Containerização usando *Docker*
- Orquestração via *Docker Compose*
- Pipeline automatizado de *CI/CD com GitHub Actions*
- *Deploy no Azure App Service* (com imagem hospedada no *Azure Container Registry*)

A aplicação expõe endpoints REST e uma interface *Swagger* para documentação automática.

---

## 🧩 Tecnologias Utilizadas

| Categoria | Ferramenta |
|------------|-------------|
| Backend | ASP.NET Core 8 |
| Banco de Dados | MongoDB |
| Containerização | Docker & Docker Compose |
| CI/CD | GitHub Actions |
| Cloud | Azure App Service |
| Repositório | GitHub |

---

## ⚙ Como Rodar Localmente

### 🧰 Pré-requisitos
- [Docker Desktop](https://www.docker.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Git](https://git-scm.com/)

### 🔧 Passos

Clone o repositório:

bash
  git clone https://github.com/VvitorSilva/Devops.git
  cd esgapp
  Suba os containers: docker-compose up --build

Acesse no navegador:
Swagger: http://localhost:8080/swagger
Endpoint de teste: http://localhost:8080/weatherforecast

---

🐳 Docker e Docker Compose
📁 Arquivo Dockerfile

Responsável por construir a imagem da aplicação .NET.

📄 Arquivo docker-compose.yml

Orquestra os serviços da aplicação e do MongoDB.

Exemplo:
version: '3.9'
services:
  app:
    build: .
    ports:
      - "8080:8080"
    depends_on:
      - mongo
  mongo:
    image: mongo:latest
    ports:
      - "27017:27017"
      
---

🔁 Pipeline CI/CD (GitHub Actions)

O workflow docker-build.yml executa build automatizado a cada push na branch main.

📄 .github/workflows/docker-build.yml

name: Build and Run ESGApp

on:
  push:
    branches:
      - main

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout código
        uses: actions/checkout@v3

      - name: Instalar Docker Compose
        run: sudo apt-get update && sudo apt-get install docker-compose -y

      - name: Build da aplicação com Docker Compose
        run: docker-compose up --build -d

      - name: Testar se a API está respondendo
        run: |
          sleep 10
          curl -f http://localhost:8080/weatherforecast || exit 1

Esse pipeline garante que a aplicação sobe corretamente antes de fazer o deploy.

☁ Deploy no Azure
🔹 Passos Seguidos:

Criado Azure Container Registry (ACR)
az acr create --resource-group esg-rg --name esgacr123 --sku Basic

---

Login e envio da imagem:
docker login esgacr123.azurecr.io
docker tag esg-app:latest esgacr123.azurecr.io/esg-app:latest
docker push esgacr123.azurecr.io/esg-app:latest 

---

Criado App Service com origem de contêiner no ACR.
Configurações principais no Azure:

Porta: 8080

Variável de ambiente:
WEBSITES_PORT = 8080

Teste do deploy:
🌍 URL pública (exemplo):

substitua pelo link real do seu App Service:
https://esg-app-bqhmhgffdqdfekbj.brazilsouth-01.azurewebsites.net 


🧠 Estrutura do Projeto
📦 esgapp
├── 📁 Controllers
│   └── ItemsController.cs
├── 📁 Models
│   └── Item.cs
├── 📁 Services
│   └── ItemService.cs
├── appsettings.json
├── docker-compose.yml
├── Dockerfile
├── Program.cs
└── README.md 


👨‍💻 Autores

Adhayne Silva
📧 adhaynedaphine@gmail.com

Felipe Silva
📧 felipedanielsilva588@gmail.com

Vitor Silva
📧 vitor.silva0628@gmail.com
💼 GitHub — VvitorSilva
