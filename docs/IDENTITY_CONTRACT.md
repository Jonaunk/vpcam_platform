```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "AppendIdentity",
    "version": "v1"
  },
  "paths": {
    "/api/v{version}/Account/Authenticate": {
      "post": {
        "tags": [
          "Account"
        ],
        "summary": "Logeo del usuario",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AuthenticationRequest"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AuthenticationRequest"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AuthenticationRequest"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/AuthenticationResponseResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/AuthenticationResponseResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/AuthenticationResponseResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Account/Register": {
      "post": {
        "tags": [
          "Account"
        ],
        "summary": "Registro de usuario",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Account/CompleteRegistration": {
      "post": {
        "tags": [
          "Account"
        ],
        "summary": "Completar registro interno del usuario",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CompletePreRegistrationCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CompletePreRegistrationCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CompletePreRegistrationCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Account/ConfirmEmail": {
      "get": {
        "tags": [
          "Account"
        ],
        "summary": "Confirmar usuario mediante el email",
        "parameters": [
          {
            "name": "Id",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "Token",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Account/ForgotPassword": {
      "post": {
        "tags": [
          "Account"
        ],
        "summary": "Recuperar password",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ForgotPasswordCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ForgotPasswordCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ForgotPasswordCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Account/ResetPassword": {
      "post": {
        "tags": [
          "Account"
        ],
        "summary": "Resetear password",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ResetPasswordCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ResetPasswordCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ResetPasswordCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Account/Refresh": {
      "post": {
        "tags": [
          "Account"
        ],
        "summary": "Genera un refresh para el usuario logeado",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Account/Revoke-token": {
      "get": {
        "tags": [
          "Account"
        ],
        "summary": "Deslogea al usuario",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Account/Introspect": {
      "post": {
        "tags": [
          "Account"
        ],
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "multipart/form-data": {
              "schema": {
                "type": "object",
                "properties": {
                  "token": {
                    "type": "string"
                  },
                  "clientKey": {
                    "type": "string"
                  }
                }
              },
              "encoding": {
                "token": {
                  "style": "form"
                },
                "clientKey": {
                  "style": "form"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/TokenIntrospectionResponseResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/TokenIntrospectionResponseResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/TokenIntrospectionResponseResponse"
                }
              }
            }
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      }
    },
    "/.well-known/openid-configuration": {
      "get": {
        "tags": [
          "OpenIdConfiguration"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/.well-known/jwks.json": {
      "get": {
        "tags": [
          "OpenIdConfiguration"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Roles": {
      "post": {
        "tags": [
          "Roles"
        ],
        "summary": "Crear un nuevo rol",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CreateRoleCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CreateRoleCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CreateRoleCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "get": {
        "tags": [
          "Roles"
        ],
        "summary": "Obtener todos los roles",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Roles/{Id}": {
      "put": {
        "tags": [
          "Roles"
        ],
        "summary": "Actualizar un rol existente",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UpdateRoleCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UpdateRoleCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UpdateRoleCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Roles"
        ],
        "summary": "Eliminar un rol existente",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Roles/Permissions": {
      "get": {
        "tags": [
          "Roles"
        ],
        "summary": "Obtener todos los permisos",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Roles/{Id}/Permissions": {
      "post": {
        "tags": [
          "Roles"
        ],
        "summary": "Asignar permisos a un rol",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignPermissionsToRoleCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignPermissionsToRoleCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignPermissionsToRoleCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Roles"
        ],
        "summary": "Remover permisos de un rol",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/RemovePermissionsToRoleCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/RemovePermissionsToRoleCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/RemovePermissionsToRoleCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Users/Profile": {
      "get": {
        "tags": [
          "Users"
        ],
        "summary": "Obtener informacion del usuario basado en el token",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Users": {
      "get": {
        "tags": [
          "Users"
        ],
        "summary": "Devuelve una lista paginada de usuarios",
        "parameters": [
          {
            "name": "Id",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "FirstName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "LastName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "UserName",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Email",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "PhoneNumber",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "PageNumber",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "PageSize",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "SortColumn",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "SortOrder",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOListResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOListResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOListResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Users/{Id}": {
      "get": {
        "tags": [
          "Users"
        ],
        "summary": "Obtener informacion del usuario por ID",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/UserDTOResponse"
                }
              }
            }
          }
        }
      },
      "delete": {
        "tags": [
          "Users"
        ],
        "summary": "Eliminar un usuario",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Users/{Id}/Profile": {
      "put": {
        "tags": [
          "Users"
        ],
        "summary": "Actualiza la informacion del usuario",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UpdateUserCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UpdateUserCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UpdateUserCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Users/ChangePassword": {
      "post": {
        "tags": [
          "Users"
        ],
        "summary": "Modificar password desde perfil",
        "parameters": [
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ChangePasswordCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ChangePasswordCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ChangePasswordCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/StringResponse"
                }
              }
            }
          }
        }
      }
    },
    "/api/v{version}/Users/{Id}/Role": {
      "post": {
        "tags": [
          "Users"
        ],
        "summary": "Asignar un rol a un usuario",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignRoleToUserCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignRoleToUserCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignRoleToUserCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Users"
        ],
        "summary": "Revocar un rol a un usuario",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/RemoveRoleToUserCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/RemoveRoleToUserCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/RemoveRoleToUserCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/v{version}/Users/{Id}/Permissions": {
      "post": {
        "tags": [
          "Users"
        ],
        "summary": "Asignar permisos a un usuario",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignPermissionsToUserCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignPermissionsToUserCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignPermissionsToUserCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Users"
        ],
        "summary": "Remover permisos de un usuario",
        "parameters": [
          {
            "name": "Id",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "version",
            "in": "path",
            "required": true,
            "style": "simple",
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/RemovePermissionsToUserCommand"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/RemovePermissionsToUserCommand"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/RemovePermissionsToUserCommand"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "AssignPermissionsToRoleCommand": {
        "type": "object",
        "properties": {
          "roleId": {
            "type": "string",
            "format": "uuid"
          },
          "permissionValues": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AssignPermissionsToUserCommand": {
        "type": "object",
        "properties": {
          "userId": {
            "type": "string",
            "format": "uuid"
          },
          "permissionValues": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AssignRoleToUserCommand": {
        "type": "object",
        "properties": {
          "userId": {
            "type": "string",
            "format": "uuid"
          },
          "roleId": {
            "type": "string",
            "format": "uuid"
          }
        },
        "additionalProperties": false
      },
      "AuthenticationRequest": {
        "type": "object",
        "properties": {
          "email": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          },
          "clientKey": {
            "type": "string",
            "nullable": true
          },
          "clientSecret": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AuthenticationResponse": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "nombre": {
            "type": "string",
            "nullable": true
          },
          "apellido": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "isVerified": {
            "type": "boolean"
          },
          "jwToken": {
            "type": "string",
            "nullable": true
          },
          "urlImage": {
            "type": "string",
            "format": "uri",
            "nullable": true
          },
          "isActive": {
            "type": "boolean"
          },
          "roles": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          },
          "roleClaims": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          },
          "clientKey": {
            "type": "string",
            "nullable": true
          },
          "appName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AuthenticationResponseResponse": {
        "type": "object",
        "properties": {
          "succeeded": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "data": {
            "$ref": "#/components/schemas/AuthenticationResponse"
          },
          "errors": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ChangePasswordCommand": {
        "type": "object",
        "properties": {
          "password": {
            "type": "string",
            "nullable": true
          },
          "newPassword": {
            "type": "string",
            "nullable": true
          },
          "confirmNewPassword": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CompletePreRegistrationCommand": {
        "type": "object",
        "properties": {
          "userName": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          },
          "confirmPassword": {
            "type": "string",
            "nullable": true
          },
          "token": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CreateRoleCommand": {
        "type": "object",
        "properties": {
          "roleName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "FileUploadRequest": {
        "type": "object",
        "properties": {
          "name": {
            "type": "string",
            "nullable": true
          },
          "extension": {
            "type": "string",
            "nullable": true
          },
          "data": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ForgotPasswordCommand": {
        "type": "object",
        "properties": {
          "email": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ProblemDetails": {
        "type": "object",
        "properties": {
          "type": {
            "type": "string",
            "nullable": true
          },
          "title": {
            "type": "string",
            "nullable": true
          },
          "status": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "detail": {
            "type": "string",
            "nullable": true
          },
          "instance": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": { }
      },
      "RegisterCommand": {
        "type": "object",
        "properties": {
          "firstName": {
            "type": "string",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          },
          "confirmPassword": {
            "type": "string",
            "nullable": true
          },
          "phoneNumber": {
            "type": "string",
            "nullable": true
          },
          "origin": {
            "type": "string",
            "nullable": true
          },
          "clientKey": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RemovePermissionsToRoleCommand": {
        "type": "object",
        "properties": {
          "roleId": {
            "type": "string",
            "format": "uuid"
          },
          "permissionValues": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RemovePermissionsToUserCommand": {
        "type": "object",
        "properties": {
          "userId": {
            "type": "string",
            "format": "uuid"
          },
          "permissionValues": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RemoveRoleToUserCommand": {
        "type": "object",
        "properties": {
          "userId": {
            "type": "string",
            "format": "uuid"
          },
          "roleId": {
            "type": "string",
            "format": "uuid"
          }
        },
        "additionalProperties": false
      },
      "ResetPasswordCommand": {
        "type": "object",
        "properties": {
          "email": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          },
          "token": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "StringResponse": {
        "type": "object",
        "properties": {
          "succeeded": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "data": {
            "type": "string",
            "nullable": true
          },
          "errors": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TokenIntrospectionResponse": {
        "type": "object",
        "properties": {
          "active": {
            "type": "boolean"
          },
          "subject": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "clientId": {
            "type": "string",
            "nullable": true
          },
          "issuer": {
            "type": "string",
            "nullable": true
          },
          "expiration": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "roles": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          },
          "permissions": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TokenIntrospectionResponseResponse": {
        "type": "object",
        "properties": {
          "succeeded": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "data": {
            "$ref": "#/components/schemas/TokenIntrospectionResponse"
          },
          "errors": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UpdateRoleCommand": {
        "type": "object",
        "properties": {
          "roleId": {
            "type": "string",
            "format": "uuid"
          },
          "roleName": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UpdateUserCommand": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "format": "uuid",
            "nullable": true
          },
          "nombre": {
            "type": "string",
            "nullable": true
          },
          "apellido": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "phoneNumber": {
            "type": "string",
            "nullable": true
          },
          "areaNumber": {
            "type": "string",
            "nullable": true
          },
          "image": {
            "$ref": "#/components/schemas/FileUploadRequest"
          },
          "deleteCurrentImage": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "UserDTO": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "format": "uuid"
          },
          "userName": {
            "type": "string",
            "nullable": true
          },
          "nombre": {
            "type": "string",
            "nullable": true
          },
          "apellido": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "urlImage": {
            "type": "string",
            "nullable": true
          },
          "isActive": {
            "type": "boolean"
          },
          "isVerified": {
            "type": "boolean"
          },
          "phoneNumber": {
            "type": "string",
            "nullable": true
          },
          "roles": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserDTOListResponse": {
        "type": "object",
        "properties": {
          "succeeded": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "data": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/UserDTO"
            },
            "nullable": true
          },
          "errors": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserDTOResponse": {
        "type": "object",
        "properties": {
          "succeeded": {
            "type": "boolean"
          },
          "message": {
            "type": "string",
            "nullable": true
          },
          "data": {
            "$ref": "#/components/schemas/UserDTO"
          },
          "errors": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    },
    "securitySchemes": {
      "Bearer": {
        "type": "apiKey",
        "description": "Please insert JWT with Bearer into field",
        "name": "Authorization",
        "in": "header"
      }
    }
  },
  "security": [
    {
      "Bearer": [ ]
    }
  ]
}
```