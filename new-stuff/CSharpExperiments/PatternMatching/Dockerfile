FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PatternMatching/PatternMatching.csproj", "PatternMatching/"]
RUN dotnet restore "PatternMatching/PatternMatching.csproj"
COPY . .
WORKDIR "/src/PatternMatching"
RUN dotnet build "PatternMatching.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatternMatching.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatternMatching.dll"]
