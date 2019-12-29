#include <AARLineTracking.h>
#include <AARMotor.h>

uint8_t Speed = 150;
uint8_t EchoPin = 8;
uint8_t TrigPin = 4;
uint16_t Time_Echo_us = 0;
uint16_t Len_mm_X100 = 0;
uint16_t Len_Integer = 0; //
uint16_t Len_Fraction = 0;
uint8_t Lag = 0;
uint8_t Tracking = 0;

volatile int16_t RightRevolutions = 0;
volatile int16_t LeftRevolutions = 0;
uint32_t LastMovement = 0;
uint32_t LastLeftMillis = 0;
uint32_t LastRightMillis = 0;
int8_t RightIncrement = 0;
int8_t LeftIncrement = 0;
uint8_t LeftLineSensor = 0;
uint8_t RightLineSensor = 0;

AARMotorClass AarMotor;
AARLineTrackingClass LineTracking;

void pciSetup(byte pin)
{
    *digitalPinToPCMSK(pin) |= bit (digitalPinToPCMSKbit(pin));  // enable pin
    PCIFR  |= bit (digitalPinToPCICRbit(pin)); // clear any outstanding interrupt
    PCICR  |= bit (digitalPinToPCICRbit(pin)); // enable interrupt for the group
}
 
 
ISR (PCINT1_vect) // handle pin change interrupt for A0 to A5 here
 {
    uint8_t currA0;
    uint8_t currA1;
    uint32_t timestamp = millis();
    uint32_t leftDiff = timestamp - LastLeftMillis;
    uint32_t rightDiff = timestamp - LastRightMillis;
    
    currA0 = digitalRead(A0);
    currA1 = digitalRead(A1);

    if (currA0){
        LeftRevolutions += LeftIncrement;
        LastLeftMillis = timestamp;
    }

    if (currA1){
        RightRevolutions += RightIncrement;
        LastRightMillis = timestamp;
    }
 }

void setup() { 
  // Initialize AAR motor
  AarMotor.Init(Speed);
  LineTracking.Init(&AarMotor);
  // Initialize serial port
  Serial.begin(9600);
  // Initialize pins for ultrasonic sensor
  pinMode(EchoPin, INPUT);
  pinMode(TrigPin, OUTPUT);
  // Initialize pins for odometry
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pciSetup(A0);
  pciSetup(A1);
}

void calculateDistance() {
  digitalWrite(TrigPin, HIGH);
  delayMicroseconds(50);
  digitalWrite(TrigPin, LOW);
  Time_Echo_us = pulseIn(EchoPin, HIGH, 10000);
  Len_mm_X100 = (Time_Echo_us * 34) / 2;
  Len_Integer = Len_mm_X100 / 100;
  Len_Fraction = Len_mm_X100 % 100;
}

void calculateLineSensors(){
  LineTracking.Track(0);
}

void printInfo(){
  // Print distance  
  Serial.print(Len_Integer, DEC);
  Serial.print(".");
  Serial.print(Len_Fraction, DEC);
  Serial.print(';');
  // Print revolutions
  Serial.print(LeftRevolutions, DEC);
  Serial.print(';');
  Serial.print(RightRevolutions, DEC);
  Serial.print(';');
  // Print speed
  Serial.print(Speed, DEC);
  Serial.print(';');
  // Print line sensors
  Serial.print(LineTracking.SensorDataLeft(), DEC);
  Serial.print(';');
  Serial.print(LineTracking.SensorDataRight(), DEC);
  Serial.println();
}

void loop() {
  int8_t cmd = 0;
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0) {
    // read the incoming bytes:
    cmd = Serial.read();
    switch (cmd) {
      case 'w':
      case 'W':
        RightIncrement = 1;
        LeftIncrement = 1;
        LastMovement = millis();
        AarMotor.Forward(0, Speed);
        break;
      case 's':
      case 'S':
        RightIncrement = -1;
        LeftIncrement = -1;
        LastMovement = millis();
        AarMotor.Backward(0, Speed);
        break;
      case 'd':
      case 'D':
        RightIncrement = -1;
        LeftIncrement = 1;
        LastMovement = millis();
        AarMotor.TurnOnSpotRight(0, Speed);
        break;
      case 'a':
      case 'A':
        RightIncrement = 1;
        LeftIncrement = -1;
        LastMovement = millis();
        AarMotor.TurnOnSpotLeft(0, Speed);
        break;
      case 'q':
      case 'Q':
        Speed = Speed == 250 ? Speed : Speed + 25;
        break;
      case 'e':
      case 'E':
        Speed = Speed == 100 ? Speed : Speed - 25;
        break;
      case 't':
        Tracking = !Tracking;
        AarMotor.Stop();
        break;
      case 'i':
      case 'I':
        calculateDistance();
        calculateLineSensors();
        printInfo();
        break;        
    }
  }

  if (Tracking){
        LineTracking.Track(0);
        if(LineTracking.SensorDataLeft() < SENSOR_COLOR_BLACK) {
        digitalWrite(PIN_MOTOR_LEFT_FORWARD, LOW);
        AarMotor.RightForward(0);
    }
    else {
       digitalWrite(PIN_MOTOR_RIGHT_FORWARD, LOW);
    }

    //Serial.print("\t\t");

    if(LineTracking.SensorDataRight() < SENSOR_COLOR_BLACK) {
        digitalWrite(PIN_MOTOR_RIGHT_FORWARD, LOW);
        AarMotor.LeftForward(0);
    }
    else {
        digitalWrite(PIN_MOTOR_LEFT_FORWARD, LOW);
    }
    LastMovement = millis();
  }

  if (millis() - LastMovement >= 500){
      AarMotor.Stop();
      RightIncrement = 0;
      LeftIncrement = 0;
  }
}
