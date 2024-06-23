## Getting Started

1. The appliciton is not self hosting. So it can be debugged like any API application
2. The project uses a CSV file to hydrate the data. This file is located in the root of the project and is called "gwpByCountry.csv". 
3. This needs to copied to a locaiton and that location needs to be added to setting "CSVFileLocaiton" in config file


## Controller
Separate Request & Response object is used. 

## UseCases
MediatR is used as query dispacher to dispath the request to the handler.

## IRepository
Only read repository is enough for the moment it uses IQueryable to get the data.

## PersistenceStore
CSV file is used as the data store. It is read and stored in memory.

## Unit Tests
Test cases are implemented for average calculation & filtering. 
