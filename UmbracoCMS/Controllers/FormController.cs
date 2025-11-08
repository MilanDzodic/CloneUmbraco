using UmbracoCMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoCMS.Services;

namespace UmbracoCMS.Controllers
{
  public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionsService formSubmissions) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
  {
    private readonly FormSubmissionsService _formSubmissions = formSubmissions;

    public IActionResult HandleCallbackForm(CallbackFormViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return CurrentUmbracoPage();
      }

      var result = _formSubmissions.SaveCallbackRequest(model);

      if (!result)
      {
        TempData["FormError"] = "Something went wrong while submitting your request. Please try again.";
        return RedirectToCurrentUmbracoPage();
      }

      TempData["FormSuccess"] = "Your request has been recieved and we will get back to you relatively soon.";
      return RedirectToCurrentUmbracoPage();
    }
  }
}
