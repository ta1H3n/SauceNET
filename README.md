# SauceNET
Asynchronous C# wrapper for [SauceNAO](https://saucenao.com/) API


## Usage
```cs
using SauceNET;
...

static async Task ClientTest()
        {
            //Enter your SauceNao API key. Optional, leave empty otherwise.
            string apiKey = "";

            //Create your SauceNET client
            var client = new SauceNETClient(apiKey);

            //Enter your image url.
            string image = "https://i.imgur.com/WRCuQAG.jpg";

            //Get the sauce
            var sauce = await client.GetSauceAsync(image);

            //Top result source url, if any.
            string source = sauce.Results[0].SourceURL;
        }
```

### SauceNao
You can find your api key [here.](https://saucenao.com/user.php?page=search-api)

## Installation
Install as a [NuGet package](https://www.nuget.org/packages/SauceNET)

```powershell
Install-Package SauceNET
```

## To-do
- More presentable result properties
