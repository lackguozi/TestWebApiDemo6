using System.Reflection;

namespace TestWebApiDemo6.Model
{
    public class ModuleInfo
    {
        public string Id { get; set; }
        public string Version { get; set; }

        public Assembly Assembly { get; set; }
    }
}
