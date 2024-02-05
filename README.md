<h1>Software Version Control Project (release notes)</h1>
<h3>using a content management system to update the register of new versions.</h3>

![image](https://github.com/Mark0liveira/DecisionTree/assets/47141652/6275494b-98c2-4d9f-895f-0eaa2c37d4d0)

<h2>Functionalities:</h2>

- List of all versions.
- View the launch in detail.
- Editing an existing release (title and content).
- Creation of a new version.

<h2>Technologies used</h2>

- Abp Framework
- Entity Framework
- Angular
- MongoDB
- WYSIWYG Editor
- Docker (to run sqlserver and mongoDb)
- xUnit

<h2>Quick Start:</h2>

- Install abp framework on your local machine:
    - `dotnet -g Volo.Abp.Cli tool`
- Install dependencies in the angular project
    - `abp install-libs`
- If you want to decouple the database, you can use a docker container for mongoDb and SQL Server:
    - `docker pull mongodb/mongodb-community-server`
    - `docker run --name mongo -p 64000:27017 -d mongodb/mongodb-community-server:latest`
    - `docker pull mcr.microsoft.com/mssql/server`
    - `sudo docker run -e ‘ACCEPT_EULA=Y’ -e ‘SA_PASSWORD=AY6129Gbn’ -p 1433:1433 -d ffdd6981a89e`
- Install the `node` on the local machine.
- Install `yarn` to manage packages.
- Access the angular folder and run:
    - `yarn start`
- Access the DecisionTree project and run the DecisionTree.csproj project with Rider or Visual Studio
- With both projects running, it is possible to access a local url to view the front and backend with swagger.

<h2>Possible improvements:</h2>

- Cache application to avoid crashing in mongoDb all the time, using redis.
- Work on some improvement points in the frontend.
