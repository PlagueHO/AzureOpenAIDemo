# General practitioner referral

This document shows an example of evolution of a prompt from a simple text to a full prompt with a workflow.

Goal: Improve the referral workflow of a GP practice, to automate documentation generation and delivery.
Scenario: A Dr. Smith sees a patient, 80 year old man, Fred, at his practice. Fred has broken his upper elbow by falling off his ebike. He wants to refer Fred to the Dr. Jones, at the Fracture Clinic in Contoso Hospital.

Inputs:
1. Medical short hand Dr. Smith creating during the visit:
```text
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

1. Transcription from the visit.

```text
I saw Fred today. He tells me he fell off his ebike and landed heavily on his elbow. I've sent him to get X-rays and will refer him to Fracture Clinic at Contoso Health.
```

## Explain the Medical Shorthand

Explain the medical shorthand.

> Using the GPT-35-TURBO or GPT-4 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Explain the following medical shorthand and what it means.

### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
Explain the following medical shorthand and what it means.

### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

## Extract the medial shorthand as JSON

Output the meaning of the medical shorthand as JSON.

> Using the GPT-35-TURBO or GPT-3 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Output the meaning of the medical shorthand as JSON.

### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
Output the meaning of the medical shorthand as JSON.

### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

## Extract the medical shorthand as JSON

Output the meaning of the medical shorthand as JSON. The JSON format is not correct. Use a **one-shot** example to improve it.

> Using the GPT-35-TURBO or GPT-3 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Explain the meaning of the medical shorthand and output as JSON.
### Medical Shorthand
S: 70 y/o pt c/o CP. O: Pt appears uncomfortable, clutching chest. Vitals: BP 160/90, HR 110, RR 20, O2 sat 95% on RA. EKG shows ST elevations in leads II, III, and aVF. A: Suspected acute MI. P: Administer aspirin, nitroglycerin, and morphine. Transfer to ED for further management.
Response:
<|im_end|>
<|im_start|>Assistant
SOAP = {
    "Subjective": "70 year old patient complains of chest pain.",
    "Objective": "Patient appears uncomfortable, clutching chest. Vital signs: Blood pressure 160/90, heart rate 110, respiratory rate 20, oxygen saturation 95% on room air. Electrocardiogram shows ST elevations in leads II, III, and aVF.",
    "Assessment": "Suspected acute myocardial infarction.",
    "Plan": "Administer aspirin, nitroglycerin, and morphine. Transfer to emergency department for further management."
}
<|im_end|>
<|im_start|>User
Explain the meaning of the medical shorthand and output as JSON.
### Medical Shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.

###
Prompt: Explain the meaning of the medical shorthand and output as JSON.
### Medical Shorthand
S: 70 y/o pt c/o CP. O: Pt appears uncomfortable, clutching chest. Vitals: BP 160/90, HR 110, RR 20, O2 sat 95% on RA. EKG shows ST elevations in leads II, III, and aVF. A: Suspected acute MI. P: Administer aspirin, nitroglycerin, and morphine. Transfer to ED for further management.
Response:
SOAP = {
    "Subjective": "70 year old patient complains of chest pain.",
    "Objective": "Patient appears uncomfortable, clutching chest. Vital signs: Blood pressure 160/90, heart rate 110, respiratory rate 20, oxygen saturation 95% on room air. Electrocardiogram shows ST elevations in leads II, III, and aVF.",
    "Assessment": "Suspected acute myocardial infarction.",
    "Plan": "Administer aspirin, nitroglycerin, and morphine. Transfer to emergency department for further management."
}

###
Prompt: Explain the meaning of the medical shorthand and output as JSON.
### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
Response:
```

## Convert the Medical Shorthand to a Formal Clinic Note

Convert the medical shorthand into a formal clinic note.

> Using the GPT-35-TURBO or GPT-3 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Convert the medical shorthand below into a formal clinic note for storage in the patient's electronic medical record.

### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
Convert the medical shorthand below into a formal clinic note for storage in the patient's electronic medical record.

### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

## Create a Referral letter from the Medical Shorthand

Create a referral letter to an unspecified hospital from the medical shorthand.

