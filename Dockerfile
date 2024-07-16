FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR usr/app
COPY ./AzureChallenge.Api/bin/Release/net8.0/publish/* .
#CMD ["dotnet", "--version"]
CMD ["./AzureChallenge.Api"]
