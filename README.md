# Azure OpenAI Service demonstration

A set of demo applications for Azure OpenAI Service. These applications can be deployed to Azure using the included GitHub [workflow](.github\workflows\deploy-aas.yml), which will create the Azure resources using the Azure Bicep files found in the [bicep](bicep) folder.

## Example prompts and conversation (chat) bots

This repository contains a library of example prompts and chat (AI assistants) for various use cases and industries.

- [Prompt (text-in/text-out) examples](prompt-examples/README.md)
- [Conversation (conversation-in/text-out)](prompt-examples/README.md)

## Demonstration applications

This repository contains the following demonstrations:

- [Azure OpenAI in a Blazor .NET web server application in Azure App Service](src\AzureOpenAIBlazorServer)

## Configuring the GitHub workflow

The following GitHub Actions variables should be configured in the repository to define the region:

- `TYPE`: This is the demo type to deploy. It must be set to 'AAS' for Azure App Service.
- `APPSERVICEPLAN_CONFIGURATION`: The configuration of the Azure App Service Plan for running the Foundry VTT server. Must be one of `B1`, `P1V2`, `P2V2`, `P3V2`, `P1V3`, `P2V3`, `P3V3`.
- `BASE_RESOURCE_NAME`: The base name that will prefixed to all Azure resources deployed to ensure they are unique. For example, `dsraoaidemo`.
- `LOCATION`: The Azure region to deploy the resources to. For example, `SouthCentralUS`. **Note: This should only be regions where the Azure OpenAI Service is available.**
- `RESOURCE_GROUP_NAME`: The name of the Azure resource group to create and add the resources to. For example, `dsr-aoaidemo-rg`.

Your variables should look similar to this:
![Example of GitHub Variables](/images/github-actions-variables.png)

The following GitHub Secrets need to be defined to enable the workflow identity federation to authenticate to Azure:

- `AZURE_CLIENT_ID`: The Application (Client) ID of the Service Principal used to authenticate to Azure. This is generated as part of configuring Workload Identity Federation.
- `AZURE_TENANT_ID`: The Tenant ID of the Service Principal used to authenticate to Azure.
- `AZURE_SUBSCRIPTION_ID`: The Subscription ID of the Azure Subscription to deploy to.

These values should be kept secret and care taken to ensure they are not shared with anyone.
Your secrets should look like this:
![Example of GitHub Secrets](/images/github-actions-secrets.png)

## Configuring Workload Identity Federation for GitHub Actions workflow

Customize and run this code in Azure Cloud Shell to create the credential for the GitHub workflow to use to deploy to Azure.
[Workload Identity Federation](https://learn.microsoft.com/azure/active-directory/develop/workload-identity-federation) will be used by GitHub Actions to authenticate to Azure.

```powershell
$credentialname = '<The name to use for the credential & app>' # e.g., github-dsrazureopenaidemo-workflow
$application = New-AzADApplication -DisplayName $credentialname
$policy = "repo:<your GitHub user>/<your GitHub repo>:ref:refs/heads/main" # e.g., repo:PlagueHO/AzureOpenAIDemo:ref:refs/heads/main
$subscriptionId = '<your Azure subscription>'

New-AzADAppFederatedCredential `
    -Name $credentialname `
    -ApplicationObjectId $application.Id `
    -Issuer 'https://token.actions.githubusercontent.com' `
    -Audience 'api://AzureADTokenExchange' `
    -Subject $policy
New-AzADServicePrincipal -AppId $application.AppId

New-AzRoleAssignment `
  -ApplicationId $application.AppId `
  -RoleDefinitionName Contributor `
  -Scope "/subscriptions/$subscriptionId" `
  -Description "The deployment workflow for the Azure OpenAI Service Demos."
```

To learn how to configure Workload Identity Federation with GitHub Actions, see [this Microsoft Learn Module](https://learn.microsoft.com/training/modules/authenticate-azure-deployment-workflow-workload-identities).
Please see [this document](https://learn.microsoft.com/en-us/azure/developer/github/connect-from-azure) for more information on Workload Identities.
