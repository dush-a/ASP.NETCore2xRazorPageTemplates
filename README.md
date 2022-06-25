# ASP.NET Core 2x Razor Pages Starter Templates

In this solution there are two ASP.NET Core Razor Pages starter web application projects. The target framework is ASP.NET core 2.x

Also, It uses the default bootstrap framework for UI.

These templates are created using Default Visual Studio ASP.NET Core Razor pages web template with individual user authentication and then modified with more commonly used web site features

## Additional Features included in this template:

### Scroll to top Button
Added necessary Razor syntax, JavaScript and CSS code to show scroll up to top button at the bottom left corner of the page. This can be adjusted by CSS.

### Navbar Shrink on Scroll down
NavBar shrinks when the user scroll down the page.

### Use Page Model property values and system values
Shows how to use model variables, properties, and system variables in the Razor pages.  The demonstration can be found on the `About` page. for detailed information check the code behind page model.

### Use Font Awesom icons
Necessary code added to use font-awesome icons.

## Some Bootstrap Features Used In This Template

### Sticky Navigation Bar
The navigation bar is visible always at the top of the page.

Project RazorPages.Core21 and Project RazorPages.Core22 use two different Bootstrap versions.   

# ---------------------------------------------------------------

## Project RP.Core22

This is the base project template for ASP.NET Core 2.2 Razor Pages Web Application.

The template extends the existing Visual Studio ASP.NET Core Razor pages web template project with most helpful features to build a professional web site.

This template has no user Authentication.

### Additional features included in this template:

This project also demonstrates how to add commonly used custom UI features in the Visual Studio 2017 Community edition.

But this template does NOT demonstrates how to add custom user data to a generated project in the Visual Studio 2017 Community edition. Please check the other template that comes with user authentication enabled. And it will show the practices used to meet some of the GDPR requirements added custom user data, i.e. user can delete own user data entered any time.

#### Navbar height change on Scroll
##### Navbar shrink and expand

NavBar shrinks when the user scrolls down the page. If the user scrolls up to the top, or uses the scroll up button, it will expand back.

#### Show Page Model property values

Demonstrate how to display model property and system values.
Shows how to use model variables, properties, and system variables in the Razor pages. The demonstration can be found in the About Page.


### The following Frameworks and versions are used:
<ul>
  <li>ASP.NET Core 2.2</li>
  <li>UI Framework - bootstrap 4.3.1.</li>
  <li>Icons - font-awesome 5.1.1</li>
</ul>

### Some Bootstrap 4.3 Features Used In This Template


#### Sticky Navigation Bar
The navigation bar is visible always at the top of the page.

#### Bootstrap Carousel
The bootstrap carousel was originally NOT included with the ASP.NET Core 2.2 Web template. Added the carousel as an additional feature. So it can be edited as  nessary.

#### Equal Height Cards

Demonstrates the use of equal height cards for content boxes. This is done by using Bootstrap <i>Cards</i> feature. 

## Project RazorPages.Core21:
Uses the following Frameworks and versions
<ul>
  <li>ASP.NET Core 2.1</li>
  <li>UI Framework - bootstrap 3.4.1.</li>
  <li>Icons - font-awesome 5.10.1</li>
</ul>

### Some Bootstrap 3.4 Features Used In This Template

#### Sticky Navigation Bar
The navigation bar is visible always at the top of the page.

#### Bootstrap Carousel
The bootstrap carousel was oroginally available with the ASP.NET core 2.1 templates.

#### Equal Height Panels
As in this part, equal height panles can easily add using Bootstrap <i>Panel</i> feature.

## Project RazorPages.Core22

The following Frameworks and versions are used:
<ul>
  <li>ASP.NET Core 2.2</li>
  <li>UI Framework - bootstrap 4.3.1.</li>
  <li>Icons - font-awesome 5.10.1</li>
</ul>

### Some Bootstrap 4.3 Features Used In This Template


#### Sticky Navigation Bar
The navigation bar is visible always at the top of the page.

#### Bootstrap Carousel
The bootstrap carousel was originally NOT included with the ASP.NET Core 2.2 Web template. Added the carousel as an additional feature. So it can be edited as  nessary.

#### Equal Height Cards

Demonstrates the use of equal height cards for content boxes. This is done by using Bootstrap <i>Cards</i> feature. 

And more features to come ..

# How to use this template:

Fork or create a branch or download the code to your computer and open using any version of Visual Studio 2017. I used Visual Studio 2017 Community Edition.

Then, to suit your requirement, change the namespaces in the entire solution using "Find and replace" (Ctrl +H).

You may also need to change the http, and https port numbers for the project. You can change it directly in the "lanchSetting.json" file. Or just delete this file, and re-compile. Visual Studio will re-create the file with the correct settings.

