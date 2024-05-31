#include <LiquidCrystal.h>

// initialize the library with the numbers of the interface pins 
LiquidCrystal lcd(13, 12, 11, 10, 9, 8); 

const int trigPin = 5;
const int echoPin = 6;
const int Motor_Pin = 7;

long duration;
int distance;
bool Motor;

int MotorOnLevel = 30;
int MotorOffLevel = 100;

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(Motor_Pin, OUTPUT);
  
  Serial.begin(9600);
  lcd.begin(16, 2);
}

void loop() {
  // Measure distance
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  
  duration = pulseIn(echoPin, HIGH);
  distance = duration * 0.034 / 2;
  int Level = map(distance, 0, 1106, 0, 100);

  lcd.setCursor(0, 0);
  lcd.print("Water: ");
  lcd.print(Level);
  lcd.print("%     ");
  
  byte byteToSend = (byte)Level;
  Serial.write(byteToSend);
  
  // Check water level and control motor
  if (Level < MotorOnLevel) {
    Motor = true;
    byte signalByte = 0xA1;
    Serial.write(signalByte);
  } 
  if (Level >= MotorOffLevel) {
    Motor = false;
    byte signalByte = 0xB1;
    Serial.write(signalByte);
  }
  
  if (Motor) {
    digitalWrite(Motor_Pin, HIGH);
    lcd.setCursor(0, 1);
    lcd.print("Pump: ON      ");
  } else {
    digitalWrite(Motor_Pin, LOW);
    lcd.setCursor(0, 1);
    lcd.print("Pump: OFF     ");
  }

  // Check for new level settings from Serial
  if (Serial.available() > 0) {
    int newLevel = Serial.parseInt();
    if (Serial.read() == 'O') { // MotorOnLevel
      MotorOnLevel = newLevel;
    } else if (Serial.read() == 'F') { // MotorOffLevel
      MotorOffLevel = newLevel;
    }
  }
}
