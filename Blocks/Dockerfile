# writing the Dockerfile by defining the base image in the editor.
FROM microsoft/dotnet:2.1-sdk AS build-env
# FROM microsoft/aspnetcore

# creating the Dockerfile by defining the directory and how to download and configure the dependencies.
RUN mkdir /app
WORKDIR /app

COPY ./Infra/Core/Dharma.Core.csproj ./Infra/Core/
COPY ./Infra/LoggingBlock/Models/Logging.Models/Dharma.LoggingBlock.Models.csproj ./Infra/LoggingBlock/Models/Logging.Models/
COPY ./Infra/LoggingBlock/Components/Commands/Dharma.LoggingBlock.Components.Commands.csproj ./Infra/LoggingBlock/Components/Commands/
COPY ./Infra/LoggingBlock/Components/Queries/Dharma.LoggingBlock.Components.Queries.csproj ./Infra/LoggingBlock/Components/Queries/
COPY ./Infra/LoggingBlock/Implementation/Dharma.LoggingBlock.Implementation.csproj ./Infra/LoggingBlock/Implementation/
COPY ./Infra/LoggingBlock/Public/Dharma.LoggingBlock.csproj ./Infra/LoggingBlock/Public/

RUN dotnet restore ./Infra/Core/Dharma.Core.csproj
RUN dotnet restore ./Infra/LoggingBlock/Models/Logging.Models/Dharma.LoggingBlock.Models.csproj
RUN dotnet restore ./Infra/LoggingBlock/Components/Commands/Dharma.LoggingBlock.Components.Commands.csproj
RUN dotnet restore ./Infra/LoggingBlock/Components/Queries/Dharma.LoggingBlock.Components.Queries.csproj
RUN dotnet restore ./Infra/LoggingBlock/Implementation/Dharma.LoggingBlock.Implementation.csproj
RUN dotnet restore ./Infra/LoggingBlock/Public/Dharma.LoggingBlock.csproj

# creating the Dockerfile by defining the directory and how to download and configure the dependencies.
COPY . ./
RUN dotnet publish ./Infra/LoggingBlock/Public/Dharma.LoggingBlock.csproj -c Release -o out

# The second stage defines how the application starts and the ports it's running on.
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Dharma.LoggingBlock.dll"]

