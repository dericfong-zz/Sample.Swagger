using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Swagger.Swagger
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// Example to add header
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "test-api-key",
                In = "header",
                Type = "string",
                Required = true
            });
            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Accept-Language",
                In = "header",
                Type = "string",
                Required = false,
                Default = "en-US"
            });
        }
    }
}
