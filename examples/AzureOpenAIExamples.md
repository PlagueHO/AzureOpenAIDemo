# Azure OpenAI Service Examples

## Classification

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

A message about a paying a ransom or my files will be deleted has appeared on my laptop.

Classified category:
```

```text
Classify the following security risk into 1 of the following categories: categories: [High, Medium, Low]

Hi There, I was on the train and a stranger walked up to me. They were asking me about my job. I left my laptop unattended and unlocked for a few minutes while I went to the bathroom. When I returned, I noticed that the screen was still on and the stranger had gone.

Classified category:
```

## Summarization

```text
Serverless for Hyperscale in Azure SQL Database brings together the benefits of serverless and Hyperscale into a single database solution. Now both compute and storage automatically scale based on workload demand for databases requiring up to 80 vCores and 100 TB. Billing is based on the amount of resources used rather than the amount provisioned. Serverless Hyperscale optimizes price-performance and simplifies performance management for databases with intermittent and unpredictable usage while leaving room for growing to extreme scale and delivering high performance during active usage periods.

tl;dr
```

## Extraction

```text
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.

Extract and number the following from the conversation:
1. Main reason for the conversation.
2. Sentiment of the customer.
3. How did the agent handle the conversation
4. What was the final outcome of the conversation
5. Create a short summary of the conversation
```

```text
You must extract the following information from the phone conversation below:

1. Call reason (key: reason)
2. Cause of the incident (key: cause)
3. Names of all drivers as an array (key: driver_names)
4. Insurance number (key: insurance_number)
5. Accident location (key: location)
6. Car damages (key: damages)
7. A short, yet detailed summary (key: summary)

Make sure the fields 1 to 6 are answered very short, e.g., for location just say the location name. Please answer in JSON machine-readable format, using the keys from above. Format the output as a JSON object called "results". Pretty print the JSON and make sure that it is properly closed at the end.

Phone convesation:
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```

```text
You must extract the following information from the phone conversation below:

1. Call reason (key: reason)
2. Cause of the incident (key: cause)
3. Names of all drivers as an array (key: driver_names)
4. Insurance number (key: insurance_number)
5. Accident location (key: location)
6. Car damages (key: damages)
7. A short, yet detailed summary (key: summary)

Make sure the fields 1 to 6 are answered very short, e.g., for location just say the location name. Please answer in POCO object format, using the keys from above. Format the output as a C# object called "results".

Phone convesation:
Hi There, I just had a car accident and wanted to report it. OK, I hope you’re alright and in a safe place to have this conversation. Yes, I’m fine thank you. Can you please describe to me what happened? I was driving on the M23 and I hit another car. Are you OK? Yeah, I’m just a little shaken up. That’s understandable. Can you give me your full name? Sure, it’s Sarah Standl. Do you know what caused the accident? I think I might have hit a pothole. OK, where did the accident take place? On the M23 near junction 10. Was anyone else injured? I don’t think so. But I’m not sure. OK, well we’ll need to do an investigation. Can you give me the other drivers information? Sure, his name is John Radley. And your insurance policy number. OK. Give me a minute. OK, it’s 546452.
Ok, is there any damage to your car? Yes, Headlights are broken and the airbags went off. Are you going to be able to drive it? I don’t think so. I’m going to have to have it towed. Well, we’ll need to get it inspected. I’ll go ahead and order you a tow van. I’ll also start the claim and we’ll get everything sorted out. Thank you.
```

## Generation

```text
Wartungsfenster fur den 14. Januar von 14 bis 15 Uhr geplant, erwarten Sie Ausfallzeiten.

Generate a formal customer communication in English.
- offer help at info@operations.com
- be apologetic where possible
- use 0:00 as time format

Please output in a letter format.
```

## Code generation using Code-Cushman-001

```text
Write a C# class that calls the Microsoft Graph API to retrieve users in Azure AD.
```

## Clinical code generation

```text
Generate the CPT and ICD-10 codes for the following operation:

DATE OF OPERATION: MM/DD/YYYY

PREOPERATIVE DIAGNOSIS: Acute appendicitis.

POSTOPERATIVE DIAGNOSIS: Acute suppurative appendicitis.

OPERATION PERFORMED: Laparoscopic appendectomy.

SURGEON: John Doe, MD

ANESTHESIA: General inhalation anesthesia.

FINDINGS:
1. The appendix was thick and indurated and erythematous with a fibrinous exudate throughout the distal one-half of the appendix. There were no gangrenous tract areas. There was no pus or abscess seen. The appendix was located behind the cecum in the retrocecal position, subserosal.
2. Inside the pelvis, there was about 50 mL of serosanguinous-type fluid that was suctioned out.
3. Small intestine, normal.
4. Large intestine, normal.
5. Omentum, normal.
6. Liver and gallbladder, normal.
7. The stomach looks normal.

ESTIMATED BLOOD LOSS: Minimal.

SPECIMEN: Appendix.

HISTORY: This is a (XX)-year-old Hispanic male with abdominal pain of 1 day’s duration with associated nausea and vomiting. Started to generalize and localize to his right lower quadrant. He had 17,000 white count with a CT scan positive for appendicitis. On physical exam, with tenderness in his right lower quadrant, guarding and rebound in his right lower quadrant with McBurney and Rovsing sign. He was admitted to the hospital, given IV antibiotics and IV fluids, and was taken to the operating room for appendectomy. Informed consent was obtained for appendectomy.

DESCRIPTION OF OPERATION: The patient was taken back to the operating suite and placed under general inhalation anesthesia. The patient was sterilely prepped and draped in the usual fashion. Foley catheter was used to decompress the bladder, orogastric tube used to decompress the stomach, 0.5% Marcaine with epinephrine infiltrated on his skin as a local anesthetic.

A semilunar subumbilical incision was made with a scalpel and dissection progressed down to the umbilical fascia using hemostats. The fascia was grasped up and a Veress needle was inserted in the abdomen, tested with water drop test. The abdomen was insufflated with CO2 gas. A 10 mm trocar was placed in the abdomen and 5 mm laparoscope placed in the abdomen.

Upon initial examination, the abdomen findings were noted as above. Under direct visualization, two 5-mm ports were placed in suprapubic and right lower quadrant area. Using a combination of sharp and blunt dissection, the cecum and part of the ascending colon was mobilized so we could access the appendix. It was then dissected free from the cecum using sharp dissection. The mesoappendix was taken down with sharp dissection and looped with an Endoloop. The base of the appendix doubly looped with Endoloop and base of the appendix ligated, placed in the Endopouch and brought out through the umbilical incision.

The base of the appendix was fulgurated to remove any remaining glands. The area was then irrigated with sterile saline and there was noted to be good hemostasis. No evidence of any bowel injury. The abdomen was desufflated. Ports were removed. Laparoscope was removed. The umbilical fascia was approximated with a figure-of-eight suture of 0 Vicryl and the skin was approximated with 4-0 Monocryl in subcuticular fashion. Steri-Strips were applied over the incision site. The patient tolerated the procedure well and was taken to postanesthesia care unit in stable condition. All packs, instruments, and needles were accounted for.
```
