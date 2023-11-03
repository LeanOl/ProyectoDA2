using System.Reflection;
using ILogic;
using IPromotionProject;

namespace Logic;

public class PromotionLogic : IPromotionLogic
{
    private string dllPath = @"../PromotionAssemblies";

    public IEnumerable<IPromotion> GetPromotions()
    {
        var dlls = System.IO.Directory.GetFiles(dllPath, "*.dll");
        List<Assembly> assemblies = new List<Assembly>();
        foreach (var dll in dlls)
        {
            string fullPath = System.IO.Path.GetFullPath(dll);
            var assembly = Assembly.LoadFile(fullPath);
            assemblies.Add(assembly);
        }

        List<Type> types = assemblies.SelectMany(a => a.GetTypes()).ToList();

        List<Type> promotionTypes = types.Where(t => t.GetInterfaces().Contains(typeof(IPromotion))).ToList();

        List<IPromotion> promotions = promotionTypes.Select(t => (IPromotion)Activator.CreateInstance(t)).ToList();

        return promotions;
    }
}