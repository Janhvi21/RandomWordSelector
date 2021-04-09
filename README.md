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


![image](https://user-images.githubusercontent.com/45782617/114217688-7a0eb500-9936-11eb-99d0-74f67fcd30d7.png)
