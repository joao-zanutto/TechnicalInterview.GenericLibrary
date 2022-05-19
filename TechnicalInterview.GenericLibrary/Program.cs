using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TechnicalInterview.GenericLibrary.Services;
using TechnicalInterview.GenericLibrary.Models;
using System.Collections.Generic;

WebHost.CreateDefaultBuilder().Configure(app =>
{
    app.UseRouting();
    app.UseEndpoints(e =>
    {
        e.MapGet("/api/DocumentValidator/", async c =>
        {
            DocumentInput doc = await c.Request.ReadFromJsonAsync<DocumentInput>();
            DocumentType documentType = new DocumentValidator().AutoSelector(doc.DocumentTypeInput);
            List<DocumentInput> list = new List<DocumentInput>();
            list.Add(new DocumentInput() { DocumentTypeInput = documentType.ToString() });
            await c.Response.WriteAsJsonAsync(list);
        });

    });
}).Build().Run();