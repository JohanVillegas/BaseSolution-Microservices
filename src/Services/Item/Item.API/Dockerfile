FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Item.API/Item.API.csproj Item.API/
RUN dotnet restore Item.API/Item.API.csproj
COPY . .
WORKDIR /src/Item.API
RUN dotnet build Item.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Item.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Item.API.dll"]
