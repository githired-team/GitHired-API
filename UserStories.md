# User Stories

## As an API consumer, I want the ability to access information on job postings.

### Tasks:
Build logic that creates an object that contains job postings data for each job by querying the API database.
Build endpoint that serializes this object to JSON and sends it as a response.

### Acceptance Tests:
Verify that a request to the “get jobs” endpoint successfully returns data about job postings
Verify that job posting data returned from that endpoint relates to the given search query

## As an API consumer, I want to be able to access some basic statistical data on the occurrence of certain keywords in relevant job postings; for example, the number of job postings that mention React.js.

###	Tasks:
Build logic that counts the number of times that each skill appears in a job posting
Build an endpoint that returns this count as a serialized JSON object containing each skill and how many times it is mentioned

### Acceptance Tests:
API successfully counts the number of times each time a skill appears in a job description, ignoring duplicate instances within the same job posting
API successfully returns the serialized JSON object with each skill/count pair

##  As an API consumer, I want to be able to set filters for what information I receive back from the API, so I don’t have to build filter logic myself.

### Task:
Build filtering logic that, given a string query, queries the database and creates an object with job posting data relevant to that query
Build or add to an endpoint that accepts a request query and returns this object as a serialized JSON object

### Acceptance Tests:
Verify that different query strings create different, appropriate sets of job postings
Verify that the created object is correctly formatted, serialized and returned when endpoint is accessed.


##  As an API consumer, I want to be able to quickly access all job postings for a given company, as well as information on that company.

###	Tasks:
Build logic that takes in a query string and builds an object with company information, as well as all job postings for that company
Build endpoint that accepts a company name as a search query, and returns appropriate company/job postings object as serialized JSON

### Acceptance Tests
Test created object contains appropriate company information and job postings specific to that company
Test that this object, or a response stating that results for that company could not be found, are returned as appropriate JSON object

##  As an API consumer, I want to receive data on skill keywords contained in a job posting without having to parse the descriptions myself.

###	Tasks: 
Create logic that, when a job posting object is being created to satisfy an endpoint request, finds what skills the job posting is associated with, and adds an array of those skills to the job posting object.
	
### Acceptance Tests:
Verify that job posting objects contain array of skill keywords
Verify that skill keywords are appropriate and specific to each object
Verify that all skill keywords associated with an object exist within this array
