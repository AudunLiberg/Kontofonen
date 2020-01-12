using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag;
using NSwag.CodeGeneration.TypeScript;
using NSwag.Generation.WebApi;

namespace Kontofonen.TypeScript.TypeGenerator
{
    public class Program
    {
        private static void Main()
        {
            const string outputPath = "Kontofonen.Web/Client/types/";
            var fullOutputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../", outputPath));
            Directory.CreateDirectory(fullOutputPath);
            Console.WriteLine("Generating TypeScript types");
            var generatedCode = GenerateTypeScript();
            generatedCode.Wait();

            File.WriteAllText(fullOutputPath + "types.ts", generatedCode.Result);
            Console.WriteLine($"TypeScript types generated in {fullOutputPath}");
        }

        private static async Task<string> GenerateTypeScript()
        {
            var settings = new TypeScriptClientGeneratorSettings
            {
                GenerateClientClasses = false,
                Template = TypeScriptTemplate.Fetch,
                ImportRequiredTypes = false,
                TypeScriptGeneratorSettings =
                {
                    TypeScriptVersion = 3.0m,
                    TypeStyle = TypeScriptTypeStyle.Interface,
                    DateTimeType = TypeScriptDateTimeType.String,
                    NullValue = TypeScriptNullValue.Null,
                    MarkOptionalProperties = false,
                }
            };

            var document = await GenerateSwaggerDocument();
            var generator = new TypeScriptClientGenerator(document, settings);
            return generator.GenerateFile();
        }

        private static async Task<OpenApiDocument> GenerateSwaggerDocument()
        {
            var generator = new WebApiOpenApiDocumentGenerator(new WebApiOpenApiDocumentGeneratorSettings());
            var assembly = Assembly.GetAssembly(typeof(Web.Program));
            var controllers = WebApiOpenApiDocumentGenerator.GetControllerClasses(assembly);
            return await generator.GenerateForControllersAsync(controllers);
        }
    }
}