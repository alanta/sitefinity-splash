#Splash page control for Sitefinity

Show a splash page to give special attention to a campaign or product when a user first visits a website.

The splash control is placed on the home page or a landing page and will automatically redirect to a splash page. The splash page is shown only once to each user. 
The control allows you to configure the date to to start showing the splash page, when to stop and the page to use as the splash page.

## How does it work?
The splash control uses basic HTTP redirect to present the user with the splash page on the first visit. A cookie is set to mark that user has seen the splash page. On the next visit the splash page is not shown if the cookie is found.

## How do I set it up?

Upload or copy the `splash.ascx` and `splash.ascx.cs` files into your website. The /UserControls folder is a good place to store these kinds of controls.

### Manual setup
If you're manually adding the control to your site (i.e. not by uploading through Sitefinity) you need to add a line to your web.config file to enable the control. 
Locate the `<toolboxControls>` section and add this line:

    <add name="Splash" section="Navigation" url="~/UserControls/Company/Splash.ascx" 
      description="Redirects to a splash page on first visit.">

## How do I use it?

1. Create a splash page, this can be any page.  
   You probably don't want this page to show up in your navigation controls so set *Show in navigation?* to *no*.
2. Drop the splash control into the page that the user normally browses to. This could be the home page or a landing page.  
   It does not matter where the control is on the page, it will do it's magic before anything is actually shown on the page.
3. Configure the splash control  
   ![Configuration dialog](https://github.com/alanta/sitefinity-splash/wiki/images/configure.png)  
   Click the `(?)` next to each setting for more information on that particular setting.