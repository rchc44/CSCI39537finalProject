# Intro to APIs Final Project

I changed my project idea because it was too complicated: I originally had 5 tables with many different relationships, so I narrowed it down to just 2 tables.
My final project idea is a student seating database, with a students table to store student information, and a seats table to store seating information.

The students table has a foreign key column to the seats table to indicate with student is occupying which seat.




## Endpoints:

### GET /students/{{studentId}}

#### Description: 
Get all data of student with corresponding studentId

#### Sample Request Body:
None


#### Sample Response Body:

Student Found

{

	"statusCode":200,
	"statusDescription":"Student found",
	"data":
	{
	
		"studentId":int,
		"firstName":"firstName",
		"lastName":"lastName",
		"grade":int,
		"dob":"datetime",
		"address":"city,state",
		"seat":
		{
			"seatId":int,
			"pos":"[0-9]+,[0-9]+",
			"occupied":bool
		}
	}

}



Student Not Found


{

	"statusCode":404,
	"statusDescription":"Student is not found",
	"data":null

}


### POST /seats

#### Description: 
Create a new seat in the seats table 

#### Sample Request Body:

{

    "pos":"[0-9]+,[0-9]+"
	
}

#### Sample Response Body:


{

    "statusCode": 200,
    "statusDescription": "Seat successfully created",
    "data": null
	
}

If "pos" is an empty string:

{

    "statusCode": 404,
    "statusDescription": "Pos must not be empty",
    "data": null
	
}

##### Validation example:

The field "pos" represents an x,y coordinate system and the string must represent 2 digits separated by a comma.

Example of Incorrect request format:

{

    "pos":"5,n"
	
}

Error response:

{
    
	"type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "00-2cde1354223bcbcd97f9aeea1f7b16b2-b2dc9b75b8f699a6-00",
    "errors": {
        "Pos": [
            "Invalid Value"
        ]
    
}


### DELETE /students/{{studentId}}

#### Description: 
Delete data of student with corresponding studentId and sets "Occupied" property of seat of student to False

#### Sample Request Body:

None

#### Sample Response Body:


Student Found


{

    "statusCode": 200,
    "statusDescription": "Successfully deleted student and occupied seat changed to false",
    "data": null

}


Student NOT Found

{

    "statusCode": 404,
    "statusDescription": "Student not found",
    "data": null

}
