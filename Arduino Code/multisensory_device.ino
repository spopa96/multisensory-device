/*  BEng Project
    Handheld Multisensory Device for Investigating Multisensory Exploration
    Author: Stefan Popa (s1544586@sms.ed.ac.uk / popastefan96@gmail.com)
    The University of Edinburgh
    2019
*/


//Libraries used
#include "timer.h"
#include <SPI.h>
#include <WiFiNINA.h>
#include "arduino_secrets.h"
#include "Adafruit_Soundboard.h"
#include <MPU6050_tockn.h>
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include "Adafruit_DRV2605.h"

#define M1PIN 0 // pin for matrix 1
#define M2PIN 1 // pin for matrix 2
#define M3PIN 2 // pin for matrix 2
#define M4PIN 3 // pin for matrix 2
#define M5PIN 4 // pin for matrix 2
#define SHAKE_THRESH 1.2   //shake detection threshold <g>
#define ROT_THRESH 170     //rotation detection threshold <deg/s>
#define FORCE_THRESH 25    //force detection threshold 
#define IMU_PERIOD 500     //IMU readings sending period <ms>
#define SFX_RST 5       // soundboard RST pin
#define buttonPin 6     // button pin

//declare timer instance for updating IMU readings
Timer timer;

//declare haptic driver instance
Adafruit_DRV2605 drv;

//declare NeoMatrix instances
Adafruit_NeoMatrix matrix1 = Adafruit_NeoMatrix(8, 8, M1PIN,
                             NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +       // defines pin 1 location (TOP,LEFT)
                             NEO_MATRIX_ROWS + NEO_MATRIX_PROGRESSIVE,    // defines how the matrix leds succed each other (ROW BY ROW, PROGRESSIVE)
                             NEO_GRB            + NEO_KHZ800);

Adafruit_NeoMatrix matrix2 = Adafruit_NeoMatrix(8, 8, M2PIN,
                             NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +
                             NEO_MATRIX_ROWS + NEO_MATRIX_PROGRESSIVE,
                             NEO_GRB            + NEO_KHZ800);

Adafruit_NeoMatrix matrix3 = Adafruit_NeoMatrix(8, 8, M3PIN,
                             NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +
                             NEO_MATRIX_ROWS + NEO_MATRIX_PROGRESSIVE,
                             NEO_GRB            + NEO_KHZ800);

Adafruit_NeoMatrix matrix4 = Adafruit_NeoMatrix(8, 8, M4PIN,
                             NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +
                             NEO_MATRIX_ROWS + NEO_MATRIX_PROGRESSIVE,
                             NEO_GRB            + NEO_KHZ800);

Adafruit_NeoMatrix matrix5 = Adafruit_NeoMatrix(8, 8, M5PIN,
                             NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +
                             NEO_MATRIX_ROWS + NEO_MATRIX_PROGRESSIVE,
                             NEO_GRB            + NEO_KHZ800);

//define color set to be used with matrices (R,G,B), each color from 0 to 255
uint32_t PEACH = matrix1.Color(221, 171, 127);
uint32_t BLUE = matrix1.Color(0, 0, 255);
uint32_t LIGHTBLUE = matrix1.Color(94, 185, 247);
uint32_t RED = matrix1.Color(255, 0, 0);
uint32_t GREEN = matrix1.Color(0, 255, 0);
uint32_t GRAY = matrix1.Color(100, 100, 100);
uint32_t BROWN = matrix1.Color(117, 76, 41);
uint32_t PURPLE = matrix1.Color(152, 5, 229);
uint32_t DARKGREEN = matrix1.Color(12, 158, 17);
uint32_t PINK = matrix1.Color(250, 101, 148);
uint32_t ORANGE = matrix1.Color(241, 90, 41);
uint32_t YELLOW = matrix1.Color(255, 242, 0);
uint32_t BLACK = matrix1.Color(0, 0, 0);
uint32_t WHITE = matrix1.Color(255, 255, 255);

