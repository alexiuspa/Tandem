#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /app


COPY C:\Research\POC\Tandem\tandem\Tandem.csproj ./
RUN dotnet restore 
COPY . ./
RUN dotnet publish  -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Tandem.dll"]