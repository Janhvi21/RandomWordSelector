# RandomWordSelector


Steps to run is Project:
1) Download zip folder or clone project to local machine.
2) Open .sln file in Visual Studio
3) Build Project and resolve dependencies.
4) Open appSettings.json and replace the connection String for Database Connection:
  "ConnectionStrings": {
    "DefaultConnection": //Enter Connection String Here
  }
5) Navigate to RandomWord -> ClientApp -> src -> environments ->environment.ts and replace the localhost url :
     wsURL: 'wss://localhost:XXXXX/ws'
6) Run the project using IIS Express

# Results:

 Note: Add Input String as words separated by commas:<br>
<b>Current Server State</b> is displayed in the block below the Button<br>
 <b> Red Block: </b>Server is in Stopped State<br>
 <b>Green Block:</b> Server is Running<br>
<b>CurrentWord: </b>Server sends words randomly from the User List<br>
<b>TimeRemaining:</b> Remaining amount of time for which server would be in running state in seconds.<br>

![image](https://user-images.githubusercontent.com/45782617/114225929-ed1d2900-9940-11eb-8e9f-a51fd4691b02.png)
![image](https://user-images.githubusercontent.com/45782617/114225969-f908eb00-9940-11eb-9fcf-3f07bd6df137.png)
![image](https://user-images.githubusercontent.com/45782617/114226009-058d4380-9941-11eb-8381-7d2e0b7b84b4.png)
![image](https://user-images.githubusercontent.com/45782617/114226042-16d65000-9941-11eb-8c6c-41e9bd34f122.png)


Database Log on Server State Change:<br>
![image](https://user-images.githubusercontent.com/45782617/114226144-37060f00-9941-11eb-9cd4-e42a7bfb9767.png)

