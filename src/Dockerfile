# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bazario.Notification/src/Bazario.Notification.csproj", "Bazario.Notification/"]
COPY ["Bazario.Notification/src/Templates", "Bazario.Notification/Templates"]

COPY Bazario.AspNetCore.Shared/NuGetPackages /nuget-packages
RUN dotnet nuget add source /nuget-packages --name NuGetPackages

RUN dotnet restore "./Bazario.Notification/Bazario.Notification.csproj"
COPY Bazario.Notification/src/ .

WORKDIR "/src"

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Bazario.Notification.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bazario.Notification.dll"]