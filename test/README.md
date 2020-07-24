# Simple Com Driver

## Requirements

#### Microsoft Compatibility Package

install through nuget `microsoft.windows.compatibility`

#### com0com emulator

install `com0com` to emulate COM ports (download link):

https://sourceforge.net/projects/com0com/files/latest/download

## Run

### Driver

```
var port = new SerialPort("COM**") // ** means your number of port (f.e. COM23), you can set this in the com0com
var driver = new ComDriver(port)

// you can pass an implementation of ICommandListener here
driver.Listen(new CustomCommandListener()) 

// or default implementation that prints to console
driver.Listen() 

// write
driver.Write("some command")

// close the port at the end of program
driver.Close()

```

### Simulator 

Simulator will read file with instructions 
and execute them one by one. Line endings in the file
should be Windows-style `/r/n`


By default Simulator will start a listening
thread which will output strings to console.
 
Currently simulator is not able to wait for 
input -- you can control this using `wait: `
instruction.

#### Instructions

`write: <text>` - write text to com port

`wait: <integer>` - wait for number of milliseconds 

##### Note: do not forget to add space character after instruction keyword 

#### Example

```
var port = new SerialPort("COM**"); // ** means your number of port (f.e. COM23), you can set this in the com0com
var simulator = new Simulator(port);

// enter the path to file with instructions 
simulator.ReadInstructions("path/to/instructions.txt");

// start simulation
simulator.Simulate(3) // how much to repeat instructions execution 

```
