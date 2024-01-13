# Use a imagem base do ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Inicie a construção da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Restaure as dependências e ferramentas do projeto
COPY ["HorseMoney.Presentation/HorseMoney.Presentation.csproj", "HorseMoney.Presentation/"]
COPY ["HorseMoney.Application/HorseMoney.Application.csproj", "HorseMoney.Application/"]
COPY ["HorseMoney.Infrastructure/HorseMoney.Infrastructure.csproj", "HorseMoney.Infrastructure/"]
COPY ["HorseMoney.Domain/HorseMoney.Domain.csproj", "HorseMoney.Domain/"]
RUN dotnet restore "HorseMoney.Presentation/HorseMoney.Presentation.csproj"

# Copie os arquivos e construa o projeto
COPY . .
WORKDIR "/src/HorseMoney.Presentation"
RUN dotnet build "HorseMoney.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publique o projeto
FROM build AS publish
RUN dotnet publish "HorseMoney.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Construa a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HorseMoney.Presentation.dll"]
