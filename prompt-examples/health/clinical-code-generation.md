# Clinical code generation

> Recommended models: TEXT-DAVINCI-001, TEXT-DAVINCI-002

Generate clinical/medical codes from clinical text documentation.

## Discharge summary

Generate ICD-10 diagnosis codes from a discharge summary in JSON format and include the source of each code:

```text
Generate ICD-10 diagnosis code from the following discharge summary. Please include both the code and the description and put them in JSON format. Also indicate which line of the document that each code was generated from:

Patient name: John Smith
Date of birth: 01/01/1990
Hospital number: 123456
Admission date: 02/22/2023
Discharge date: 02/23/2023
Reason for admission: Acute appendicitis
Diagnosis: Acute appendicitis with perforation
Procedure: Emergency laparoscopic appendectomy with drainage of peritoneal abscess
Medications on discharge: Paracetamol 1 g four times daily, Amoxicillin-clavulanate 625 mg three times daily for seven days
Follow-up instructions: Keep incisions clean and dry, avoid heavy lifting for four weeks, see GP in one week for wound check and removal of sutures, contact hospital if signs of infection or bleeding occur.
Other information: Patient tolerated procedure well, no intraoperative complications, pathology confirmed acute suppurative appendicitis with perforation and abscess formation. The patient fell over in hospital and fractured thier pelvis. A chest X-ray was also performed.

Discharge summary prepared by:
Dr. Jane Doe
General Surgeon
02/23/2023
```

Generate CPT codes from the following discharge summary. Please include both the code and the description and the source of each code and put them in JSON format:

```text
Generate CPT charge codes from the following discharge summary. Please include both the code and the description and put them in JSON format. Also indicate which line of the document that each code was generated from:

Patient name: John Smith
Date of birth: 01/01/1990
Hospital number: 123456
Admission date: 02/22/2023
Discharge date: 02/23/2023
Reason for admission: Acute appendicitis
Diagnosis: Acute appendicitis with perforation
Procedure: Emergency laparoscopic appendectomy with drainage of peritoneal abscess
Medications on discharge: Paracetamol 1 g four times daily, Amoxicillin-clavulanate 625 mg three times daily for seven days
Follow-up instructions: Keep incisions clean and dry, avoid heavy lifting for four weeks, see GP in one week for wound check and removal of sutures, contact hospital if signs of infection or bleeding occur.
Other information: Patient tolerated procedure well, no intraoperative complications, pathology confirmed acute suppurative appendicitis with perforation and abscess formation. The patient fell over in hospital and fractured thier pelvis. A chest X-ray was also performed.

Discharge summary prepared by:
Dr. Jane Doe
General Surgeon
02/23/2023
```

## Operation note

> IMPORTANT: This scenario is currently blocked by the filters.

Generate ICD-10 diagnosis codes from an operation node:

```text
Generate the ICD-10 diagnosis codes for the following operation:

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
