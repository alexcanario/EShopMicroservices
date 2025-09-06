# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Ordering/EShop.Ordering.API/EShop.Ordering.API.csproj", "Services/Ordering/EShop.Ordering.API/"]
COPY ["BuildingBlocks/EShop.BuildingBlocks/EShop.BuildingBlocks.csproj", "BuildingBlocks/EShop.BuildingBlocks/"]
COPY ["Services/Ordering/EShop.Ordering.App/EShop.Ordering.App.csproj", "Services/Ordering/EShop.Ordering.App/"]
COPY ["BuildingBlocks/EShop.BuildingBlocks.Messaging/EShop.BuildingBlocks.Messaging.csproj", "BuildingBlocks/EShop.BuildingBlocks.Messaging/"]
COPY ["Services/Ordering/EShop.Ordering.Domain/EShop.Ordering.Domain.csproj", "Services/Ordering/EShop.Ordering.Domain/"]
COPY ["Services/Ordering/EShop.Ordering.Infra/EShop.Ordering.Infra.csproj", "Services/Ordering/EShop.Ordering.Infra/"]
RUN dotnet restore "./Services/Ordering/EShop.Ordering.API/EShop.Ordering.API.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/EShop.Ordering.API"
RUN dotnet build "./EShop.Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EShop.Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.Ordering.API.dll"]