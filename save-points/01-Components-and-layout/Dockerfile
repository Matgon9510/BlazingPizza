FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["BlazingPizza.Server/BlazingPizza.Server.csproj", "BlazingPizza.Server/"]
COPY ["BlazingPizza.Client/BlazingPizza.Client.csproj", "BlazingPizza.Client/"]
COPY ["BlazingPizza.Shared/BlazingPizza.Shared.csproj", "BlazingPizza.Shared/"]
COPY ["BlazingComponents/BlazingComponents.csproj", "BlazingComponents/"]
COPY ["BlazingPizza.ComponentsLibrary/BlazingPizza.ComponentsLibrary.csproj", "BlazingPizza.ComponentsLibrary/"]

RUN dotnet restore "BlazingPizza.Server/BlazingPizza.Server.csproj"

COPY . .

WORKDIR "/src/BlazingPizza.Server"
RUN dotnet publish "BlazingPizza.Server.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "BlazingPizza.Server.dll"]