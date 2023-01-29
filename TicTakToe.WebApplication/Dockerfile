#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TicTakToe.WebApplication/TicTakToe.WebApplication.csproj", "TicTakToe.WebApplication/"]
COPY ["TicTakToe.Infrastructure/TicTakToe.Infrastructure.csproj", "TicTakToe.Infrastructure/"]
COPY ["TicTakToe.Core/TicTakToe.Core.csproj", "TicTakToe.Core/"]
RUN dotnet restore "TicTakToe.WebApplication/TicTakToe.WebApplication.csproj"
COPY . .
WORKDIR "/src/TicTakToe.WebApplication"
RUN dotnet build "TicTakToe.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicTakToe.WebApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicTakToe.WebApplication.dll"]