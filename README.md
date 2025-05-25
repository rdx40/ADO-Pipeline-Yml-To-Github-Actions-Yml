# ADO-Pipeline-Yml-To-Github-Actions-Yml
A web api for converting Azure DevOps pipeline yml to GitHub Actions yml


This project is heavily dependent and built upon the project 
https://github.com/samsmithnz/AzurePipelinesToGitHubActionsConverter
By 
github.com/samsmithnz



### 1. Clone the repository
```bash
git clone https://github.com/your-username/ADO-Pipeline-Yml-To-Github-Actions-Yml.git
cd ADO-Pipeline-Yml-To-Github-Actions-Yml

dotnet restore

dotnet build

dotnet run --project src/AzurePipelinesToGitHubActionsConverter.Api


http://localhost:5000/swagger
dotnet test



