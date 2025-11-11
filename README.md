## Weather Dashboard Application - Backend Project

This project was build using Asp Ner Core version 8.0.21: https://versionsof.net/core/8.0/. Also, thi project is using Mongo DB as main engine due to is a Non SQL database due to is one of the ideal solution to work with Microservices environment.

## Project setup and installation instructions

To run this project correcly you need to install first the next applications:
* Microsoft Visual Studio Professional 2022 or Enterprise (64 bits) Version 17.14.19
* Docker Desktop application latest version
* Git the latest version
* Mongo DB Compass application latest version

Then,to start a local development server, run:

1. Open the application Docker Desktop app as adminitrador user.
2. From the File menu, select Open > Project/Solution.... and select the project download it from this repository.
3. Select Solution File: Select the .sln (solution) file associated with your ASP.NET Core project and click Open.
4. Once the project is open, you can explore the file estructure in the Solution Explorer and manage an run the Nuget Package Manager to install the packages dependencies in the project.
5. Then click on the compile/ recompile solution to help in case that the nuget package has not restored properly.
6. FInally click on run button (Container Dockerfile) in the interface to execute the application.


Once the server is running, a new browser windows will be open with the URL similar to this 'https://localhost:[Available_port]/swagger/index.html' where is API is running and can be access as well as the swagger index page will be open to test the API endpoints and get the documentation about this API for each of the endpoints.


## Stack of NPM used in the project

* Microsoft.VisualStudio.Azure.Containers.Tools.Targets version 1.22.1
* FluentValidation.DependencyInjectionExtensions version 12.1.0
* MediatR version 13.1.0
* MongoDB.EntityFrameworkCore version 9.0.3
* Microsoft.Extensions.DependencyInjection.Abstractions 9.0.9
* Moq version 4.20.72 
* xunit version 2.5.3
* karma version 6.4.0
* Microsoft.NET.Test.Sdk version 17.8.0
* Microsoft.AspNetCore.Mvc.Core 2.3.0

## Running unit tests

