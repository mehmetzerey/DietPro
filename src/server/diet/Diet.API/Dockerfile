#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 50011

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/server/diet/Diet.API/Diet.API.csproj", "src/server/diet/Diet.API/"]
RUN dotnet restore "src/server/diet/Diet.API/Diet.API.csproj"
COPY . .
WORKDIR "/src/src/server/diet/Diet.API"
RUN dotnet build "Diet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diet.API.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diet.API.dll"]