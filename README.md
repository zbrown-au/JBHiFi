# JBHiFi

To test, build and run application:

The application should be displayed with a list of Products.


Use fiddler (or similar) to test API:
  - May need to change port number
  - Refresh application home page after each call to see the results

-----------
Get Products
-----------
GET http://localhost:54223/api/products/get

User-Agent: Fiddler
Host: localhost:54223

----------
Get Product
----------
GET http://localhost:54223/api/products/get/1

User-Agent: Fiddler
Host: localhost:54223

----------
Add Product
----------
POST http://localhost:54223/api/products/post

User-Agent: Fiddler
Host: localhost:54223
Content-Type: application/json

Request Body:
{"Brand":"Samsung","Description":"TV", "Model":"8100"}

----------
Update Product
----------
PUT http://localhost:54223/api/products/put/1

User-Agent: Fiddler
Host: localhost:54223
Content-Type: application/json

Request Body:
{"Brand":"Sony","Description":"TV", "Model":"Bravia"}

-----------
Delete Product
-----------
DELETE http://localhost:54223/api/products/delete/1

User-Agent: Fiddler
Host: localhost:54223