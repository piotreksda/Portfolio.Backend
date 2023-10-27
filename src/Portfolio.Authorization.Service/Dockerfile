# Use the official .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set a working directory in the container
WORKDIR /publish

COPY src/Portfolio.Authorization.Service Portfolio.Authorization.Service
COPY src/Portfolio.Migration Portfolio.Migration
COPY src/Portfolio.Domain.Core Portfolio.Domain.Core

RUN dotnet publish "./Portfolio.Authorization.Service/Portfolio.Authorization.Service.csproj" -c release -o out

RUN dotnet dev-certs https

# Use a smaller runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set a working directory in the container
WORKDIR /app

# Copy the published application from the build environment
COPY --from=build /publish/out .
COPY --from=build /publish/Portfolio.Migration /Portfolio.Migration

ENV ASPNETCORE_URLS https://*:5000

# Expose the port your application listens on (adjust as needed)
EXPOSE 5000

# Specify the entry point for the application
CMD ["dotnet", "Portfolio.Authorization.Service.dll"]