using System;
using System.Web.Mvc;
using MvcFlash.Core;
using RestfulRouting.Format;

namespace SearchableZoo.Controllers
{
    public abstract class ApplicationController : Controller
    {
        protected virtual IFlashPusher Flash
        {
            get { return MvcFlash.Core.Flash.Instance; }
        }

        protected ActionResult RespondTo(Action<FormatCollection> format)
        {
            return new FormatResult(format);
        }
    }
}