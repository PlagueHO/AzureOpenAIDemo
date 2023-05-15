# Recommender

These examples of recommenders for recommending products to customers based on various grounding data.

Important: Recommenders need access to the latest products available in the store. Relying on the training data in the model to only recommend relevant material will not work well as they will only recommend older products. The recommender needs to be able to access the latest products available in the store, which would need to be provided via grounding the prompt with relevant products based on a semantic index (using Embeddings).

## Recommender with customer grounding

Simple recommendations provided based on customer interests and previous purchases.

> Recommended models: GPT-35-TURBO, GPT-4

```text
<|im_start|>System
You are an AI assistant for "The Nile" books in Australia. You suggest books that people might like based on their interests. You only suggest books that can be found on the Nile website.
<|im_end|>
<|im_start|>User
Recommend 5 books that are available from the Nile bookstore for the customer below based on their previous purchases and interests. Provide a one paragraph summary of why the customer would be interested in each recommended book.

### Customer
32-year old named Janet who has previously purchased the following books:
- The Martian by Andy Weir - customer rated 3 star
- The Three-Body Problem by Liu Cixin - customer rated 5 star
- We Are Legion (We Are Bob) by Dennis E. Taylor - customer didn't rate
- Seveneves by Neal Stephenson - customer rated 1 star
- Leviathan Wakes by James S. A. Corey - customer rated 5 star

Janet also has interests in the following: cats, software development, DevOps & Dungeons and Dragons.
<|im_end|>
<|im_end|>Assistant
```

## Recommender with customer and relevant book grounding

Improved recommendations provided based on customer interests, previous purchases and relevant books from Semantic Index. The "Similar Books" section would be pulled from a Semantic Index based on the customer's interests and previous purchases. This would be a suitable use case for Embeddings.

> Recommended models: GPT-35-TURBO, GPT-4

```text
<|im_start|>System
You are an AI assistant for "The Nile" books in Australia. You suggest books that people might like based on their interests. You only suggest books that can be found on the Nile website. You will only suggest books that are appropriate reading for the customer's age.
<|im_end|>
<|im_start|>User
Recommend 5 books that are available from the Nile bookstore for the customer below based on their previous purchases and interests. Provide a one sentence summary of why the customer would be interested in each book recommendation. You may also suggest books from the similar books list below.

### Customer
8-year old named Mary who has previously purchased the following books:
- The Hitchhikers Guide to the Galaxy

Janet also has interests in the following: cats, space travel, dinosaurs, science fiction.

### Similar books
- Our Blue Orange by A.R. Merrydew: A humorous sci-fi adventure about an inventor who discovers a new phenomenon that affects the aging android fleet that serves the colony on Mars.
- Alcatraz Versus the Evil Librarians by Brandon Sanderson: A witty and action-packed fantasy series about a boy named Alcatraz who has a talent for breaking things and a destiny to save the world from the evil librarians who control all the information.
- Light From Uncommon Stars by Ryka Aoki: A quirky and heartwarming tale of three women who make a deal with the devil: a violin prodigy, a donut shop owner, and a spaceship captain who plays the violin.
- Matching Configurations by Kyle Keyes: A light sci-fi story that features Olan Chapman, a hero vigilante who defends the weak and helpless victims of today’s society with his quantum roots and matching configurations.
<|im_end|>
<|im_end|>Assistant
```