# Simple Com Driver

## Requirements

#### Microsoft Compatibility Package

install through nuget `microsoft.windows.compatibility`

#### com0com emulator

install `com0com` to emulate COM ports (download link):

https://sourceforge.net/projects/com0com/files/latest/download

## Run

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