> Using the GPT-35-TURBO or GPT-3 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Create a referral letter to the hospital from the medical shorthand.
### Medical Shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
Create a referral letter to a hospital from the medical shorthand.
### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

### Improve the Referral letter with Grounding

Create a referral letter to a hospital from the medical shorthand, but include grounding information on the patient, the referring hospital and the referring doctor.

> Using the GPT-35-TURBO or GPT-3 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Create a referral letter to the Fracture Clinic Team at Contoso Health from the medical shorthand.
### Patient information
Fred Smith. Age:80, Male. Allergies: Amoxicillin. Medications: Codeine. Hx: HTN, T2DM.
### Dr information
Dr. Jenny Jones, Contoso Medical Center
### Medical Shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
Create a referral letter to the Fracture Clinic Team at Contoso Health from the medical shorthand. The patient is a 80 year-old male named Fred Smith. The referral letter is from Dr. Jenny Jones from Contoso Medical Center.
### Patient information
Fred Smith. Age:80, Male. Allergies: Amoxicillin. Medications: Codeine. Hx: HTN, T2DM.
### Dr information
Dr. Jenny Jones, Contoso Medical Center
### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

### Identify missing clinical information from the medical shorthand

Create a list of additional clinical information that should be collected for this type of case.

> Using the GPT-35-TURBO or GPT-3 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You help produce professional documentation and make recommendations on documentation gaps.
<|im_end|>
<|im_start|>User
Provide a list of recommended and relevant clinical information that is not mentioned in the medical shorthand below that should be collected for this type of case.
### Patient information
Fred Smith. Age:80, Male. Allergies: Amoxicillin. Medications: Codeine. Hx: HTN, T2DM.
### Dr information
Dr. Jenny Jones, Contoso Medical Center
### Medical Shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
Provide a list of recommended and relevant clinical information that is not mentioned in the medical shorthand below that should be collected for this type of case.
### Patient information
Fred Smith. Age:80, Male. Allergies: Amoxicillin. Medications: Codeine. Hx: HTN, T2DM.
### Dr information
Dr. Jenny Jones, Contoso Medical Center
### Medical Shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
```

## Define a plan to carry execute the skills

Orchestrators like Semantic Kernel show their full power when being used to build and execute plans based on a goal.

> Using the GPT-35-TURBO or GPT-4 Models and ChatML

```text
<|im_start|>System
You are a medical AI assistant for applications at a general medical practice. You produce plans that will achieve a specific medical goal specified by medical shorthand. You create plans from a subset of the available skills below.
You should only recommend skills that are relevant for this medical shorthand. You will include the short name of the skill and explain why each skill was selected. You will specify for each skill the information that needs to be provided to that skill.

### Available Skills
1. You can identity any recommended and relevant clinical information that is not mentioned in the medical shorthand below that should be collected for this type of case. Short name: Identify missing info.
2. You can create referral letters for patients to hospitals from medial shorthand. Short name: Create referral letter.
3. You can deliver referral documentation to hospitals using the Azure FHIR API. Short name: Send referral letter via FHIR.
4. You can create a clinic note for patient visits. Short name: Create clinic note.
5. Store created documents in the medical practice electronic health record. Short name: Store document in EHR.
6. You can schedule visits with the clinic nurse. Short name: Schedule nurse visit.
7. You can schedule follow-up visits with the doctor. Short name: Schedule follow-up visit.
8. You can schedule X-rays visits with Contoso Radiology. Short name: Schedule x-ray visit.

<|im_end|>
<|im_start|>User
Define a plan using the available skills as a set of steps from the medical shorthand.

### Patient information
Fred Smith. Age:80, Male. Allergies: Amoxicillin. Medications: Codeine. Hx: HTN, T2DM.
### Dr information
Dr. Jenny Jones, Contoso Medical Center
### Medical shorthand
S: Pt c/o pain in R elbow after fall. Hx of HTN, T2DM. O: R elbow swollen, tender to palpation. ROM limited. No obvious deformity. A: Suspected R upper elbow fx. P: X-ray ordered. RICE, analgesics, sling for immobilization. Ref to Fracture Clinic.
<|im_end|>
<|im_start|>Assistant
```
