#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app


COPY ["MakeWeBet/MakeWeBet.APIs.csproj", "MakeWeBet/"]
COPY ["Business/MakeWeBet.Business.csproj", "Business/"]
COPY ["Data/MakeWeBet.Data.csproj", "Data/"]
RUN dotnet restore "MakeWeBet/MakeWeBet.APIs.csproj"
COPY . .
WORKDIR "/src/MakeWeBet.APIs"
RUN dotnet build "MakeWeBet.APIs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MakeWeBet.APIs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY "MakeWeBet.APIs/appsettings.json" .
ENTRYPOINT ["dotnet", "MakeWeBet.APIs.dll"]
