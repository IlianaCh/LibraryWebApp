## Project Description
App Link:[Library Web App](https://librarywebappcosc3380.azurewebsites.net)

The library lends books, audio, and movies. These items can be loaned to students, faculty, and library staff. These items all have similar attributes but also have distinguishable attributes.The database will store students and faculty’s userID, email, first and last name and total fees due. It will also store information about the different items (such as Title, Author, Publisher, Equipment description, etc.). The database will keep track of the checkout record for every user for limit tracking purposes, amount of times items have been borrowed, and whether the user has reached the limit of amount owed. All relationships will run through this checkout record as it is an efficient way to store who purchased what and the fees they've accumulated or paid off.

## File Description
Data Entry Form:
The admin and staff have the ability to modify the database, they can edit the Browse Catalog, Checkout, and Fees Pages. On the Browse Catalog page, the users can change objects, object_type, object_title, object_author, object_medium, object_genre, and object_length. On the fee pages user_id, transaction_id, create_date, total_fee, remaining_fee, is_paid. On the Checkout Record, they can modify the username, the checkout date and the item being checked out.

Create
When the user submits the form, the controller receives the data. A new instance of the SqlCommand class is created with an SQL INSERT query, and the user-provided data is used to populate the query.
Modify
The Edit action retrieves the existing object from the database, modifies its properties, and then uses db.Entry(objects).State = EntityState.Modified to mark it as modified. The changes are then saved to the Azure SQL Database using db.SaveChanges().
Delete
When a user initiates a delete action, the controller receives a request to delete a particular record.



## User Roles

Student, Faculty, Staff, Admin

## Triggers

## Reports

Reports are accessed via admin login (user: admin password: pass) 

View Total Books Purchased: A cumulative view of data pulled from the checkout records table, and the books table. This will display all necessary information on the checkout of the book and the data of the book itself. Along with that you can view the exact total of the books purchased at the bottom within the date range that you set manually.

View Total Fees Accumulated: A cumulative view of data pulled from the checkout records, fees, and users tables respectively. This will display all necessary information on the fees, the date it was created and the user it is attached to. Along with that you can view the summation of the fees that have been accumulated within the date range you set manually.

View Total Movies Purchased: A cumulative view of data pulled from the checkout records table, and the movies table. This will display all necessary information on the checkout of the movies and the data of the book itself. Along with that you can view the exact total of the movies purchased at the bottom within the date range that you set manually.

## Running the App

## Authors
- Iliana Chevez - [ilianaCh](https://github.com/IlianaCh)
- Sergio Rivera - [TheSergeon](https://github.com/TheSergeon)
- Ivy Doan - [Huynh07](https://github.com/Huynh07)
- Zachary Pierce - [Zacharypierce25](https://github.com/Zacharypierce25)
- Kamui Morita-Albright - [kamui-moritaalbright](https://github.com/kamui-moritaalbright)
- Jennifer Figueroa - [JenniferFigueroa628](https://github.com/JenniferFigueroa628)
