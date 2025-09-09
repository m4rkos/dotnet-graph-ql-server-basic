FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["videos_graph_ql/videos_graph_ql.csproj", "videos_graph_ql/"]
RUN dotnet restore "videos_graph_ql/videos_graph_ql.csproj"
COPY . .
WORKDIR "/src/videos_graph_ql"
RUN dotnet build "./videos_graph_ql.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./videos_graph_ql.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "videos_graph_ql.dll"]
