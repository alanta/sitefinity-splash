using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Cms.Web.UI;

public partial class Splash : UserControl
{
   public Splash()
   {
      CookieName = "Splash";
      StopDateTime = DateTime.Today.AddDays( 1 );
      StartDateTime = DateTime.Today;
      CookieExpiration = "Once";
   }

   [DisplayName("Stop date")]
   [Description("The date and time to stop showing the splash screen.")]
   public DateTime StopDateTime { get; set; }

   [DisplayName( "Start date" )]
   [Description( "The date and time to start showing the splash screen." )]
   public DateTime StartDateTime { get; set; }

   [DisplayName("Show splash")]
   [Description("'Session' or 'Once' (without quotes).")]
   public string CookieExpiration { get; set; }

   [DisplayName("Splash page")]
   [Description( "The URL of the splash page." )]
   [WebEditor( "Telerik.Cms.Web.UI.UrlEditorWrapper, Telerik.Cms" )]
   public string SplashPageUrl { get; set; }

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

      if( Request.Params.Keys.Cast<string>().Contains( "cmspagemode", StringComparer.OrdinalIgnoreCase ))
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
               // nothing to do
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