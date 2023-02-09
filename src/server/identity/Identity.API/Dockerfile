#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 50010

ENV ASPNETCORE_ENVIRONMENT=Development
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/server/identity/Identity.API/Identity.API.csproj", "src/server/identity/Identity.API/"]
COPY ["src/server/identity/Identity.Application/Identity.Application.csproj", "src/server/identity/Identity.Application/"]
COPY ["src/server/identity/Identity.Domain/Identity.Domain.csproj", "src/server/identity/Identity.Domain/"]
COPY ["src/server/identity/Identity.Infrastructure/Identity.Infrastructure.csproj", "src/server/identity/Identity.Infrastructure/"]
RUN dotnet restore "src/server/identity/Identity.API/Identity.API.csproj"
COPY . .
WORKDIR "/src/src/server/identity/Identity.API"
RUN dotnet build "Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.API.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.API.dll"]