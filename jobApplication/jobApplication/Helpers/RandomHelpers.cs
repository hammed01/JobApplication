using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobApplication.Helpers
{
    public static class RandomHelpers
    {
        public static string GenerateApplicantId()
        {
            Guid randomId = Guid.NewGuid();
            return randomId.ToString().Replace("-", "").Substring(0, 6).ToUpper();

        }
    }
}