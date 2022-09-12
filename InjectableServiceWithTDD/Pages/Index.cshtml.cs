using InjectableServiceWithTDD.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjectableServiceWithTDD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ISplit Split;
        public bool IsActive;

        public IndexModel(ILogger<IndexModel> logger, ISplit split)
        {
            _logger = logger;
            Split = split;
        }

        public void OnGet()
        {
            var result = Split.SDK.GetTreatment("AFUser1", "AF_Cache_Service");

            if (result == "on")
            {
                IsActive = true;
            }
            else if (result == "off")
            {
                IsActive = false;

            }
        }
    }
}
