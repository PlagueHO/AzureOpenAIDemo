using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticKernelDemoApp.Classes
{
    internal class SemanticKernelExamples
    {
        IKernel kernel;
        public SemanticKernelExamples(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public async Task MovieDataExtractorExampleAsync()
        {
            var movieDataExtractorPrompt = @"For the movie review below, please extract the following information:

            1. The name of the movie being reviewed (key: Name).
            2. Classify the sentiment of the movie review below into one of: [very positive, positive, neutral, negative, very negative] (key: Sentiment).
            3. The director of the movie being reviewed. If it is not mentioned, please return ""unknown"" (key: Director).
            4. An array of actors/characters mentioned and thier acting performance as one of: [good, bad, terrible] (key: Actors).

            Make sure the fields 1 to 4 are answered very short, e.g., for location just say the location name. Please answer in JSON machine-readable format, using the keys from above. Format the output as a JSON object called ""results"". Pretty print the JSON and make sure that it is properly closed at the end.

            ## Start Movie Review
            {{$input}}
            ## End Movie Review
            ";

            var extractMovieData = kernel.CreateSemanticFunction(movieDataExtractorPrompt);

            string movieReview1 = @"
            If you are looking for a movie that combines science fiction, action, comedy and horror, you might want to check out the sequel to the cult hit Sharknado. Directed by Anthony C. Ferrante and starring Ian Ziering, Tara Reid and Vivica A. Fox, this film delivers more of the same absurd and hilarious premise: a storm of deadly sharks that attack New York City. The film is full of over-the-top scenes, cheesy dialogue and ridiculous special effects that make it a fun and entertaining watch for fans of the genre. The director and the main actors seem to be aware of the film's campy nature and play along with it, making it even more enjoyable. Ziering reprises his role as Fin Shepard, a former surfer and shark slayer who tries to save his family and friends from the sharknadoes. Reid plays his ex-wife April Wexler, who loses her hand to a shark in the beginning of the film but gets a chainsaw prosthetic later on. Fox plays Skye, Fin's old flame who helps him fight the sharks in New York. The film also features many cameo appearances by celebrities such as Billy Ray Cyrus, Judd Hirsch, Kelly Osbourne and Matt Lauer. The film does not take itself seriously and neither should the viewers. It is a movie that knows what it is and embraces it with gusto. It is not meant to be realistic or logical, but rather a fun and outrageous ride that will make you laugh and cringe at the same time. If you enjoyed the first film, you will probably like this one too. If you are looking for a movie that will challenge your intellect or scare you senseless, this is not it. But if you are looking for a movie that will make you say ""Did that just happen?"" and ""What will they do next?"", this is the one for you.";
            string movieReview2 = @"
            Platoon is a war movie that will make you laugh, cry and cringe. It follows a group of soldiers in Vietnam who face the horrors of combat, the brutality of their own comrades and the moral dilemmas of killing. The movie is realistic, gritty and intense, with superb performances by Charlie Sheen, Willem Dafoe and Tom Berenger. Platoon is not for the faint of heart, but it is a powerful and unforgettable cinematic experience that will leave you speechless.";
            string movieReview3 = @"
            If you're looking for a cinematic masterpiece that will make you laugh, cry and question your sanity, look no further than this 2003 cult classic directed by and starring Tommy Wiseau. He plays Johnny, a successful banker who is betrayed by his fiancée Lisa (Juliette Danielle) and his best friend Mark (Greg Sestero). The plot is full of twists and turns, such as a drug dealer threatening a teenager, a cancer diagnosis that is never mentioned again, and a rooftop football game. The acting is so bad that it's good, with Wiseau delivering his lines with a mysterious accent and a lack of emotion. Danielle is equally wooden and unconvincing as the manipulative Lisa, while Sestero tries his best to act like a normal human being. The dialogue is hilarious, with memorable quotes like ""You are tearing me apart, Lisa!"" and ""Oh hi Mark"". The film also features some of the most awkward and unnecessary sex scenes ever filmed, with Wiseau's bare buttocks stealing the show. This film is so bad that it's good, and you'll never forget it once you've seen it.";

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
        }

        public async Task SummarizeAndTranslateExampleAsync()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("Summarize laws of thermodynamics and translate into mathematics");
            Console.WriteLine("===============================================================");
            Console.WriteLine();

            string translationPrompt = @"{{$input}}

                Translate the text to math.";

            string summarizePrompt = @"{{$input}}

                Give me a TLDR with the fewest words.";

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
        }

        public async Task ExtractAndTranslateExample()
        {
            Console.WriteLine("==================================================================================");
            Console.WriteLine("Extract financial information as a bullet pointed list and then translate to Maori");
            Console.WriteLine("==================================================================================");
            
            string extractKeyPointsPrompt = @"Below is an extract from the annual financial report of a company. Extract key financial number (if present), key internal risk factors, and key external risk factors as a bullet pointed list.

                ### Start of Report
                {{$input}}
                ### End of Report";

            string translateToMaoriPrompt = @"Translate the following text to Maori and retain the formatting:

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
        }
    }
}
