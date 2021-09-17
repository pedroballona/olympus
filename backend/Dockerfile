# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Totvs.Olympus.API.dll"]
