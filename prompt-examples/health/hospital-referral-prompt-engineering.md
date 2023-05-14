# Hospital referral

This document shows an example of evolution of a prompt from simple text to a more complex prompt including grounding and one-shot examples.

Goal: Improve the referral workflow for a fracture clinic at a hospital to automate clinical summary on referral receipt.
Scenario: A Dr. Smith sees a patient, 80 year old man, Fred, at his practice. Fred has broken his upper elbow by falling off his ebike. Dr. Smith has referred the patient to the Fracture Clinic at Contoso Health. The Fracture Clinic has requested a clinical summary of the patient's visit combined with other relevant information from the hospitals electronic Health record. The clinical summary can be used to triage the patient and determine the urgency of the referral.

Inputs:
1. Referral request from the GP practice to Contoso Health Fracture Clinic:

```text
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Fred Smith, for further evaluation and management of a suspected right upper elbow fracture. Mr. Smith is an 80-year-old male with a history of hypertension and type 2 diabetes mellitus. He reports an allergy to Amoxicillin and is currently taking Codeine for pain management.

Mr. Smith presented to our clinic complaining of pain in his right elbow after a fall. On examination, his right elbow was swollen and tender to palpation with limited range of motion. There was no obvious deformity. An X-ray has been ordered and he has been advised to rest, ice, compress, and elevate the affected limb, as well as to take analgesics and use a sling for immobilization.

Given his presentation and history, I suspect that Mr. Smith may have sustained a right upper elbow fracture and would benefit from further evaluation and management by your team. Please do not hesitate to contact me if you require any further information.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Jenny Jones
Contoso Medical Center.
```

## Extract the clinical summary from the referral request

Extract the relevant medical information from the referral request.

> Using the GPT-35-TURBO or GPT-4 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at Contoso Health hospital. You help produce the fracture clinic team prepare for weekly clinics by preparing relevant documentation, summaries and recommendations.
<|im_end|>
<|im_start|>User
Extract the relevant medical information from the referral letter the referral request. If the information is not found in the referral letter, set the value to "not specified".

### Referral Letter
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Jane Doe, for further evaluation and management of a left hip fracture. Ms. Doe is an 44-year-old female. Ms. Doe has a history of pain in left hip.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Who
Contoso Medical Center.
<|im_end|>
<|im_start|>Assistant
<|im_end|>
{
    "Reason": "Left hip fracture"
    "History": "Pain, left hip"
    "Patient_Name": "Jane Doe"
    "Patient_DOB" : "01/01/1977"
    "Health_Id": "not specified"
}
<|im_start|>User
Extract the relevant medical information from the referral letter the referral request.

### Referral Letter
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Fred Smith, for further evaluation and management of a suspected right upper elbow fracture. Mr. Smith is an 80-year-old male with a history of hypertension and type 2 diabetes mellitus. He reports an allergy to Amoxicillin and is currently taking Codeine for pain management.

Mr. Smith presented to our clinic complaining of pain in his right elbow after a fall. On examination, his right elbow was swollen and tender to palpation with limited range of motion. There was no obvious deformity. An X-ray has been ordered and he has been advised to rest, ice, compress, and elevate the affected limb, as well as to take analgesics and use a sling for immobilization.

Given his presentation and history, I suspect that Mr. Smith may have sustained a right upper elbow fracture and would benefit from further evaluation and management by your team. Please do not hesitate to contact me if you require any further information.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Jenny Jones
Contoso Medical Center.
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
You are a medical AI assistant for applications at Contoso Health hospital. You help produce the fracture clinic team prepare for weekly clinics by preparing relevant documentation, summaries and recommendations.

###
Prompt: Extract the relevant medical information from the referral letter the referral request.
### Referral Letter
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Jane Doe, for further evaluation and management of a left hip fracture. Ms. Doe is an 44-year-old female. Ms. Doe has a history of pain in left hip.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Who
Contoso Medical Center.
Response:
{
    "Reason": "Left hip fracture"
    "History": "Pain, left hip"
    "Patient_Name": "Jane Doe"
    "Patient_DOB" : "01/01/1977"
    "Health_Id": "not specified"
}

###
Prompt: Extract the relevant medical information from the referral letter the referral request.
### Referral Letter
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Fred Smith, for further evaluation and management of a suspected right upper elbow fracture. Mr. Smith is an 80-year-old male with a history of hypertension and type 2 diabetes mellitus. He reports an allergy to Amoxicillin and is currently taking Codeine for pain management.

