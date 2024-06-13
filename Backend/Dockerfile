# Usamos una imaben base de .NET SDK para consturir la aplicacion
FROM mcr.microsoft.com/dotnet/sdk:8.0.101-jammy-amd64 AS build

COPY . /source

WORKDIR /source/webAPI
RUN dotnet restore \
	&& dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0.1-jammy-amd64 AS runtime

LABEL MAINTAINER sartorlautaro3@gmail.com

EXPOSE 5000

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

COPY --from=build /publish/ /app

WORKDIR /app
ENTRYPOINT ["dotnet", "webAPI.dll"]