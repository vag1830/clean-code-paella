FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Paella.WebApi/Paella.WebApi.csproj", "Paella.WebApi/"]
COPY ["Paella/Paella.csproj", "Paella/"]
RUN dotnet restore "Paella.WebApi/Paella.WebApi.csproj"
COPY . .
WORKDIR "/src/Paella.WebApi"
RUN dotnet build "Paella.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paella.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paella.WebApi.dll"]