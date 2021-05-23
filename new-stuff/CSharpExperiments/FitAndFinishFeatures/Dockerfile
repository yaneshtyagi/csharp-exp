FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FitAndFinishFeatures/FitAndFinishFeatures.csproj", "FitAndFinishFeatures/"]
RUN dotnet restore "FitAndFinishFeatures/FitAndFinishFeatures.csproj"
COPY . .
WORKDIR "/src/FitAndFinishFeatures"
RUN dotnet build "FitAndFinishFeatures.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitAndFinishFeatures.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitAndFinishFeatures.dll"]
