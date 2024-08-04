# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY LMS_BACKEND_MAIN/LMS_BACKEND_MAIN.csproj LMS_BACKEND_MAIN/
COPY Contracts/Contracts.csproj Contracts/
COPY Entities/Entities.csproj Entities/
COPY LMS_BACKEND_MAIN.Presentation/LMS_BACKEND_MAIN.Presentation.csproj LMS_BACKEND_MAIN.Presentation/
COPY LMS_UnitTest/LMS_UnitTest.csproj LMS_UnitTest/
COPY LoggerServices/LoggerServices.csproj LoggerServices/
COPY Repository/Repository.csproj Repository/
COPY Service/Service.csproj Service/
COPY Service.Contracts/Service.Contracts.csproj Service.Contracts/
COPY Shared/Shared.csproj Shared/

RUN dotnet restore LMS_BACKEND_MAIN/LMS_BACKEND_MAIN.csproj

# Copy the entire source code
COPY LMS_BACKEND_MAIN/. LMS_BACKEND_MAIN/
COPY Contracts/. Contracts/
COPY Entities/. Entities/
COPY LMS_BACKEND_MAIN.Presentation/. LMS_BACKEND_MAIN.Presentation/
COPY LMS_UnitTest/. LMS_UnitTest/
COPY LoggerServices/. LoggerServices/
COPY Repository/. Repository/
COPY Service/. Service/
COPY Service.Contracts/. Service.Contracts/
COPY Shared/. Shared/

WORKDIR /src/LMS_BACKEND_MAIN
RUN dotnet build LMS_BACKEND_MAIN.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish LMS_BACKEND_MAIN.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS_BACKEND_MAIN.dll"]