#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Frank.Apps.QuickEngine/Frank.Apps.QuickEngine.csproj", "Frank.Apps.QuickEngine/"]
RUN dotnet restore "Frank.Apps.QuickEngine/Frank.Apps.QuickEngine.csproj"
COPY . .
WORKDIR "/src/Frank.Apps.QuickEngine"
RUN dotnet build "Frank.Apps.QuickEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frank.Apps.QuickEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frank.Apps.QuickEngine.dll"]