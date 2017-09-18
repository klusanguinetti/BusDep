namespace BusDep.Web.BackOffice
{
    using System.Web.Hosting;
    using System.Web.Optimization;
    using System.IO;
    internal static class BundleExtensions
    {
        public static Bundle WithLastModifiedToken(this Bundle sb)
        {
            sb.Transforms.Add(new LastModifiedBundleTransform());
            return sb;
        }


        public class LastModifiedBundleTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                foreach (var file in response.Files)
                {
                    if (!string.IsNullOrWhiteSpace(file.IncludedVirtualPath) && !file.IncludedVirtualPath.Contains("?v="))
                    {
                        var lastWrite = File.GetLastWriteTime(HostingEnvironment.MapPath(file.IncludedVirtualPath)).Ticks.ToString();
                        file.IncludedVirtualPath = string.Concat(file.IncludedVirtualPath, "?v=", lastWrite);
                    }
                }
            }
        }
    }
}