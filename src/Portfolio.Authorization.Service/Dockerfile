# Use the official .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set a working directory in the container
WORKDIR /publish

COPY src/Portfolio.Authorization.Service Portfolio.Authorization.Service
COPY src/Portfolio.Migration Portfolio.Migration
COPY src/Portfolio.Domain.Core Portfolio.Domain.Core

RUN dotnet publish "./Portfolio.Authorization.Service/Portfolio.Authorization.Service.csproj" -c release -o out

RUN dotnet dev-certs https

# Use a smaller runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set a working directory in the container
WORKDIR /app

# Copy the published application from the build environment
COPY --from=build /publish/out .
COPY --from=build /publish/Portfolio.Migration /Portfolio.Migration
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/

ARG DB_HOST
ENV DB_HOST=$DB_HOST

ARG DB_NAME
ENV DB_NAME=$DB_NAME

ARG DB_PORT
ENV DB_PORT=$DB_PORT

ARG DB_USER
ENV DB_USER=$DB_USER

ARG DB_PASSWORD
ENV DB_PASSWORD=$DB_PASSWORD

ARG DB_KEEPALIVE
ENV DB_KEEPALIVE=$DB_KEEPALIVE

ENV ASPNETCORE_URLS https://*:5000

# Expose the port your application listens on (adjust as needed)
EXPOSE 5000

# Specify the entry point for the application
CMD ["dotnet", "Portfolio.Authorization.Service.dll"]