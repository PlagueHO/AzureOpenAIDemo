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

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: resourceGroupName
  location: location
}

module openAiService './modules/openAiService.bicep' = {
  name: 'openAiService'
  scope: rg
  params: {
    location: location
    openAiServiceName: '${baseResourceName}-openai'
  }
}

module appServicePlan './modules/appServicePlan.bicep' = {
  name: 'appServicePlan'
  scope: rg
  dependsOn: [
    openAiService
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
  ]
  params: {
    location: location
    appServicePlanId: appServicePlan.outputs.appServicePlanId
    webAppName: baseResourceName
    openAiEndpoint: 'https://${openAiService.outputs.openAiServiceEndpoint}/openai/${openAiService.outputs.openAiServiceDeployment}'
  }
}

output webAppName string = webAppBlazor.outputs.webAppName
output webAppHostName  string = webAppBlazor.outputs.webAppHostName
output openAiServiceEndpoint string = openAiService.outputs.openAiServiceEndpoint
output openAiServiceDeployment string = openAiService.outputs.openAiServiceDeployment
