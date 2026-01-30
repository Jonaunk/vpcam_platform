```json
{
  "openapi": "3.0.1",
  "info": { "title": "VPCAM API", "version": "1.0.MVP" },
  "paths": {
    "/api/users/sync": {
      "post": {
        "summary": "Sync Identity User to Local DB",
        "description": "Must be called immediately after login. Uses JWT claims to create/update local user.",
        "responses": {
          "200": { "description": "Returns Local User ID", "content": { "application/json": { "schema": { "type": "object", "properties": { "localId": { "type": "string" }, "isNew": { "type": "boolean" } } } } } }
        }
      }
    },
    "/api/matches": {
      "get": {
        "summary": "List matches",
        "parameters": [
          { "name": "date", "in": "query", "schema": { "type": "string", "format": "date" } }
        ],
        "responses": {
          "200": { "description": "List of matches", "content": { "application/json": { "schema": { "type": "array", "items": { "$ref": "#/components/schemas/MatchSummary" } } } } }
        }
      }
    },
    "/api/matches/{id}": {
      "get": {
        "summary": "Get streaming URL",
        "responses": {
          "200": { "content": { "application/json": { "schema": { "$ref": "#/components/schemas/MatchDetail" } } } }
        }
      }
    },
    "/api/webhooks/dahua": {
      "post": { 
        "summary": "Receive recordUpload event",
        "requestBody": { "content": { "application/json": { "schema": { "type": "object", "properties": { "deviceId": { "type": "string" }, "fileUrl": { "type": "string" } } } } } },
        "responses": { "200": { "description": "Enqueued" } }
      }
    }
  },
  "components": {
    "schemas": {
      "MatchSummary": {
        "type": "object",
        "properties": { "id": { "type": "integer" }, "status": { "type": "string" }, "startTime": { "type": "string" } }
      },
      "MatchDetail": {
        "type": "object",
        "properties": { "id": { "type": "integer" }, "streamUrl": { "type": "string" } }
      }
    }
  }
}
```