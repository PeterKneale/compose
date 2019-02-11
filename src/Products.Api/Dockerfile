FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /usr/src/app
COPY Products.Api.csproj /usr/src/app
RUN dotnet restore Products.Api.csproj
COPY . .
WORKDIR /usr/src/app
RUN dotnet build Products.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Products.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Products.Api.dll"]