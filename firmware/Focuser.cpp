

//ADDED FOR COMPATIBILITY WITH WIRING
extern "C" {
  #include <stdlib.h>
}

#include "WProgram.h"
#include "Focuser.h"

AF_Stepper motor(360 / DEGREES_PER_STEP, 2); // Create our stepper motor. I have mine on port 2 of the motor shield.

long position = 0;
bool reversed = false;

//
// Constructor
// 
Focuser::Focuser(void)
{
  motor.setSpeed(10); // Set a default RPM of 10
}

//
// Function for interpreting a command string of the format ": COMMAND <ARGUMENT> #"
//
void Focuser::interpretCommand(Messenger *message)
{
  message->readChar(); // Reads ":"
  char command = message->readChar(); // Read the command
  
  switch(command){
    case 'M': // Move
      move(message->readLong());
      break;
    case 'R': // Release motor coils
      reverse(message->readInt());
      break;
    case 'L':
      motor.release();
      break;
    case 'P':
      setPosition(message->readLong());
      break;
    case 'G':
      printPosition();
      break;
    case 'H':
      Serial.flush();
      break;
  }
}

void Focuser::setPosition(long newpos)
{
  position = newpos;
  printPosition();
}

void Focuser::printPosition()
{
  Serial.print("P ");
  Serial.println(position);
}

void Focuser::reverse(bool rev = false)
{
  reversed = rev;
}

//
// Function for issuing moves
//
void Focuser::move(long val)
{
  long move = val - position; // calculate move
  
  if(abs(move) > FAST)
  {
    long fastSteps = move - ((move > 0)?SLOWSTEPS:(SLOWSTEPS * -1));
    
    motor.setSpeed(FASTSPEED);
    step(fastSteps, DOUBLE);
    
    motor.setSpeed(SLOWSPEED);
    step(((move > 0)?SLOWSTEPS:(SLOWSTEPS * -1)), MICROSTEP);
  }
  else
  {
    step(move, MICROSTEP);
  }
  
  motor.release(); // Release the motors when done. This works well for me but might not for others
  Serial.print("P ");
  Serial.println(position);
}

void Focuser::step(long val, uint8_t steptype)
{
  if (val > 0) { // If move is positive, move forward
    while(val--)
    {
      if(Serial.available() > 0)
        break;
      motor.step(1, (reversed)?FORWARD:BACKWARD, steptype);
      position++;
    }
  }
  else if (val < 0) { // else if move is negative, move backward
    long counter = abs(val);
    while(counter--)
    {
      if(Serial.available() > 0 || position == 0)
        break;
      motor.step(1, (reversed)?BACKWARD:FORWARD, steptype);
      position--;
    }
  } 
}
