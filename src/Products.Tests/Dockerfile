﻿FROM microsoft/dotnet:2.1-sdk
WORKDIR /app
COPY . .
RUN dotnet restore
ENTRYPOINT ["dotnet", "test"]