//declare MPU6050 instance
MPU6050 mpu6050(Wire);

//declare Soundboard instance
Adafruit_Soundboard sfx = Adafruit_Soundboard(&Serial1, NULL, SFX_RST);


///////please enter your sensitive data in the Secret tab/arduino_secrets.h
char ssid[] = SECRET_SSID;        // your network SSID (name)
char pass[] = SECRET_PASS;       // your network password (use for WPA, or use as key for WEP)
int keyIndex = 0;                // your network key Index number (needed only for WEP)

boolean alreadyConnected = false; // whether or not the client was connected previously

int status = WL_IDLE_STATUS;
WiFiServer server(80);


boolean updatetime = false;        //variable becomes true when it is time to send new IMU readings to the server
boolean enable = false;        //variable controls when the program sends IMU reading or not
boolean sound_detected = false;    //variable becomes true when a sound is detected

int MIC_THRESHOLD = 0;             //value over which the mic will detect a sound
int button_state = LOW;            //becomes true when button is pressed

int loop_counter = 0;              //variables used to introduce delays in the program
int loop_counter2 = 0;
int loop_counter3 = 0;
int loop_counter4 = 0;
int loop_counter1 = 0;


int track = -1;                    //variable stores the tack number to be played
int waveform = -1;                 //variable stores the haptic waveform to be played

//Setup part of the program. Will run when the device is powered on.
void setup() {
  //Set up uart connection to the soundboard and reset it
  Serial1.begin(9600);
  sfx.reset();

  //Set up connection to the matrices and delete any previous patterns stored.
  matrix1.begin();
  matrix1.setBrightness(5);   //sets matrix brightness
  matrix1.fillScreen(0);      //turns off all leds
  matrix1.show();             //applies changes

  matrix2.begin();
  matrix2.setBrightness(5);
  matrix2.fillScreen(0);
  matrix2.show();

  matrix3.begin();
  matrix3.setBrightness(5);
  matrix3.fillScreen(0);
  matrix3.show();

  matrix4.begin();
  matrix4.setBrightness(5);
  matrix4.fillScreen(0);
  matrix4.show();

  matrix5.begin();
  matrix5.setBrightness(5);
  matrix5.fillScreen(0);
  matrix5.show();

  //Initialize serial and wait for port to open:
  Serial.begin(115200);
  //  while (!Serial) {
  //    ; // wait for serial port to connect. Needed for native USB port only
  // }

  Serial.println("Access Point Web Server");

  // check for the WiFi module:
  if (WiFi.status() == WL_NO_MODULE) {
    Serial.println("Communication with WiFi module failed!");
    // don't continue
    while (true);
  }

  String fv = WiFi.firmwareVersion();
  if (fv < "1.0.0") {
    Serial.println("Please upgrade the firmware");
  }

  // by default the local IP address of will be 192.168.4.1
  // you can override it with the following:
  // WiFi.config(IPAddress(10, 0, 0, 1));

  // print the network name (SSID);
  Serial.print("Creating access point named: ");
  Serial.println(ssid);

  // Create open network. Change this line if you want to create an WEP network:
  status = WiFi.beginAP(ssid, pass);
  if (status != WL_AP_LISTENING) {
    Serial.println("Creating access point failed");
    // don't continue
    while (true);
  }

  // wait 5 seconds for connection:
  delay(5000);

  // start the web server on port 80
  server.begin();

  // you're connected now, so print out the status
  printWiFiStatus();

  //MPU6050 configuration
  Wire.begin();       //set up I2C connection
  mpu6050.begin();
  mpu6050.calcGyroOffsets(true);   //calculate angle offsets


  analogReadResolution(10);       //microphone input resolution

  //Haptic driver configuration
  drv.begin();
  drv.selectLibrary(1);
  drv.setMode(DRV2605_MODE_INTTRIG);

  //initialise timer
  timer.setInterval(IMU_PERIOD);        //send IMU readings tot he server every 500ms. Change the value for slower/faster data rate.
  timer.setCallback(readIMU);
  timer.start();

  MIC_THRESHOLD = mic_calibration();    //set the mic treshold to the average noise in the environment
}

