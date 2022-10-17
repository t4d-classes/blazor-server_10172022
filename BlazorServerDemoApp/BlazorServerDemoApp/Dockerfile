#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorServerDemoApp/BlazorServerDemoApp.csproj", "BlazorServerDemoApp/"]
RUN dotnet restore "BlazorServerDemoApp/BlazorServerDemoApp.csproj"
COPY . .
WORKDIR "/src/BlazorServerDemoApp"
RUN dotnet build "BlazorServerDemoApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorServerDemoApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorServerDemoApp.dll"]