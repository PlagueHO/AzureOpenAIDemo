# Data Extraction from Support Timeline

Extract data from a support timeline summary of events to create a structured data set.

> Recommended models: GPT-35-TURBO

```text
You must extract the following information from the customer support case timeline below:

1. Issue title (key: issue_title)
2. Cause of the issue (key: cause)
3. Product (key: product)
4. Order number (key: ordernumber)
5. Case number (key: casenumber)
6. A short, yet detailed summary of the issue (key: issue_summary)
7. The resolution of the issue, if any (key: resolution)
8. An array of improvements that can be made to avoid this issue in future (key: improvements)
9. How many days did it take to resolve the issue (key: days_to_resolve)

Make sure the fields are very short. Ensure any abbreviations are expanded. Please answer in JSON machine-readable format, using the keys from above. Pretty print the JSON and make sure that it is properly closed at the end.

### Case details
Customer Service Case: Clothing Product Issue
Customer Name: Jane Doe
Product Name: Blue Denim Jacket
Order Number: 123456789
Case Number: 987654321

### Timeline of Events
- Jan 1, 2023: Customer placed an order for a blue denim jacket (size M) on the online store. Order confirmation email was sent to customer.
- Jan 5, 2023: Customer received an email notification that the order was shipped via UPS with tracking number.
- Jan 10, 2023: Customer received the order and found that the jacket was too small and had a tear on the sleeve. Customer contacted customer service via email and attached photos of the jacket. Customer requested a refund or exchange.
- Jan 11, 2023: Customer service agent replied to customer's email and apologized for the product issue. Agent offered to send a prepaid return label and process a full refund or exchange once the jacket was returned. Agent asked customer to confirm their preference and mailing address.
- Jan 12, 2023: Customer replied to agent's email and confirmed that they wanted an exchange for a blue denim jacket (size L). Customer also confirmed their mailing address.
- Jan 13, 2023: Agent sent customer a prepaid return label via email and instructed them to pack the jacket securely and drop it off at any UPS location. Agent also informed customer that they would receive an email notification once the exchange order was shipped.
- Jan 15, 2023: Customer returned the jacket using the prepaid return label. Return tracking number was updated on agent's system.
- Jan 18, 2023: Agent received confirmation that the jacket was delivered back to warehouse. Agent processed exchange order for blue denim jacket (size L) and shipped it via UPS with tracking number. Exchange order confirmation email was sent to customer.
- Jan 23, 2023: Customer received exchange order and found that jacket fit well and had no defects. Customer contacted customer service via email and thanked them for resolving their issue quickly and satisfactorily.
- Jan 24, 2023: Agent replied to customer's email and thanked them for their feedback. Agent also asked customer to rate their experience on a scale of one to five stars.
```

> Recommended models: GPT-35-TURBO, GPT-4

```text
<|im_start|>System
You are an AI assistant that helps improve support cases but extracting information from a customer support case timeline and recommending improvements.
<|im_end|>
<|im_start|>User
You must extract the following information from the customer support case timeline below:

1. Issue title (key: issue_title)
2. Cause of the issue (key: cause)
3. Product (key: product)
4. Order number (key: ordernumber)
5. Case number (key: casenumber)
6. A short, yet detailed summary of the issue (key: issue_summary)
7. The resolution of the issue, if any (key: resolution)
8. An array of improvements that can be made to avoid this issue in future (key: improvements)
9. How many days did it take to resolve the issue (key: days_to_resolve)

Make sure the fields are very short. Ensure any abbreviations are expanded. Please answer in JSON machine-readable format, using the keys from above. Pretty print the JSON and make sure that it is properly closed at the end.

### Case details
Customer Service Case: Clothing Product Issue
Customer Name: Jane Doe
Product Name: Blue Denim Jacket
Order Number: 123456789
Case Number: 987654321

### Timeline of Events
- Jan 1, 2023: Customer placed an order for a blue denim jacket (size M) on the online store. Order confirmation email was sent to customer.
- Jan 5, 2023: Customer received an email notification that the order was shipped via UPS with tracking number.
- Jan 10, 2023: Customer received the order and found that the jacket was too small and had a tear on the sleeve. Customer contacted customer service via email and attached photos of the jacket. Customer requested a refund or exchange.
- Jan 11, 2023: Customer service agent replied to customer's email and apologized for the product issue. Agent offered to send a prepaid return label and process a full refund or exchange once the jacket was returned. Agent asked customer to confirm their preference and mailing address.
- Jan 12, 2023: Customer replied to agent's email and confirmed that they wanted an exchange for a blue denim jacket (size L). Customer also confirmed their mailing address.
- Jan 13, 2023: Agent sent customer a prepaid return label via email and instructed them to pack the jacket securely and drop it off at any UPS location. Agent also informed customer that they would receive an email notification once the exchange order was shipped.
- Jan 15, 2023: Customer returned the jacket using the prepaid return label. Return tracking number was updated on agent's system.
- Jan 18, 2023: Agent received confirmation that the jacket was delivered back to warehouse. Agent processed exchange order for blue denim jacket (size L) and shipped it via UPS with tracking number. Exchange order confirmation email was sent to customer.
- Jan 23, 2023: Customer received exchange order and found that jacket fit well and had no defects. Customer contacted customer service via email and thanked them for resolving their issue quickly and satisfactorily.
- Jan 24, 2023: Agent replied to customer's email and thanked them for their feedback. Agent also asked customer to rate their experience on a scale of one to five stars.
<|im_end|>
<|im_start|>Assistant
```
