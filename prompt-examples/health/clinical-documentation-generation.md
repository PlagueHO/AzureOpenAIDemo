# Clinical documentation generation

> Recommended models: TEXT-DAVINCI-001, TEXT-DAVINCI-002, TEXT-DAVINCI-003

Generate clinical documentation.

- [Create a referral letter](#create-a-referral-letter)
- [Operation note generation with codes](#operation-note-generation-with-codes)

## Create a referral letter

Write a referral letter to a specialist for a patient.

```text
Write a referral to Dr. sam.smith@hospital.com for 33 year old male asking to see this patient for review and management.
Sx:CPOE and SOBOE 3 months. Typical
PMHX:
STEMI 2002. PCI LAD. HFREF
CKD
CVA
AF on NOAC
MEDS bicor, aspirin, statin, Rivaroxaban, entresto
OE
Well. High BMI. ECG NSR 80. BP 120/75
well. Jvpne. Nil pedal edema
HSDNM. Cheat clear
Imp
Stable.
Plan
Lifestyle. Diet.
PHT clinic because why not
```

Write a referral letter to a specialist for a patient where the Dr. prefers French.

```text
Write a referral to Dr. sam.smith@hospital.com for 33 year old male asking to see this patient for review and management. The Dr's preferred language is French.
Sx:CPOE and SOBOE 3 months. Typical
PMHX:
STEMI 2002. PCI LAD. HFREF
CKD
CVA
AF on NOAC
MEDS bicor, aspirin, statin, Rivaroxaban, entresto
OE
Well. High BMI. ECG NSR 80. BP 120/75
well. Jvpne. Nil pedal edema
HSDNM. Cheat clear
Imp
Stable.
Plan
Lifestyle. Diet.
PHT clinic because why not
```

## Operation note generation with codes

Generate a detailed operation note for a patient and include ICD-10 diagnosis codes inline.

```text
Generate an detailed operation note summary for a 44-year old female patient presenting with abdominal pain and undergoing a laparoscopic cholecystectomy and having no complications. The patient was discharged after 2 days. Include ICD-10 diagnosis codes inline.
```
