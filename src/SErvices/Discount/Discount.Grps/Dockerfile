#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SErvices/Discount/Discount.Grps/Discount.Grps.csproj", "src/SErvices/Discount/Discount.Grps/"]
RUN dotnet restore "src/SErvices/Discount/Discount.Grps/Discount.Grps.csproj"
COPY . .
WORKDIR "/src/src/SErvices/Discount/Discount.Grps"
RUN dotnet build "Discount.Grps.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.Grps.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grps.dll"]
