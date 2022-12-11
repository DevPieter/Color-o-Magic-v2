FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Color o Magic v2/Color o Magic v2.csproj", "Color o Magic v2/"]
RUN dotnet restore "Color o Magic v2/Color o Magic v2.csproj"
COPY . .
WORKDIR "/src/Color o Magic v2"
RUN dotnet build "Color o Magic v2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Color o Magic v2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Color o Magic v2.dll"]
