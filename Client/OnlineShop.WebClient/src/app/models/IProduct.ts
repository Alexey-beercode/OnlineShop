export interface IProduct  
{
      "id": {
        "type": "string",
        // "format": "uuid"
      },
      "name": {
        "type": "string"
      },
      "price": {
        "type": "number",
        "format": "decimal"
      },
      "categoryId": {
        "type": "string",
        "format": "uuid"
      },
      "category": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "format": "uuid"
          },
          "name": {
            "type": "string"
          }
        },
        "required": ["id", "name"]
      },
      "description": {
        "type": "string"
      },
      "isDeleted": {
        "type": "boolean"
      }
  }
  
