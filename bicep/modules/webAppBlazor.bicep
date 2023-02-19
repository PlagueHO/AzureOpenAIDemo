param location string
param appServicePlanId string
param webAppName string

resource webApp 'Microsoft.Web/sites@2021-01-15' = {
  name: webAppName
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: appServicePlanId
    httpsOnly: true
    siteConfig: {
      numberOfWorkers: 1
      linuxFxVersion: 'DOTNETCORE|7.0'
      appSettings: []
    }
    clientAffinityEnabled: true
  }

  resource config 'config@2021-01-15' = {
    name: 'web'
    properties: {
      httpLoggingEnabled: true
      logsDirectorySizeLimit: 35
      detailedErrorLoggingEnabled: true
      linuxFxVersion: 'DOTNETCORE|7.0'
    }
  }

  resource WebAppStaging 'slots@2022-03-01' = {
    name: 'staging'
    location: location
    kind: 'app,linux'
    properties: {
      serverFarmId: appServicePlanId
      httpsOnly: true
      siteConfig: {
        numberOfWorkers: 1
        linuxFxVersion: 'DOTNETCORE|7.0'
        appSettings: []
      }
      clientAffinityEnabled: true
    }

    resource config 'config@2021-01-15' = {
      name: 'web'
      properties: {
        httpLoggingEnabled: true
        logsDirectorySizeLimit: 35
        detailedErrorLoggingEnabled: true
        linuxFxVersion: 'DOTNETCORE|7.0'
      }
    }
  }
}


output url string = 'https://${webAppName}.azurewebsites.net'

