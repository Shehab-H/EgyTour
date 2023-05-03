# EgypTour

EgypTour is a .NET WebAPI that provides users with a way to explore trip destinations to visit in Egypt, read and write reviews about differnet places , it also has a trip scheduling system and it has a recommendations system based on the city visited and the activities the user chooses , and add posts. It uses SQL Server for storage and is designed to be easily scalable  

## Features

- Explore destinations to visit in Egypt
- Read & write reviews about different places and services
- Schedule trips
- Posts System to share your moments with friends 
- add friends to your scheduled trips to be able to see it and interact with it's activities 
- trip photowall to share trip images

## Technologies Used

- ASP.Net core (.Net 6.0)
- SQL Server 2019
- Entity Framework Core  


## Getting Started

### Prerequisites

- .NET6 SDK - includes the .NET runtime and command line tools ([link to download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)).
- SQL Server ([link to microsoft downloads page](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)).

### Installation

1. Clone the repository
<code>git clone https://github.com/mohab-elrouby/EgypTour.git</code>

2. Navigate to the project directory
3. Build the project
<pre>dotnet build</pre>
4. Update the appsettings.json file with your SQL Server connection string
<pre>  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=EgyTour;Integrated Security=true;Encrypt=False"
  }</pre>
5. apply the migrations to create the database 
<pre>dotnet ef database update</pre>
6. Run the project
<pre>dotnet run</pre>




