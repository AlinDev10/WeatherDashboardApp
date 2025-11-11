## Weather Dashboard Application - Backend Project

This project was build using Asp Ner Core version 8.0.21: https://versionsof.net/core/8.0/.

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

##Environment variables required

*Replace the value of "ConnectionString" variable with your connection string from Mongo DB clusters, link: https://cloud.mongodb.com/.

##Database Schema



