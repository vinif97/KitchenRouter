FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KitchenRouter.WebAPI/KitchenRouter.WebAPI.csproj", "KitchenRouter.WebAPI/"]
RUN dotnet restore "KitchenRouter.WebAPI/KitchenRouter.WebAPI.csproj"
COPY . .
WORKDIR "/src/KitchenRouter.WebAPI"
RUN dotnet build "KitchenRouter.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KitchenRouter.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KitchenRouter.WebAPI.dll"]