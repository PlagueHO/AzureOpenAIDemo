param location string
param openAiServiceName string

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
  }
}

resource openAiServiceDavinciDeployment 'Microsoft.CognitiveServices/accounts/deployments@2022-12-01' = {
  parent: openAiService
  name: 'text-davinci-002'
  properties: {
    model: {
      format: 'OpenAI'
      name: 'text-davinci-002'
      version: '1'
    }
    scaleSettings: {
      scaleType: 'Standard'
    }
  }
}
