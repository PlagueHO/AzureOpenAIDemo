# Fraud detection

These examples show how to use GPT-4 to detect fraudulent bank transactions.

## Detect fraudulent bank transactions

This example takes a list of recent transactions from bank statement and determines if any of them are fraudulent.

> Recommended models: GPT-4. Older models can be used but don't perform as well.

```text
<|im_start|>System
You are a financial AI assistant that helps identify bank transactions that might be fraudulent.
<|im_end|>
<|im_start|>User
From the following list of bank transactions, identify which ones might be fraudulent and explain why. Present your answer as a numbered list.

### Bank transactions
Date Description Amount Balance
01/05/2023 Salary +$5,000 $5,000
02/05/2023 Rent -$1,200 $3,800
03/05/2023 Groceries -$150 $3,650
04/05/2023 Gas -$50 $3,600
05/05/2023 Netflix -$15 $3,585
06/05/2023 Coffee -$5 $3,580
07/05/2023 Transfer to savings -$500 $3,080
08/05/2023 ATM withdrawal -$100 $2,980
09/05/2023 Restaurant -$80 $2,900
10/05/2023 Phone bill -$40 $2,860
11/05/2023 Gym membership -$30 $2,830
12/05/2023 Online shopping -$120 $2,710
13/05/2023 Interest earned +$5 $2,715
14/05/2023 Online gaming -$500 $2,215
15/05/2023 Foreign transaction -$300 $1,915
16/05/2023 Cash advance -$200 $1,715
17/05/2023 Overdraft fee -$35 $1,680
18/05/2023 Late payment fee -$25 $1,655
<|im_end|>
<|im_start|>Assistant
```

## Determine if a transaction is fraudulent

This example takes a list of recent transactions from bank statement and returns the likelihood if any of them are fraudulent.

> Recommended models: GPT-4, GPT-35-TURBO

```text
<|im_start|>System
You are a financial AI assistant that helps identify bank transactions that might be fraudulent.
<|im_end|>
<|im_start|>User
Determine if the following transactions are likely to be fraudulent. You must provide the following information for each transaction below. The date format is in DD/MM/YYYY:

1. Transaction date (key: date, format: YYYY-MM-DD)
2. Description (key: description)
3. Amount (key: amount)
4. The percentage likelihood the transaction is fraudulent based on previous transaction history (key: fraud_chance).
5. Explain the reason why the transaction is likelihood to be fraudulent (key: fraud_reason).

Please answer in JSON machine-readable format, using the keys from above. Format the output as a JSON object called "results". Pretty print the JSON and make sure that it is properly closed at the end.

### Transactions
02/07/2023 Rent -$1,200
03/07/2023 Rent -$1,200
04/07/2023 R3nt -$1,200
03/07/2023 Groceries -$490

### Recent bank statement
Date Description Amount
01/05/2023 Salary +$5,000
02/05/2023 Rent -$1,200
03/05/2023 Groceries -$150
04/05/2023 Gas -$50
05/05/2023 Netflix -$15
06/05/2023 Coffee -$5
07/05/2023 Transfer to savings -$500
08/05/2023 ATM withdrawal -$100
09/05/2023 Restaurant -$80
10/05/2023 Phone bill -$40
11/05/2023 Gym membership -$30
12/05/2023 Online shopping -$120
13/05/2023 Interest earned +$5
02/06/2023 Rent -$1,200
05/05/2023 Groceries -$180
<|im_end|>
<|im_start|>Assistant
```

### Use a C# model to define the output

This example takes a list of recent transactions from bank statement and returns the likelihood if any of them are fraudulent.

> Recommended models: GPT-4, GPT-35-TURBO

```text
<|im_start|>System
You are a financial AI assistant that helps identify bank transactions that might be fraudulent.
<|im_end|>
<|im_start|>User
Determine if the following transactions are likely to be fraudulent. The date format is in DD/MM/YYYY. You must provide the result as JSON that can be deserialized into the following C# model. Do not output any other content except the JSON.

### Model

/// <summary>
/// This class is used to represent the determination of fraud on a financial transaction.
/// </summary>
public class fraud {
    /// <summary>
    /// The date of the financial transaction.
    /// </summary>
    [JsonPropertyName("transactionDate")]
    public DateTime transactionDate { get; set; }
    /// <summary>
    /// The description of the financial transaction.
    /// </summary>
    [JsonPropertyName("transactionDescription")]
    public string transactionDescription { get; set; }
    /// <summary>
    /// The amount of the financial transaction.
    /// </summary>
    [JsonPropertyName("transactionAmount")]
    public decimal transactionAmount { get; set; }
    /// <summary>
    /// The percentage likelihood the transaction is fraudulent based on previous transaction history.
    /// </summary>
    [JsonPropertyName("fraudLikelihood")]
    public decimal fraudLikelihood { get; set; }
    /// <summary>
    /// The reason the transaction is considered fraudulent.
    /// </summary>
    [JsonPropertyName("fraudReason")]
    public string fraudReason { get; set; }
}

### Transactions
02/07/2023 Rent -$1,200
03/07/2023 Rent -$1,200
04/07/2023 R3nt -$1,200
03/07/2023 Groceries -$490

### Recent bank statement
Date Description Amount
01/05/2023 Salary +$5,000
02/05/2023 Rent -$1,200
03/05/2023 Groceries -$150
04/05/2023 Gas -$50
05/05/2023 Netflix -$15
06/05/2023 Coffee -$5
07/05/2023 Transfer to savings -$500
08/05/2023 ATM withdrawal -$100
09/05/2023 Restaurant -$80
10/05/2023 Phone bill -$40
11/05/2023 Gym membership -$30
12/05/2023 Online shopping -$120
13/05/2023 Interest earned +$5
02/06/2023 Rent -$1,200
05/05/2023 Groceries -$180
<|im_end|>
<|im_start|>Assistant
```

### Evaluate fraud possibility as a single sentence output

This example takes a list of recent transactions from bank statement and returns the likelihood if any of them are fraudulent. It outputs a single sentence for each transaction.

> Recommended models: GPT-4, GPT-35-TURBO

```text
Determine if the following transactions are likely to be fraudulent. You must evaluate the fraud possibility for each transaction below, considering the customer information. The date format is in DD/MM/YYYY. Please provide a single sentence description containing the transaction date, description, amount, fraud chance (as a %) and reason you think it is fraudulent.

### Customer
Lives in: New Zealand
Household: 2 Adults

### Transactions
02/07/2023 Rent -$1,200
03/07/2023 Rent -$1,200
04/07/2023 R3nt -$1,200
03/07/2023 Groceries -$490

### Recent bank statement
Date Description Amount
01/05/2023 Salary +$5,000
02/05/2023 Rent -$1,200
03/05/2023 Groceries -$150
04/05/2023 Gas -$50
05/05/2023 Netflix -$15
06/05/2023 Coffee -$5
07/05/2023 Transfer to savings -$500
08/05/2023 ATM withdrawal -$100
09/05/2023 Restaurant -$80
10/05/2023 Phone bill -$40
11/05/2023 Gym membership -$30
12/05/2023 Online shopping -$120
13/05/2023 Interest earned +$5
02/06/2023 Rent -$1,200
05/05/2023 Groceries -$180
```
