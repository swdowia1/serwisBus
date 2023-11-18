#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SErvices/Ordering/Ordering.API/Ordering.API.csproj", "src/SErvices/Ordering/Ordering.API/"]
COPY ["src/SErvices/Ordering/Ordering.Application/Ordering.Application.csproj", "src/SErvices/Ordering/Ordering.Application/"]
COPY ["src/SErvices/Ordering/Ordering.Domain/Ordering.Domain.csproj", "src/SErvices/Ordering/Ordering.Domain/"]
COPY ["src/BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "src/BuildingBlocks/EventBus.Messages/"]
COPY ["src/SErvices/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "src/SErvices/Ordering/Ordering.Infrastructure/"]
RUN dotnet restore "src/SErvices/Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/SErvices/Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]