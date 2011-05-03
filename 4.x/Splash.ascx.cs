using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web;
using System.Web.UI;

public partial class Splash : UserControl
{
   public Splash()
   {
      CookieName = "Splash";
      StopDateTime = DateTime.Today.AddDays( 1 );
      StartDateTime = DateTime.Today;
      CookieExpiration = "Once";
   }

   /* Note : the attributes below are not currently supported in Sitefinity 4. */

   [Category("Basic settings")]
   [DisplayName("Stop date")]
   [Description("The date and time to stop showing the splash screen.")]
   [Editor( "System.ComponentModel.Design.DateTimeEditor", "System.Drawing.Design.UITypeEditor" )]
   public DateTime StopDateTime { get; set; }

   [Category( "Basic settings" )]
   [DisplayName( "Start date" )]
   [Description( "The date and time to start showing the splash screen." )]
   [Editor( "System.ComponentModel.Design.DateTimeEditor", "System.Drawing.Design.UITypeEditor" )]
   public DateTime StartDateTime { get; set; }

   [Category( "Basic settings" )]
   [DisplayName("Splash page")]
   [Description( "The URL of the splash page." )]
   [DefaultValue( "" ), Editor( "System.Web.UI.Design.UrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof( UITypeEditor ) ), UrlProperty]
   public string SplashPageUrl { get; set; }

   [Category( "Advanced settings" )]
   [DisplayName( "Show splash" )]
   [Description( "'Session' or 'Once' (without quotes)." )]
   public string CookieExpiration { get; set; }
   
   [Category( "Advanced settings" )]
   [DisplayName( "Cookie name" )]
   [Description( "Pick a unique cookie name for each splash screen." )]
   public string CookieName { get; set; }

   protected override void OnLoad( EventArgs e )
   {
      base.OnLoad( e );
      if ( string.IsNullOrEmpty( SplashPageUrl ) )
      {
         return;
      }
      
      if( this.IsDesignMode() || this.IsPreviewMode() )
      {
         return;
      }
      
      if( !IsPostBack && DateTime.Now <= StopDateTime && DateTime.Now > StartDateTime )
      {
         var cookie = Request.Cookies.Get( CookieName ?? "Splash" );
         if ( null == cookie || string.IsNullOrEmpty( cookie.Value ) )
         {
            var setCookie = new HttpCookie( CookieName ?? "Splash", DateTime.UtcNow.ToString( "yyyy/MM/dd hh:mm:ss" ) );
            if ( string.Equals( CookieExpiration, "Session" ) )
            {
               // nothing to do, this is default behaviour
            }
            else if ( string.Equals( CookieExpiration, "Once" ) )
            {
               setCookie.Expires = StopDateTime;
            }
            Response.Cookies.Set( setCookie );
            Response.Redirect( ResolveClientUrl( SplashPageUrl ) );
         }
      }
   }

   protected override void Render( HtmlTextWriter writer )
   {
      return; // do not render any content
   }
}