//Part of the program that will loop continously during device operation.
void loop() {

  timer.update();
  sound_detected = false;

  // compare the previous status to the current status
  if (status != WiFi.status())
  {
    // it has changed update the variable
    status = WiFi.status();

    if (status == WL_AP_CONNECTED)
      Serial.println("Device connected to AP");    // a device has connected to the AP
    else
      Serial.println("Device disconnected from AP");     // a device has disconnected from the AP, and we are back in listening mode
  }

  mpu6050.update();            // update the IMU readings


  if (updatetime && enable)   //when the timer ends and the IMU is enabled
  {
    //variables in which the IMU readings are stored
    float accX, accY, accZ;
    float gyroX, gyroY, gyroZ;
    float angleX, angleY, angleZ;

    //print the positional data to the server
    server.print("accX : "); server.print(accX = mpu6050.getAccX());
    server.print("\taccY : "); server.print(accY = mpu6050.getAccY());
    server.print("\taccZ : "); server.print(accZ = mpu6050.getAccZ());

    server.print("\tgyroX : "); server.print(gyroX = mpu6050.getGyroX());
    server.print("\tgyroY : "); server.print(gyroY = mpu6050.getGyroY());
    server.print("\tgyroZ : "); server.print(gyroZ = mpu6050.getGyroZ());

    server.print("\tangleX : "); server.print(angleX = mpu6050.getAngleX());
    server.print("\tangleY : "); server.print(angleY = mpu6050.getAngleY());
    server.print("\tangleZ : "); server.print(angleZ = mpu6050.getAngleZ());
    server.print("\t\r\n");
    delay(50);    // allow 50ms for the data to be recieved correctly

    if (abs(accX) > SHAKE_THRESH) server.print("SX\r\n");         //signal shake in X direction 
    if (abs(accY) > SHAKE_THRESH) server.print("SY\r\n");         //signal shake in Y direction 
    if (abs(accZ) > SHAKE_THRESH) server.print("SZ\r\n");         //signal shake in Z direction
    if (abs(gyroX) > ROT_THRESH) server.print("RX\r\n");        //signal rotation about X axis 
    if (abs(gyroY) > ROT_THRESH) server.print("RY\r\n");        //signal rotation about Y axis 
    if (abs(gyroZ) > ROT_THRESH) server.print("RZ\r\n");        //signal rotation about Z axis

    updatetime = false;
  }

  WiFiClient client = server.available();   //connect to the client when available
  if (client)
  {
    if (!alreadyConnected) {
      client.flush();
      alreadyConnected = true;
    }

    char incomingString[] = "";          // string storing thhe incoming data
    int x = 0;

    //read incoming data character by character into the incomingStirng variable
    while (client.available() > 0)
    {
      incomingString[x] = client.read();
      x++;
    }
    client.flush();
      //  Serial.println(incomingString);   //send the string on the serial port (for debugging)

    switch (incomingString[0]) {
      case 's' :                       //trigger sound
        {
          char* index;
          index = strtok(incomingString, "$");   //get the track number form "s$track"
          index = strtok(NULL, "$");
          track = atoi(index);
        } break;
      case 'e' : {              //transmission enabled
          enable = true;
          client.flush();
        } break;
      case 'd' : enable = false; break;    //transmission disabled
      case 'v' :                               //trigger vibration
        {
          char* index;
          index = strtok(incomingString, "$");   //get haptic pattern number form "v$waveform"
          index = strtok(NULL, "$");
          waveform = atoi(index);
        } break;
      case 'm' :                       //trigger matrix pattern
        {
          char* index;
          int pattern_no = 0;
          int matrix_no = 0;
          index = strtok(incomingString, "$");    //get matrix number from "m$matrix_no$pattern_no"
          index = strtok(NULL, "$");
          matrix_no = atoi(index);
          index = strtok(NULL, "$");              //get pattern number from "m$matrix_no$pattern_no"
          pattern_no = atoi(index);
          // Serial.print(matrix_no);
          // Serial.print(pattern_no);
          loop_counter1++;
          switch (matrix_no)                      //call the display_pattern fucntion depending on the matrix chosen
          {
            case 1: display_pattern(matrix1, pattern_no); break;
            case 2: display_pattern(matrix2, pattern_no); break;
            case 3: display_pattern(matrix3, pattern_no); break;
            case 4: display_pattern(matrix4, pattern_no); break;
            case 5: display_pattern(matrix5, pattern_no); break;
            case 6:                               //display pattern on all matrices
              {
                display_pattern(matrix1, pattern_no);
                display_pattern(matrix2, pattern_no);
                display_pattern(matrix3, pattern_no);
                display_pattern(matrix4, pattern_no);
                display_pattern(matrix5, pattern_no);
              } break;
          }
        } break;
    }
  }

 /* if (loop_counter1 > 0)
    loop_counter1++;
  if (loop_counter1 > 1000)
  {
    loop_counter1 = 0;
    matrix1.begin();
    matrix1.fillScreen(0);      //turns off all leds
    matrix1.show();  //applies changes
    matrix2.begin();
    matrix2.fillScreen(0);
    matrix2.show();
    matrix3.begin();
    matrix3.fillScreen(0);
    matrix3.show();
    matrix4.begin();
    matrix4.fillScreen(0);
    matrix4.show();
    matrix5.begin();
    matrix5.fillScreen(0);
    matrix5.show();
    delay(50);
  }
*/

  //=========READ SIGNAL FROM SENSORS==============

  if (enable)
  {

    int mic_reading = analogRead(A0);      //get reading from microphone

    // if reading is bigger or smaller than MIC_THRESHOLD +- 10 -> sound is detected
    if ((mic_reading > (MIC_THRESHOLD + 10) || mic_reading < (MIC_THRESHOLD - 10)) && loop_counter == 0)
    {
      sound_detected = true;
      loop_counter++;
      server.print("MIC\r\n");
    }

    //add a delay of 100 loops between force detections
    if (loop_counter > 0)
      loop_counter++;
    if (loop_counter > 100)
      loop_counter = 0;

    int force_reading1 = analogRead(A1);  //get reading from force sensor 1

    //if reading is lower than 27 ->force is applied
    if (force_reading1 < FORCE_THRESH && loop_counter2 == 0)
    {
      server.print("F1\r\n");
      loop_counter2++;
    }

    //add a delay of 100 loops between force detections
    if (loop_counter2 > 0)
      loop_counter2++;
    if (loop_counter2 > 100)
      loop_counter2 = 0;

    int force_reading2 = analogRead(A2);  //get reading from force sensor 2

    //if reading is lower than 27 ->force is applied
    if (force_reading2 < FORCE_THRESH && loop_counter3 == 0)
    {
      server.print("F2\r\n");
      loop_counter3++;
    }

    //add a delay of 100 loops between force detections
    if (loop_counter3 > 0)
      loop_counter3++;
    if (loop_counter3 > 100)
      loop_counter3 = 0;

    int force_reading3 = analogRead(A3);  //get reading from force sensor 3

    //if reading is lower than 27 ->force is applied
    if (force_reading3 < FORCE_THRESH && loop_counter4 == 0)
    {
      server.print("F3\r\n");
      loop_counter4++;
    }

    //add a delay of 100 loops between force detections
    if (loop_counter4 > 0)
      loop_counter4++;
    if (loop_counter4 > 100)
      loop_counter4 = 0;


    //detect if button is pressed
    int button_reading = digitalRead(buttonPin);
    if (button_reading == HIGH && button_state == LOW)
      server.print("BUT\r\n");
    button_state = button_reading;
  }

  // =================== ENABLE ACTUATORS ==================

  if (track >= 0)            //if track was changed, play track
  {
    sfx.playTrack(track);
    Serial.println(track);
    track = -1;
  }

  if (waveform >= 0)         //if waveform was changed, play waveform
  {
    drv.setWaveform(0, waveform);  // play effect
    drv.setWaveform(1, 0);       // end waveform
    drv.go();
    waveform = -1;
  }

}


