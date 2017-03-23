FROM microsoft/dotnet:latest

WORKDIR /app
COPY ./src/DataCat/bin/Release/netcoreapp1.1 .

EXPOSE 80/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "DataCat.dll"]