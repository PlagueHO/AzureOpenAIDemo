targetScope = 'subscription'

@description('The location to deploy the main demo into.')
@allowed([
  'EastUS'
  'FranceCentral'
  'SouthCentralUS'
  'WestEurope'
])
param location string = 'SouthCentralUS'

@description('The name of the resource group that will contain all the resources.')
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

// OpenAI Resource required for Blazor App
module openAiServiceBlazor './modules/openAiService.bicep' = {
  name: 'openAiServiceBlazor'
  scope: rg
  dependsOn: [
    monitoring
  ]
  params: {
    location: location
    openAiServiceName: '${baseResourceName}-openai'
    openAiModeldeployments: [{
      name: 'dsr-text-davinci-003'
      modelName: 'text-davinci-003'
      modelVersion: '1'
    }
    {
      name: 'dsr-gpt-35-turbo'
      modelName: 'gpt-35-turbo'
      modelVersion: '0301'
    }]
  }
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
    appInsightsInstrumentationKey: monitoring.outputs.applicationInsightsInstrumentationKey
    appInsightsConnectionString: monitoring.outputs.applicationInsightsConnectionString
  }
}

// Deploy OpenAI resources for each region
var openAiResourceDeployments = [
  {
    location: 'FranceCentralUS'
    name: 'aoaidemo1-fc'
  }
  {
    location: 'FranceCentralUS'
    name: 'aoaidemo2-fc'
  }
  {
    location: 'FranceCentralUS'
    name: 'aoaidemo3-fc'
  }
  {
    location: 'SouthCentralUS'
    name: 'aoaidemo1-sc'
  }
  {
    location: 'SouthCentralUS'
    name: 'aoaidemo2-sc'
  }
  {
    location: 'SouthCentralUS'
    name: 'aoaidemo3-sc'
  }
  {
    location: 'WestEurope'
    name: 'aoaidemo1-we'
  }
  {
    location: 'WestEurope'
    name: 'aoaidemo2-we'
  }
  {
    location: 'WestEurope'
    name: 'aoaidemo3-we'
  }
]

var openAiModelDeployments = [
  {
    name: 'text-ada-001'
    modelName: 'text-ada-001'
    modelVersion: 1
  }
  {
    name: 'text-curie-001'
    modelName: 'text-curie-001'
    modelVersion: '1'
  }
  {
    name: 'text-davinci-003'
    modelName: 'text-davinci-003'
    modelVersion: '1'
  }
  {
    name: 'code-davinci-002'
    modelName: 'code-davinci-002'
    modelVersion: '1'
  }
  {
    name: 'text-embedding-ada-002'
    modelName: 'text-embedding-ada-002'
    modelVersion: '2'
  }
  {
    name: 'gpt-35-turbo'
    modelName: 'gpt-35-turbo'
    modelVersion: '0301'
  }
]

module openAiService './modules/openAiService.bicep' = [for (resource, i) in openAiResourceDeployments: {
  name: 'openAiService${resource.name}'
  scope: rg
  dependsOn: [
    monitoring
  ]
  params: {
    location: resource.location
    openAiServiceName: '${baseResourceName}-${resource.name}'
    openAiModeldeployments: openAiModelDeployments
  }
}]


output webAppName string = webAppBlazor.outputs.webAppName
output webAppHostName  string = webAppBlazor.outputs.webAppHostName
output webAppStagingName string = webAppBlazor.outputs.webAppStagingName
output webAppStagingHostName  string = webAppBlazor.outputs.webAppStagingHostName
output openAiServiceEndpoint string = openAiServiceBlazor.outputs.openAiServiceEndpoint
