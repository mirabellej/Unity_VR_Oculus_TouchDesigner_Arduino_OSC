#include <Wire.h>
#include "Adafruit_VL6180X.h"

const int DELAYTIME = 100; // time between sensor readings / print statements

Adafruit_VL6180X vl = Adafruit_VL6180X();

void setup() {
  delay(1000); // warm up delay
  
  Serial.begin(115200); // default baudrate for VL6180X
  vl.begin(); // initialize sensor
  
  delay(1000);  // warm up delay to remove garbage readings
}

void loop() {
  
  uint8_t range = vl.readRange();
  float lux = vl.readLux(VL6180X_ALS_GAIN_5);
  Serial.println(range);
  Serial.println(lux); 
  
  delay(DELAYTIME); // sanity delay
  
}
