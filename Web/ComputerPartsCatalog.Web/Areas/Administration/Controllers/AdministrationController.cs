namespace ComputerPartsCatalog.Web.Areas.Administration.Controllers
{
    using ComputerPartsCatalog.Common;
    using ComputerPartsCatalog.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
