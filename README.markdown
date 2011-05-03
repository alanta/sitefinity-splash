#Splash page control for Sitefinity

Show a splash page to give special attention to a campaign or product when a user first visits a website.

The splash control is placed on the home page or a landing page and will automatically redirect to a splash page. The splash page is shown only once to each user. 
The control allows you to configure the date to to start showing the splash page, when to stop and the page to use as the splash page.

## How does it work?
The splash control uses basic HTTP redirect to present the user with the splash page on the first visit. A cookie is set to mark that user has seen the splash page. On the next visit the splash page is not shown if the cookie is found.

## How do I set it up?

Upload or copy the `splash.ascx` and `splash.ascx.cs` files into your website. The /UserControls folder is a good place to store these kinds of controls.

### Setup in Sitefinity 3.7
If you're manually adding the control to your site (i.e. not by uploading through Sitefinity) you need to add a line to your web.config file to enable the control. 
Locate the `<toolboxControls>` section and add this line:

    <add name="Splash" section="Navigation" url="~/UserControls/Company/Splash.ascx" 
      description="Redirects to a splash page on first visit."/>
      
### Setup in Sitefinity 4.x
Setting up custom controls is a bit tedious in Sitefinity 4.x. The full procedure is described in the [developer guide](http://www.sitefinity.com/40/help/developers-guide/sitefinity-essentials-controls-adding-controls-to-the-toolbox.html). This is the short version:

1. Log in to Sitefinity backend.
1. In the main menu in the upper part of the screen, click Administration » Settings.
1. Go to the Advanced settings by clicking the *Advanced* link.
1. In the treeview on the left, click Toolboxes » Toolboxes » PageControls » Sections » NavigationControlsSection » Tools.
1. Click Create New.
1. In the ControlType field, enter *~/UserControls/Splash.ascx*.
1. In the Name field, enter *Splash*.
1. In the Title field, enter *Splash*.
1. In the Description field, enter something descriptive like *Redirects to a splash page on first visit.*.
1. Click Save changes.

![Sitefinity 4 control registration](https://github.com/alanta/sitefinity-splash/wiki/images/sf4-create-control2.png)  

Now you are ready to drop the Splash control into a page.

## How do I use it?

1. Create a splash page. This can be any page.  
   You probably don't want this page to show up in your navigation controls so set *Show in navigation?* to *no*.
2. Drop the splash control into the page that the user normally browses to. This could be the home page or a landing page.  
   It does not matter where the control is on the page.
3. Configure the splash control  
   _In Sitefinity 3.7:_  
   ![Configuration dialog](https://github.com/alanta/sitefinity-splash/wiki/images/configure.png)  
   Click the `(?)` next to each setting for more information on that particular setting.
   
   _In Sitefinity 4.x:_  
   ![Configuration dialog](https://github.com/alanta/sitefinity-splash/wiki/images/sf4-configure.png)    
   Unfortunatly the default control designer is a bit cumbersome in SF4. Select the right hand icon under the Edit title to get a bit more structured view of the control properties.