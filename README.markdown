#Splash screen control for Sitefinity

Drop this control into a page to enable splash screens on a Sitefinity website.
This control will redirect all visitors to an alternate page on their first visit to the site.

## Setup

Upload or copy the `splash.ascx` and `splash.ascx.cs` files into your website. The /UserControls folder is a good place to store these kinds of controls.

### Manual setup
If you're manually adding the control to your site (i.e. not by uploading it through Sitefinity) you need to add a line to your web.config file to enable the control. 
Locate the `<toolboxControls>` section and add this line:

    <add name="Splash" section="Navigation" url="~/UserControls/Company/Splash.ascx" description="Redirects to a splash page on first visit.">

## Using the control

1. Create the splash page
2. Drop the splash control into the page that the user normally browses to. Usually the home page.  
   It does not matter where the control is on the page.
3. Configure the splash control  
   ![Configuration dialog](http://www.alanta.nl/img/github-splash/configure.png)  
   Click the `(?)` next to each setting for more information on that particular setting.