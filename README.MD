# Dietician API
This repo contains source for Dietician service.

## Runing the Eureka discovery server
```bash
git clone https://github.com/spring-cloud-samples/eureka
cd eureka
mvn spring-boot:run
```

Or with docker
```bash
docker run --publish 8761:8761 steeltoeoss/eureka-server
```

## Running the API.

```bash
cd src/NadeeraKodithuwakku.Dietician.API
dotnet restore
dotnet run
```