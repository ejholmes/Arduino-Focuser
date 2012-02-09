What is it?
==========

The Arduino Focuser is an effort to make a computer controlled focuser using an [Arduino](http://www.arduino.cc/), a [Motor Shield](http://adafruit.com/index.php?main_page=product_info&cPath=17_21&products_id=81) and a bipolar stepper motor. The project consists of the Arduino code for the firmware and also an ASCOM driver to control the focuser from any ASCOM compliant software such as [MaxIm DL](http://www.cyanogen.com/).

Building Your Own
-----------------

1. Download an install the ASCOM driver from the [downloads page](https://github.com/ejholmes/Arduino-Focuser/downloads).
2. Download and install the [Arduino IDE](http://arduino.cc/).
3. Download the [source code](https://github.com/ejholmes/Arduino-Focuser).
4. Connect your Arduino to your computer and compile and upload the firmware within the "firmware" directory in the source code.


Technical Information
---------------------

Since the Arduino Focuser is based on the Arduino board, the focuser is controlled through the COM port created by the Arduino. This is accomplished by parsing serial commands sent from the ASCOM Driver. When a command is received in the `: command <arg> #` format, the Messenger object is passed to the `Focuser::interpretCommand()` function, which looks at the `command` and acts accordingly.
 
The following commands are currently available:

- `: M <position> #` Moves the focuser to `position`.
- `: L #` Issues a motor.release(). Some steppers get pretty hot when the coils are not released.
- `: R <0-1> #` Reverses motor direction. 0=false, 1=true.
- `: P <position> #` Sets the current position to `position`. Note, this does not issue a move, it just tells the focuser that it's at said position.
- `: G #` Prints out the current position to the serial port. Useful for syncing.
- `: H #` Doesn't really do anything since anything in the serial buffer will halt the motor. Just prettier.


- Uses the [AFMotor library](http://www.ladyada.net/make/mshield/use.html) and a modified Messenger library.
- Code is for the motor shield from [adafruit industries](http://adafruit.com/index.php?main_page=product_info&cPath=17_21&products_id=81).