void display_pattern(Adafruit_NeoMatrix matrix, int pattern)   //function that selects the required pattern
{
  matrix.begin();
  matrix.fillScreen(0);         //turn off all leds
  matrix.show();
  switch (pattern)              //call the function corresponding to the selected pattern
  {
    case 1: patternRED(matrix); break;
    case 2: patternGREEN(matrix); break;
    case 3: patternBLUE(matrix); break;
    case 4: patternYELLOW(matrix); break;
 //   case 5: patternSMILEYFACE(matrix); break;
    case 6: patternRO(matrix); break;
    case 7: patternSCO(matrix); break;
    case 8: patternRECTANGLES(matrix); break;
    case 9: patternLINES(matrix); break;
    case 10: patternGREEN(matrix); break;
  }
}


void readIMU() {              //if function is called and the the client is still connected
  if (alreadyConnected)
    updatetime = true;        //it is time to send new IMU readings
}

int mic_calibration()          //fucntion that clculates the mic threshold
{
  int sum = 0;
  for (int i = 1; i <= 500; i++)
    sum = sum + analogRead(A0);
  return sum / 500;
}

void printWiFiStatus() {
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your WiFi shield's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print where to go in a browser:
  Serial.println(ip);
}

//======================== MATRIX PATTERNS =======================