To execute unit tests with the [Xunit](https://xunit.net/?tabs=cs) test runner, use the following command:

```bash
dotnet run
```
Or Open the Tests explorer window and run from there the stacks of unit test created in this project by class or by each method.

## API documentation (JSON File)

```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "WeatherDashboardAPI",
    "version": "1.0"
  },
  "paths": {
    "/api/FavoriteCities": {
      "post": {
        "tags": [
          "FavoriteCities"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/FavoriteCitiesEntity"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/FavoriteCitiesEntity"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/FavoriteCitiesEntity"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "get": {
        "tags": [
          "FavoriteCities"
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "put": {
        "tags": [
          "FavoriteCities"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/FavoriteCitiesEntity"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/FavoriteCitiesEntity"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/FavoriteCitiesEntity"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/FavoriteCities/{favoriteCityId}": {
      "get": {
        "tags": [
          "FavoriteCities"
        ],
        "parameters": [
          {
            "name": "favoriteCityId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "FavoriteCities"
        ],
        "parameters": [
          {
            "name": "favoriteCityId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Users": {
      "post": {
        "tags": [
          "Users"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserEntity"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserEntity"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserEntity"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "get": {
        "tags": [
          "Users"
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "put": {
        "tags": [
          "Users"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserEntity"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserEntity"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserEntity"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Users/{userId}": {
      "get": {
        "tags": [
          "Users"
        ],
        "parameters": [
          {
            "name": "userId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Users"
        ],
        "parameters": [
          {
            "name": "userId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/WeatherHistories": {
      "post": {
        "tags": [
          "WeatherHistories"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/WeatherHistoryEntity"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/WeatherHistoryEntity"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/WeatherHistoryEntity"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "get": {
        "tags": [
          "WeatherHistories"
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "put": {
        "tags": [
          "WeatherHistories"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/WeatherHistoryEntity"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/WeatherHistoryEntity"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/WeatherHistoryEntity"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/WeatherHistories/{weatherHistoryId}": {
      "get": {
        "tags": [
          "WeatherHistories"
        ],
        "parameters": [
          {
            "name": "weatherHistoryId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "WeatherHistories"
        ],
        "parameters": [
          {
            "name": "weatherHistoryId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "FavoriteCitiesEntity": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "nullable": true
          },
          "userId": {
            "type": "string",
            "nullable": true
          },
          "cityName": {
            "maxLength": 100,
            "type": "string",
            "nullable": true
          },
          "countryCode": {
            "maxLength": 2,
            "type": "string",
            "nullable": true
          },
          "addedAt": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserEntity": {
        "required": [
          "userName"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "maxLength": 50,
            "minLength": 1,
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "WeatherHistoryEntity": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "nullable": true
          },
          "userId": {
            "type": "string",
            "nullable": true
          },
          "cityName": {
            "maxLength": 100,
            "type": "string",
            "nullable": true
          },
          "countryCode": {
            "maxLength": 2,
            "type": "string",
            "nullable": true
          },
          "searchedAt": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "weatherData": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```

## Environment variables required

*Replace the value of "ConnectionString" variable with your connection string from Mongo DB clusters, link: https://cloud.mongodb.com/. Located in the "appsettings.json" file in the solution "WeatherDashboardAPI.csproj"


## Database Schema from Mongo DB Diagram JSON representation

```json
{
  "collections": {
    "weather_dashboard.favorite_cities": {
      "ns": "weather_dashboard.favorite_cities",
      "jsonSchema": {
        "bsonType": "object",
        "required": [
          "_id",
          "added_at",
          "city_name",
          "country_code",
          "user_id"
        ],
        "properties": {
          "_id": {
            "bsonType": "objectId"
          },
          "added_at": {
            "bsonType": "date"
          },
          "city_name": {
            "bsonType": "string"
          },
          "country_code": {
            "bsonType": "string"
          },
          "user_id": {
            "bsonType": "objectId"
          }
        }
      }
    },
    "weather_dashboard.users": {
      "ns": "weather_dashboard.users",
      "jsonSchema": {
        "bsonType": "object",
        "required": [
          "_id",
          "username"
        ],
        "properties": {
          "_id": {
            "bsonType": "objectId"
          },
          "username": {
            "bsonType": "string"
          }
        }
      }
    },
    "weather_dashboard.weather_history": {
      "ns": "weather_dashboard.weather_history",
      "jsonSchema": {
        "bsonType": "object",
        "required": [
          "_id",
          "city_name",
          "country_code",
          "searched_at",
          "user_id",
          "weather_data"
        ],
        "properties": {
          "_id": {
            "bsonType": "objectId"
          },
          "city_name": {
            "bsonType": "string"
          },
          "country_code": {
            "bsonType": "string"
          },
          "searched_at": {
            "bsonType": "date"
          },
          "user_id": {
            "bsonType": "objectId"
          },
          "weather_data": {
            "bsonType": "string"
          }
        }
      }
    }
  },
  "relationships": [
    {
      "id": "11eb3310-cecc-4ef2-a274-908bb75fa908",
      "relationship": [
        {
          "ns": "weather_dashboard.favorite_cities",
          "fields": [
            "user_id"
          ],
          "cardinality": 1
        },
        {
          "ns": "weather_dashboard.users",
          "fields": [
            "_id"
          ],
          "cardinality": 1
        }
      ],
      "isInferred": true
    },
    {
      "id": "4392746b-23e8-40ac-b799-d6de63952eaa",
      "relationship": [
        {
          "ns": "weather_dashboard.weather_history",
          "fields": [
            "user_id"
          ],
          "cardinality": 1
        },
        {
          "ns": "weather_dashboard.users",
          "fields": [
            "_id"
          ],
          "cardinality": 1
        }
      ],
      "isInferred": true
    }
  ]
}
```

## Data sample json format

* "users" Entity

```json
  {
  "_id": {
    "$oid": "6913553e650bb7006c14bffe"
  },
  "username": "Test"
}
```

* "favorite_cities" Entity

```json
  {
  "_id": {
    "$oid": "69137499341e5aab42498ed1"
  },
  "added_at": {
    "$date": "2025-11-11T17:38:33.874Z"
  },
  "city_name": "Cancún",
  "country_code": "MX",
  "user_id": {
    "$oid": "690be55a9833df8b2f206bb3"
  }
}
```

* "weather_history" Entity

```json
{
  "_id": {
    "$oid": "6913748c341e5aab42498ed0"
  },
  "city_name": "Cancún",
  "country_code": "MX",
  "searched_at": {
    "$date": "2025-11-11T17:38:20.264Z"
  },
  "user_id": {
    "$oid": "690be55a9833df8b2f206bb3"
  },
  "weather_data": "{\"id\":3531673,\"name\":\"Cancún\",\"dt\":1762882696,\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"main\":{\"temp\":25.54,\"feels_like\":25.59,\"temp_min\":23.92,\"temp_max\":25.54,\"pressure\":1023,\"humidity\":55,\"sea_level\":1023,\"grnd_level\":1022},\"wind\":{\"speed\":3.6,\"deg\":50},\"sys\":{\"type\":2,\"id\":2017394,\"country\":\"MX\",\"sunrise\":1762862152,\"sunset\":1762902429},\"coord\":{\"lon\":-86.8466,\"lat\":21.1743},\"base\":\"stations\",\"visibility\":9656,\"clouds\":{\"all\":75},\"timezone\":-18000,\"cod\":200}"
}
```
