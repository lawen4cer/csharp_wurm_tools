# Wurm Tools

Currently only supports automation in mining. The automation is limited as the tools do not interact with the game at all. The tools are sending timed keystrokes to the active window. This is very nice for leveling up your mining skill. This application requires .NET Framework v4.7.2 or higher installed on your PC. 

If you don't have .NET Framework v4.7.2 or higher, download it here https://dotnet.microsoft.com/download/dotnet-framework/net472

# Install Instructions:

1. Unzip the WurmTools.zip
2. Run WurmTools.exe

# Usage Instructions

1. You must set a total execution time in seconds. This value is the total time that the script waits to fire the next command. Think of it as the total time that it takes you to mine 3 times plus a stamina regen period. I would start with about 50 seconds and tune from there. Don't forget to allow enough time for your stamina to regen. Click the save button if you want the program to remember your default time. 

2. Select your mining mode. This will dictate what hot key the script presses for you. I plan on eventually adding support for leveling and other mining operations. 

3. Click the start mining button and immediately bring Wurm as the active window and target the wall that you want to mine. You only have  5 seconds by default before the script starts sending commands. This is plenty of time. You can change this value in the settings page under initial delay value.

### Wurm must remain the active window. This tool does not interact with the client and will not work as intended unless Wurm is the active window.


