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