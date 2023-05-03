using Microsoft.SemanticKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Azure.Identity;
using SemanticKernelDemoApp.Models;
using SemanticKernelDemoApp.Classes;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(async (hostingContext, configuration) =>
    {
        #region Get Configuration
        configuration.Sources.Clear();

        IHostEnvironment env = hostingContext.HostingEnvironment;

        configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configurationRoot = configuration.Build();

        AzureOpenAIServiceOptions azureOpenAIServiceTextCompletionOptions = new();
        configurationRoot.GetSection(nameof(azureOpenAIServiceTextCompletionOptions))
                         .Bind(azureOpenAIServiceTextCompletionOptions);

        AzureOpenAIServiceOptions azureOpenAIServiceChatCompletionOptions = new();
        configurationRoot.GetSection(nameof(azureOpenAIServiceChatCompletionOptions))
                         .Bind(azureOpenAIServiceChatCompletionOptions);
        #endregion

        #region Create the Semantic Kernel
        // Create the Semantic Kernel
        var kernel = Kernel.Builder.Build();

        // Get an Azure AD token to use for authenticating to Azure OpenAI Service
        var azureCredential = new DefaultAzureCredential();

        // Add an Azure OpenAI Service Text Completion endpoint
        kernel.Config.AddAzureTextCompletionService(
            "davinci-azure",                                                 // Alias used by the kernel
            azureOpenAIServiceTextCompletionOptions.DeploymentName,          // Azure OpenAI Deployment Name
            azureOpenAIServiceTextCompletionOptions.Endpoint,                // Azure OpenAI Endpoint
            azureCredential                                                  // Use an Azure AD token
        )
        .AddAzureChatCompletionService(
            "chatgpt-azure",
            azureOpenAIServiceChatCompletionOptions.DeploymentName,
            azureOpenAIServiceChatCompletionOptions.Endpoint,
            azureCredential
        );

        // SemanticKernelExamples semanticKernelExamples = new SemanticKernelExamples(kernel);

        #endregion

        #region Semantic Kernel Example 1
        // Running prompts with input parameters (simple templating)
        Console.WriteLine("====================================");
        Console.WriteLine("Create a movie review data extractor");
        Console.WriteLine("====================================");

        var movieDataExtractorPrompt = @"Extract the following information from the movie review below:

            1. The name of the movie being reviewed (key: Name).
            2. Classify the sentiment of the movie review below into one of: [very positive, positive, neutral, negative, very negative] (key: Sentiment).
            3. The director of the movie being reviewed. If it is not mentioned, please return ""unknown"" (key: Director).
            4. An array of actors/characters mentioned and thier acting performance as one of: [good, bad, terrible] (key: Actors).

            Make sure the fields 1 to 4 are answered very short.
            Please answer in JSON machine-readable format, using the keys from above.
            Format the output as a JSON object called ""results"".
            Pretty print the JSON and make sure that it is properly closed at the end.

            ### Movie Review
            {{$input}}";

        var extractMovieData = kernel.CreateSemanticFunction(movieDataExtractorPrompt);

        string movieReview1 = @"
            If you are looking for a movie that combines science fiction, action, comedy and horror, you might want to check out the sequel to the cult hit Sharknado. Directed by Anthony C. Ferrante and starring Ian Ziering, Tara Reid and Vivica A. Fox, this film delivers more of the same absurd and hilarious premise: a storm of deadly sharks that attack New York City. The film is full of over-the-top scenes, cheesy dialogue and ridiculous special effects that make it a fun and entertaining watch for fans of the genre. The director and the main actors seem to be aware of the film's campy nature and play along with it, making it even more enjoyable. Ziering reprises his role as Fin Shepard, a former surfer and shark slayer who tries to save his family and friends from the sharknadoes. Reid plays his ex-wife April Wexler, who loses her hand to a shark in the beginning of the film but gets a chainsaw prosthetic later on. Fox plays Skye, Fin's old flame who helps him fight the sharks in New York. The film also features many cameo appearances by celebrities such as Billy Ray Cyrus, Judd Hirsch, Kelly Osbourne and Matt Lauer. The film does not take itself seriously and neither should the viewers. It is a movie that knows what it is and embraces it with gusto. It is not meant to be realistic or logical, but rather a fun and outrageous ride that will make you laugh and cringe at the same time. If you enjoyed the first film, you will probably like this one too. If you are looking for a movie that will challenge your intellect or scare you senseless, this is not it. But if you are looking for a movie that will make you say ""Did that just happen?"" and ""What will they do next?"", this is the one for you.";
        string movieReview2 = @"
            Platoon is a war movie that will make you laugh, cry and cringe. It follows a group of soldiers in Vietnam who face the horrors of combat, the brutality of their own comrades and the moral dilemmas of killing. The movie is realistic, gritty and intense, with superb performances by Charlie Sheen, Willem Dafoe and Tom Berenger. Platoon is not for the faint of heart, but it is a powerful and unforgettable cinematic experience that will leave you speechless.";
        string movieReview3 = @"
            If you are looking for a classic musical drama that will make you sing along and cry, you might want to watch this film. It is based on a stage musical and tells the story of a young woman who leaves a convent to become a governess for seven children of a widowed naval officer in 1930s Austria. The film is produced and directed by Robert Wise, who did a great job of capturing the beauty of the Alps and the charm of the songs. The cast is superb, especially Julie Andrews as Maria, the cheerful and spirited governess who wins the hearts of the children and their father, played by Christopher Plummer. The other actors who play the children are also very talented and adorable, especially Charmian Carr as Liesl, the oldest daughter who falls in love with a young man. The film also features Eleanor Parker as the Baroness, a sophisticated woman who wants to marry the captain, and Richard Haydn as Max Detweiler, a witty and opportunistic music producer. The film has many memorable scenes and songs, such as ""Do-Re-Mi"", ""My Favorite Things"", ""Edelweiss"", and ""Climb Ev'ry Mountain"". It is a heartwarming and uplifting story that celebrates love, family, music, and freedom.";

        Console.WriteLine("Movie review data for Movie 1:");
        Console.WriteLine(movieReview1);
        Console.WriteLine();
        Console.WriteLine(await extractMovieData.InvokeAsync(movieReview1));

        Console.WriteLine("Movie review data for Movie 2:");
        Console.WriteLine(movieReview2);
        Console.WriteLine();
        Console.WriteLine(await extractMovieData.InvokeAsync(movieReview2));

        Console.WriteLine("Movie review data for Movie 3:");
        Console.WriteLine(movieReview3);
        Console.WriteLine();
        Console.WriteLine(await extractMovieData.InvokeAsync(movieReview3));

        Console.WriteLine();
        Console.WriteLine("====================================");
        Console.WriteLine();

        // await semanticKernelExamples.MovieDataExtractorExampleAsync();
        #endregion

        #region Semantic Kernel Example 2
        // Prompt chaining (summarize then translate to maths)
        Console.WriteLine("===============================================================");
        Console.WriteLine("Summarize laws of thermodynamics and translate into mathematics");
        Console.WriteLine("===============================================================");
        Console.WriteLine();

        string translationPrompt = @"Translate the following text to math.

            ### Text to translate        
            {{$input}}";

        string summarizePrompt = @"Give me a TLDR for the following text with the fewest words.

            ### Text
            {{$input}}";

        var translator = kernel.CreateSemanticFunction(translationPrompt);
        var anotherSummarize = kernel.CreateSemanticFunction(summarizePrompt);

        string inputText = @"
            1st Law of Thermodynamics - Energy cannot be created or destroyed.
            2nd Law of Thermodynamics - For a spontaneous process, the entropy of the universe increases.
            3rd Law of Thermodynamics - A perfect crystal at zero Kelvin has zero entropy.";

        // Run two prompts in sequence (prompt chaining)
        var output = await kernel.RunAsync(inputText, translator, anotherSummarize);

        Console.WriteLine("Summarize and convert to Maths:");
        Console.WriteLine(inputText);
        Console.WriteLine();
        Console.WriteLine(output);
        Console.WriteLine();
        Console.WriteLine("===============================================================");
        Console.WriteLine();

        // await semanticKernelExamples.SummarizeAndTranslateExampleAsync();
        #endregion

        #region Semantic Kernel Example 3
        // More prompt chaining (extract then translate Maori)
        Console.WriteLine("==================================================================================");
        Console.WriteLine("Extract financial information as a bullet pointed list and then translate to Maori");
        Console.WriteLine("==================================================================================");

        string extractKeyPointsPrompt = @"Below is an extract from the annual financial report of a company.
                Extract key financial number (if present), key internal risk factors, and key external risk
                factors as a bullet pointed list.

                ### Financial report
                {{$input}}";

        string translateToMaoriPrompt = @"Translate the following text to Maori and retain the formatting:

                ### Text to translate
                {{$input}}";

        var extractKeyPoints = kernel.CreateSemanticFunction(extractKeyPointsPrompt);
        var translateToMaori = kernel.CreateSemanticFunction(translateToMaoriPrompt);

        string financialReport = @"
                Revenue increased $7.5 billion or 16%. Commercial products and cloud services revenue increased $4.0 billion or 13%. O365 Commercial revenue grew 22% driven by seat growth of 17% and higher revenue per user. Office Consumer products and cloud services revenue increased $474 million or 10% driven by Consumer subscription revenue, on a strong prior year comparable that benefited from transactional strength in Japan. Gross margin increased $6.5 billion or 18% driven by the change in estimated useful lives of our server and network equipment. 

                Our competitors range in size from diversified global companies with significant research and development resources to small, specialized firms whose narrower product lines may let them be more effective in deploying technical, marketing, and financial resources. Barriers to entry in many of our businesses are low and many of the areas in which we compete evolve rapidly with changing and disruptive technologies, shifting user needs, and frequent introductions of new products and services. Our ability to remain competitive depends on our success in making innovative products, devices, and services that appeal to businesses and consumers.
                ";

        // Run two prompts in sequence (prompt chaining)
        var translatedFinancialReport = await kernel.RunAsync(financialReport, extractKeyPoints, translateToMaori);

        Console.WriteLine("Extract key points and convert to Maori:");
        Console.WriteLine(financialReport);
        Console.WriteLine();
        Console.WriteLine(translatedFinancialReport);
        Console.WriteLine();
        Console.WriteLine("==================================================================================");
        Console.WriteLine();

        // await semanticKernelExamples.ExtractAndTranslateExample();
        #endregion





    })
    .Build();

await host.RunAsync();
