using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticKernelDemoApp.Models
{
    internal class AzureOpenAIServiceOptions
    {
        public string DeploymentName { get; set; }
        public string Endpoint { get; set; }
        public string ApiKey { get; set; }
    }
}
