using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Commons.PipelineBehaviors.Caching
{
    public static class CreateKey
    {
        public static string ReplacePlaceholders(string template, object request)
        {
            var properties = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var placeholder = $"{{{property.Name}}}";
                if (template.Contains(placeholder))
                {
                    var value = property.GetValue(request)?.ToString();
                    template = template.Replace(placeholder, value);
                }
            }

            return template;
        }
    }
}
