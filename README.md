# Lightyear Software Company

Lightyear is a fictional enterprise software company. In this project, a website has been developed for this software company. Before it was developed, the websites of many different software companies were examined and the necessary sections were determined. If we think of the whole project as a system, this system has 2 ends: the main panel that users see, and the admin panel that admins have access to. Users can access and interact with the About, Team, Services, Carrier, Blog, and Contact pages on the main panel. In the Admin Panel, the pages in the Main Panel are controlled and edited. Through these controls, direct communication with the database is established.

## Technologies

This website was created by using Model-View-Controller, a.k.a MVC, architectural pattern. The backend of the project was developed using the ASP.NET framework. Entity Framework, an ORM tool, was used on the database side, and properties (DbContext and Classes) were created with the Code First method. MSSQL was used as database management system. Technologies and libraries such as HTML, CSS, Bootstrap, Javascript and JQuery were used on the frontend of the project.

## Database
I do both the data shown to the users on the frontend of my project and the operations done on the backend through a diagram in the database. As you can see below, some of my tables are independent and single tables, while some of my tables are connected by a One-to-Many structure. The job postings we show in the Carrier Section each have a category, and this structure is formed by connecting two different tables (Carrier and CarrierCategory). The same is true for the Blog Section (Blog and Blog Category).

![1](https://user-images.githubusercontent.com/57845882/179307555-fd1a396d-fbb9-49f4-93ef-3fad92b45221.png)

## Main Panel
There are 7 pages in main panel that users can access: Home, About, Team, Services, Carrier, Blog, and Contact. 

### Home Page
The homepage has 3 basic elements: Navigation Bar, Body, and Footer. There are buttons in the Navigation Bar that allow us to access sections on the website. In the Body section, there will be a slider where general information about the company and website will be given to users and/or they can see the latest news and updates. In the Footer section, there will be shortcuts for accessing some parts of the site, the company's social media accounts and contact information. This footer will not only be on the home page but also on all other pages.

![1](https://user-images.githubusercontent.com/57845882/179311785-b1edf2cb-5a99-46b3-8a00-698d02a11d6c.png)
![2](https://user-images.githubusercontent.com/57845882/179311790-5ca97e08-df21-4bed-8679-42b76e0a7fa1.png)
![3](https://user-images.githubusercontent.com/57845882/179311791-97d408d6-721d-4d12-9ee3-667534da9298.png)

### About Page
In the About section, there will be general information about the identity, history, works and achievements of the company. There are also some static parts such as numbers about company and testimonials.

![4](https://user-images.githubusercontent.com/57845882/179312025-8bedc786-082e-48c1-bcfe-c50fe5bfd450.png)
![5](https://user-images.githubusercontent.com/57845882/179312029-6869647e-797c-4b27-aa76-18fc5b2d0902.png)

### Team Page
Team section with important personalities in our company. It is the section where the people at the head of the departments are specified. It has a static structure.

![6](https://user-images.githubusercontent.com/57845882/179312129-010d7fde-d62e-43dc-94d4-7fbfe6777658.png)

### Services Page
In the Services section, you can look at the services offered by the company and the products it has developed. I make this section in the form of a gallery
by using the card structure in bootstrap. Each service/product will be written on a card and users can access detailed information. There is also a pricing section which is a static structure.

![7](https://user-images.githubusercontent.com/57845882/179312138-c5e25fc7-80c6-4fa8-bd79-7564e204d701.png)
![8](https://user-images.githubusercontent.com/57845882/179312143-0657520e-975c-4562-8f4f-0b799a181f5e.png)

### Carrier Page
In this section, you can see the career opportunities and job postings offered by our company. It is coded in card and gallery structure. You can access detailed information about job postings by clicking on the cards. Job postings in gallery format can be viewed in order. Thanks to the buttons at the top of the page, job postings can be listed by category.

![9](https://user-images.githubusercontent.com/57845882/179312146-aaba586a-bf06-415b-8a1d-b95a3ad820c1.png)

### Blog Page
In the Blog section, you can access both world technology news and company news. You can read an update about a new product developed by the company, news about an agreement with another company, a blog post about a prominent technological development in the world. You can also comment on these created posts. Each post will have a detail page. You can filter these blog posts according to their category.

![10](https://user-images.githubusercontent.com/57845882/179312149-59eaec8e-2f64-458f-bc97-7701c14b87b9.png)

### Contact Page
On the Contact page, users will be able to access the company's address and contact information. I'm considering embedding an <iframe> I got from Google Maps. In this way, users will be able to see the company's location on the map. I am also planning to create a contact form using SMTP. Users will be able to convey their opinions, complaints and questions to the admins through this contact form.

![11](https://user-images.githubusercontent.com/57845882/179312150-306f3f85-1217-431b-b217-d2cdb87b9ee3.png)

## Admin Panel
Admin Panel is a panel that the administrators and editors of the site can access. They will access this panel by entering their own id and password to a login system. I plan to connect almost every data on the website to a database. Everything from the slider on the site to the cards and blog posts in the services section will be controlled through a database. Admins can do these controls thanks to this panel. They will be able to update and delete information on different pages and provide new data entry when necessary. For example, they can add a card about a newly developed product by the company to the services section, approve a user comment on a post in the blog section, and delete a job posting in the carrier section if that position is filled. I plan to perform authorization operations in this panel. For example, the parts that an admin and the editor can access and the changes they can make will not be the same. The editor's authority will be less than the admin's and will not be able to access the tabs accessed by the admins and will not be able to make the necessary arrangements in the database.

### Login Page of Admin Panel
![12](https://user-images.githubusercontent.com/57845882/179313089-c4071d53-135c-470e-8d07-127cf7cb5884.png)

### Dashboard
![13](https://user-images.githubusercontent.com/57845882/179313095-bb9e8642-3a51-4205-8029-584458d876c9.png)

### Identity and About Sections
![14](https://user-images.githubusercontent.com/57845882/179313098-7a3881ad-796b-47d7-9aab-2757e2a21eb9.png)
![15](https://user-images.githubusercontent.com/57845882/179313099-9d1613f0-6411-4387-84d3-9d218143cc1b.png)

### Contact Section
![16](https://user-images.githubusercontent.com/57845882/179313100-d85e88b6-204c-4cea-8de1-2f27f6993760.png)

### Slider (In the Home Page) Section 
![17](https://user-images.githubusercontent.com/57845882/179313101-6472a1c8-036d-4e3c-8e4f-c5b304395f83.png)

### Services Section
![18](https://user-images.githubusercontent.com/57845882/179313103-e463d18e-7ae4-4695-b4b1-7f7d50b52160.png)

### Blog Entries and Their Categories Sections
![19](https://user-images.githubusercontent.com/57845882/179313104-24e10e88-4844-414e-9025-e367bb4af45a.png)

### Carrier and Their Categories Sections
![20](https://user-images.githubusercontent.com/57845882/179313107-7a68733d-9f0d-4ae8-911c-b56b7a7d8a1f.png)

### Template of an Edit Page
All the Edit Pages in the Admin Panel use the same template. All of them have the same view. This is one of the examples.

![2](https://user-images.githubusercontent.com/57845882/179313943-f57f3d67-60ac-42fb-b93d-d96ea13d1ee2.png)

## Conclusion
This website that I have developed is almost fully functional. It is at a level to perform all the necessary main operations. There may be many new features to be added, such as security, optimization, additional functionality and controls. I will update this repository if I add them.
