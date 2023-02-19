param location string
param appServicePlanId string
param webAppName string
param openAiEndpoint string
param appInsightsInstrumentationKey string
param appInsightsConnectionString string

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
      appSettings: [
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: appInsightsInstrumentationKey
        }
        {
          name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
          value: appInsightsConnectionString
        }
        {
          name: 'OPENAI_ENDPOINT'
          value: openAiEndpoint
        }
      ]
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
        appSettings: [
          {
            name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
            value: appInsightsInstrumentationKey
          }
          {
            name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
            value: appInsightsConnectionString
          }
          {
            name: 'OPENAI_ENDPOINT'
            value: openAiEndpoint
          }
        ]
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

output webAppName string = webApp.name
output webAppHostName  string = webApp.properties.defaultHostName

