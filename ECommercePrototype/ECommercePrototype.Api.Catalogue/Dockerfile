FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ECommercePrototype.Api.Catalogue/ECommercePrototype.Api.Catalogue.csproj", "ECommercePrototype.Api.Catalogue/"]
RUN dotnet restore "ECommercePrototype.Api.Catalogue/ECommercePrototype.Api.Catalogue.csproj"
COPY . .
WORKDIR "/src/ECommercePrototype.Api.Catalogue"
RUN dotnet build "ECommercePrototype.Api.Catalogue.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ECommercePrototype.Api.Catalogue.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ECommercePrototype.Api.Catalogue.dll"]