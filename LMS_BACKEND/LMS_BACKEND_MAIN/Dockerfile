#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LMS_BACKEND_MAIN/LMS_BACKEND_MAIN.csproj", "LMS_BACKEND_MAIN/"]
RUN dotnet restore "LMS_BACKEND_MAIN/LMS_BACKEND_MAIN.csproj"
COPY . .
WORKDIR "/src/LMS_BACKEND_MAIN"
RUN dotnet build "LMS_BACKEND_MAIN.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LMS_BACKEND_MAIN.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS_BACKEND_MAIN.dll"]