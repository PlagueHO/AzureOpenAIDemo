# Classify the sentiment of a movie review

> Recommended models: TEXT-DAVINCI-003

Extract the name of a movie from a movie review and generate a sentiment classification for the review.

```text
For the movie review below, please extract the following information:

1. The name of the movie being reviewed.
2. Classify the sentiment of the movie review below into one of: [very positive, positive, neutral, negative, very negative]
3. The director of the movie being reviewed. If it is not mentioned, please return "unknown".
4. A list of the actors/characters mentioned and the sentiment of their performances into one of: [good, neutral, bad]

Movie review:
A person might argue that once you’ve figured out how to download a person’s consciousness into a lab-grown, giant blue superhuman body, you don’t absolutely need to travel across the galaxy to hunt whales that produce minute quantities of stuff that stops human aging. But that person would be missing the point of director and co-writer James Cameron’s sequel to Avatar, a sequel that deploys even more high tech (or at least, high frame rate) than its predecessor in service to its message that happiness lies in reconnecting to nature. Because once humanity lost sight of that, erm, native truth, what else was left but the itch for innovation, expansion, and conquest? It would also be missing the point to lament the incessant addition of “bro!” and “cuz!” to the ends of lines spoken by the dreadlocked blue teen offspring of gone-Na'vi soldier Jake Sully, or the weird dramatic and personal vacancy of their torn-between-two-worlds human friend Spider. Because dialogue and character and even plot mechanics must here bend the knee before spectacle and dynamics. And those are things Cameron knows well enough to make you feel them in whatever part of you has made him so unerringly successful at the box office. Here, it’s the spectacle of a well lighted life below the ocean waves, and the dynamics of fathers and sons, of hosts and refugees, of hunter and hunted. And it would be missing the point in truly special fashion to call the proceedings indulgent to the point of self-infatuation: Cameron has built a new world from the remixed bits of this one, and he seems determined that we should not simply visit Pandora, we should, for at least three hours, live in it. However, it might not be missing the point to note that the devotion to ever-higher CG resolution and ever-more immersive 3-D has a tendency to drain the drama — the visceral, vital impact — from hand-to-hand combat, and to make the biggest battles feel like video-game cutscenes. To reduce, ultimately,
the experience's sum total of felt life. But then, there is more than one way to see this particular movie, so your mileage may vary.
```

> Recommended models: TEXT-DAVINCI-003

Extract the name of a movie from a movie review and generate a sentiment classification for the review as JSON.

```text
For the movie review below, please extract the following information:

1. The name of the movie being reviewed (key: name)
2. Classify the sentiment of the movie review below into one of: [very positive, positive, neutral, negative, very negative] (key: sentiment)
3. The director of the movie being reviewed. If it is not mentioned, please return "unknown". (key: director)
4. An array of the actors/characters mentioned and the sentiment of their performances into one of: [good, neutral, bad] (key: characters)

Make sure the fields 1 to 6 are answered very short, e.g., for location just say the location name. Please answer in JSON machine-readable format, using the keys from above. Format the output as a JSON object called "results". Pretty print the JSON and make sure that it is properly closed at the end.

Movie review:
A person might argue that once you’ve figured out how to download a person’s consciousness into a lab-grown, giant blue superhuman body, you don’t absolutely need to travel across the galaxy to hunt whales that produce minute quantities of stuff that stops human aging. But that person would be missing the point of director and co-writer James Cameron’s sequel to Avatar, a sequel that deploys even more high tech (or at least, high frame rate) than its predecessor in service to its message that happiness lies in reconnecting to nature. Because once humanity lost sight of that, erm, native truth, what else was left but the itch for innovation, expansion, and conquest? It would also be missing the point to lament the incessant addition of “bro!” and “cuz!” to the ends of lines spoken by the dreadlocked blue teen offspring of gone-Na'vi soldier Jake Sully, or the weird dramatic and personal vacancy of their torn-between-two-worlds human friend Spider. Because dialogue and character and even plot mechanics must here bend the knee before spectacle and dynamics. And those are things Cameron knows well enough to make you feel them in whatever part of you has made him so unerringly successful at the box office. Here, it’s the spectacle of a well lighted life below the ocean waves, and the dynamics of fathers and sons, of hosts and refugees, of hunter and hunted. And it would be missing the point in truly special fashion to call the proceedings indulgent to the point of self-infatuation: Cameron has built a new world from the remixed bits of this one, and he seems determined that we should not simply visit Pandora, we should, for at least three hours, live in it. However, it might not be missing the point to note that the devotion to ever-higher CG resolution and ever-more immersive 3-D has a tendency to drain the drama — the visceral, vital impact — from hand-to-hand combat, and to make the biggest battles feel like video-game cutscenes. To reduce, ultimately,
the experience's sum total of felt life. But then, there is more than one way to see this particular movie, so your mileage may vary.
```