param location string
param openAiServiceName string
param deploymentName string
param modelName string

resource openAiService 'Microsoft.CognitiveServices/accounts@2022-12-01' = {
  name: openAiServiceName
  location: location
  sku: {
    name: 'S0'
  }
  kind: 'OpenAI'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    publicNetworkAccess: 'Enabled'
    restore: true
  }
}

resource openAiServiceDeployment 'Microsoft.CognitiveServices/accounts/deployments@2022-12-01' = {
  parent: openAiService
  name: deploymentName
  properties: {
    model: {
      format: 'OpenAI'
      name: modelName
      version: '1'
    }
    scaleSettings: {
      scaleType: 'Standard'
    }
  }
}

output openAiServiceEndpoint string = openAiService.properties.endpoint
output openAiServiceDeployment string = openAiServiceDeployment.properties.model.name
