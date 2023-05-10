# Generate SQL from Natural language

You can use any of the Codex models to generate SQL from natural language. 

## About Codex

The Codex models are descendants of our base GPT-3 models that can understand and generate code. Their training data contains both natural language and billions of lines of public code from GitHub.

They’re most capable in Python and proficient in over a dozen languages, including C#, JavaScript, Go, Perl, PHP, Ruby, Swift, TypeScript, SQL, and Shell. In the order of greater to lesser capability, the Codex models are:

- code-davinci-002
- code-cushman-001

## Davinci

Similar to GPT-3, Davinci is the most capable Codex model and can perform any task the other models can perform, often with less instruction. For applications requiring deep understanding of the content, Davinci produces the best results. Greater capabilities require more compute resources, so Davinci costs more and isn't as fast as other models.

## Cushman
Cushman is powerful, yet fast. While Davinci is stronger when it comes to analyzing complicated tasks, Cushman is a capable model for many code generation tasks. Cushman typically runs faster and cheaper than Davinci, as well.

Learn more about the Codex models [here]( 
https://learn.microsoft.com/en-us/azure/cognitive-services/openai/concepts/models#codex-models).

> Recommended model: Use either of the ones listed above. If for any reason you don't have access to the codex models, you can fall back to text-davinci-003.

## Examples

```sql
### Postgres SQL tables, with their properties:
#
# Employee(id, name, department_id)
# Department(id, name, address)
# Salary_Payments(id, employee_id, amount, date)
#
### A query to list the names of the departments which employed more than 10 employees in the last 3 months

SELECT
```

## Notes:
- Use the following stop sequence to indicate the end of the query: `#` and `;`

