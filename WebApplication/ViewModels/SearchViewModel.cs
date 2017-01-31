using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication.ViewModels
{
    public class SearchViewModel
    {
        public string SelectedEmail { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
}