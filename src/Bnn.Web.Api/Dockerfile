FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/Bnn.Web.Api/Bnn.Web.Api.csproj", "src/Bnn.Web.Api/"]
COPY ["src/Bnn.Services/Bnn.Services.csproj", "src/Services.Api/"]
COPY ["src/Bnn.Data/Bnn.Data.csproj", "src/Bnn.Data/"]
RUN dotnet restore "./src/Bnn.Web.Api/Bnn.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Bnn.Web.Api"
RUN dotnet build "Bnn.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Bnn.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bnn.Web.Api.dll"]
