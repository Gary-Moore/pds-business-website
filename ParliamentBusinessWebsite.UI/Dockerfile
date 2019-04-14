FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ParliamentBusinessWebsite.UI.csproj", "ParliamentBusinessWebsite.UI/"]
COPY ["src/ParliamentBusinessWebsite.Domain/ParliamentBusinessWebsite.Domain.csproj", "ParliamentBusinessWebsite.Domain/"]
RUN dotnet restore "ParliamentBusinessWebsite.UI/ParliamentBusinessWebsite.UI.csproj"
COPY . .

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ParliamentBusinessWebsite.UI.dll"]