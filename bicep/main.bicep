targetScope = 'subscription'

param location string = 'SouthCentralUS'
param resourceGroupName string

@description('The base name that will prefixed to all Azure resources deployed to ensure they are unique.')
param baseResourceName string

@description('The Azure App Service SKU for running the Blazor App.')
@allowed([
  'F1'
  'B1'
  'B2'
  'B3'
  'P1V2'
  'P2V2'
  'P3V2'
  'P1V3'
  'P2V3'
  'P3V3'
])
param appServicePlanConfiguration string = 'P1V2'

@description('The model to deploy to the Open AI service.')
@allowed([
  'code-custman-001'
  'code-search-ada-code-001'
  'code-search-ada-text-001'
  'code-search-babbage-code-001'
  'code-search-babbage-text-001'
  'text-ada-001'
  'text-babbage-001'
  'text-curie-001'
  'text-davinci-001'
  'text-davinci-002'
  'text-embedding-ada-002'
  'text-search-ada-doc-001'
  'text-search-ada-query-001'
  'text-search-babbage-doc-001'
  'text-search-babbage-query-001'
  'text-search-curie-doc-001'
  'text-search-curie-query-001'
  'text-search-davinci-doc-001'
  'text-search-davinci-query-001'
  'text-similarity-ada-001'
  'text-similarity-babbage-001'
  'text-similarity-curie-001'
])
param openAiModelName string = 'text-davinci-002'

@description('The name of the deployment for the model  in the Open AI service.')
param openAiDeploymentlName string = 'text-davinci-002'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: resourceGroupName
  location: location
}

module monitoring './modules/monitoring.bicep' = {
  name: 'monitoring'
  scope: rg
  params: {
    location: location
    logAnalyticsWorkspaceName: '${baseResourceName}-law'
    applicationInsightsName: '${baseResourceName}-ai'
  }
}

module openAiService './modules/openAiService.bicep' = {
  name: 'openAiService'
  scope: rg
  dependsOn: [
    monitoring
  ]
  params: {
    location: location
    openAiServiceName: '${baseResourceName}-openai'
    modelName: openAiModelName
    deploymentName: openAiDeploymentlName
  }
}

module appServicePlan './modules/appServicePlan.bicep' = {
  name: 'appServicePlan'
  scope: rg
  dependsOn: [
    openAiService
    monitoring
  ]
  params: {
    location: location
    appServicePlanName: '${baseResourceName}-asp'
    appServicePlanConfiguration: appServicePlanConfiguration
  }
}

module webAppBlazor './modules/webAppBlazor.bicep' = {
  name: 'webAppBlazor'
  scope: rg
  dependsOn: [
    appServicePlan
    monitoring
  ]
  params: {
    location: location
    appServicePlanId: appServicePlan.outputs.appServicePlanId
    webAppName: baseResourceName
    openAiEndpoint: '${openAiService.outputs.openAiServiceEndpoint}openai/${openAiService.outputs.openAiServiceDeployment}/'
    appInsightsInstrumentationKey: monitoring.outputs.applicationInsightsInstrumentationKey
    appInsightsConnectionString: monitoring.outputs.applicationInsightsConnectionString
  }
}

output webAppName string = webAppBlazor.outputs.webAppName
output webAppHostName  string = webAppBlazor.outputs.webAppHostName
output webAppStagingName string = webAppBlazor.outputs.webAppStagingName
output webAppStagingHostName  string = webAppBlazor.outputs.webAppStagingHostName
output openAiServiceEndpoint string = openAiService.outputs.openAiServiceEndpoint
output openAiServiceDeployment string = openAiService.outputs.openAiServiceDeployment
