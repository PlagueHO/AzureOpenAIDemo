# Security Risk Classification

Classify a free text issue description into one of the following categories: [High, Medium, Low]

This is an improved security risk classification that provides grounding (from Azure AD on the user and their devices), a bases the risk on the ISO 31000 risk management framework, and provides a more granular classification of the risk. It also provides few-shot training.

```text
Please classify the security risk for the following user situation into one of the following categories: [high security risk, medium security risk, low security risk]

The situation concerns the user daniel@contoso.com, who is a IT administrator. The user has MFA enabled on thier account. The user's device is not currently compliant with Contoso device policy.

Use the ISO 31000 risk management framework as a basis for classifying the risk.

A high security risk is any situation that could:
- cause an administrator credential to be compromised
- cause credit card or PCI data to be compromised
- cause loss of data or reputation damage to Contoso

###
Prompt: I left my laptop on, logged in and unattended on a train. It was connected to my cell phone and I had logged into Azure.
Security Risk: High

###
Prompt: I have deployed an Azure App Service that hosts a web site. The App Service collects credit card data and stores it in an Azure SQL Database. The Database is on a public IP address with no firewall.
Security Risk: High

###
Prompt:  I left my laptop on and unattended on a train. It was connected to my cell phone and I had logged into Azure. My laptop was logged in. I noticed a browser window had been opened that I didn't open.
Security Risk: High

###
Prompt: I have deployed an Azure App Service that hosts a web site. The App Service does collects recipes and stores them in an Azure SQL Database. The Database is on a public IP address with no firewall.
Security Risk:
```

The following are simpler zero-shot examples that don't provide grounding.

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Risk: The Azure AD Global Administrator password has been compromized.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Risk: User has connected to a unencrypted public wifi.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Risk: User does not have multi-factor authentication enabled.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Risk: Global Administrator does not have multi-factor authentication enabled.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Risk: We use Azure AD and our organization does not have multi-factor authentication enabled.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

A message about a paying a ransom or my files will be deleted has appeared on my laptop.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Hi There, I was on the train and a stranger walked up to me. They were asking me about my job. I left my laptop unattended and unlocked for a few minutes while I went to the bathroom. When I returned, I noticed that the screen was still on and the stranger had gone.

Classified category:
```
