# Transport & Logistics

These prompts are for transport and logistics.

## Driver assistant

This prompt makes 10 driver recommendations based on vehicle maintenance, previous routes, weather and traffic incidents. It would be expected that the inputs into the prompt may come from other systems or other LLM prompts.

> Recommended models: GPT-35-TURBO, GPT-4

```text
<|im_start|>System
You are an AI assistant that helps a transportation & logistics heavy vehicle driver make informed decisions about their daily driving jobs. Drivers typically drive heavy vehicles, performing one or more jobs per day.
<|im_end|>
<|im_start|>User
Provide a list of 10 recommendations on improvements to the driver that they should consider based on the vehicle maintainence, previous routes, weather and traffic incidents below. For each recommendation, provide your thoughts that made you suggest this and the data you used to make the suggestion. You will make recommendations that the driver can follow.

### Jobs planned today
job_id,pick_up,drop_off,route,weight
1,Smithfield Foods, 2301 N Halstead St, Wichita, KS 67204,Dillons, 1910 W 21st St N, Wichita, KS 67203,I-135 S, US-81 S, KS-96 W, I-235 S, US-54 W, 15 tons
2,Dillons, 1910 W 21st St N, Wichita, KS 67203,Hy-Vee, 3504 Clinton Pkwy, Lawrence, KS 66047,US-54 E, I-235 N, I-135 N, KS-96 E, I-35 S, KS-10 E, 12 tons
3,Hy-Vee, 3504 Clinton Pkwy, Lawrence, KS 66047,Costco, 9350 Marshall Dr, Lenexa, KS 66215,KS-10 W, I-435 S, I-35 N, US-69 N, I-435 W, 10 tons

### Vehicle maintenance and repair records
Date,Mileage,Service,Cost,Notes
01/02/2020,250000,Annual inspection,250,Passed inspection, no issues found
01/15/2020,252500,Oil and filter change,150,Recommended every 10,000 miles
02/10/2020,257000,Tire rotation and alignment,200,Improved fuel efficiency and handling
03/05/2020,261000,Fuel filter replacement,100,Prevent clogging and loss of power
03/25/2020,263500,Breakdown and tow,500,Fuel pump failure, truck stalled on highway
03/26/2020,263500,Fuel pump replacement,800,Replaced faulty fuel pump, tested OK
04/20/2020,267000,Air filter replacement,50,Recommended every 15,000 miles
05/15/2020,271000,Oil and filter change,150,Regular service
06/10/2020,275000,Coolant flush and refill,100,Prevent overheating and corrosion
07/01/2020,278000,Battery replacement,200,Old battery was weak and failed load test
07/20/2020,281000,Brake pad and rotor

### Fuel consumption and efficiency
route,fuel_used,fuel_efficiency,fuel_expected,fuel_difference
I-95 from Boston to New York,50,6,50,0
I-80 from Chicago to Omaha,100,6,100,0
I-10 from Los Angeles to Phoenix,75,5.4,72,3
I-70 from Denver to Kansas City,90,5.6,84,6
I-40 from Nashville to Memphis,40,6.4,40,0
I-5 from Seattle to Portland,35,6.6,35,0
I-90 from Cleveland to Buffalo,45,6.4,45,0
I-75 from Atlanta to Tampa,70,5.6,67,3
I-35 from Dallas to Oklahoma City,35,6.4,35,0
I-94 from Minneapolis to Fargo,50,5.6,48,2

### Driver behavior
driver_id,speeding,hard_braking,rapid_acceleration
1,0,0,0
2,1,0,0
3,0,1,0
4,0,0,1
5,1,1,0
6,0,0,0
7,1,0,1
8,0,1,1
9,0,0,0
10,1,1,1
11,0,0,0
12,1,0,0
13,0,1,0
14,0,0,1
15,1,1,0
16,0,0,0
17,1,0,1
18,0,1,1
19,0,0,0
20,1,1,1

### Accident and incident reports
location,incident_type,severity,description,effect
I-95 N, Exit 22, Philadelphia,PA,accident,moderate,two cars collided on the right shoulder,causing delays and rubbernecking,slow down and use caution
US-1 N, Trenton,NJ,construction,minor,road work on the left lane near Perry St,expect lane closure and reduced speed limit
I-287 N, Exit 10, Edison,NJ,disabled vehicle,low,a truck broke down on the right shoulder near the exit ramp,no impact on traffic flow
I-87 N, Exit 16, Harriman,NY,toll plaza,high,heavy congestion and long queues at the toll booths,consider alternate routes or use E-ZPass
I-90 W, Exit 24, Albany,NY,weather,moderate,snow and ice on the road surface,creating slippery conditions,drive carefully and reduce speed
I-81 N, Exit 25, Syracuse,NY,incident,high,a hazmat spill on the ramp from I-690 W to I-81 N,closing the ramp and diverting traffic,avoid the area and follow detour signs

### Weather report
The weather forecast for Kansas for the next three days is mostly sunny and dry, with some scattered showers and thunderstorms possible in the eastern and central parts of the state. The temperatures will range from the low 60s to the mid 80s, with moderate humidity and winds. The visibility will be good, except for some areas of fog in the early mornings and evenings.

The main weather hazards for heavy vehicle drivers in Kansas are:

- Severe thunderstorms, which can produce strong winds, hail, lightning, and heavy rain, especially in the spring and summer months. These can reduce visibility, create slippery road conditions, and damage vehicles and cargo. Drivers should monitor the weather alerts and radar, and seek shelter or avoid driving in areas under severe weather warnings. Drivers should also be aware of the risk of flash flooding, especially in low-lying or urban areas, and avoid crossing flooded roads or bridges.
- Tornadoes, which can occur any time of the year, but are most common in the spring and early summer. These can cause devastating damage and pose a serious threat to life and property. Drivers should be familiar with the signs of a tornado, such as a dark, funnel-shaped cloud, a loud roar, or flying debris, and follow the instructions of local authorities and emergency services. Drivers should never try to outrun a tornado, but instead seek shelter in a sturdy building or a low-lying ditch, and cover their head and body with a blanket or coat.
- High winds, which can occur throughout the year, but are more frequent in the fall and winter. These can create dust storms, reduce visibility, and make driving difficult and dangerous, especially for high-profile vehicles. Drivers should reduce their speed, increase their following distance, and steer firmly and smoothly. Drivers should also be alert for sudden gusts, crosswinds, and flying debris, and avoid driving near power lines, trees, or other objects that could fall or be blown onto the road. Drivers should also secure their cargo and check their tires and brakes regularly.
- Extreme temperatures, which can vary widely in Kansas, from below freezing in the winter to above 100 degrees in the summer. These can affect the performance and safety of the vehicle and the driver, as well as the quality and condition of the cargo. Drivers should check the fluid levels, battery, hoses, belts, and tires of their vehicle before and during their trip, and carry extra water, coolant, and antifreeze. Drivers should also dress appropriately, stay hydrated, and take breaks as needed. Drivers should also monitor the temperature and ventilation of their cargo, and avoid leaving it exposed to direct sunlight or extreme heat or cold.
<|im_end|>
<|im_start|>Assistant
```
