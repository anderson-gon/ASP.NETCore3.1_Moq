FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API/Moq.API/Moq.API.csproj", "API/Moq.API/"]
RUN dotnet restore "API/Moq.API/Moq.API.csproj"
COPY . .
WORKDIR "/src/API/Moq.API"
RUN dotnet build "Moq.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Moq.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Moq.API.dll"]