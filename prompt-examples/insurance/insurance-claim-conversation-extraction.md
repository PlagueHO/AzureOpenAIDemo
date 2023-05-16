# Insurance Claim Conversation Extraction

- [Extract data in list](#extract-data-in-list)
- [Extract data in numbered list](#extract-data-in-numbered-list)
- [Extract data in JSON format](#extract-data-in-json-format)
- [Extract data in POCO format](#extract-data-in-poco-format)
- [Generate a follow-up letter](#generate-a-follow-up-letter)

## Extract data in list

> Recommended models: TEXT-DAVINCI-003

Extracts information from a phone conversation between an insurance agent and a customer in a list.

```text
Extract the following from the conversation below:
1. Main reason for the conversation.
2. Sentiment of the customer.
3. How did the agent handle the conversation
4. What was the final outcome of the conversation
5. Create a short summary of the conversation
6. Was a tow truck ordered?

### Conversation
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```

## Extract data in numbered list

> Recommended models: TEXT-DAVINCI-003

Extracts information from a phone conversation between an insurance agent and a customer into a numbered list.

```text
Extract and number the following from the conversation below as a numbered list:
1. Main reason for the conversation.
2. Sentiment of the customer.
3. How did the agent handle the conversation
4. What was the final outcome of the conversation
5. Create a short summary of the conversation
6. Was a tow truck ordered?

### Conversation
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```

## Extract data in JSON format

Extracts information from a phone conversation between an insurance agent and a customer into a JSON object that an application can read.

> Recommended models: TEXT-DAVINCI-003

```text
You must extract the following information from the conversation below:

1. Call reason (key: reason)
2. Cause of the incident (key: cause)
3. Names of all drivers as an array (key: driver_names)
4. Insurance number (key: insurance_number)
5. Accident location (key: location)
6. Car damages (key: damages)
7. A short, yet detailed summary (key: summary)

Make sure the fields 1 to 6 are answered very short, e.g., for location just say the location name. Please answer in JSON machine-readable format, using the keys from above. Format the output as a JSON object called "results". Pretty print the JSON and make sure that it is properly closed at the end.

### Conversation
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```

### Generate a follow-up letter

> Recommended models: TEXT-DAVINCI-003

Generate a follow-up letter from a phone conversation between an insurance agent and a customer.

```text
Generate a follow-up letter to the customer from the following phone conversation, and include a summary of the accident and policy number. If a tow truck or tow van was called, please also include this.

### Conversation
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```

### Generate a follow-up letter with recent history and suggestions

> Recommended models: TEXT-DAVINCI-003

```text
Generate a follow-up letter to the customer from the following phone conversation, and include a summary of the accident and policy number. If a tow truck or tow van was called, please also include this.

Politely and helpfully include any driving improvement recommendations based on the customer history.

### Customer history
2020-05-05: Collision with delivery van while backing. No injuries. Minor damage to rear fender.
2021-06-03: Collision with power pole while backing. No injuries. Minor damage to rear fender.
2022-08-29: Collision with garage while backing. No injuries. Minor damage to rear fender.

### Conversation
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```