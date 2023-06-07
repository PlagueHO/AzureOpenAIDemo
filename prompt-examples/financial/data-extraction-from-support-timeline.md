# Data Extraction from Support Timeline

Extract data from a support timeline summary of events to create a structured data set.

> Recommended models: TEXT-DAVINCI-003

```text
You must extract the following information from the customer support case timeline below:

1. Issue title (key: issue_title)
2. Cause of the issue (key: cause)
3. Case number (key: casenumber)
4. A short, yet detailed summary of the issue (key: issue_summary)
5. The resolution of the issue, if any (key: resolution)
6. An array of improvements that can be made to avoid this issue in future (key: improvements)
7. How many days did it take to resolve the issue (key: days_to_resolve)
8. What is the risk to the organization, measured against the ISO 31000 risk management framework (key: risk)
9. Describe the risk in detail using the ISO 31000 framework (key: risk_detail)
10. What information should also be collected to improve determination of risk (key: missing_information)

Make sure the fields are very short. Ensure any abbreviations are expanded. Please answer in JSON machine-readable format, using the keys from above. Pretty print the JSON and make sure that it is properly closed at the end.

### Case details
Customer Service Case: Mortgage
Customer Name: Jane Doe
Product Name: Home Mortgage
Case Number: 987654321

### Timeline of Events
1. 2021-05-01 10:00 - John, the customer, meets with a mortgage broker, Sarah, to discuss mortgage options.
2. 2021-05-01 11:00 - Sarah provides John with incorrect information regarding the mortgage terms.
3. 2021-05-15 14:00 - John signs the mortgage agreement, based on the incorrect information provided by Sarah.
4. 2021-06-01 09:00 - John receives his first mortgage statement and realizes that the terms are different from what Sarah had told him.
5. 2021-06-01 10:00 - John calls the bank's customer service to complain about the discrepancy.
6. 2021-06-01 10:30 - Customer service representative, Mark, listens to John's complaint and promises to investigate the matter.
7. 2021-06-02 14:00 - Mark calls John back to inform him that the bank is looking into the matter and will get back to him within a week.
8. 2021-06-09 16:00 - Mark calls John to inform him that the bank has found that Sarah did provide incorrect information, but the documentation provided to John was unclear.
9. 2021-06-09 16:30 - John expresses his dissatisfaction with the situation and demands a resolution.
10. 2021-06-10 09:00 - Mark escalates the issue to his supervisor, Lisa.
11. 2021-06-11 11:00 - Lisa calls John to discuss the situation and offers to renegotiate the mortgage terms.
12. 2021-06-14 10:00 - John meets with Lisa to renegotiate the mortgage terms.
13. 2021-06-14 11:00 - John and Lisa come to an agreement on the new mortgage terms.
14. 2021-06-15 09:00 - Lisa sends John the new mortgage agreement for review.
15. 2021-06-16 14:00 - John signs the new mortgage agreement.
16. 2021-06-17 10:00 - Lisa calls John to confirm that the new mortgage agreement has been processed and the new terms are in effect.
17. 2021-06-17 10:30 - John expresses his satisfaction with the resolution and thanks Lisa for her assistance.
18. 2021-06-18 09:00 - Lisa informs Sarah of the situation and provides her with additional training to prevent similar mistakes in the future.
19. 2021-06-18 14:00 - Lisa reviews the bank's mortgage documentation to ensure that it is clear and easy to understand for customers.
20. 2021-06-30 16:00 - John receives his new mortgage statement reflecting the new terms and is satisfied with the outcome.
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
3. Case number (key: casenumber)
4. A short, yet detailed summary of the issue (key: issue_summary)
5. The resolution of the issue, if any (key: resolution)
6. An array of improvements that can be made to avoid this issue in future (key: improvements)
7. How many days did it take to resolve the issue (key: days_to_resolve)
8. What is the risk to the organization, measured against the ISO 31000 risk management framework (key: risk)
9. Describe the risk in detail using the ISO 31000 framework (key: risk_detail)
10. What information should also be collected to improve determination of risk (key: missing_information)

Make sure the fields are very short. Ensure any abbreviations are expanded. Please answer in JSON machine-readable format, using the keys from above. Pretty print the JSON and make sure that it is properly closed at the end.

### Case details
Customer Service Case: Mortgage
Customer Name: Jane Doe
Product Name: Home Mortgage
Case Number: 987654321

### Timeline of Events
1. 2021-05-01 10:00 - John, the customer, meets with a mortgage broker, Sarah, to discuss mortgage options.
2. 2021-05-01 11:00 - Sarah provides John with incorrect information regarding the mortgage terms.
3. 2021-05-15 14:00 - John signs the mortgage agreement, based on the incorrect information provided by Sarah.
4. 2021-06-01 09:00 - John receives his first mortgage statement and realizes that the terms are different from what Sarah had told him.
5. 2021-06-01 10:00 - John calls the bank's customer service to complain about the discrepancy.
6. 2021-06-01 10:30 - Customer service representative, Mark, listens to John's complaint and promises to investigate the matter.
7. 2021-06-02 14:00 - Mark calls John back to inform him that the bank is looking into the matter and will get back to him within a week.
8. 2021-06-09 16:00 - Mark calls John to inform him that the bank has found that Sarah did provide incorrect information, but the documentation provided to John was unclear.
9. 2021-06-09 16:30 - John expresses his dissatisfaction with the situation and demands a resolution.
10. 2021-06-10 09:00 - Mark escalates the issue to his supervisor, Lisa.
11. 2021-06-11 11:00 - Lisa calls John to discuss the situation and offers to renegotiate the mortgage terms.
12. 2021-06-14 10:00 - John meets with Lisa to renegotiate the mortgage terms.
13. 2021-06-14 11:00 - John and Lisa come to an agreement on the new mortgage terms.
14. 2021-06-15 09:00 - Lisa sends John the new mortgage agreement for review.
15. 2021-06-16 14:00 - John signs the new mortgage agreement.
16. 2021-06-17 10:00 - Lisa calls John to confirm that the new mortgage agreement has been processed and the new terms are in effect.
17. 2021-06-17 10:30 - John expresses his satisfaction with the resolution and thanks Lisa for her assistance.
18. 2021-06-18 09:00 - Lisa informs Sarah of the situation and provides her with additional training to prevent similar mistakes in the future.
19. 2021-06-18 14:00 - Lisa reviews the bank's mortgage documentation to ensure that it is clear and easy to understand for customers.
20. 2021-06-30 16:00 - John receives his new mortgage statement reflecting the new terms and is satisfied with the outcome.
<|im_end|>
<|im_start|>Assistant
```
