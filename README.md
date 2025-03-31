1.- In order to Run the application you need to replace the connection string in appsettings.json to point  to your local environment.

Example : 

 "ConnectionStrings": {
   "Sql": "Server=.;Database=Curotec;Trusted_Connection=True;TrustServerCertificate=True"
 }

2.- Once you have youur connection string in place you need to update the database using the migrations.

Open Package anager Console.
Select Infrastructure\Curotec.Persistence as Default  project.

Execute update-database command.
![image](https://github.com/user-attachments/assets/0f1853e6-4ae5-4c13-a46b-071f3132f9a4)

Tis will be Creating the Database and corresponding  tables in your local Sql  Server Instance.
![image](https://github.com/user-attachments/assets/7dde0ad9-9160-4a25-826d-5851710ea75f)

The next Step is to run the application, a swagger page will be shown.

![image](https://github.com/user-attachments/assets/73526656-5790-4e8d-8aeb-7a371aa5bf1f)

In order to be authenticated in the API you should consume  /api/Users/authenticate endpoint 

![image](https://github.com/user-attachments/assets/76146145-b763-4d60-82fb-60e46a1ee877)
![image](https://github.com/user-attachments/assets/be73b882-e580-4501-ab6d-caca6bdcf0ca)

Copy the token value from response

![image](https://github.com/user-attachments/assets/15d5916c-12ef-4bea-9ae0-c8ef16de1ca1)

This value  will be usefull to authenticate the protected methods
![image](https://github.com/user-attachments/assets/fe9686c8-0e00-4b10-8725-e8c02ded5e7e)


![image](https://github.com/user-attachments/assets/6e82c259-a37b-4150-9990-8412bd350f30)

![image](https://github.com/user-attachments/assets/de72dcf4-5a9a-4d70-a2c6-e2bb8aa622f0)

I have immplemmented SOLID principles, Clean architecture, Mediatr, Repository PAttern , Unit of Work, Fluent Validation, JWT authentication.















