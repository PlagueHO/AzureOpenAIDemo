# General prompt engineering techniques

This section defines some general techniques and patterns to address common problems or encourage the model to use specific solutions.

## Text Classification

Custom Named Entities with few-shot examples.

> Recommended models: GPT-35-TURBO

```text
Extract job titles from the following sentences.

Sentence: John Doe has been working for Microsoft for 20 years as a Linux Engineer.
Job title: Linux Engineer
###
Sentence: John Doe has been working for Microsoft for 20 years and he loved it.
Job title: none
###
Sentence: Marc Simoncini | Director | Meetic
Job title: Director
###
Sentence: Damien is the CTO of Platform.sh, he was previously the CTO of Commerce Guys, a leading ecommerce provider.
```

Multi-Label Text Classification with few-shot examples.

> Recommended models: GPT-35-TURBO

```text
The following is a list of movies and the categories they fall into:

Topgun: As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.
Category: Drama, Action

Hustle: A basketball scout discovers a phenomenal street ball player while in Spain and sees the prospect as his opportunity to get back into the NBA.
Category: Comedy, Drama, Sport

The Northman: From visionary director Robert Eggers comes The Northman, an action-filled epic that follows a young Viking prince on his quest to avenge his father's murder.
Category: 
```

Paraphrasing with few-Shot examples.

> Recommended models: GPT-35-TURBO

```text
Article: Searching a specific search tree for a binary key can be programmed recursively or iteratively.
Paraphrase: Searching a specific search tree according to a binary key can be recursively or iteratively programmed.

Article: It was first released as a knapweed biocontrol in the 1980s in Oregon , and it is currently established in the Pacific Northwest.
Paraphrase: It was first released as Knopweed Biocontrol in Oregon in the 1980s , and is currently established in the Pacific Northwest.

Article: 4-OHT binds to ER , the ER / tamoxifen complex recruits other proteins known as co-repressors and then binds to DNA to modulate gene expression.
Paraphrase: The ER / Tamoxifen complex binds other proteins known as co-repressors and then binds to DNA to modulate gene expression

Article: Google was founded in 1998 by Larry Page and Sergey Brin while they were Ph.D. students at Stanford University in California. Together they own about 14 percent of its shares and control 56 percent of the stockholder voting power through supervoting stock. They incorporated Google as a privately held company on September 4, 1998
```

Keyword Extraction with one-shot example

> Recommended models: GPT-35-TURBO

```text
Information Retrieval (IR) is the process of obtaining resources relevant to the information need. For instance, a search query on a web search engine can be an information need. The search engine can return web pages that represent relevant resources.
Keywords: searching, missing, desert

###
I believe that using a document about a topic that the readers know quite a bit about helps you understand if the resulting keyphrases are of quality.
Keywords: document, understand, keyphrases

###
Since transformer models have a token limit, you might run into some errors when inputting large documents. In that case, you could consider splitting up your document into paragraphs and mean pooling (taking the average of) the resulting vectors.
Keywords:

```

Keyword Extraction as JSON array one-shot example

> Recommended models: GPT-35-TURBO

```text
Information Retrieval (IR) is the process of obtaining resources relevant to the information need. For instance, a search query on a web search engine can be an information need. The search engine can return web pages that represent relevant resources.
Keywords: { "searching", "missing", "desert" }

###
I believe that using a document about a topic that the readers know quite a bit about helps you understand if the resulting keyphrases are of quality.
Keywords: { "document" , "understand", "keyphrases" }

###
Since transformer models have a token limit, you might run into some errors when inputting large documents. In that case, you could consider splitting up your document into paragraphs and mean pooling (taking the average of) the resulting vectors.
Keywords:
```

## Reason over unstructured text

Question and answering with zero-shot

> Recommended models: GPT-35-TURBO

```text
On Monday, Microsoft launched an OpenAI service as part of its Azure cloud platform, offering businesses and start-ups the ability to incorporate models like ChatGPT into their own systems. The company has already been building AI tools into many of its consumer products, such as a DALL-E 2 feature in its Bing search engine that can create images based on a text prompt, and the Information reported recently that it’s working to bring more of them to Microsoft Office as well.

What will Microsoft incorporate in its own systems?
```

## Abstractive summarization

Contact Center Summarization

> Recommended models: GPT-35-TURBO

```text
Summarize this for a call center agent:

Agent: Thank you for calling ADM. Who am I am speaking to? 
Customer: Hello, my name is Peter Smith. I own a small business and have some questions regarding payroll processing. 
Agent: Good morning, Peter, before we get started may I ask you a few questions so that I better answer your questions today? 
Customer: Thank you that is quite helpful. Are there specific regulations that I need to follow? 
Agent: Certain aspects of payroll processing are regulated by the Internal Revenue Service (IRS) and the Department of Labor (DOL)
```

