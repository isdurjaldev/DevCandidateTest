# DevCandidateTest
 
This is a minimal .NET API solution that does

1.- Persist Employees to a data store.

2.- Validate uniqueness of an employee (uniqueness is defined by RFC).

3.-	Validate RFC Format and length.

4.-	Retrieve Employees sorted by born date and filtered optionally by name.

# /api/employeelist

GET - This gets a list of employees, also creates the database in memory for testing, so its a good idea to execute this one first

# /api/newemployee

POST - This is to add employees I'll leave a few objects so you can post them individually

```json
[
    {
        "Name": "Alberto",
        "LastName": "Garcia",
        "RFC": "JGID895623WE8",
        "bornDate": "1990-03-17T00:00:00",
        "Status": 0
    },
    {
        "Name": "Jorge",
        "LastName": "Diaz",
        "RFC": "DIGJ784512AS3",
        "bornDate": "2000-03-17T00:00:00",
        "Status": 1
    },
    {
        "Name": "Iliana",
        "LastName": "Romero",
        "RFC": "RIDL234589BG7",
        "bornDate": "1992-03-17T00:00:00",
        "Status": 2
    },
    {
        "Name": "Margarita",
        "LastName": "Rostenkawzki",
        "RFC": "RIDL234589BG7",
        "bornDate": "2005-03-17T00:00:00",
        "Status": 2
    }
]
```

# /api/employeelistsorted

GET - This gets a list of employees sorted by their Born Date

you can add the parameter in the URL
```bash
?SortByName
```
to also sort them by Name
