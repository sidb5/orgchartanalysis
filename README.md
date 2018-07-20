

This program is based on REST, .NET WebApi, and architecting for testability.  
The solution is setup with a Web, DataAccess, and Test project. There is data for an organization chart prepoulated in collections in the DataAccess library. 
1. A RESTful call is implemented in the UserController that returns a specified user by their Id. The returned object is JSON. 
2. Another RESTful call is also implemented in the UserController that returns an org chart reporting up to a specified user by Id. For example, the the data output will be in following way.The response is in JSON
3. A call is also implemented in the UserController that returns how deep the org chart is, with CEO being level 0.
4. A combination of unit tests and integration tests are also implemented.

Overview
	-For methods in the UserController
		-All my methods return Json. In real line of business apps this design choice is dictated by the business needs and the user 
		 audience for the API. 
		-I have used WebApi2's AttributeRouting feature instead of conventional route registration.
		-I used IHttpActionResult as the return type of choice due to its simplicity and convenience during testing.
		-I have added a class to extend the JsonFormatter to return Json for requests with for text/html media type header (from browser).
		-I have also added support for OWIN ensuring that these WebAPI can be hosted outside IIS as well
			-This allows for looser coupling with IIS
			-This also allows me to write integration test cases that can be executed on demand without webserver setup. (Alternative to in-memory HttpServer)
			-I have ensured that the default mode of operation is still IIS.
	-I have also created a few Model classes for use in generating the exact Json structure per specifications.
		-Though this could have been done through decoration attributes on the business objects, that wouldnt be an appropriate design choice
			-The reason is that it would compromise the independence of data access layer from requirements on persentation layer. 
	-I have added a set of access methods in DataAccess classes to serve the data required to fulfill the requirements. 
	-Business logic of data parsing and transformation has been done in the DataAccess classes to keep the WebAPI layer light weight
	-For more effective design, had this application grown, I would create a custom BaseApiController class encapsulating common functionality.
		-All controllers can derive from this base ApiController.
	-For tree traversal,I have used a mix of LINQ queries and recursion.
		-I recognize that in production code when we are working with large databases, recursion may not be prudent.
			-This is because of possibility of stack over flow exception issue.
			-However,in production applications such data resides in the database.
				-In such scenarios, we would leverage the DB capacity by using CTE operations on the DB side (perhaps through a stored proc). (This is an ideal candidate for async)
	-To ensure quality through CI, I have created 25 automated test procedures 
		-7 are integration tests that are run by launching a HTTP server and querying the server using WebAPI calls.
		-18 are unit test cases exercising the Controller layer and the data access layer. Though Mocks seems overkill for an app with static in-memory data, I have included
		 an example of its usage since Mocks are very useful in real world scenarios.
		-These cases cover the range of valid and invalid scenarios to ensure graceful functionality in all scenarios
	-For the purpose of this program I have chosen to use synchronous controller and ActionMethods since this is a CPU leaning exercise. In real world scenario, 
		with DB/third party API etc. operations, I would have used WebApi's Async features to increase capacity of high traffic API. I would also leverage C#'s async support
		(async-await) to propagate asynchrony through the application layers right down to the DB/API operations. Async over sync methods offer no benefits for WebApi.
	-In a real world situation we would have various cross-cutting concerns such as authentication and authorization, caching, logging, exception handling etc. There
		are different design choices available and I would try to leverage Asp.Net WebApi's out of box offerings along with custom Attributes and Filters where required.
		Also we would be leveraging several design patterns (factory, Repository, Decorator, Singleton etc.)
	-Dependency Inversion and IOC containers are another key aspect of production ready code. Although not mandatory, its really powerful in enabling structuring of
		loosely coupled code. Unit and Integration testing can be done with minimum dependencies. Exposing the dependencies of a class via its constructor improves 
		readability and maintainability.



	



