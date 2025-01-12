&#xa0;

<h1 align="center">Candy Shop</h1>

<p align="center">

<img alt="GitHub Top Language Badge" src="https://img.shields.io/github/languages/top/wilsonsouto/candy-shop?&color=56BEB8"/>

<img alt="GitHub Language Count Badge" src="https://img.shields.io/github/languages/count/wilsonsouto/candy-shop?&color=56BEB8"/>

<img alt="GitHub Repository Size Badge" src="https://img.shields.io/github/repo-size/wilsonsouto/candy-shop?&color=56BEB8"/>

<img alt="Github License Badge" src="https://img.shields.io/github/license/wilsonsouto/candy-shop?color=56BEB8">

</p>

<p align="center">
  <a href="#dart-about">About</a> &#xa0; | &#xa0; 
  <a href="#sparkles-features">Features</a> &#xa0; | &#xa0;
  <a href="#rocket-technologies">Technologies</a> &#xa0; | &#xa0;
  <a href="#white_check_mark-requirements">Requirements</a> &#xa0; | &#xa0;
  <a href="#checkered_flag-starting">Starting</a> &#xa0; | &#xa0;
  <a href="#memo-license">License</a> &#xa0; | &#xa0;
  <a href="https://github.com/wilsonsouto" target="_blank">Author</a>
</p>

<br>

## :dart: About

Candy Shop is a console-based inventory management application designed to streamline the management of a candy store's product inventory. It interacts directly with a database to allow users to add, retrieve, update, and delete product information. Featuring a clean, interactive console interface and robust input validation, the application simplifies inventory management while ensuring data accuracy.

## :sparkles: Features

:heavy_check_mark: **ViewProductsList**: Display all products in a formatted table;\
:heavy_check_mark: **ViewSingleProduct**: Show detailed info for a selected product;\
:heavy_check_mark: **AddProduct**: Add new Chocolate Bars or Lollipops with input validation;\
:heavy_check_mark: **DeleteProduct**: Remove products from the inventory;\
:heavy_check_mark: **UpdateProduct**: Modify product details selectively;\
:heavy_check_mark: **QuitProgram**: Exit the application;\
:heavy_check_mark: **Unit Tests**: Includes tests to ensure reliable input handling;

## :rocket: Technologies

The following tools were used in this project:

- .NET 8.0
- C#
- MySQL
- Spectre Console

## :white_check_mark: Requirements

Before starting :checkered_flag:, you need to have [Git](https://git-scm.com) and [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed.

## :checkered_flag: Starting

```bash
# Clone this project
$ git clone https://github.com/wilsonsouto/candy-shop

# Access
$ cd candy-shop/CandyShop

# Set up the database connection, edit the .env file with your MySQL credentials
DB_HOST=localhost
DB_NAME=CandyShop
DB_USER=root
DB_PASSWORD=1234
DB_PORT=3306

# Run the project
$ dotnet run

# The application will initialize in the console
```

## :memo: License

This project is under license from MIT. For more details, see the [LICENSE](LICENSE) file.

Made with :heart: by <a href="https://github.com/wilsonsouto" target="_blank">wilsonsouto</a>

&#xa0;

<a href="#top">Back to top</a>