Mr. Smith presented to our clinic complaining of pain in his right elbow after a fall. On examination, his right elbow was swollen and tender to palpation with limited range of motion. There was no obvious deformity. An X-ray has been ordered and he has been advised to rest, ice, compress, and elevate the affected limb, as well as to take analgesics and use a sling for immobilization.

Given his presentation and history, I suspect that Mr. Smith may have sustained a right upper elbow fracture and would benefit from further evaluation and management by your team. Please do not hesitate to contact me if you require any further information.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Jenny Jones
Contoso Medical Center.
Response:
```

## Summarize past episodes of care related to the referral

Summarize the past episodes of care that might be relevant to the referral. The summary of each episode is grounding. Other grounding, such as other known history, family history could also be included.

> Using the GPT-35-TURBO or GPT-4 Models and ChatML

```Text
<|im_start|>System
You are a medical AI assistant for applications at Contoso Health hospital. You help produce the fracture clinic team prepare for weekly clinics by preparing relevant documentation, summaries and recommendations.
<|im_end|>
<|im_start|>User
Summarize the relevant past episodes of care at Consoso Health hospital for the patient. The summary should only include episodes of care clinically related to the referral letter. Explain why each episode of care is relevant to the issue being referred.

### Referral Letter
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Fred Smith, for further evaluation and management of a suspected right upper elbow fracture. Mr. Smith is an 80-year-old male with a history of hypertension and type 2 diabetes mellitus. He reports an allergy to Amoxicillin and is currently taking Codeine for pain management.

Mr. Smith presented to our clinic complaining of pain in his right elbow after a fall. On examination, his right elbow was swollen and tender to palpation with limited range of motion. There was no obvious deformity. An X-ray has been ordered and he has been advised to rest, ice, compress, and elevate the affected limb, as well as to take analgesics and use a sling for immobilization.

Given his presentation and history, I suspect that Mr. Smith may have sustained a right upper elbow fracture and would benefit from further evaluation and management by your team. Please do not hesitate to contact me if you require any further information.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Jenny Jones
Contoso Medical Center.

### Past episodes of care at Contoso Health
January 1, 2000. Osteoarthritis of the knee. Total knee replacement
June 1, 2000. Gallstones. Laparoscopic cholecystectomy
December 1, 2000. Skin cancer on the face. Mohs surgery
March 1, 2001. Osteoarthritis of the hip. Total hip replacement
September 1, 2001. Hernia repair. Laparoscopic inguinal hernia repair
February 1, 2002. Facial trauma from a fall. Facial reconstruction
<|im_end|>
<|im_start|>Assistant
```

> Using the TEXT-DAVINCI-003

```Text
You are a medical AI assistant for applications at Contoso Health hospital. You help produce the fracture clinic team prepare for weekly clinics by preparing relevant documentation, summaries and recommendations.

Summarize the relevant past episodes of care at Consoso Health hospital for the patient. The summary should only include episodes of care clinically related to the referral letter. Explain why each episode of care is relevant to the issue being referred.

### Referral Letter
Dear Fracture Clinic Team at Contoso Health,

I am writing to refer my patient, Fred Smith, for further evaluation and management of a suspected right upper elbow fracture. Mr. Smith is an 80-year-old male with a history of hypertension and type 2 diabetes mellitus. He reports an allergy to Amoxicillin and is currently taking Codeine for pain management.

Mr. Smith presented to our clinic complaining of pain in his right elbow after a fall. On examination, his right elbow was swollen and tender to palpation with limited range of motion. There was no obvious deformity. An X-ray has been ordered and he has been advised to rest, ice, compress, and elevate the affected limb, as well as to take analgesics and use a sling for immobilization.

Given his presentation and history, I suspect that Mr. Smith may have sustained a right upper elbow fracture and would benefit from further evaluation and management by your team. Please do not hesitate to contact me if you require any further information.

Thank you for your assistance in the care of this patient.

Sincerely,
Dr. Jenny Jones
Contoso Medical Center.

### Past episodes of care at Contoso Health
January 1, 2000. Osteoarthritis of the knee. Total knee replacement
June 1, 2000. Gallstones. Laparoscopic cholecystectomy
December 1, 2000. Skin cancer on the face. Mohs surgery
March 1, 2001. Osteoarthritis of the hip. Total hip replacement
September 1, 2001. Hernia repair. Laparoscopic inguinal hernia repair
February 1, 2002. Facial trauma from a fall. Facial reconstruction
```