# [GitHired-API](https://githiredapi.azurewebsites.net/api/)

RESTful API that provides data about active job postings, employers, and data about the skills that job postings mention as requirements. 

Swagger documentation at: [Link to Swagger UI](https://githiredapi.azurewebsites.net/swagger/index.html)


## GitHired Team Members: Richard Flinn Mike Filicetti, Xia Liu, Julie Ly, Sean Miller

### Group Kanban: https://waffle.io/githired-team/GitHired-API

## Database Schema
![Database Schema](assets/apiSchema.JPG)
- Companies: Contains data about individual employers. 
- Jobs: Contains data for individual job listings. 
- Skills: Contains a list of individual skills that can then be associated with individual job postings via the "RequiredSkills" join table
-RequiredSkills: Contains a list of associations between job postings and the skills they mention as requirements


## Endpoints
Base URL: https://githiredapi.azurewebsites.net/api/

GitHired api has three enpoints: GetCompanyInfo, Getjobs and Skills.

`/GetJobs` is the primary endpoint for this API. It accepts a string as an optional URL query parameter, and returns all job postings whose title or description contains a word within that query string (or all job posting data if no query is provided). 

`/GetCompanyInfo` returns all data for all companies contained within the GitHiredApi database.
`/GetCompanyInfo/{id}` returns data on the company with a given ID, as well as all job postings associated with that company. This endpoint is primarily intended for use with the data returned by the /GetJobs endpoint, as each job posting contains a company ID which may be used to reference a company via this endpoint.

`/Skills` returns data on how many times each skill registered in the GitHiredApi database is associated with a job posting.

For more information, refer to the linked Swagger UI documentation.





## User Cases
![User Case](/UserStories.md)

## Software Requirements
![Software Requirements](https://github.com/githired-team/GitHired-MVC/blob/DevelopmentStaging/Requirements.md)
