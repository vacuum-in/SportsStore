FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY SportsStore/SportsStore.csproj SportsStore/
RUN dotnet restore SportsStore/SportsStore.csproj
COPY . .
WORKDIR /src/SportsStore
RUN dotnet build SportsStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SportsStore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SportsStore.dll"]
