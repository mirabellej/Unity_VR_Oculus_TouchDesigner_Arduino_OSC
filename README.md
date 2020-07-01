# Unity_VR_Oculus_TouchDesigner_Arduino_OSC
A network for sharing sensor data between Arduino, TouchDesigner, and Unity for using real world sensors in XR. 
<br><br>
How can you combine real world sensors with XR experiences?
<br><br>
This project allows you to take in data from sensors, actuators, and other electronics via Teensy or Arduino into Unity and other programs using Serial communication and OSC (Open Sound Control). It shows how to use this in combination with XR HMDs like the Oculus Quest.
<br><br>
This repo integrates a copy of the version of the UnityOSC library from Thomas Fredericks https://github.com/thomasfredericks/UnityOSC that is contemporary with this release. If desired, to reduce file size, feel free to download individual components rather than cloning this entire repo. I will add a Docker file shortly.
<br><br>
In this example, data is sent to TouchDesigner for a VL6180X time of flight sensor using a Serial DAT. The sensor data is then formatted for OSC to Unity in a Python script. (This step can be skipped and OSC directly sent to Unity if you prefer, but I wanted to include it in order to show how an intermediary software like MaxMSP, TD, Notch, etc. could be used if desired to chain, broadcast, or sort OSC events between programs and languages.) Finally, Unity receives the data using the UnityOSC library and a simple if statement is used to generate the output.
<br><br><strong>
Instructions for Use:</strong>
1. Open the Arduino sketch or create an appropriate sketch for your sensor. In your sketch, make sure the data for your sensor is output in a Serial.println statement with one reading per line.
2. Open the TouchDesigner network. Make sure the correct serial port is selected in the serial DAT and that the DAT is set to active.
3. You should see the data streaming in from the Serial DAT. If you have more than one sensor, you can use selects as illustrated to sort your data and divide this into different OSC messages.
4. By default, the first sensor's data will be sent to Unity but you can adjust the python script in OSC_Send to send data for more than one sensor.
5. Open the Unity project. This project already includes the UnityOSC library and is set up to work with the Oculus Quest integration's latest release as of July 1st, 2020. The OSC data is received and handled in an OSC script attached to the cauldron object. In this instance, a simple if statement is used to trigger the output of particles when the hand is held over the sensor, but you could easily create a switch or if / else that includes different states or different actions depending on the values of a combination of sensors.
<br><br>

<strong>Potential use cases:</strong> this application is potentially more useful for embedding sensors in real world objects to be explored in AR / MR than in VR where you are less likely to desire interaction with physical real world objects. That said, this program and its methodologies could have interesting applications in wearables (esp. with biosensors like EEG, EKG, and GSR) that might influence digital / 3D gameplya or visual output, "special objects" such as objects which serve as aditional or external controllers for installations, additional boundary forming / guardian or environmental constraints (ex: you have a beam in the middle or your play area), tracking / getting feedback from moving real world objects (drones, rovers, cat?), therapeutic or research uses, and more. If you have used it, I would love to hear how. Please feel free to get in touch: mirabellejones@gmail.com. MiraJones.net