void patternRO(Adafruit_NeoMatrix matrix)
{
  matrix.fillRect(0, 0, 3, 8, BLUE);
  matrix.fillRect(3, 0, 2, 8, YELLOW);
  matrix.fillRect(5, 0, 3, 8, RED);
  matrix.show();
  delay(20);
  return;
}
void patternRED(Adafruit_NeoMatrix matrix)
{
  matrix.fillScreen(RED);
  matrix.show();
  delay(20);
  return;
}
void patternGREEN(Adafruit_NeoMatrix matrix)
{
  matrix.fillScreen(GREEN);
  matrix.show();
  delay(20);
  return;
}
void patternBLUE(Adafruit_NeoMatrix matrix)
{
  matrix.fillScreen(BLUE);
  matrix.setCursor(1,1);
  matrix.setTextColor(RED); 
  matrix.print("E");
  matrix.show();
  delay(20);
  return;
}
void patternYELLOW(Adafruit_NeoMatrix matrix)
{
  matrix.fillScreen(YELLOW);
  matrix.show();
  delay(20);
  return;
}
void patternSCO(Adafruit_NeoMatrix matrix)
{
  matrix.fillScreen(BLUE);
  matrix.drawLine(0, 0, 7, 7, WHITE);
  matrix.drawLine(0, 7, 7, 0, WHITE);
  matrix.show();
  delay(20);
  return;
}
void patternSMILEYFACE(Adafruit_NeoMatrix matrix)
{
  matrix.drawPixel(0, 3,GREEN);
  matrix.drawPixel(0, 4,GREEN);
  matrix.drawPixel(0, 5,GREEN);
  matrix.drawPixel(3, 0,GREEN);
  matrix.drawPixel(4, 0,GREEN);
  matrix.drawPixel(5, 0,GREEN);
  matrix.drawPixel(6, 1,GREEN);
  matrix.drawPixel(7, 2,GREEN);
  matrix.drawPixel(7, 3,GREEN);
  matrix.drawPixel(7, 4,GREEN);
  matrix.drawPixel(7, 5,GREEN);
  matrix.drawPixel(6, 6,GREEN);
  matrix.drawPixel(5, 7,GREEN);
  matrix.drawPixel(4, 7,GREEN);
  matrix.drawPixel(3, 7,GREEN);
  matrix.drawPixel(2, 7,GREEN);
  matrix.drawPixel(1, 6,GREEN);
  matrix.drawPixel(2, 0,GREEN);
  matrix.drawPixel(1, 1,GREEN);
  matrix.drawPixel(0, 2,GREEN);
  matrix.drawPixel(5, 3,RED);
  matrix.drawPixel(5, 4,RED);
  matrix.drawPixel(2, 2,BLUE);
  matrix.drawPixel(2, 5,BLUE);
  matrix.drawPixel(1, 0,YELLOW);
  matrix.drawPixel(0, 0,YELLOW);
  matrix.drawPixel(0, 1,YELLOW);
  matrix.drawPixel(2, 1,YELLOW);
  matrix.drawPixel(1, 2,YELLOW);
  matrix.drawPixel(1, 3,YELLOW);
  matrix.drawPixel(1, 4,YELLOW);
  matrix.drawPixel(1, 5,YELLOW);
  matrix.drawPixel(2, 6,YELLOW);
  matrix.drawPixel(1, 7,YELLOW);
  matrix.drawPixel(0, 7,YELLOW);
  matrix.drawPixel(0, 6,YELLOW);
  matrix.drawPixel(2, 4,YELLOW);
  matrix.drawPixel(2, 3,YELLOW);
  matrix.drawPixel(3, 1,YELLOW);
  matrix.drawPixel(3, 2,YELLOW);
  matrix.drawPixel(3, 3,YELLOW);
  matrix.drawPixel(3, 4,YELLOW);
  matrix.drawPixel(3, 5,YELLOW);
  matrix.drawPixel(3, 6,YELLOW);
  matrix.drawPixel(4, 4,YELLOW);
  matrix.drawPixel(4, 3,YELLOW);
  matrix.drawPixel(4, 1,YELLOW);
  matrix.drawPixel(5, 1,YELLOW);
  matrix.drawPixel(5, 6,YELLOW);
  matrix.drawPixel(4, 6,YELLOW);
  matrix.drawPixel(6, 4,YELLOW);
  matrix.drawPixel(6, 3,YELLOW);
  matrix.drawPixel(6, 2,YELLOW);
  matrix.drawPixel(7, 1,YELLOW);
  matrix.drawPixel(7, 0,YELLOW);
  matrix.drawPixel(6, 0,YELLOW);
  matrix.drawPixel(7, 6,YELLOW);
  matrix.drawPixel(7, 7,YELLOW);
  matrix.drawPixel(6, 7,YELLOW);
  matrix.drawPixel(6, 5,YELLOW);
  matrix.drawPixel(5, 2,YELLOW);
  matrix.drawPixel(5, 5,YELLOW);
  matrix.drawPixel(4, 2,RED);
  matrix.drawPixel(4, 5,RED);
  matrix.show();
  delay(20);
  return;
}

void patternRECTANGLES(Adafruit_NeoMatrix matrix)
{
  matrix.drawRect(0, 0, 8, 8, YELLOW);
  matrix.drawRect(1, 1, 6, 6, GREEN);
  matrix.drawRect(2, 2, 4, 4, BLUE);
  matrix.drawRect(3, 3, 2, 2, RED);
  matrix.show();
  delay(20);
  return;
}

void patternLINES(Adafruit_NeoMatrix matrix)
{
  matrix.drawFastHLine(0, 0, 8, BLUE);
  matrix.drawFastHLine(0, 1, 8, YELLOW);
  matrix.drawFastHLine(0, 2, 8, RED);
  matrix.drawFastHLine(0, 3, 8, GREEN);
  matrix.drawFastHLine(0, 4, 8, PEACH);
  matrix.drawFastHLine(0, 5, 8, PURPLE);
  matrix.drawFastHLine(0, 6, 8, DARKGREEN);
  matrix.drawFastHLine(0, 7, 8, PINK);
  matrix.show();
  delay(20);
  return;
}
