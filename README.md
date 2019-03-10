# ShoppingOL
ShoppingOL is an online shopping application built by ASP.Net Core 2.1 and Angular + Bootstrap.
# Features

* Front-end & Back-end Fully Seperated.
* Orders Management & Shopping Cart & Admin Identity 
* Front-end framework: Angular 7 ; Back-end: Asp.NET Core 2.1 MVC

# Front-end Structure:
```
● src
+---● app
|   +--● checkout
|   |  |--checkout.component.ts|.html|.css
|   |  +--● payment-detail
|   |  |  |--payment-detail.component.ts|.html|.css
|   |  |
|   |  +--● login
|   |  |  |--login.component.ts|.html
|   |  |
|   |  +--● shared
|   |     |--dataService.ts
|   |     |--order.ts
|   |     |--product
|   |  +--● Shop
|   |     |--cart.component.ts|.html
|   |     |--ProductList.component.ts|.html
|   |     |--Shop.component.ts|.html
|   |--app.module.ts
|   |--app.component.ts|.html
```
# Back-end Structure
```
● CardRegisterApp.API
+---● Controllers
|   +--● AppController.cs
|   +--● OrderItemsController.cs
|   +--● OrdersController.cs
|   +--● ProductsController.cs
+---● Data
|   +--● Entities
|   |  +--● Order.cs
|   |  +--● OrderItem.cs
|   |  +--● Product.cs
|   |  +--● StoreUser.cs
|   +--● CustomDBContext.cs
|   +--● IShoppingRepository.cs
|   +--● ShoppingRepository.cs
|   +--● MappingProfile.cs
|   +--● ShoppingolSeeder.cs
+---● Services
|   +--● IMailService.cs
|   +--● NullMailService.cs
+---● Migrations //EF core migration files
+---● ViewModels
|   +--● ContactViewModel.cs
|   +--● LoginViewModel.cs
|   +--● OrderItemViewModel.cs
|   +--● OrderViewModel.cs
+---● Views
|   +--● App
|   |  +--● About.cshtml
|   |  +--● Contact.cshtml
|   |  +--● Index.cshtml
|   |  +--● Shop.cshtml
|   +--● Shared
|   |  +--● _Layout.cshtml
|   +--● _ViewImports.csthml
|   +--● _ViewStart.csthml
+---● package.json
+---● appsettings.json
+---● Program.cs
+---● Startup.cs
```
# Demo
![demo](/ShoppingOL_ScreenShot.jpg)
