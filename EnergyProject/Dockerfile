# Use the official Microsoft .NET SDK image for build
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Energy.API/Energy.API.csproj", "Energy.API/"]
COPY ["Energy.Application/Energy.Application.csproj", "Energy.Application/"]
COPY ["Energy.Domain/Energy.Domain.csproj", "Energy.Domain/"]
COPY ["Energy.Infra/Energy.Infra.csproj", "Energy.Infra/"]
RUN dotnet restore "Energy.API/Energy.API.csproj"
COPY . .
WORKDIR "/src/Energy.API"
RUN dotnet build "Energy.API.csproj" -c Release -o /app/build

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__DefaultConnection="Server=.\\SQLEXPRESS;Database=EnergyDb;User Id=sa;Password=123!asd;TrustServerCertificate=true;"

# Install SQL Server Express prerequisites
RUN apt-get update \
    && apt-get install -y gnupg2 curl \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/debian/10/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools unixodbc-dev \
    && apt-get clean

FROM build AS publish
RUN dotnet publish "Energy.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Energy.API.dll"]
