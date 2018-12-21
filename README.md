# SauceNET
Simple Visual Studio wrapper for the SauceNao API


### Tutorial
```cs
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
            string source = sauce.Results[0].SourceURLs[0];
        }
```

#### SauceNao
You can find your api key here: https://saucenao.com/user.php?page=search-api

### To-do
- Named databases
- Presentable result properties
