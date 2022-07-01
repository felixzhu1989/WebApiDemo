var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//最小Api实现文件上传
app.MapPost("/Upload", async (HttpRequest httpRequest) =>
 {
     var file = httpRequest.Form.Files.FirstOrDefault();
     if (file != null)
     {
        //await using FileStream fs = new($"{AppContext.BaseDirectory}{file.FileName}", FileMode.Create);
        await using FileStream fs = System.IO.File.Create($"{AppContext.BaseDirectory}{file.FileName}");
         await file.CopyToAsync(fs);
     }
 });
app.Run();