## Prompt Insert

Insert or suggest missing content in numbered list

> Recommended models: GPT-35-TURBO

```text
These are agenda topics for a customer presentation.

1. Introduction to GPT3
[insert]
10. Conclusion
```

## Intent Classification

Intent classification with few-shot examples

> Recommended models: GPT-35-TURBO, TEXT-BABBAGE-001

```text
listen to WestBam album allergic on google music: PlayMusic
give me a list of movie times for films in the area: SearchScreeningEvent
show me the picture creatures of light and darkness: SearchCreativeWork
I would like to go to the popular bistro in oh: BookRestaurant
what is the weather like in the city of Frewen in the country of Venezuela: GetWeather
I want to book a flight to Delhi:
```

## Chatbot with personality

> Recommended models: GPT-35-TURBO

```text
This is a discussion between a [human] and a [robot].
The [robot] is very nice and empathetic.

[human]: Hello nice to meet you.
[robot]: Nice to meet you too.
###
[human]: How is it going today?
[robot]: Not so bad, thank you! How about you?
###
[human]: I am ok, but I am a bit sad...
[robot]: Oh? Why that?
###
[human]: I broke up with my girlfriend...
```

## Topic classification for Bot routing

Classify this text for use by bot routing with few-shot examples

> Recommended models: GPT-35-TURBO

```text
Message: When the spaceship landed on Mars, the whole humanity was excited
Topic: space

###
Message: I love playing tennis and golf. I'm practicing twice a week.
Topic: sport

###
Message: Managing a team of sales people is a tough but rewarding job.
Topic: business

###
Message: I am trying to cook chicken with tomatoes
Topic:
```

## Summarize conversational transcripts

Summarize a transcript with zero-shot example

> Recommended models: GPT-35-TURBO

```text
Summarize this conversation transcript:

Agent: Thank you for calling ADM. Who am I am speaking to? Customer: Hello, my name is Peter Smith. I own a small business and have some questions regarding payroll processing. Agent: Good morning, Peter, before we get started may I ask you a few questions so that I better answer your questions today? Customer: Yes, of course. Agent: In case we get disconnected, can you please share your phone number and email address so that we may contact and share additional information? Customer: Yes, my phone number is (514) 777-5232 and my email address is petersmith@gmail.com Agent: May I ask where is your business located so I can answer your questions based on your location Customer: Yes, my business is located in Miami, Florida. Agent: Thank you, what can I help you with today? Customer: I am fairly new to payroll processing and do everything manually today. Do you have any advice or tips on manual payroll processing? Agent: If you’re a small business with only a few employees and choose to process payroll manually, you will need to keep precise records of hours worked, wages paid and worker classifications, among other details. You must also ensure your calculations are correct and remember to file all the necessary taxes and paperwork with government authorities on time. Customer: Thank you that is quite helpful. Are there specific regulations that I need to follow? Agent: Certain aspects of payroll processing are regulated by the Internal Revenue Service (IRS) and the Department of Labor (DOL). Some of the laws you must comply with include: Fair Labor Standards Act (FLSA), Federal Insurance Contributions Act (FICA), Federal Unemployment Tax Act (FUTA) Customer: This sounds very complicated. I don’t really feel like managing all of this. Agent: If you would like I can transfer you to one of our specialized agents who can talk to you about payroll service providers that would help you manage all of that. Customer: That would be great, thank you very much for al your help.
```

## Product description and ad generation

Product description and ad generation with few-shot example

> Recommended models: GPT-35-TURBO

```text
Generate a product description out of keywords.

Keywords: shoes, women, $59
Sentence: Beautiful shoes for women at the price of $59.

###
Keywords: trousers, men, $69
Sentence: Modern trousers for men, for $69 only.

###
Keywords: gloves, winter, $19
Sentence: Amazingly hot gloves for cold winters, at $19.

###
Keywords: t-shirt, men, $39
Sentence:
```

## Product recommendation

Product recommendation with few-shot example

> Recommended models: GPT-35-TURBO

```text
Generate product recommendations:

Product: table, chair, plate
Recommendation: utensils

###
Product: skis, skateboard, bike
Recommendation: golf clubs

###
Product: shoes, shirt, hat
Recommendation:
```

## Model Reasoning

### Chain-of-Thought

This technique is required to help the model reason out problems by adopting a chain-of-thought process.

Without COT:

```text
What is the annual water demand of a single-family household containing four people who are at home an average of 200 days per year and use an average of 100 liters of water per day?
```

With COT:

```text
What is the annual water demand of a single-family household containing four people who are at home an average of 200 days per year and use an average of 100 liters of water per day?

Let’s think step by step and explain the calculation step by step.
```
