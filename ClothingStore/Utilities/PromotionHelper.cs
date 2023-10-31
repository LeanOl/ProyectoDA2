using System.Reflection;
using IPromotionProject;

namespace Utilities
{
    public class PromotionHelper : IPromotionHelper
    {
        private string dllPath = @"C:\Users\olmed\Desktop\ReflectionMainEjercicio";

        public IEnumerable<IPromotion> GetPromotions()
        {
            var dlls = System.IO.Directory.GetFiles(dllPath, "*.dll");
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFile(dll);
                assemblies.Add(assembly);
            }

            List<Type> types = assemblies.SelectMany(a => a.GetTypes()).ToList();

            List<Type> promotionTypes = types.Where(t => t.GetInterfaces().Contains(typeof(IPromotion))).ToList();

            List<IPromotion> promotions = promotionTypes.Select(t => (IPromotion)Activator.CreateInstance(t)).ToList();

            return promotions;
        }
    }
}