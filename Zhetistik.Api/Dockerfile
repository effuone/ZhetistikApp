#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Zhetistik.Api/Zhetistik.Api.csproj", "Zhetistik.Api/"]
RUN dotnet restore "Zhetistik.Api/Zhetistik.Api.csproj"
COPY . .
WORKDIR "/src/Zhetistik.Api"
RUN dotnet build "Zhetistik.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zhetistik.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zhetistik.Api.dll"]